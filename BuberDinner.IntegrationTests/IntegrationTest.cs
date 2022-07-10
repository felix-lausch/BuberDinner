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
                builder.ConfigureServices(services =>
                {
                    // Ensure clean repo for every test
                    using (var scope = services.BuildServiceProvider().CreateScope())
                    {
                        UserRepository.ClearRepo();
                    }
                });

            });

        httpClient = appFactory.CreateClient();

        jsonSerializerOptions.PropertyNameCaseInsensitive = true;
    }

    public async Task<AuthenticationResponse> SetupUser()
    {
        var request = new RegisterRequest(
            "TestFirstName",
            "TestLastName",
            "TestEmail",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/register", request, jsonSerializerOptions);

        var responseBody = await response.Content.ReadFromJsonAsync<AuthenticationResponse>(jsonSerializerOptions);
        return responseBody!;
    }
}
