using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Core_Portfolio.Controllers
{
    public class TestController : Controller
    {
        private readonly HttpClient _httpClient;

        public TestController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> GetApiData()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://localhost:7028/api/Category");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return Content(content);
                }
                else
                {
                    return BadRequest($"Failed to fetch data. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while fetching data: {ex.Message}");
            }
        }
    }
}
