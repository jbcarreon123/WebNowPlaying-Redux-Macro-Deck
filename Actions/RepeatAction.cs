using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using WNPReduxAdapterLibrary;

namespace jbcarreon123.WebNowPlayingPlugin.Actions
{
    public class RepeatAction : PluginAction
    {
        public override string Name => "Repeat";

        public override string Description => "Toggle repeat";

        public override bool CanConfigure => false;

        public override string BindableVariable => "wnp_repeat";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (WNPRedux.MediaInfo.Controls.SupportsToggleRepeatMode)
            {
                WNPRedux.MediaInfo.Controls.TryToggleRepeat();   
            }
        }
    }
}