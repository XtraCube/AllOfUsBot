using Impostor.Api.Events;
using Impostor.Api.Events.Meeting;
using Impostor.Api.Events.Player;
using Impostor.Api.Innersloth;
using Impostor.Api.Innersloth.Customization;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using XtraCube.Plugins.AllofUs;

namespace XtraCube.Plugins.AllOfUs.Handlers
{
    public class GameEventListener : IEventListener
    {
        private readonly ILogger<AllOfUsPlugin> _logger;

        public async Task sendWelcome(Impostor.Api.Net.Inner.Objects.IInnerPlayerControl host, string name, byte color)
        {
            await Task.Delay(700);
            await host.SetNameAsync($"[FF0000FF]All Of Us Bot | Public");
            await host.SetColorAsync((byte)0);
            await host.SendChatAsync($"Welcome to the server!");
            await host.SendChatAsync($"This server is powered by All of Us Bot, an Impostor plugin designed to be used with All of Us Mod, a 100 Player Mod for Among Us!");
            await host.SendChatAsync($"Type /help for a list of all the commands!");
            await host.SetNameAsync($"{name}");
            await host.SetColorAsync(color);
        }

        public GameEventListener(ILogger<AllOfUsPlugin> logger)
        {
            _logger = logger;
        }

        [EventListener]
        public void OnLobbyCreate(IPlayerSpawnedEvent e)
        {
            if (e.ClientPlayer.IsHost)
            {
                var host = e.Game.Host.Character;
                var name = e.ClientPlayer.Character.PlayerInfo.PlayerName;
                var color = e.ClientPlayer.Character.PlayerInfo.ColorId;
                sendWelcome(host,name,color);
            }
        }

        [EventListener]
        public void OnGameStarted(IGameStartedEvent e)
        {
            //            _logger.LogInformation($"Game is starting.");
            foreach (var player in e.Game.Players)
            {
                var info = player.Character.PlayerInfo;
                var isImpostor = info.IsImpostor;
                if (isImpostor)
                {
                   // _logger.LogInformation($"- {info.PlayerName} is an impostor.");
                }
                else
                {
                    //    _logger.LogInformation($"- {info.PlayerName} is a crewmate.");
                }
            }
        }

        [EventListener]
        public void OnGameEnded(IGameEndedEvent e)
        {
            //            _logger.LogInformation($"Game has ended.");
        }

        [EventListener]
        public void OnMeeting(IMeetingStartedEvent e)
        {
            /*foreach (var player in e.Game.Players)
            {
                player.
            }*/
        }

