using System;
using SuchByte.MacroDeck;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using SuchByte.MacroDeck.Plugins;
using System.Text;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.GUI.CustomControls;
using System.Windows.Forms;

namespace jbcarreon123.WebNowPlayingPlugin.Config
{
    public partial class Config : DialogForm
    {
        public Config()
        {
            InitializeComponent();
            try
            {
                var port = PluginConfiguration.GetValue(PluginInstance.Main, "port");
                textBox1.Text = (String.IsNullOrWhiteSpace(port)) ? "8974" : port;
                roundedTextBox1.Text = (String.IsNullOrWhiteSpace(port)) ? "8195" : port;
            }
            catch (Exception) { }
            try {
                var mode = PluginConfiguration.GetValue(PluginInstance.Main, "mode");
                tabControl1.SelectedIndex = (mode == "Normal") ? 0 : 1;
            }
            catch (Exception) { tabControl1.SelectedIndex = 0; }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PluginConfiguration.SetValue(PluginInstance.Main, "port", (tabControl1.SelectedIndex == 0) ? textBox1.Text : roundedTextBox1.Text);
            PluginConfiguration.SetValue(PluginInstance.Main, "mode", (tabControl1.SelectedIndex == 0) ? "Normal" : "Redux");
            //          PluginConfiguration.SetValue(PluginInstance.Main, "passThrough", (checkBox1.Checked)? "true":"false");
            //          PluginConfiguration.SetValue(PluginInstance.Main, "pTPort", textBox2.Text);
            using var messageBox = new SuchByte.MacroDeck.GUI.CustomControls.MessageBox();
            var msgDiag = messageBox.ShowDialog(LanguageManager.Strings.MacroDeckNeedsARestart, LanguageManager.Strings.MacroDeckMustBeRestartedForTheChanges, MessageBoxButtons.YesNo);
            if (msgDiag == DialogResult.Yes)
            {
                MacroDeck.RestartMacroDeck();
            }
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
