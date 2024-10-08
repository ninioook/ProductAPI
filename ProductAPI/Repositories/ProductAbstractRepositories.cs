﻿using ProductAPI.Entities;

namespace ProductAPI.Repositories
{
    public interface IProductWriteRepository
    {
        Task Add(Product product, CancellationToken cancellationToken);

        Task Update(Product product, CancellationToken cancellationToken);

        Task Delete(string id, CancellationToken cancellationToken);
    }

    public interface IProductReadRepository
    {
        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken);

        Task<Product> Get(string id, CancellationToken cancellationToken);
    }
}