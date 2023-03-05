using System.Text.Json;

namespace NetMdvt.Logic
{
    public static class JsonDownloader
    {
        public static async Task<JsonDocument> GetJsonAsync(string url, int fakeDelay)
        {
            await Task.Delay(fakeDelay);

            try
            {
                using var client = new HttpClient();
                await using var stream = await client.GetStreamAsync(url);
                return await JsonDocument.ParseAsync(stream);
            }
            catch (Exception ex)
            {
                return JsonSerializer.SerializeToDocument(ex);
            }
        }
    }
}
