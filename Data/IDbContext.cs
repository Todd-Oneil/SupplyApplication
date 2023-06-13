namespace OrdersApplication.Data
{
    public interface IDbContext
    {
        Task<IEnumerable<T>> GetDataWithQuery<T, P>(string Query, P parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string query, T parameters, string connectionId = "DefaultConnection");
    }
}