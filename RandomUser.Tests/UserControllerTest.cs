using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using RandomUser.App.Controllers;
using System.Net.Http;
using System.Threading.Tasks;

namespace RandomUser.Tests
{
    public class UserControllerTest
    {
        private IHttpClientFactory _httpClientFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddHttpClient();

            var serviceProvider = services.BuildServiceProvider();

            _httpClientFactory = serviceProvider.GetService<IHttpClientFactory>();
        }

        [Test]
        public async Task HealthCheckTest()
        {
            var userController = new UserController(_httpClientFactory);

            var actionResult = await userController.HealthCheck();

            Assert.Pass();
        }

        [Test]
        public async Task GetRandomUserTest()
        {
            var userController = new UserController(_httpClientFactory);

            var actionResult = await userController.GetRandomUser();

            var okResult = actionResult as OkObjectResult;

            Assert.IsTrue(okResult != null, "No success response received.");

            if (okResult != null)
            {
                var data = okResult.Value as string;
                Assert.IsTrue(!string.IsNullOrEmpty(data), "No data returned.");
            }
        }
    }
}