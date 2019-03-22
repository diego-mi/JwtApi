using FluentAssertions;
using JwtAuthentication.DTO.Usuario;
using JwtAuthentication.ViewModels.Auth;
using JwtAuthenticationTest.Helpers;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace JwtAuthenticationTest
{
    public class AuthControllerTest
    {
        [Fact]
        public async Task Test_Register_Success()
        {
            using (var client = new TestClientProvider().Client)
            {
                string email = GeradorDeStringsHelper.GerarEmailPorLength(20);
                string nome = GeradorDeStringsHelper.GerarNomeCompleto();
                string senha = GeradorDeStringsHelper.GerarStringAlfanumericaPorLength(10);


                var response = await client.PostAsync(
                    "/api/v1/auth/register",
                    new StringContent(
                        JsonConvert.SerializeObject(
                            new RegisterViewModel{
                                Email = email,
                                Name = nome,
                                Password = senha
                            }
                        ),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);

                string responseContentString = await response.Content.ReadAsStringAsync();

                responseContentString.Should().Be(
                    JsonConvert.SerializeObject(
                        new UserRegisterResponse
                        {
                            Succeded = true,
                            Message = new List<string>()
                        }
                    ).ToLower()
                );
            }
        }

        [Fact]
        public async Task Test_Register_Fail_Username_Duplicated()
        {
            using (var client = new TestClientProvider().Client)
            {
                string email = "diego@email.com.br";
                string nome = GeradorDeStringsHelper.GerarNomeCompleto();
                string senha = GeradorDeStringsHelper.GerarStringAlfanumericaPorLength(10);


                var response = await client.PostAsync(
                    "/api/v1/auth/register",
                    new StringContent(
                        JsonConvert.SerializeObject(
                            new RegisterViewModel
                            {
                                Email = email,
                                Name = nome,
                                Password = senha
                            }
                        ),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                response.StatusCode.Should().Be(HttpStatusCode.BadRequest);

                string responseContentString = await response.Content.ReadAsStringAsync();

                UserRegisterResponse userRegisterResponse = new UserRegisterResponse
                {
                    Succeded = false,
                    Message = new List<string>()
                };
                userRegisterResponse.Message.Add("O email '" + email + "' já está em uso.");

                responseContentString.ToLower().Should().Be(
                    JsonConvert.SerializeObject(userRegisterResponse).ToLower()
                );
            }
        }

        [Fact]
        public async Task Test_Login_Success()
        {
            using (var client = new TestClientProvider().Client)
            {
                string username = "diego@email.com.br";
                string senha = "123456";


                var response = await client.PostAsync(
                    "/api/v1/auth/login",
                    new StringContent(
                        JsonConvert.SerializeObject(
                            new LoginViewModel
                            {
                                Username = username,
                                Password = senha
                            }
                        ),
                        Encoding.UTF8,
                        "application/json"
                    )
                );

                response.EnsureSuccessStatusCode();

                response.StatusCode.Should().Be(HttpStatusCode.OK);
            }
        }
    }
}
