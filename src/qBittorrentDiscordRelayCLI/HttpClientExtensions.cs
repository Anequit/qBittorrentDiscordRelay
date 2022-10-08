using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace qBittorrentDiscordRelayCLI;

public static class HttpClientExtensions
{
    public static async Task MessageWebhookAsync(this HttpClient client, string webhook, string message)
    {
        try
        {
            await client.PostAsJsonAsync(webhook, new Dictionary<string, string>()
            {
                {
                    "username", "qBittorrentRelay"
                },
                {
                    "avatar_url", "https://pics.computerbase.de/6/4/9/3/8/logo-256.png"
                },
                {
                    "content", message
                }
            });
        }
        catch(Exception) { }
    }
}
