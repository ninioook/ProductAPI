using Dapper;
using ProductAPI.Entities;
using ProductAPI.Repositories;
using System.Data;

public class OrderWriteRepository : IOrderWriteRepository
{
    private readonly IDbConnection _connection;

    public OrderWriteRepository(IDbConnection connection)
    {
        _connection = connection;
    }

    public async Task AddOrder(Order order)
    {
        if (_connection.State != ConnectionState.Open)
        {
            _connection.Open();
        }

        using (var transaction = _connection.BeginTransaction())
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_productId", order.ProductId);
                parameters.Add("p_price", order.Price);
                parameters.Add("p_quantity", order.Quantity);
                parameters.Add("p_amount", order.Amount);
                parameters.Add("p_create_date", DateTime.Now);

                await _connection.ExecuteAsync("CALL AddOrder(@p_productId, @p_price, @p_quantity, @p_amount, @p_create_date)", parameters);
                await DecreaseStock(order.ProductId, order.Quantity);

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }
    }

    public async Task DecreaseStock(int productId, int quantity)
    {
        var parameters = new DynamicParameters();
        parameters.Add("p_productId", productId);
        parameters.Add("p_quantity", quantity);

        await _connection.ExecuteAsync("CALL DecreaseStock(@p_productId,  @p_quantity)", parameters);
    }
}