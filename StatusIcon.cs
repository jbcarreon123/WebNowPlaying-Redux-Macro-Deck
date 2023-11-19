using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using jbcarreon123.WebNowPlayingPlugin.Properties;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using WNPReduxAdapterLibrary;

namespace jbcarreon123.WebNowPlayingPlugin
{
    public class StatusIcon
    {
        private ContentSelectorButton statusButton = new ContentSelectorButton();
        private MainWindow mainWindow;
        private readonly ToolTip _statusToolTip;
        private readonly Main main = new Main();

        public StatusIcon()
        {
            _statusToolTip = new ToolTip();

            MacroDeck.OnMainWindowLoad += MacroDeck_OnMainWindowLoad;
        }

        private void MacroDeck_OnMainWindowLoad(object sender, EventArgs e)
        {
            mainWindow = sender as MainWindow;
            
            bool connected = WNPRedux.clients > 0;

            this.statusButton = new ContentSelectorButton
            {
                BackgroundImage = WNPRedux.clients > 0 ? Properties.Resources.wnp_companion : Properties.Resources.wnp_nocompanion,
                BackgroundImageLayout = ImageLayout.Stretch,

            };
            var assembly = Assembly.GetExecutingAssembly().GetName().Version;
            string version = $"{assembly.Major}.{assembly.Minor}.{assembly.Build}";
            string isnativeapi = WNPRedux.isUsingNativeAPIs
                ? "\r\nUsing Native APIs"
                : "";
            var toolip = connected
                ? $"WebNowPlaying Plugin {version}\r\n{WNPRedux.clients} connected{isnativeapi}"
                : $"WebNowPlaying Plugin {version}\r\nNo clients connected at this time";
            _statusToolTip.SetToolTip(statusButton, toolip);
            
            mainWindow.contentButtonPanel.Controls.Add(statusButton);
        }

        public void UpdateStatusButton(bool connected)
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly().GetName().Version;
                string version = $"{assembly.Major}.{assembly.Minor}.{assembly.Build}";
                string isnativeapi = WNPRedux.isUsingNativeAPIs
                        ? "\r\nUsing Native APIs"
                        : "";
                var toolip = connected
                    ? $"WebNowPlaying Redux {version}\r\n{WNPRedux.clients} connected{isnativeapi}"
                    : $"WebNowPlaying Redux {version}\r\nNo clients connected at this time";
                statusButton.BackgroundImage = connected ? Resources.wnp_companion : Resources.wnp_nocompanion;;
                _statusToolTip.SetToolTip(statusButton, toolip);
            }
            catch (Exception e)
            {
                MacroDeckLogger.Warning(PluginInstance.Main, $"{e}");
            }  
        }
    }
}