using curRESTAPI.Dtos;
using Newtonsoft.Json;

namespace curRESTAPI.Repositories
{
    public class AllCurrency : IAllCurrency
    {

        public async Task<IEnumerable<Root>> GetTenLastAsync()
        {
            Root items = new();
            items = await TenGetLastValue("eur");
            List<Root> result = new List<Root>();
            result.Add(items);
            return await Task.FromResult(result);
        }
        public async Task<IEnumerable<CurrencyNames>> GetAllAsync()
        {
            CurrencyNames items = await GetCurrencyNames();
            List<CurrencyNames> result = new List<CurrencyNames>();
            result.Add(items);
            return result;
        }
        public async Task<Root> GetLastAsync()
        {
            Root item = await GetLastValue("eur");
            return item;
        }

        public static async Task<Root> GetLastValue(string userCur)
        {
            string url = "https://api.nbp.pl/api/exchangerates/rates/a/" + userCur + "/?format=json";
            Root myval = new Root();
            myval = await GetData<Root>(url);
            return myval;
        }
        public static async Task<CurrencyNames> GetCurrencyNames()
        {
            string url = "https://api.nbp.pl/api/exchangerates/tables/a/today/?format=json";
            CurrencyNames val = new CurrencyNames();
            val = await GetNamesData<CurrencyNames>(url);
            return val;
        }
        public static async Task<Root> TenGetLastValue(string userCur)
        {
            string url = "http://api.nbp.pl/api/exchangerates/rates/a/" + userCur + "/last/30/?format=json";
            Root val = new Root();
            val = await GetData<Root>(url);
            List<Root> result = new List<Root>();
            result.Add(val);
            return val;
        }

        

        public static async Task<Root> GetData<T>(string url)
        {
            var myroot = new Root();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<Root>(ResponseString);
                        return ResponseObject;
                    }
                    return myroot;
                }
            }
            catch
            {
                Console.WriteLine("Connection Error");
                return myroot;
            }
        }
        public static async Task<CurrencyNames> GetNamesData<T>(string url)
        {
            var myroot = new CurrencyNames();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        ResponseString = ResponseString.Trim('[');
                        ResponseString = ResponseString.Trim(']');
                        var ResponseObject = JsonConvert.DeserializeObject<CurrencyNames>(ResponseString);
                        return ResponseObject;
                    }
                    return myroot;
                }
            }
            catch
            {
                Console.WriteLine("Connection Error");
                return myroot;
            }
        }

    }

}
