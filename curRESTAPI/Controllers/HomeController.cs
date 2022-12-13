using curRESTAPI.Dtos;
using curRESTAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace curRESTAPI.Controllers
{
    [ApiController]
    [Route("cur")]
    public class HomeController : ControllerBase
    {
        private readonly IAllCurrency repository;

        public HomeController(IAllCurrency repository)
        {
            this.repository = repository;
        }
        [HttpGet("TenLast")]
        public async Task<IEnumerable<Root>> GetTenLastAsync()
        {
            var items = await repository.GetTenLastAsync();
            return items;
        }

        [HttpGet("All")]
        public async Task<IEnumerable<CurrencyNames>> GetAllAsync()
        {
            //wpierdolic mongo do zapisania danych
            var items = await repository.GetAllAsync();
            return items;
        }
        [HttpGet("Last")]
        public async Task<Root> GetLastAsync()
        {
            var item = await repository.GetLastAsync();
            return item;
        }
        [HttpGet("{name}")]
        public async Task<Root> GetLastCurrencyUserDefined(string name)
        {
            var item = await repository.GetLastCurrencyUserDefined(name);
            return item;
        }

    }
}






