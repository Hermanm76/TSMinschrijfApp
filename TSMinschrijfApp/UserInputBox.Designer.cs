namespace TSMinschrijfApp
{
    partial class UserInputBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInputBox));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbox_Email = new System.Windows.Forms.TextBox();
            this.txtbox_Paswoord = new System.Windows.Forms.TextBox();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Annuleer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wachtwoord :";
            // 
            // txtbox_Email
            // 
            this.txtbox_Email.Location = new System.Drawing.Point(99, 13);
            this.txtbox_Email.Name = "txtbox_Email";
            this.txtbox_Email.Size = new System.Drawing.Size(159, 20);
            this.txtbox_Email.TabIndex = 2;
            // 
            // txtbox_Paswoord
            // 
            this.txtbox_Paswoord.Location = new System.Drawing.Point(99, 48);
            this.txtbox_Paswoord.Name = "txtbox_Paswoord";
            this.txtbox_Paswoord.PasswordChar = '*';
            this.txtbox_Paswoord.Size = new System.Drawing.Size(126, 20);
            this.txtbox_Paswoord.TabIndex = 3;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(58, 78);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Annuleer
            // 
            this.btn_Annuleer.Location = new System.Drawing.Point(183, 78);
            this.btn_Annuleer.Name = "btn_Annuleer";
            this.btn_Annuleer.Size = new System.Drawing.Size(75, 23);
            this.btn_Annuleer.TabIndex = 5;
            this.btn_Annuleer.Text = "Annuleer";
            this.btn_Annuleer.UseVisualStyleBackColor = true;
            this.btn_Annuleer.Click += new System.EventHandler(this.btn_Annuleer_Click);
            // 
            // UserInputBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(309, 125);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Annuleer);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.txtbox_Paswoord);
            this.Controls.Add(this.txtbox_Email);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserInputBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gebruikersnaam en wachtwoord";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbox_Email;
        private System.Windows.Forms.TextBox txtbox_Paswoord;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Annuleer;
    }
}