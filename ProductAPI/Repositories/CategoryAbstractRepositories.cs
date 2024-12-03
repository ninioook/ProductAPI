namespace ProductAPI.Repositories
{
    public interface ICategoryWriteRepository
    {
        Task Add(string name);
    }
}