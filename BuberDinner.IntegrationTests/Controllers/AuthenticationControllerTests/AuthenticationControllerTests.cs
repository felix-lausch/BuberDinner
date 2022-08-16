namespace BuberDinner.IntegrationTests.Controllers.AuthenticationControllerTests;

using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Net;


[TestClass]
public class AuthenticationControllerTests : IntegrationTest
{
    [TestMethod]
    public async Task RegisterReturnsOk()
    {
        var request = new RegisterRequest(
            "TestFirstName",
            "TestLastName",
            "TestEmail@mail.com",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/register", request, jsonSerializerOptions);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<AuthenticationResponse>(jsonSerializerOptions);

        Assert.IsNotNull(responseBody);
        Assert.AreNotEqual(Guid.Empty, responseBody.Id);
        Assert.AreNotEqual(string.Empty, responseBody.Token);
        Assert.AreEqual("TestFirstName", responseBody.FirstName);
        Assert.AreEqual("TestLastName", responseBody.LastName);
        Assert.AreEqual("TestEmail@mail.com", responseBody.Email);
    }

    [TestMethod]
    public async Task RegisterWithRegisteredEmailReturnsConflict()
    {
        await SetupUser();

        var request = new RegisterRequest(
            "TestFirstName",
            "TestLastName",
            "TestEmail@mail.com",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/register", request, jsonSerializerOptions);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.Conflict, response.StatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<ProblemDetails>(jsonSerializerOptions);

        Assert.IsNotNull(responseBody);
        Assert.AreEqual("Email is already in use.", responseBody.Title);
    }

    [TestMethod]
    public async Task LoginReturnsOk()
    {
        await SetupUser();

        var request = new LoginRequest(
            "TestEmail@mail.com",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/login", request, jsonSerializerOptions);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<AuthenticationResponse>(jsonSerializerOptions);

        Assert.IsNotNull(responseBody);
        Assert.AreNotEqual(Guid.Empty, responseBody.Id);
        Assert.AreNotEqual(string.Empty, responseBody.Token);
        Assert.AreEqual("TestFirstName", responseBody.FirstName);
        Assert.AreEqual("TestLastName", responseBody.LastName);
        Assert.AreEqual("TestEmail@mail.com", responseBody.Email);
    }

    [TestMethod]
    public async Task LoginReturnsUnauthorizedOnUserDoesntExist()
    {
        var request = new LoginRequest(
            "TestEmail@mail.com",
            "TestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/login", request, jsonSerializerOptions);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<ProblemDetails>(jsonSerializerOptions);

        Assert.IsNotNull(responseBody);
        Assert.AreEqual("Invalid credentials.", responseBody.Title);
    }

    [TestMethod]
    public async Task LoginReturnsUnauthorizedOnWrongPassword()
    {
        await SetupUser();

        var request = new LoginRequest(
            "TestEmail@mail.com",
            "InvalidTestPassword"
        );

        var response = await httpClient.PostAsJsonAsync("auth/login", request, jsonSerializerOptions);

        Assert.IsNotNull(response);
        Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);

        var responseBody = await response.Content.ReadFromJsonAsync<ProblemDetails>(jsonSerializerOptions);

        Assert.IsNotNull(responseBody);
        Assert.AreEqual("Invalid credentials.", responseBody.Title);
    }
}