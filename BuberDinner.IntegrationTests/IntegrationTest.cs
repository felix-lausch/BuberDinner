namespace BuberDinner.IntegrationTests;

using BuberDinner.Contracts.Authentication;
using BuberDinner.infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;


public class IntegrationTest
{
    protected readonly HttpClient httpClient;
    protected readonly JsonSerializerOptions jsonSerializerOptions = new();

    public IntegrationTest()
    {
        var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", "5001");
                builder.ConfigureServices(services =>
                {
                    // Ensure clean repo for every test
                    using (var scope = services.BuildServiceProvider().CreateScope())
                    {
                        UserRepository.ClearRepo();
                    }
                });

                //builder.ConfigureServices(services => services.)

            });

        httpClient = appFactory.CreateClient();

        jsonSerializerOptions.PropertyNameCaseInsensitive = true;
    }

    public async Task<AuthenticationResponse> SetupUser()
    {
        var request = new RegisterRequest(
            "TestFirstName",
            "TestLastName",
            "TestEmail@mail.com",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/register", request, jsonSerializerOptions);

        var rawRes = await response.Content.ReadAsStringAsync();

        var responseBody = await response.Content.ReadFromJsonAsync<AuthenticationResponse>(jsonSerializerOptions);
        return responseBody!;
    }
}
