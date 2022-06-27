using qBittorrentDiscordRelayCLI.DataModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace qBittorrentDiscordRelayCLI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        if(args.Length < 1)
        {
            Console.Write("Webhook URL: ");
            string? url = Console.ReadLine();

            if(url is null)
                Environment.Exit(87);

            if(File.Exists("config.json"))
                File.Delete("config.json");

            await File.AppendAllTextAsync("config.json", JsonSerializer.Serialize(new Config(url), typeof(Config), new JsonSerializerOptions()
            {
                WriteIndented = true
            }));

            Environment.Exit(0);
        }    

        using(FileStream stream = new FileStream("config.json", FileMode.Open, FileAccess.Read))
        {
            Config? config = await JsonSerializer.DeserializeAsync<Config>(stream);

            if(config is null)
                Environment.Exit(13);

            using(HttpClient client = new HttpClient())
            {
                await client.PostAsJsonAsync(config.WebhookUrl, new Dictionary<string, string>()
                {
                    { "content", $"{args[0]} has finished downloading." }
                });
            }
        }
    }
}