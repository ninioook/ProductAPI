using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        public Task Add(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Product product, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}