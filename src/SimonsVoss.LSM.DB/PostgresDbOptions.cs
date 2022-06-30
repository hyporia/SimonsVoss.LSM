using Microsoft.Extensions.Logging;

namespace SimonsVoss.LSM.DB;

public class PostgresDbOptions
{
    public string ConnectionString { get; set; } = null!;

    public ILoggerFactory? SqlLoggerFactory { get; set; }
}