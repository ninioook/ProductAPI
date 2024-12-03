using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public interface IOrderWriteRepository
    {
        Task AddOrder(Order order);
    }

    public interface IOrderReadRepository
    {
        Task<int> GetStock(int productId);
    }
}
