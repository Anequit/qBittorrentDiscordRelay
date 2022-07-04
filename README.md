# qBittorrentDiscordRelay
[![GitHub all releases](https://img.shields.io:/github/downloads/Anequit/qBittorrentDiscordRelay/total)](https://github.com/Anequit/qBittorrentDiscordRelay/releases)
[![GitHub release (latest by date)](https://img.shields.io:/github/v/release/Anequit/qBittorrentDiscordRelay)](https://github.com/Anequit/qBittorrentDiscordRelay/releases)
[![GitHub repo size](https://img.shields.io:/github/repo-size/Anequit/qBittorrentDiscordRelay)](https://github.com/Anequit/qBittorrentDiscordRelay/releases)

### What does this do?
This program will send a message to a discord server whenever a torrent finishes downloading. It uses a preconfigured webhook to send the messages.

### Setup Guide
1. Download and run the latest version [here](https://github.com/Anequit/qBittorrentDiscordRelay/releases/latest).
 
2. Copy your webhook url from discord and paste it into the program. If you don't know how to get your webhook url then you can follow this guide [here](https://support.discord.com/hc/en-us/articles/228383668-Intro-to-Webhooks).

3. Check your discord for the test message, if you didn't get it, then your url might be wrong. 

4. If you got your test message, then open the folder where qBittorrent is installed and drag qBittorrentDiscordRelay into the folder.

4. Open qBittorrent and navigate to tools, options, then downloads.

5. Scroll to the bottom and enable "Run external program on torrent completion".

6. Copy and paste `.\qBittorrentDiscordRelay.exe "%N has finished downloading."` into the text field.

7. Try torrenting something small and quick to verify that qBittorrent is setup correctly.
