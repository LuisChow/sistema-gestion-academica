using Newtonsoft.Json;

namespace SistemaAcademia.Components
{
    /// <summary>
    /// Representa la configuración de una consulta SQL, incluyendo cláusulas SELECT, FROM, JOIN, WHERE, GROUP BY, INSERT, UPDATE y DELETE.
    /// Permite mapear configuraciones desde JSON para construir consultas dinámicas.
    /// </summary>
            public class QueryConfig
    {
        /// <summary>
        /// Lista de columnas o expresiones a seleccionar en la consulta (cláusula SELECT).
        /// </summary>
        [JsonProperty("select")]
        public List<string>? Select { get; set; }

        /// <summary>
        /// Tabla principal de la consulta (cláusula FROM).
        /// </summary>
        [JsonProperty("from")]
        public string? From { get; set; }

        /// <summary>
        /// Lista de configuraciones de JOIN para la consulta.
        /// </summary>
        [JsonProperty("joins")]
        public List<JoinConfig>? Joins { get; set; }

        /// <summary>
        /// Lista de condiciones para la cláusula WHERE.
        /// </summary>
        [JsonProperty("where")]
        public List<string>? Where { get; set; }

        /// <summary>
        /// Lista de columnas para la cláusula GROUP BY.
        /// </summary>
        [JsonProperty("group_by")]
        public List<string>? GroupBy { get; set; }

        /// <summary>
        /// Tabla destino para la operación INSERT (cláusula INSERT INTO).
        /// </summary>
        [JsonProperty("insert_into")]
        public string? InsertInto { get; set; }

        /// <summary>
        /// Lista de columnas para la operación INSERT.
        /// </summary>
        [JsonProperty("columns")]
        public List<string>? Columns { get; set; }

        /// <summary>
        /// Lista de valores para la operación INSERT.
        /// </summary>
        [JsonProperty("values")]
        public List<string>? Values { get; set; }
        
        /// <summary>
        /// Lista de condiciones opcionales para la cláusula WHERE.
        /// </summary>
        [JsonProperty("where_optional")]
        public List<string>? WhereOptional { get; set; }

        /// <summary>
        /// Lista de columnas o expresiones para la cláusula ORDER BY.
        /// </summary>
        [JsonProperty("order_by")]
        public List<string>? OrderBy { get; set; }

        /// <summary>
        /// Tabla destino para la operación DELETE (cláusula DELETE FROM).
        /// </summary>
        [JsonProperty("delete_from")]
        public string? DeleteFrom { get; set; }

        /// <summary>
        /// Expresión SET para la operación UPDATE.
        /// </summary>
        [JsonProperty("update_set")]
        public string? UpdateSet { get; set; }

        /// <summary>
        /// Lista de asignaciones para la cláusula SET en UPDATE.
        /// </summary>
        [JsonProperty("set")]
        public List<string>? Set { get; set; }

        /// <summary>
        /// Diccionario de asignaciones clave-valor para la cláusula SET en UPDATE.
        /// </summary>
        [JsonProperty("set_dict")]
        public Dictionary<string, string>? SetDict { get; set; }
    }

    /// <summary>
    /// Representa la configuración de un JOIN en una consulta SQL.
    /// </summary>
    public class JoinConfig
    {
        /// <summary>
        /// Nombre de la tabla a unir.
        /// </summary>
        [JsonProperty("table")]
        public string? Table { get; set; }

        /// <summary>
        /// Condición ON para el JOIN.
        /// </summary>
        [JsonProperty("on")]
        public string? On { get; set; }

        /// <summary>
        /// Tipo de JOIN (por ejemplo: INNER, LEFT, RIGHT).
        /// </summary>
        [JsonProperty("type")]
        public string? Type { get; set; }
    }
}