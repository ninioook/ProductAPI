
using Dapper;
using ProductAPI.Dtos;
using ProductAPI.Entities;
using System.Data;

namespace ProductAPI.Repositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        private readonly IDbConnection _connection;

        public ProductReadRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Product> Get(int id)
        {
            var sql = "GetProductById";

            var parameters = new { p_productId = id };

            var product = await _connection.QuerySingleOrDefaultAsync<Product>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return product;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            var sql = "GetAllProducts";

            var products = _connection.QueryAsync<Product>(
                sql,
                commandType: CommandType.StoredProcedure
            );

            return products;
        }

        public async Task<IEnumerable<ProductCategoryListItemDto>> GetAllProductCategories()
        {
            var sql = "GetAllProductCategories";

            var productCategories = await _connection.QueryAsync<ProductCategoryListItemDto>(
                sql,
                commandType: CommandType.StoredProcedure
            );

            return productCategories;
        }

        public async Task<IEnumerable<string>> GetProductCategoriesById(int productId)
        {
            var sql = "GetProductCategories";

            var parameters = new { p_productId = productId };

            var productCategories = await _connection.QueryAsync<string>(
                sql,
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return productCategories;
        }
    }
}