using Newtonsoft.Json;
using Npgsql;
using System.Data;

/// <summary>
/// Componente de base de datos para conexión, transacciones y ejecución de consultas.
/// Diseñado para trabajar con PostgreSQL y bloques SQL definidos externamente.
/// </summary>
public class DBComponent
{
    private readonly string connectionString;
    private readonly NpgsqlConnection connection;
    private NpgsqlTransaction? transaction;

    /// <summary>
    /// Constructor principal que inicializa la conexión con la cadena especificada.
    /// No abre la conexión automáticamente; se requiere llamada explícita a Connect().
    /// </summary>
    /// <param name="connectionString">Cadena de conexión válida para PostgreSQL.</param>
    public DBComponent(string connectionString)
    {
        this.connectionString = connectionString;
        this.connection = new NpgsqlConnection(connectionString);
    }

    /// <summary>
    /// Crea y devuelve una instancia de DBComponent usando un archivo JSON de configuración.
    /// Busca la clave 'connectionString' dentro del archivo especificado.
    /// </summary>
    /// <param name="jsonPath">Ruta absoluta o relativa al archivo JSON de configuración.</param>
    /// <returns>Instancia conectada de DBComponent lista para ejecutar consultas.</returns>
    /// <exception cref="FileNotFoundException">Si el archivo no existe.</exception>
    /// <exception cref="InvalidDataException">Si el JSON no se puede interpretar.</exception>
    /// <exception cref="KeyNotFoundException">Si la clave 'connectionString' no está presente o está vacía.</exception>
    public static DBComponent FromSettings(string jsonPath)
    {
        if (!File.Exists(jsonPath))
            throw new FileNotFoundException($"Archivo no encontrado: {jsonPath}");

        string json = File.ReadAllText(jsonPath);
        var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        if (config is null)
            throw new InvalidDataException("El contenido del archivo JSON no pudo ser interpretado correctamente.");

        if (!config.TryGetValue("connectionString", out var connectionString) || string.IsNullOrWhiteSpace(connectionString))
            throw new KeyNotFoundException("La clave 'connectionString' no existe o está vacía en el archivo JSON.");

        var db = new DBComponent(connectionString);
        db.Connect();
        return db;
    }

    /// <summary>
    /// Abre la conexión si aún no está abierta. Requerida antes de ejecutar cualquier consulta.
    /// </summary>
    public void Connect()
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();
    }

    /// <summary>
    /// Inicia una transacción si aún no existe. Requiere que la conexión esté abierta.
    /// </summary>
    /// <exception cref="InvalidOperationException">Si la conexión está cerrada al invocar.</exception>
    public void BeginTransaction()
    {
        if (connection.State != ConnectionState.Open)
            throw new InvalidOperationException("Conexión no abierta.");

        if (transaction == null)
            transaction = connection.BeginTransaction();
    }

    /// <summary>
    /// Confirma (commit) la transacción activa, limpia el objeto y cierra la conexión.
    /// </summary>
    public void Commit()
    {
        transaction?.Commit();
        transaction = null;
        Close();
    }

    /// <summary>
    /// Revierte (rollback) la transacción activa, limpia el objeto y cierra la conexión.
    /// </summary>
    public void Rollback()
    {
        transaction?.Rollback();
        transaction = null;
        Close();
    }

    /// <summary>
    /// Cierra la conexión si está abierta. No afecta la transacción.
    /// </summary>
    public void Close()
    {
        if (connection.State == ConnectionState.Open)
            connection.Close();
    }
    
    /// <summary>
    /// ClonaParametros
    /// </summary>
    public NpgsqlParameter[] CloneParameter(IEnumerable<NpgsqlParameter> originales)
    {
        return originales
            .Select(p => new NpgsqlParameter(p.ParameterName, p.Value))
            .ToArray();
    }


    /// <summary>
    /// Ejecuta una consulta SELECT con o sin parámetros. Usa transacción activa si existe.
    /// </summary>
    /// <param name="sql">Cadena SQL que representa una consulta tipo SELECT.</param>
    /// <param name="parameters">Parámetros opcionales para la consulta.</param>
    /// <returns>DataTable con los resultados de la consulta.</returns>
    public DataTable ExecuteQuery(string sql, NpgsqlParameter[]? parameters = null)
    {
        if (connection.State != ConnectionState.Open)
            connection.Open();

        using var cmd = transaction != null
            ? new NpgsqlCommand(sql, connection, transaction)
            : new NpgsqlCommand(sql, connection);

        if (parameters != null)
            cmd.Parameters.AddRange(parameters);

        using var adapter = new NpgsqlDataAdapter(cmd);
        var dt = new DataTable();
        adapter.Fill(dt);
        return dt;
    }

    /// <summary>
    /// Ejecuta una consulta tipo INSERT, UPDATE o DELETE.
    /// Usa transacción activa si existe. Retorna cantidad de filas afectadas.
    /// </summary>
    /// <param name="sql">Cadena SQL de acción sobre datos.</param>
    /// <param name="parameters">Parámetros opcionales para la consulta.</param>
    /// <returns>Número de filas modificadas por la operación.</returns>
    public int ExecuteNonQuery(string sql, NpgsqlParameter[]? parameters = null)
    {
        using var cmd = transaction != null
            ? new NpgsqlCommand(sql, connection, transaction)
            : new NpgsqlCommand(sql, connection);

        if (parameters != null)
            cmd.Parameters.AddRange(parameters);

        return cmd.ExecuteNonQuery();
    }

    /// <summary>
    /// Acceso público a la conexión activa usada internamente por el componente.
    /// </summary>
    public NpgsqlConnection Connection => connection;

    /// <summary>
    /// Acceso público a la transacción activa, si existe. Puede ser null.
    /// </summary>
    public NpgsqlTransaction? Transaction => transaction;
}
