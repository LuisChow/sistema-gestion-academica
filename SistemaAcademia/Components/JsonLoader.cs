using Newtonsoft.Json;
using Npgsql;
using System.Text;

namespace SistemaAcademia.Components
{
    /// <summary>
    /// Cargador dinámico de bloques SQL definidos en archivos JSON.
    /// Permite generar instrucciones tipo SELECT, INSERT, UPDATE y DELETE
    /// a partir de estructuras declarativas.
    /// </summary>
    public class JsonLoader
    {
        private readonly Dictionary<string, QueryConfig>? queries;

        /// <summary>
        /// Inicializa el cargador leyendo el archivo JSON de configuración.
        /// </summary>
        /// <param name="path">Ruta del archivo que contiene los bloques SQL.</param>
        /// <exception cref="FileNotFoundException">Si el archivo no existe.</exception>
        /// <exception cref="JsonException">Si el contenido no puede deserializarse.</exception>
        public JsonLoader(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException($"No se encontró el archivo JSON: {path}");

            string json = File.ReadAllText(path);
            queries = JsonConvert.DeserializeObject<Dictionary<string, QueryConfig>>(json);
        }

        /// <summary>
        /// Construye una consulta SQL a partir de una clave definida en el JSON.
        /// Soporta SELECT, INSERT, UPDATE y DELETE.
        /// </summary>
        /// <param name="key">Identificador lógico del bloque SQL.</param>
        /// <returns>Cadena con la consulta SQL generada.</returns>
        /// <exception cref="InvalidOperationException">Si el bloque está incompleto.</exception>
        /// <exception cref="KeyNotFoundException">Si la clave no existe.</exception>
        public string BuildSql(string key)
        {
            if (queries == null)
                throw new InvalidOperationException("El archivo JSON no contiene datos válidos.");

            if (!queries.TryGetValue(key, out var q))
                throw new KeyNotFoundException($"Consulta '{key}' no existe en el archivo JSON.");

            // INSERT
            if (q.InsertInto != null && !string.IsNullOrWhiteSpace(q.InsertInto.Trim()))
            {
                if (q.Columns == null || q.Values == null || q.Columns.Count != q.Values.Count)
                    throw new InvalidOperationException($"Consulta '{key}' de tipo INSERT está incompleta.");

                string table = q.InsertInto.Trim();
                string columns = string.Join(", ", q.Columns);
                string values = string.Join(", ", q.Values);

                return $"INSERT INTO {table} ({columns}) VALUES ({values})";
            }

            // DELETE
            if (!string.IsNullOrWhiteSpace(q.DeleteFrom))
            {
                if (q.Where == null || !q.Where.Any())
                    throw new InvalidOperationException($"Consulta '{key}' de tipo DELETE está incompleta.");

                return $"DELETE FROM {q.DeleteFrom} WHERE " + string.Join(" AND ", q.Where);
            }

            // UPDATE
            if (!string.IsNullOrWhiteSpace(q.UpdateSet))
            {
                string setClause;

                if (q.Set != null && q.Set.Any())
                    setClause = string.Join(", ", q.Set);
                else if (q.SetDict != null && q.SetDict.Any())
                    setClause = string.Join(", ", q.SetDict.Select(kv => $"{kv.Key} = {kv.Value}"));
                else
                    throw new InvalidOperationException($"Consulta '{key}' de tipo UPDATE está incompleta.");

                if (q.Where == null || !q.Where.Any())
                    throw new InvalidOperationException($"Consulta '{key}' de tipo UPDATE sin cláusula WHERE.");

                return $"UPDATE {q.UpdateSet} SET {setClause} WHERE " + string.Join(" AND ", q.Where);
            }

            // SELECT
            if (q.Select == null || string.IsNullOrWhiteSpace(q.From))
                throw new InvalidOperationException($"Consulta '{key}' no contiene cláusula 'select' o 'from'.");

            var sb = new StringBuilder();
            sb.AppendLine("SELECT " + string.Join(", ", q.Select));
            sb.AppendLine("FROM " + q.From);

            if (q.Joins != null)
            {
                foreach (var join in q.Joins)
                {
                    if (string.IsNullOrWhiteSpace(join.Table) || string.IsNullOrWhiteSpace(join.On))
                        throw new InvalidDataException($"Consulta '{key}' tiene join incompleto.");

                    string tipoJoin = string.Equals(join.Type, "left", StringComparison.OrdinalIgnoreCase)
                        ? "LEFT JOIN"
                        : "JOIN";

                    sb.AppendLine($"{tipoJoin} {join.Table} ON {join.On}");
                }
            }

            if (q.Where != null && q.Where.Any())
                sb.AppendLine("WHERE " + string.Join(" AND ", q.Where));

            if (q.GroupBy != null && q.GroupBy.Any())
                sb.AppendLine("GROUP BY " + string.Join(", ", q.GroupBy));

            if (q.OrderBy != null && q.OrderBy.Any())
                sb.AppendLine("ORDER BY " + string.Join(", ", q.OrderBy));

            return sb.ToString();
        }

