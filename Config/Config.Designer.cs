
namespace jbcarreon123.WebNowPlayingPlugin.Config
{
    partial class Config
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.textBox2 = new SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox();
            this.button1 = new SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(131, 20);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Passthrough Mode";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Passthrough Mode Port";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Icon = null;
            this.textBox1.Location = new System.Drawing.Point(21, 52);
            this.textBox1.MaxCharacters = 32767;
            this.textBox1.Multiline = false;
            this.textBox1.Name = "textBox1";
            this.textBox1.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBox1.PasswordChar = false;
            this.textBox1.PlaceHolderColor = System.Drawing.Color.Gray;
            this.textBox1.PlaceHolderText = "";
            this.textBox1.ReadOnly = false;
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox1.SelectionStart = 0;
            this.textBox1.Size = new System.Drawing.Size(100, 25);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(65)))), ((int)(((byte)(65)))));
            this.textBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox2.Icon = null;
            this.textBox2.Location = new System.Drawing.Point(21, 136);
            this.textBox2.MaxCharacters = 32767;
            this.textBox2.Multiline = false;
            this.textBox2.Name = "textBox2";
            this.textBox2.Padding = new System.Windows.Forms.Padding(8, 5, 8, 5);
            this.textBox2.PasswordChar = false;
            this.textBox2.PlaceHolderColor = System.Drawing.Color.Gray;
            this.textBox2.PlaceHolderText = "";
            this.textBox2.ReadOnly = false;
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.textBox2.SelectionStart = 0;
            this.textBox2.Size = new System.Drawing.Size(100, 25);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // button1
            // 
            this.button1.BorderRadius = 8;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.HoverColor = System.Drawing.Color.Empty;
            this.button1.Icon = null;
            this.button1.Location = new System.Drawing.Point(235, 149);
            this.button1.Name = "button1";
            this.button1.Progress = 0;
            this.button1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(103)))), ((int)(((byte)(205)))));
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.UseWindowsAccentColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 182);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Config";
            this.Text = "Config";
            this.Controls.SetChildIndex(this.checkBox1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBox1, 0);
            this.Controls.SetChildIndex(this.textBox2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox textBox1;
        private SuchByte.MacroDeck.GUI.CustomControls.RoundedTextBox textBox2;
        private SuchByte.MacroDeck.GUI.CustomControls.ButtonPrimary button1;
    }
}