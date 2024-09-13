using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public class ProductReadRepository : IProductReadRepository
    {
        public ProductReadRepository()
        {

        }

        public Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}