        /// <summary>
        /// Construye una consulta SELECT con condiciones opcionales,
        /// en función de los parámetros actuales. Solo aplican las cláusulas WHERE relevantes.
        /// </summary>
        /// <param name="key">Clave lógica del bloque de consulta.</param>
        /// <param name="parametros">Parámetros actuales del flujo para decidir filtros.</param>
        /// <returns>Cadena SQL con filtros dinámicos según parámetros.</returns>
        public string BuildSql(string key, List<NpgsqlParameter> parametros)
        {
            if (queries == null)
                throw new InvalidOperationException("El archivo JSON no contiene datos válidos.");

            if (!queries.TryGetValue(key, out var q))
                throw new KeyNotFoundException($"Consulta '{key}' no existe en el archivo JSON.");

            var sb = new StringBuilder();
            sb.AppendLine("SELECT " + string.Join(", ", q.Select ?? Enumerable.Empty<string>()));
            sb.AppendLine("FROM " + q.From);

            if (q.Joins is not null)
            {
                foreach (var join in q.Joins)
                {
                    if (string.IsNullOrWhiteSpace(join.Table) || string.IsNullOrWhiteSpace(join.On))
                        throw new InvalidDataException($"Consulta '{key}' tiene join incompleto.");

                    string tipoJoin = string.Equals(join.Type, "left", StringComparison.OrdinalIgnoreCase) ? "LEFT JOIN" : "JOIN";
                    sb.AppendLine($"{tipoJoin} {join.Table} ON {join.On}");
                }
            }

            var filtros = new List<string>();

            if (q.Where is not null && q.Where.Any())
                filtros.AddRange(q.Where);

            if (q.WhereOptional is not null && q.WhereOptional.Any())
            {
                foreach (var cond in q.WhereOptional)
                {
                    foreach (var param in parametros)
                    {
                        if (cond.Contains(param.ParameterName) &&
                            param.Value != null &&
                            !string.IsNullOrWhiteSpace(param.Value.ToString()))
                        {
                            filtros.Add(cond);
                            break;
                        }
                    }
                }
            }

            if (filtros.Count > 0)
                sb.AppendLine("WHERE " + string.Join(" AND ", filtros));

            if (q.GroupBy is not null && q.GroupBy.Any())
                sb.AppendLine("GROUP BY " + string.Join(", ", q.GroupBy));

            if (q.OrderBy is not null && q.OrderBy.Any())
                sb.AppendLine("ORDER BY " + string.Join(", ", q.OrderBy));

            return sb.ToString();
        }

        /// <summary>
        /// Construye una instrucción INSERT simple (sin RETURNING ni subconsultas).
        /// Ideal para llamadas a ExecuteNonQuery().
        /// </summary>
        /// <param name="key">Clave lógica del bloque tipo INSERT.</param>
        /// <returns>Cadena SQL que representa el INSERT completo.</returns>
        /// <exception cref="InvalidOperationException">Si el bloque no está bien definido.</exception>
        public string BuildInsertSql(string key)
        {
            if (queries == null)
                throw new InvalidOperationException("El archivo JSON no contiene datos válidos.");

            if (!queries.TryGetValue(key, out var q))
                throw new KeyNotFoundException($"Consulta '{key}' no existe en el archivo JSON.");

            if (string.IsNullOrWhiteSpace(q.InsertInto))
                throw new InvalidOperationException($"Bloque '{key}' no es de tipo INSERT.");

            if (q.Columns == null || q.Values == null || q.Columns.Count != q.Values.Count)
                throw new InvalidOperationException($"Bloque '{key}' tiene columnas/valores inconsistentes.");

            string table = q.InsertInto.Trim();
            string columns = string.Join(", ", q.Columns);
            string values = string.Join(", ", q.Values);

            return $"INSERT INTO {table} ({columns}) VALUES ({values})";
        }
    }
}
