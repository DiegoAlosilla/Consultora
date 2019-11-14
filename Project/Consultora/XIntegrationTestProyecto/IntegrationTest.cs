using ConsultoraAPI.Models.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XIntegrationTestProyecto
{
    public class IntegrationTest
    {
        [Fact]
        public async Task Test_Post()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PostAsync("api/proyecto/create", new
                    StringContent(JsonConvert.SerializeObject(new Proyecto()
                    {
                        Titulo = "IntegrationTest",
                        Descripcion = "Prubas de Integracion"
                    }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }


        [Fact]
        public async Task Test_Get_All()
        {
            using (var client = new TestClientProvider().Client)
            {

                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue( "Bearer", Token);
                var response = await client.GetAsync("api/proyecto");
                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }

        [Fact]
        public async Task Test_Put()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.PutAsync("api/proyecto/update/2", new
                    StringContent(JsonConvert.SerializeObject(new Proyecto()
                    {
                        Id = 2,
                        Titulo = "update 4",
                        Descripcion = "Prubas de Integracion"
                    }), Encoding.UTF8, "application/json"));

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }


        [Fact]
        public async Task Test_Delete()
        {
            using (var client = new TestClientProvider().Client)
            {
                var response = await client.DeleteAsync("api/proyecto/delete/2");

                response.EnsureSuccessStatusCode();
                response.StatusCode.Should().Be(HttpStatusCode.OK);

            }
        }


    }
}
