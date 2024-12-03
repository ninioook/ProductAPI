using Dapper;
using System.Data;

namespace ProductAPI.Repositories
{
    public class CategoryWriteRepository : ICategoryWriteRepository
    {
        private readonly IDbConnection _connection;

        public CategoryWriteRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task Add(string name)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            var query = @"
            INSERT INTO Categories (Name) 
            VALUES (@Name);";

            await _connection.ExecuteAsync(query, new { Name = name });
        }
    }
}
