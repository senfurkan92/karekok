using Microsoft.AspNetCore.Mvc;

namespace MulakatProjesi.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// api sorgularında kullanılacak nesne burada field olarak eklendi
        /// </summary>
        protected readonly HttpClient _httpClient;

        public BaseController(IConfiguration config)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://api.kitapbulal.com"),
            };
            _httpClient.DefaultRequestHeaders.Add("Authorization", config["AuthToken"]);
        }
    }
}
