using qBittorrentDiscordRelayCLI.DataModels;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace qBittorrentDiscordRelayCLI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        if(args.Length > 1)
            Environment.Exit(160);

        HttpClient client = new HttpClient();

        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "qBittorrentDiscordRelay");

        if(!Directory.Exists(path))
            Directory.CreateDirectory(path);

        path = Path.Combine(path, "config.json");

        if(File.Exists(path))
        {
            if(args.Length == 1)
            {
                using(FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    Config? config = await JsonSerializer.DeserializeAsync<Config>(stream);

                    if(config is null)
                        Environment.Exit(13);

                    await client.MessageWebhookAsync(config.WebhookUrl, args[0]);
                    Environment.Exit(0);
                }
            }
        }

        string url = await GetWebhookURLAsync(client);

        if(File.Exists(path))
            File.Delete(path);

        await File.AppendAllTextAsync(path, JsonSerializer.Serialize(new Config(url), typeof(Config)));

        Console.Write("\nPress any key to close...");
        Console.ReadKey();
        Environment.Exit(0);
    }

    private static async Task<string> GetWebhookURLAsync(HttpClient client)
    {
        while(true)
        {
            Console.Clear();

            Console.WriteLine("[1/2] Paste in your discord webhook url below, then press enter to confirm it. \n");
            Console.Write("Webhook URL: ");
            string url = Console.ReadLine() ?? "";

            // Send test message
            await client.MessageWebhookAsync(url, "If you receive this message, then your relay is configured correctly.");

            Console.Clear();
            Console.Write("[2/2] Did you receive the test message? (Y/n) ");
            string answer = Console.ReadLine() ?? "Y";

            if(answer.ToUpper() == "Y" || answer == "")
                return url;
        }
    }
}