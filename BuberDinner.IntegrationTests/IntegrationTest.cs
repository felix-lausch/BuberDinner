namespace BuberDinner.IntegrationTests;

using BuberDinner.Contracts.Authentication;
using BuberDinner.infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

public class IntegrationTest
{
    private readonly HttpClient httpClient;
    private readonly JsonSerializerOptions jsonSerializerOptions = new();

    protected HttpClient HttpClient => httpClient;

    protected JsonSerializerOptions JsonSerializerOptions => jsonSerializerOptions;

    public IntegrationTest()
    {
        var appFactory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.UseSetting("https_port", "5001"); //TODO: find out if this is really needed
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
            "TestEmail@mail.com",
            "TestPassword");

        var response = await HttpClient.PostAsJsonAsync("auth/register", request, JsonSerializerOptions);

        var rawRes = await response.Content.ReadAsStringAsync();

        var responseBody = await response.Content.ReadFromJsonAsync<AuthenticationResponse>(JsonSerializerOptions);
        return responseBody!;
    }
}
