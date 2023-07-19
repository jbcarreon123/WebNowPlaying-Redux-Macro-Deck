using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using jbcarreon123.WebNowPlayingPlugin.Actions;
using SuchByte.MacroDeck;
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

        private StatusIcon _statusIcon;

        public Main()
        {
            Instance = this;
            PluginInstance.Main = this;
        }

        public override bool CanConfigure => false;

        public override void Enable()
        {
            try
            {
                Instance ??= this;
                Actions = new List<PluginAction>
                {
                    new PlayPauseAction(),
                    new PreviousAction(),
                    new NextAction(),
                    new ShuffleAction(),
                    new RepeatAction()
                };
                Init();
                _statusIcon = new StatusIcon();
            }
            catch (Exception e)
            {
                MacroDeckLogger.Error(this, $"There is a error.\r\n{e}");
            }
        }

        public void Init()
        {
            var assembly = Assembly.GetExecutingAssembly().GetName().Version;
            string version = $"{assembly.Major}.{assembly.Minor}.{assembly.Build}";
            WNPRedux.Start(8698, version, ((type, s) => Logger((int)type, s)));

            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                _statusIcon?.UpdateStatusButton(WNPRedux.clients > 0);

                if (WNPRedux.clients == 0)
                {
                    Thread.Sleep(500);
                    continue;
                }

                var mediainfo = WNPRedux.MediaInfo;

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
                VariableManager.SetValue("wnp_player", mediainfo.PlayerName, VariableType.String, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_state", mediainfo.State, VariableType.Integer, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_volume", mediainfo.Volume, VariableType.Integer, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_shuffle", mediainfo.ShuffleActive, VariableType.Bool, PluginInstance.Main,
                    null);
                VariableManager.SetValue("wnp_repeatone", mediainfo.RepeatMode == MediaInfo.RepeatModeEnum.ONE,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_repeatall", mediainfo.RepeatMode == MediaInfo.RepeatModeEnum.ALL,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_is_playing", mediainfo.State == MediaInfo.StateMode.PLAYING,
                    VariableType.Bool, PluginInstance.Main, null);
                VariableManager.SetValue("wnp_repeat",
                    mediainfo.RepeatMode != MediaInfo.RepeatModeEnum.NONE, VariableType.Bool, PluginInstance.Main,
                    null);

                Thread.Sleep(300);
            }
        }

        public void Logger(int type, string message)
        {
            if (type == 0)
                MacroDeckLogger.Info(PluginInstance.Main, message);
            else if (type == 1)
                MacroDeckLogger.Warning(PluginInstance.Main, message);
            else
                MacroDeckLogger.Error(PluginInstance.Main, message);
        }
    }
}