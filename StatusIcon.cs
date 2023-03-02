using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using jbcarreon123.WebNowPlayingPlugin.Properties;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jbcarreon123.WebNowPlayingPlugin
{
    public class StatusIcon : ContentSelectorButton
    {
        private bool? isConnected;
        private readonly ToolTip _statusToolTip;
        private Main main = new Main();

        /*
        public StatusIcon() : base()
        {
            _statusToolTip = new ToolTip();
            UpdateStatusButton();
            Click += StatusButton_Click;
            main.WSCChanged += WNP_Polling;
            SuchByte.MacroDeck.MacroDeck.MainWindow.FormClosed += MainWindow_FormClosed;
        }

        private void StatusButton_Click(object sender, EventArgs e)
        {
            if (PluginInstance.Main.CanConfigure)
            {
                PluginInstance.Main.OpenConfigurator();
            }
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e) => main.WSCChanged -= WNP_Polling;

        private void WNP_Polling(object sender, EventArgs e) => UpdateStatusButton();

        private void UpdateStatusButton()
        {
            try
            {
                bool connected = PluginInstance.Main.IsClientConnected();

                if (isConnected is null || isConnected != connected)
                {
                    isConnected = connected;
                    BackgroundImage = connected ? Resources.wnp_companion : Resources.wnp_nocompanion;
                    string toolip = connected
                                  ? $"WebNowPlaying :: {Main.wsclientcount}"
                                  : "WebNowPlaying :: No clients connected";
                    _statusToolTip.SetToolTip(this, toolip);
                }
            }
            catch { }
        }
        */
    }
}