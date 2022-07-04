using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace qBittorrentDiscordRelayCLI;

public static class HttpClientExtensions
{
	public static async Task MessageWebhookAsync(this HttpClient client, string webhook, string message)
	{
        await client.PostAsJsonAsync(webhook, new Dictionary<string, string>()
        {
            { 
                "content", message 
            }
        });
    }
}
