namespace qBittorrentDiscordRelayCLI.DataModels;

internal class Config
{
	public Config(string webhookUrl)
	{
		WebhookUrl = webhookUrl;
	}

    public string WebhookUrl { get; set; }
}
