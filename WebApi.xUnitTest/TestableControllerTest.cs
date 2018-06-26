using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using Xunit;

namespace WebApi.IntegrationTest
{
    public class TestableControllerTest
    {

        [Fact]
        public async Task TestGetAll()
        {
            using (var client = new ClienteProvider().Client)
            {
                var response = await client.GetAsync("/api/Testable");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

        }

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new ClienteProvider().Client)
            {
                var response = await client.PostAsync("/api/Testable"
                    , new StringContent(JsonConvert.SerializeObject(new Product() { Id= 1, Description= "Test"}), Encoding.UTF8, "application/json" )
                    );

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
