using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RandomUser.App.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("healthcheck")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok();
        }

        [HttpGet("randomuser")]
        [BasicAuthentication]
        public async Task<IActionResult> GetRandomUser()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync("https://randomuser.me/api");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return StatusCode((int)response.StatusCode);
        }
    }
}
