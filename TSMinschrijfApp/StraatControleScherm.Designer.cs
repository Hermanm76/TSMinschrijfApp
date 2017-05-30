namespace TSMinschrijfApp
{
    partial class StraatControleScherm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StraatControleScherm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbox_VolledigeStraat = new System.Windows.Forms.TextBox();
            this.txtbox_StraatZonderHuisNr = new System.Windows.Forms.TextBox();
            this.txtbox_HuisNr = new System.Windows.Forms.TextBox();
            this.txtbox_Bus = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingelezen Straat";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Straat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nr";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bus";
            // 
            // txtbox_VolledigeStraat
            // 
            this.txtbox_VolledigeStraat.Location = new System.Drawing.Point(16, 47);
            this.txtbox_VolledigeStraat.Name = "txtbox_VolledigeStraat";
            this.txtbox_VolledigeStraat.ReadOnly = true;
            this.txtbox_VolledigeStraat.Size = new System.Drawing.Size(409, 20);
            this.txtbox_VolledigeStraat.TabIndex = 4;
            // 
            // txtbox_StraatZonderHuisNr
            // 
            this.txtbox_StraatZonderHuisNr.Location = new System.Drawing.Point(16, 117);
            this.txtbox_StraatZonderHuisNr.Name = "txtbox_StraatZonderHuisNr";
            this.txtbox_StraatZonderHuisNr.Size = new System.Drawing.Size(293, 20);
            this.txtbox_StraatZonderHuisNr.TabIndex = 5;
            // 
            // txtbox_HuisNr
            // 
            this.txtbox_HuisNr.Location = new System.Drawing.Point(16, 155);
            this.txtbox_HuisNr.Name = "txtbox_HuisNr";
            this.txtbox_HuisNr.Size = new System.Drawing.Size(122, 20);
            this.txtbox_HuisNr.TabIndex = 6;
            // 
            // txtbox_Bus
            // 
            this.txtbox_Bus.Location = new System.Drawing.Point(16, 193);
            this.txtbox_Bus.Name = "txtbox_Bus";
            this.txtbox_Bus.Size = new System.Drawing.Size(122, 20);
            this.txtbox_Bus.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(220, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Gelieve de correcte gegevens aan te vullen..";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Kan straat, huisnr en bus niet automatisch herkennen.";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(209, 190);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Ga verder met aanmaken";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // StraatControleScherm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(450, 241);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtbox_Bus);
            this.Controls.Add(this.txtbox_HuisNr);
            this.Controls.Add(this.txtbox_StraatZonderHuisNr);
            this.Controls.Add(this.txtbox_VolledigeStraat);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StraatControleScherm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Straat Controle Scherm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StraatControleScherm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbox_VolledigeStraat;
        private System.Windows.Forms.TextBox txtbox_StraatZonderHuisNr;
        private System.Windows.Forms.TextBox txtbox_HuisNr;
        private System.Windows.Forms.TextBox txtbox_Bus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
    }
}