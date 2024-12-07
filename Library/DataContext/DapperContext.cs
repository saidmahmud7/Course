using Npgsql;

namespace Library.DataContext;

public class DapperContext
{
    private readonly string _connectionString =
    "Server=127.0.0.1;Port=5432;Database=DapperCrudDB;User Id=postgres;Password=280806;";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}
