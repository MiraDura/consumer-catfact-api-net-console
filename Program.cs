using System.Net.Http.Json;
using System.Text.Json.Serialization;

using HttpClient httpClient = new();

try
{
    CatFact? response = await httpClient.GetFromJsonAsync<CatFact>(
        "https://catfact.ninja/fact");

    if (string.IsNullOrWhiteSpace(response?.Fact))
    {
        Console.WriteLine("A API não retornou um fato sobre gatos.");
        return;
    }

    Console.WriteLine("Fato sobre Gatos:");
    Console.WriteLine(response.Fact);
}
catch (HttpRequestException exception)
{
    Console.Error.WriteLine($"Erro ao acessar a API: {exception.Message}");
}
catch (TaskCanceledException)
{
    Console.Error.WriteLine("A requisição à API demorou demais.");
}

internal sealed record CatFact([property: JsonPropertyName("fact")] string Fact);
