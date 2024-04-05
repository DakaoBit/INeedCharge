using INeedCharge.Models;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text.Json;

namespace INeedCharge.Services
{
    public class AccessDataService
    {
        private readonly IHttpClientFactory _clientFactory;
        public AccessDataService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        private async Task<AccessToken> GetToken(string requestUrl)
        {

            var parameters = new Dictionary<string, string>()
            {
                { "grant_type", "client_credentials"},
                { "client_id", "XXXXXXXXXX-XXXXXXXX-XXXX-XXXX" },
                { "client_secret", "XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX"}
            };

            var formData = new FormUrlEncodedContent(parameters);
            var client = _clientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            //client.DefaultRequestHeaders.Add("Accept-Encoding", "br,gzip");
            var response = await client.PostAsync(requestUrl, formData);

            var responseContent = await DecompressResponse(response);
            var token = JsonSerializer.Deserialize<AccessToken>(responseContent);
            return token;
        }

        public async Task<string> DecompressResponse(HttpResponseMessage response)
        {
            if (response.Content.Headers.ContentEncoding.Contains("br"))
            {
                using (var stream = new BrotliStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            else if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                using (var stream = new GZipStream(await response.Content.ReadAsStreamAsync(), CompressionMode.Decompress))
                {
                    using (var reader = new StreamReader(stream))
                    {
                        return await reader.ReadToEndAsync();
                    }
                }
            }
            else
            {
                return await response.Content.ReadAsStringAsync();
            }
        }

        public async Task<string> Get(Dictionary<string, string> parameters, string requestUri, string token)
        {
            var client = _clientFactory.CreateClient();

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Add("authorization", $"Bearer {token}");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "br,gzip");
            }
            //client.DefaultRequestHeaders.Add("Content-Type", "application/json; charset=utf-8");

            if (parameters.Any())
            {
                var strParam = string.Join("&", parameters.Where(d => !string.IsNullOrWhiteSpace(d.Value)).Select(o => o.Key + "=" + o.Value));
                requestUri = string.Concat(requestUri, '?', strParam);
            }
            client.BaseAddress = new Uri(requestUri);

            var response = await client.GetAsync(requestUri).ConfigureAwait(false);

            var responseContent = await DecompressResponse(response);

            return responseContent;
        }


        private Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { $"$select","StationName" },
                { $"$filter",""},
                { $"$orderby",""},
                { $"$top","30"},
                { $"$skip",""},
                { $"health",""},
                { $"$format","JSON"},
            };
        }
    }
}
