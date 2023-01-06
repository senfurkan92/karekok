using Microsoft.AspNetCore.Mvc;
using MulakatProjesi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace MulakatProjesi.Controllers;

public class HomeController : BaseController
{
    public HomeController(IConfiguration config) : base(config)
    {

    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // ###########################################################

    /// <summary>
    /// İletişim sayfasına gider
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Contact()
    {
        return View();
    }

    /// <summary>
    /// İletişim formu post metodu
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Contact([FromBody]ContactVM model)
    {
        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
        var resp = _httpClient.PostAsync("/chat/add", content).Result;
        var respContent = resp.Content.ReadAsStringAsync().Result;
        var result = new Dictionary<string, string>();
        result.Add("status", resp.StatusCode.ToString());
        result.Add("body", respContent);
        return Ok(result);
    }

    // ###########################################################

    /// <summary>
    /// Ürünler sayfasına gider
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Products()
    {
        var resp = _httpClient.GetAsync("/test/getproducts").Result;
        var content = resp.Content.ReadAsStringAsync().Result;
        var products = JsonConvert.DeserializeObject<JToken>(content);
        return View(products.Children().ToList());
    }
}