using Microsoft.Extensions.Logging;

namespace SimonsVoss.LSM.DB;

public class PostgresDbOptions
{
    /// <summary>
    /// Connection string for the database
    /// </summary>
    public string ConnectionString { get; set; } = null!;

    /// <summary>
    /// Logger for debugging SQL queries in the development mode
    /// </summary>
    public ILoggerFactory? SqlLoggerFactory { get; set; }
}