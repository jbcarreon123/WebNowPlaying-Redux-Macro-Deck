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
using WNPReduxAdapterLibrary;

namespace jbcarreon123.WebNowPlayingPlugin.Actions
{
    public class PreviousAction : PluginAction
    {
        public override string Name => "Previous";

        public override string Description => "Previouses the track";

        public override bool CanConfigure => false;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (PluginConfiguration.GetValue(PluginInstance.Main, "mode") == "Normal")
                Main.socket.Send("previous");
            else
                WNPRedux.mediaEvents.Previous();
        }
    }
}