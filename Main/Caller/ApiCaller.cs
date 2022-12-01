using System.Net.Http.Headers;

namespace Main.Caller;

public class ApiCaller
{
    private readonly HttpClient _client = new();
    public ApiCaller(string authO)
    {
        _client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authO);
    }
    public async Task<string> GetInput(string path)
    {
        var stringResponse = "";
        var response = await _client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            stringResponse = await response.Content.ReadAsStringAsync();
        }
        return stringResponse;
    }
}