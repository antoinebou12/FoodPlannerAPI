using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace APIGateway.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;

        public ApiController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet("recipe/{id}")]
        public async Task<IActionResult> GetRecipe(int id)
        {
            var client = _clientFactory.CreateClient();

            // Copy the Authorization header from the incoming request
            if (Request.Headers.ContainsKey("Authorization"))
            {
                client.DefaultRequestHeaders.Add("Authorization", Request.Headers["Authorization"].ToString());
            }

            // Forward the request to the Recipe Microservice
            var response = await client.GetAsync($"http://recipemicroservice/recipe/{id}");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return Ok(result);
            }
            else
            {
                return StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}
