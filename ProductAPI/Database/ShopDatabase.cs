using Dapper;
using System.Data;

public class ShopDatabase
{
    private readonly IDbConnection _connection;

    public ShopDatabase(IDbConnection connection)
    {
        _connection = connection;
    }

    public void ApplyMigrations()
    {
        var migrationsPath = Path.Combine(Directory.GetCurrentDirectory(), "Migrations");
        var migrationFiles = Directory.GetFiles(migrationsPath, "*.sql");

        foreach (var migrationFile in migrationFiles)
        {
            var sqlScript = File.ReadAllText(migrationFile);
            _connection.Execute(sqlScript);
        }
    }
}