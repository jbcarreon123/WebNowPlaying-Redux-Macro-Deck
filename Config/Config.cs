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
            }
            catch (Exception) { }
            try {
            var pT = PluginConfiguration.GetValue(PluginInstance.Main, "passThrough");
            checkBox1.Checked = Convert.ToBoolean(pT);
            }
            catch (Exception) { }
            try {
            var pTPort = PluginConfiguration.GetValue(PluginInstance.Main, "pTPort");
            textBox2.Text = (String.IsNullOrWhiteSpace(pTPort)) ? "8974" : pTPort;
            }
            catch (Exception) { }
            checkBox1.Checked = false;
            checkBox1.Enabled = false;
            checkBox1.Text = "Passthrough Mode (ongoing development)";
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = checkBox1.Checked;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PluginConfiguration.SetValue(PluginInstance.Main, "port", textBox1.Text);
            PluginConfiguration.SetValue(PluginInstance.Main, "passThrough", (checkBox1.Checked)? "true":"false");
            PluginConfiguration.SetValue(PluginInstance.Main, "pTPort", textBox2.Text);
            using var messageBox = new SuchByte.MacroDeck.GUI.CustomControls.MessageBox();
            var msgDiag = messageBox.ShowDialog(LanguageManager.Strings.MacroDeckNeedsARestart, LanguageManager.Strings.MacroDeckMustBeRestartedForTheChanges, MessageBoxButtons.YesNo);
            if (msgDiag == DialogResult.Yes)
            {
                MacroDeck.RestartMacroDeck();
            }
            this.Close();
        }
    }
}
