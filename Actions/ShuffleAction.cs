using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using WNPReduxAdapterLibrary;

namespace jbcarreon123.WebNowPlayingPlugin.Actions
{
    public class ShuffleAction : PluginAction
    {
        public override string Name => "Shuffle";

        public override string Description => "Toggle shuffle";

        public override bool CanConfigure => false;

        public override string BindableVariable => "wnp_shuffle";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (WNPRedux.MediaInfo.Controls.SupportsToggleShuffleActive)
            {
                WNPRedux.MediaInfo.Controls.TryToggleShuffleActive();   
            }
        }
    }
}