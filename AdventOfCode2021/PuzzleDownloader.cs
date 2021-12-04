using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AdventOfCode2021
{
    public class PuzzleDownloader
    {
        private readonly HttpClient httpClient;
        private readonly string sessionToken;

        public PuzzleDownloader(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            sessionToken = configuration.GetValue<string>("SESSION_TOKEN");
        }

        public async Task<string> DownloadInput(int puzzle, CancellationToken cancellationToken = default)
        {
            HttpRequestMessage request = new(HttpMethod.Get, $"https://adventofcode.com/2021/day/{puzzle}/input");
            request.Headers.Add("cookie", $"session={sessionToken}");

            HttpResponseMessage response = await httpClient.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync(cancellationToken);
            }

            return string.Empty;
        }
    }
}