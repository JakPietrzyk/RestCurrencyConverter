using curRESTAPI.Dtos;

namespace curRESTAPI.Repositories
{
    public interface IAllCurrency
    {
        Task<IEnumerable<Root>> GetTenLastAsync();
        Task<IEnumerable<CurrencyNames>> GetAllAsync();
        Task<Root> GetLastAsync();
        Task<Root> GetLastCurrencyUserDefined(string name);
    }
}
