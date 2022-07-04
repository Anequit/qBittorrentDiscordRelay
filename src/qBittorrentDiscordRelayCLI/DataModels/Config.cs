namespace qBittorrentDiscordRelayCLI.DataModels;

internal class Config
{
	public Config(string webhookUrl, string message)
	{
		WebhookUrl = webhookUrl;
		Message = message;
	}

    public string WebhookUrl { get; set; }
	public string Message { get; set; }
}
