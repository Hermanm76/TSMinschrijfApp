namespace TSMinschrijfApp
{
    partial class HelpScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpScherm));
            this.btn_helpscherm_sluiten = new System.Windows.Forms.Button();
            this.lbl_versienr = new System.Windows.Forms.Label();
            this.lbl_projectwerk = new System.Windows.Forms.Label();
            this.lbl_dev = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_helpscherm_sluiten
            // 
            this.btn_helpscherm_sluiten.Location = new System.Drawing.Point(149, 232);
            this.btn_helpscherm_sluiten.Name = "btn_helpscherm_sluiten";
            this.btn_helpscherm_sluiten.Size = new System.Drawing.Size(75, 23);
            this.btn_helpscherm_sluiten.TabIndex = 0;
            this.btn_helpscherm_sluiten.Text = "Sluiten";
            this.btn_helpscherm_sluiten.UseVisualStyleBackColor = true;
            this.btn_helpscherm_sluiten.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_versienr
            // 
            this.lbl_versienr.AutoSize = true;
            this.lbl_versienr.Location = new System.Drawing.Point(259, 224);
            this.lbl_versienr.Name = "lbl_versienr";
            this.lbl_versienr.Size = new System.Drawing.Size(66, 13);
            this.lbl_versienr.TabIndex = 1;
            this.lbl_versienr.Text = "Versie: 1.1.1";
            // 
            // lbl_projectwerk
            // 
            this.lbl_projectwerk.AutoSize = true;
            this.lbl_projectwerk.Location = new System.Drawing.Point(259, 237);
            this.lbl_projectwerk.Name = "lbl_projectwerk";
            this.lbl_projectwerk.Size = new System.Drawing.Size(117, 13);
            this.lbl_projectwerk.TabIndex = 2;
            this.lbl_projectwerk.Text = "Projectwerk 2016-2017";
            // 
            // lbl_dev
            // 
            this.lbl_dev.AutoSize = true;
            this.lbl_dev.Location = new System.Drawing.Point(259, 251);
            this.lbl_dev.Name = "lbl_dev";
            this.lbl_dev.Size = new System.Drawing.Size(92, 13);
            this.lbl_dev.TabIndex = 3;
            this.lbl_dev.Text = "Herman Messagie";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(28, 36);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(497, 176);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // HelpScherm
            // 
            this.AcceptButton = this.btn_helpscherm_sluiten;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(537, 287);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_dev);
            this.Controls.Add(this.lbl_projectwerk);
            this.Controls.Add(this.lbl_versienr);
            this.Controls.Add(this.btn_helpscherm_sluiten);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HelpScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Help Scherm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_helpscherm_sluiten;
        private System.Windows.Forms.Label lbl_versienr;
        private System.Windows.Forms.Label lbl_projectwerk;
        private System.Windows.Forms.Label lbl_dev;
        private System.Windows.Forms.TextBox textBox1;
    }
}