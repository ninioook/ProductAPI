using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository()
        {

        }

        public Task Add(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}