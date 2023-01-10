using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck;
using jbcarreon123.WebNowPlayingPlugin;

namespace jbcarreon123.WebNowPlayingPlugin.Actions
{
    public class PlayPauseAction : PluginAction
    {
        public override string Name => "Play/Pause";

        public override string Description => "Plays or pauses the current track for all supported tabs";

        public override bool CanConfigure => false;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            Main.socket.Send("playpause");
        }
    }
}