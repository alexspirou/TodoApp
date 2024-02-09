using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class QuoteService
{
    private readonly HttpClient _httpClient;

    public QuoteService(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    public async Task<Quote> GetRandomQuoteAsync()
    {
        var response = await _httpClient.GetAsync("https://api.quotable.io/random");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var quote = JsonSerializer.Deserialize<Quote>(content);
            return quote;
        }
        else
        {
            throw new HttpRequestException($"Failed to retrieve random quote. Status code: {response.StatusCode}");
        }
    }

    public record Quote(string _id, string content, string author, string[] tags, string authorSlug, int length, DateTime dateAdded, DateTime dateModified);

}