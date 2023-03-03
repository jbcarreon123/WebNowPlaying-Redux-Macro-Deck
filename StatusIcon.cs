using System;
using System.Windows.Forms;
using jbcarreon123.WebNowPlayingPlugin.Properties;
using SuchByte.MacroDeck;
using SuchByte.MacroDeck.GUI.CustomControls;

namespace jbcarreon123.WebNowPlayingPlugin
{
    public class StatusIcon : ContentSelectorButton
    {
        /*
        private readonly ToolTip _statusToolTip;
        private bool? isConnected;
        private readonly Main main = new Main();

        public StatusIcon()
        {
            _statusToolTip = new ToolTip();
            UpdateStatusButton();
            Click += StatusButton_Click;
            
            MacroDeck.MainWindow.FormClosed += MainWindow_FormClosed;
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (PluginInstance.Main.CanConfigure) PluginInstance.Main.OpenConfigurator();
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            main.WSCChanged -= WNP_Polling;
        }

        private void WNP_Polling(object sender, EventArgs e)
        {
            UpdateStatusButton();
        }

        private void UpdateStatusButton()
        {
            try
            {
                bool connected = PluginInstance.Main.IsClientConnected();

                if (isConnected is null || isConnected != connected)
                {
                    isConnected = connected;
                    BackgroundImage = connected ? Resources.wnp_companion : Resources.wnp_nocompanion;
                    var toolip = connected
                        ? $"WebNowPlaying :: {Main.wsclientcount}"
                        : "WebNowPlaying :: No clients connected";
                    _statusToolTip.SetToolTip(this, toolip);
                }
            }
            catch
            {
            }  
        }
        */
    }
}