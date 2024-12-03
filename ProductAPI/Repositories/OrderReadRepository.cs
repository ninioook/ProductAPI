using Dapper;
using ProductAPI.Entities;
using System.Data;

namespace ProductAPI.Repositories
{
    public class OrderReadRepository:IOrderReadRepository
    {
        private readonly IDbConnection _connection;

        public OrderReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> GetStock(int productId)
        {
            var sql = "GetStock";

            var parameters = new { p_productId = productId };

            var stock = await _connection.QuerySingleOrDefaultAsync<int>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return stock;
        }
    }
}
