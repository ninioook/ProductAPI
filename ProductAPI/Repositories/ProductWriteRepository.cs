using Dapper;
using ProductAPI.Entities;
using System.Data;
using ILogger = Serilog.ILogger;

namespace ProductAPI.Repositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        private readonly ILogger _logger;
        private readonly IDbConnection _connection;

        public ProductWriteRepository(IDbConnection connection, ILogger logger)
        {
            _logger = logger;
            _connection = connection;
        }

        public async Task Add(Product product, IEnumerable<int> categoryIds)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    int productId = await AddProductInternal(product.Name, product.Price, product.ImageUrl);

                    foreach (var categoryId in categoryIds)
                    {
                        await AddProductCategoryInternal(productId, categoryId);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.Error(ex, "Error adding product: {ProductName}", product.Name);
                    throw;
                }
            }
        }

        public async Task Update(Product product, IEnumerable<int> categoryIds)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await UpdateProductInternal(product.Id, product.Name, product.Price, product.ImageUrl);

                    await DeleteProductCategories(product.Id);

                    foreach (var categoryId in categoryIds)
                    {
                        await AddProductCategoryInternal(product.Id, categoryId);
                    }

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.Error(ex, "Error updating product Id: {ProductId}", product.Id);
                    throw;
                }
            }
        }

        public async Task Delete(int productId)
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }

            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    await DeleteProductInternal(productId);

                    await DeleteProductCategories(productId);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    _logger.Error(ex, "Error deleting product Id: {ProductId}", productId);
                    throw;
                }
            }
        }

        private async Task<int> AddProductInternal(string name, decimal price, string imageUrl)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_name", name);
            parameters.Add("p_price", price);
            parameters.Add("p_image_url", imageUrl);

            var id = await _connection.QuerySingleAsync<int>("AddProduct", parameters);

            return id;
        }

        private async Task UpdateProductInternal(int id, string name, decimal price, string imageUrl)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_id", id);
            parameters.Add("p_name", name);
            parameters.Add("p_price", price);
            parameters.Add("p_image_url", imageUrl);

            await _connection.ExecuteAsync("CALL UpdateProduct(@p_id, @p_name, @p_price, @p_image_url)", parameters);
        }

        private async Task DeleteProductInternal(int productId)
        {
            await _connection.ExecuteAsync("CALL DeleteProduct(@p_productId)", new { p_productId = productId });
        }

        private async Task AddProductCategoryInternal(int productId, int categoryId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_product_id", productId);
            parameters.Add("p_category_id", categoryId);

            await _connection.ExecuteAsync("CALL AddProductCategory(@p_product_id, @p_category_id)", parameters);
        }

        private async Task DeleteProductCategories(int productId)
        {
            await _connection.ExecuteAsync("CALL DeleteProductCategories(@p_productId)", new { p_productId = productId });
        }
    }
}