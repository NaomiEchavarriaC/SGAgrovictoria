using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SGAgrovictoriaWEB.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SGAgrovictoriaWEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : Controller
    {
        private readonly HttpClient _httpClient;


        public IActionResult Index()
        {
            return View("/Views/Proveedores/Index.cshtml");
        }

        //public ProveedoresController(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}

        //[HttpGet("mostrar")]
        //public async Task<IActionResult> Mostrar()
        //{
        //    string apiUrl = "https://api.com/proveedores";
        //    HttpResponseMessage response = await _httpClient.GetAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string jsonData = await response.Content.ReadAsStringAsync();
        //        List<Proveedor> proveedores = JsonSerializer.Deserialize<List<Proveedor>>(jsonData);
        //        return View("/Views/Proveedores/Index.cshtml", proveedores);
        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //}

        //[HttpGet("create")]
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost("create")]
        //public async Task<IActionResult> Create(Proveedor proveedor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string apiUrl = "https://api.com/proveedores";
        //        string jsonData = JsonSerializer.Serialize(proveedor);
        //        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
        //        HttpResponseMessage response = await _httpClient.PostAsync(apiUrl, content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View(proveedor);
        //        }
        //    }
        //    return View(proveedor);
        //}



        //[HttpPut("edit/{id}")]
        //public async Task<IActionResult> Edit(Proveedor proveedor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        string apiUrl = $"https://api.com/proveedores/{proveedor.Id}";
        //        string jsonData = JsonSerializer.Serialize(proveedor);
        //        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        //        HttpResponseMessage response = await _httpClient.PutAsync(apiUrl, content);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            return RedirectToAction("Index");
        //        }
        //        else
        //        {
        //            return View(proveedor);
        //        }
        //    }
        //    return View(proveedor);
        //}

        //[HttpDelete("delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    string apiUrl = $"https://api.com/proveedores/{id}";
        //    HttpResponseMessage response = await _httpClient.DeleteAsync(apiUrl);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //}
    }
}