        [EventListener]
        public void OnPlayerChat(IPlayerChatEvent e)
        {
            string botname = "[FF0000FF]All Of Us Bot | Public";
            //            _logger.LogInformation($"{e.PlayerControl.PlayerInfo.PlayerName} said {e.Message}");
            string[] args = e.Message.Trim().Split(" ");
            string name = e.PlayerControl.PlayerInfo.PlayerName;
            byte color = e.PlayerControl.PlayerInfo.ColorId;
            if (e.Game.GameState == GameStates.NotStarted)
            {
                if (args[0].ToLower() == "/help" || args[0].ToLower() == "/commands")
                {
                    {
                        if (e.ClientPlayer.IsHost)
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"Commands: /map, /name, /color, /playerlimit, /implimit, /help");
                            e.PlayerControl.SendChatAsync($"Type /<command name> to learn how to use it");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                        else
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"Commands: /name, /color, /help");
                            e.PlayerControl.SendChatAsync($"Type /<command name> to learn how to use it");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                    }

                }
                if (args[0].ToLower() == "/color")
                {
                    if (args.Length > 1)
                    {
                        if (args[1].ToLower() == "red")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "blue")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)1);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "green")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)2);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "pink")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)3);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "orange")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)4);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "yellow")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)5);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "black")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)6);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "white")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)7);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "purple")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)8);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "brown")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)9);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "cyan")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)10);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                        if (args[1].ToLower() == "lime")
                        {
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SendChatAsync($"Color changed successfully");
                            e.PlayerControl.SetColorAsync((byte)11);
                            e.PlayerControl.SetNameAsync($"{name}");
                        }
                    }
                    if (args.Length == 1)
                    {
                        e.PlayerControl.SetNameAsync($"{botname}");
                        e.PlayerControl.SetColorAsync((byte)0);
                        e.PlayerControl.SendChatAsync($"/color {{color}}\n Change your color!");
                        e.PlayerControl.SendChatAsync($"Available colors: Red, Blue, Green, Pink, Orange, Yellow, Black, White, Purple, Brown, Cyan, Lime");
                        e.PlayerControl.SetNameAsync($"{name}");
                        e.PlayerControl.SetColorAsync(color);
                    }

                }
                if (args[0].ToLower() == "/name")
                {
                    if (args.Length > 1)
                    {
                        if (args[1].Length < 11 && args[1].Length > 3)
                        {
                            bool nameUsed = false;
                            foreach (var player in e.Game.Players)
                            {
                                string playerName = player.Character.PlayerInfo.PlayerName;
                                if (playerName == args[1])
                                {
                                    nameUsed = true;
                                    e.PlayerControl.SetNameAsync($"{botname}");
                                    e.PlayerControl.SetColorAsync((byte)0);
                                    e.PlayerControl.SendChatAsync($"Name already taken!");
                                    e.PlayerControl.SetNameAsync($"{name}");
                                    e.PlayerControl.SetColorAsync(color);
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (!nameUsed)
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.PlayerControl.SendChatAsync($"Name changed successfully!");
                                e.PlayerControl.SetNameAsync($"{args[1]}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                        }
                        else
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"Name is too long or too short! Please try a different name!");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                    }
                    if (args.Length == 1)
                    {
                        e.PlayerControl.SetNameAsync($"{botname}");
                        e.PlayerControl.SetColorAsync((byte)0);
                        e.PlayerControl.SendChatAsync($"/name {{name}}\n Change your name!");
                        e.PlayerControl.SetNameAsync($"{name}");
                        e.PlayerControl.SetColorAsync(color);
                    }
                }
                if (args[0].ToLower() == "/implimit")
                {
                    if (e.ClientPlayer.IsHost)
                    {
                        if (args.Length > 1)
                        {
                            int limit;
                            bool tryLimit = int.TryParse(args[1].ToLower(), out limit);
                            if (tryLimit)
                            {
                                if (limit < 127 && limit > 0)
                                {
                                    if ((e.Game.Options.MaxPlayers / limit) > 2f)
                                    {
                                        e.PlayerControl.SetNameAsync($"{botname}");
                                        e.PlayerControl.SetColorAsync((byte)0);
                                        e.Game.Options.NumImpostors = (byte)limit;
                                        e.PlayerControl.SendChatAsync($"Impostor limit has been set to {args[1].ToLower()}!");
                                        e.PlayerControl.SetNameAsync($"{name}");
                                        e.PlayerControl.SetColorAsync(color);
                                        e.Game.SyncSettingsAsync();
                                    }
                                    else
                                    {
                                        e.PlayerControl.SetNameAsync($"{botname}");
                                        e.PlayerControl.SetColorAsync((byte)0);
                                        e.PlayerControl.SendChatAsync($"Impostor limit is too high! Please make it lower!");
                                        e.PlayerControl.SetNameAsync($"{name}");
                                        e.PlayerControl.SetColorAsync(color);
                                        e.Game.SyncSettingsAsync();
                                    }
                                }
                                else
                                {
                                    e.PlayerControl.SetNameAsync($"{botname}");
                                    e.PlayerControl.SetColorAsync((byte)0);
                                    e.PlayerControl.SendChatAsync($"[FF0000FF]Error: Impostor limit can only be greater or equal to than 1 and less than 64!");
                                    e.PlayerControl.SetNameAsync($"{name}");
                                    e.PlayerControl.SetColorAsync(color);
                                    e.Game.SyncSettingsAsync();
                                }
                            }
                            else
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.PlayerControl.SendChatAsync($"[FF0000FF]Error: Please enter a number! If you did enter a number, then there was an error!");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                        }
                        if (args.Length == 1)
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"/implimit {{amount}}\nSet the maximum impostor count. Max is 63, minimum is 1");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                    }
                    else
                    {
                        e.PlayerControl.SetNameAsync($"{botname}");
                        e.PlayerControl.SetColorAsync((byte)0);
                        e.PlayerControl.SendChatAsync($"[FF0000FF] You can't use that command!");
                        e.PlayerControl.SetNameAsync($"{name}");
                        e.PlayerControl.SetColorAsync(color);
                    }
                }
                if (args[0].ToLower() == "/playerlimit")
                {
                    if (e.ClientPlayer.IsHost)
                    {
                        if (args.Length > 1)
                        {
                            int limit;
                            bool tryLimit = int.TryParse(args[1].ToLower(), out limit);
                            if (tryLimit)
                            {
                                if (limit < 127 && limit > 4)
                                {
                                    e.PlayerControl.SetNameAsync($"{botname}");
                                    e.PlayerControl.SetColorAsync((byte)0);
                                    e.Game.Options.MaxPlayers = (byte)limit;
                                    e.PlayerControl.SendChatAsync($"Player limit has been set to {args[1].ToLower()}!\nNote: The counter will not change until someone joins/leaves!");
                                    e.PlayerControl.SetNameAsync($"{name}");
                                    e.PlayerControl.SetColorAsync(color);
                                    e.Game.SyncSettingsAsync();
                                }
                                else
                                {
                                    e.PlayerControl.SetNameAsync($"{botname}");
                                    e.PlayerControl.SetColorAsync((byte)0);
                                    e.PlayerControl.SendChatAsync($"[FF0000FF]Error: Player limit can only be greater than 3 and less than 128!");
                                    e.PlayerControl.SetNameAsync($"{name}");
                                    e.PlayerControl.SetColorAsync(color);
                                    e.Game.SyncSettingsAsync();
                                }
                            }
                            else
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.PlayerControl.SendChatAsync($"[FF0000FF]Error: Please enter a number! If you did enter a number, then there was an error!");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                        }
                        if (args.Length == 1)
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"/playerlimit {{amount}}\nSet the maximum player limit. Max is 127, minimum is 4");
                            e.PlayerControl.SendChatAsync($"Note: The counter will not change until someone joins/leaves!");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                    }
                    else
                    {
                        e.PlayerControl.SetNameAsync($"{botname}");
                        e.PlayerControl.SetColorAsync((byte)0);
                        e.PlayerControl.SendChatAsync($"[FF0000FF] You can't use that command!");
                        e.PlayerControl.SetNameAsync($"{name}");
                        e.PlayerControl.SetColorAsync(color);
                    }
                }
                if (args[0].ToLower() == "/map")
                {
                    if (e.ClientPlayer.IsHost)
                    {
                        if (args.Length > 1)
                        {
                            string mapname = args[1].ToLower();
                            if (mapname == "skeld")
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.Game.Options.Map = (MapTypes)(byte)MapTypes.Skeld;
                                e.Game.SyncSettingsAsync();
                                e.PlayerControl.SendChatAsync($"Map has been set to The Skeld!");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                            else if (mapname == "mira" || mapname == "mirahq")
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.Game.Options.Map = (MapTypes)(byte)MapTypes.MiraHQ;
                                e.Game.SyncSettingsAsync();
                                e.PlayerControl.SendChatAsync($"Map has been set to MiraHQ!");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                            else if (mapname == "polus")
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.Game.Options.Map = (MapTypes)(byte)MapTypes.Polus;
                                e.Game.SyncSettingsAsync();
                                e.PlayerControl.SendChatAsync($"Map has been set to Polus!");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                            }
                            else
                            {
                                e.PlayerControl.SetNameAsync($"{botname}");
                                e.PlayerControl.SetColorAsync((byte)0);
                                e.PlayerControl.SendChatAsync($"[FF0000FF]Error: That is not a map!\nAvailable Maps: Skeld, Mira/MiraHQ. Polus");
                                e.PlayerControl.SetNameAsync($"{name}");
                                e.PlayerControl.SetColorAsync(color);
                                e.Game.SyncSettingsAsync();
                            }
                        }
                        if (args.Length == 1)
                        {
                            e.PlayerControl.SetNameAsync($"{botname}");
                            e.PlayerControl.SetColorAsync((byte)0);
                            e.PlayerControl.SendChatAsync($"/map {{map}}\nSet the map without making a new lobby! Maps: Skeld, Mira/MiraHQ, Polus");
                            e.PlayerControl.SetNameAsync($"{name}");
                            e.PlayerControl.SetColorAsync(color);
                        }
                    }
                    else
                    {
                        e.PlayerControl.SetNameAsync($"{botname}");
                        e.PlayerControl.SetColorAsync((byte)0);
                        e.PlayerControl.SendChatAsync($"[FF0000FF] You can't use that command!");
                        e.PlayerControl.SetNameAsync($"{name}");
                        e.PlayerControl.SetColorAsync(color);
                    }
                }
                if (args[0].ToLower() == "/about")
                {
                    e.PlayerControl.SetNameAsync($"{botname}");
                    e.PlayerControl.SetColorAsync((byte)0);
                    e.PlayerControl.SendChatAsync($"All of Us is a 100 Player Mod for Among Us developed by XtraCube, CN_Pure, and andry08.");
                    e.PlayerControl.SendChatAsync($"All Of Us Bot is a server plugin for the custom Among Us server, Impostor. It can't be used to play 100 player games without the client mod!");
                    e.PlayerControl.SendChatAsync($"This server is using the public version of the mod with stripped down features!");
                    e.PlayerControl.SetNameAsync($"{name}");
                    e.PlayerControl.SetColorAsync(color);
                }
            }
        }
    }

}