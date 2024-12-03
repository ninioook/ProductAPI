using ProductAPI.Dtos;
using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public interface IProductWriteRepository
    {
        Task Add(Product product, IEnumerable<int> categoryIds);

        Task Update(Product product, IEnumerable<int> categoryIds);

        Task Delete(int id);
    }

    public interface IProductReadRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

        Task<Product> Get(int id);

        Task<IEnumerable<ProductCategoryListItemDto>> GetAllProductCategories();

        Task<IEnumerable<string>> GetProductCategoriesById(int productId);
    }
}