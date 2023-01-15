using System;
using System.Drawing;
using System.Windows.Forms;
using jbcarreon123.WebNowPlayingPlugin.Actions;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using Fleck;
using System.Collections.Generic;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace jbcarreon123.WebNowPlayingPlugin
{

    public static class PluginInstance
    {
        public static Main Main { get; set; }
    }

    public class Main : MacroDeckPlugin
    {
        public static Main Instance;
        public static int wsclientcount = 0;
        public static IWebSocketConnection socket { get; internal set; }

        public Main()
        {
            Instance = this;
            PluginInstance.Main = this;
        }

        public override void Enable()
        {
            Instance ??= this;
            this.Actions = new List<PluginAction>
            {
                new PlayPauseAction(),
                new PreviousAction(),
                new NextAction(),
                new ShuffleAction(),
                new RepeatAction()
            };
            // MacroDeckLogger.Info(this, $"Finished loading WebNowPlaying Plugin ({stp.ElapsedMilliseconds}ms)");
            OpenWS();
        }

        public bool StringToBoolean(string value) {
            if (value == "true" || Convert.ToInt32(value) >= 0) {
                return true;
            } else {
                return false;
            }
        }

        public void OpenWS()
        {
            var server = new WebSocketServer("ws://0.0.0.0:8974");
            server.Start(socket =>
                {
                    Main.socket = socket;
                    socket.OnMessage = message => {
                        if (!(message.IndexOf("error", StringComparison.CurrentCultureIgnoreCase) >= 0)) {
                            if (message.IndexOf("title", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_title", message.Replace("TITLE:", ""), VariableType.String, PluginInstance.Main, null);
                            } else if (message.IndexOf("artist", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_artist", message.Replace("ARTIST:", ""), VariableType.String, PluginInstance.Main, null);
                            } else if (message.IndexOf("album", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_album", message.Replace("ALBUM:", ""), VariableType.String, PluginInstance.Main, null);
                            } else if (message.IndexOf("player", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_player", message.Replace("PLAYER:", ""), VariableType.String, PluginInstance.Main, null);
                            } else if (message.IndexOf("volume", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_volume", message.Replace("VOLUME:", ""), VariableType.Float, PluginInstance.Main, null);
                            } else if (message.IndexOf("state", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_is_playing", (message.Replace("STATE:","") == "1"), VariableType.Bool, PluginInstance.Main, null);
                                VariableManager.SetValue("wnp_state", message.Replace("STATE:", ""), VariableType.Integer, PluginInstance.Main, null);
                            } else if (message.IndexOf("repeat", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                var repeat = message.Replace("REPEAT:", "");
                                VariableManager.SetValue("wnp_repeat", (repeat == "2" || repeat == "1"), VariableType.Bool, PluginInstance.Main, null);
                                VariableManager.SetValue("wnp_repeatall", (repeat == "2"), VariableType.Bool, PluginInstance.Main, null);
                                VariableManager.SetValue("wnp_repeatone", (repeat == "1"), VariableType.Bool, PluginInstance.Main, null);
                            } else if (message.IndexOf("shuffle", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_shuffle", StringToBoolean(message.Replace("SHUFFLE:", "")), VariableType.Bool, PluginInstance.Main, null);
                            } else if (message.IndexOf("position", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_position", message.Replace("POSITION:", ""), VariableType.String, PluginInstance.Main, null);
                            } else if (message.IndexOf("duration", StringComparison.CurrentCultureIgnoreCase) >= 0) {
                                VariableManager.SetValue("wnp_duration", message.Replace("DURATION:", ""), VariableType.String, PluginInstance.Main, null);
                            }
                        }
                    };
                    socket.OnOpen = () => {
                        socket.Send("Version:0.5.0.0");
                        wsclientcount++;
                        MacroDeckLogger.Trace(PluginInstance.Main, "A websocket client was connected.");
                    };
                    socket.OnClose = () => {
                        wsclientcount--;
                        MacroDeckLogger.Trace(PluginInstance.Main, "A websocket client was disconnected.");
                    };
                }
            );
        }
    }
}
