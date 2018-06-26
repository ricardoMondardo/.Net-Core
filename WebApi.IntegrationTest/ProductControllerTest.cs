using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using Xunit;

namespace WebApi.IntegrationTest
{
    public class ProductControllerTest
    {

        [Fact]
        public async Task TestCount()
        {
            using (var client = new ClienteProvider().Client)
            {
                var response = await client.GetAsync("/api/Product/Count");

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Chech the cound
            }

        }

        [Fact]
        public async Task Test_Post()
        {
            using (var client = new ClienteProvider().Client)
            {
                var response = await client.PostAsync("/api/Product/Post"
                    , new StringContent(JsonConvert.SerializeObject(new Product() { Id= 1, Description= "Test"}), Encoding.UTF8, "application/json" )
                    );

                response.EnsureSuccessStatusCode();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                //Check when the model is wrong...
            }
        }
    }
}
