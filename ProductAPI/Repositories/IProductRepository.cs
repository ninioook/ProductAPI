using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public interface IProductRepository
    {
        Task Add(Product product, CancellationToken cancellationToken);

        Task Update(Product product, CancellationToken cancellationToken);

        Task Delete(int id, CancellationToken cancellationToken);

        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken);

        Task<Product> Get(int id, CancellationToken cancellationToken);
    }
}