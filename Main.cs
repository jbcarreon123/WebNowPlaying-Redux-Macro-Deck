using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using jbcarreon123.WebNowPlayingPlugin.Actions;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using WNPReduxAdapterLibrary;

namespace jbcarreon123.WebNowPlayingPlugin
{
    public static class PluginInstance
    {
        public static Main Main { get; set; }
    }

    public class Main : MacroDeckPlugin
    {
        public static Main Instance;

        public Main()
        {
            Instance = this;
            PluginInstance.Main = this;
        }

        public override bool CanConfigure => false;

        public override void Enable()
        {
            new StatusIcon();
            Instance ??= this;
            try
            {
                OpenWS();
                Actions = new List<PluginAction>
                {
                    new PlayPauseAction(),
                    new PreviousAction(),
                    new NextAction(),
                    new ShuffleAction(),
                    new RepeatAction()
                };
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(this, $"There is a error.\r\n{e}");
            }
        }

        public void OpenWS()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName().Version;
            string version = $"{assembly.Major}.{assembly.Minor}.{assembly.Build}";
            WNPRedux.Initialize(8698, version, Logger);

            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                if (WNPRedux.clients == 0)
                {
                    Thread.Sleep(100);
                    continue;
                }

                var mediainfo = WNPRedux.mediaInfo;

                VariableManager.SetValue("wnp_title", mediainfo.Title, VariableType.String, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_album", mediainfo.Album, VariableType.String, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_artist", mediainfo.Artist, VariableType.String, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_position", mediainfo.Position, VariableType.String, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_pos_percent", mediainfo.PositionPercent, VariableType.Float,
                    PluginInstance.Main, null);
                VariableManager.SetValue("wnp_duration", mediainfo.Duration, VariableType.String, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_player", mediainfo.Player, VariableType.String, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_state", mediainfo.State, VariableType.Integer, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_volume", mediainfo.Volume, VariableType.Integer, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_shuffle", mediainfo.Shuffle, VariableType.Bool, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_repeatone", mediainfo.RepeatState == WNPRedux.MediaInfo.RepeatMode.ONE,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_repeatall", mediainfo.RepeatState == WNPRedux.MediaInfo.RepeatMode.ALL,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_is_playing", mediainfo.State == WNPRedux.MediaInfo.StateMode.PLAYING,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_repeat",
                    mediainfo.RepeatState == WNPRedux.MediaInfo.RepeatMode.ALL ||
                    mediainfo.RepeatState == WNPRedux.MediaInfo.RepeatMode.ONE, VariableType.Bool, PluginInstance.Main,
                    null);

                Thread.Sleep(100);
            }
        }

        public void Logger(WNPRedux.LogType type, string message)
        {
            if (type == WNPRedux.LogType.DEBUG)
                MacroDeckLogger.Info(PluginInstance.Main, message);
            else if (type == WNPRedux.LogType.WARNING)
                MacroDeckLogger.Warning(PluginInstance.Main, message);
            else
                MacroDeckLogger.Error(PluginInstance.Main, message);
        }
    }
}