namespace Prueba
{
    partial class FrmPasswordRecover
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.TxtSendMail = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Correo";
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(101, 30);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(185, 20);
            this.TxtEmail.TabIndex = 1;
            // 
            // TxtSendMail
            // 
            this.TxtSendMail.Location = new System.Drawing.Point(292, 28);
            this.TxtSendMail.Name = "TxtSendMail";
            this.TxtSendMail.Size = new System.Drawing.Size(75, 23);
            this.TxtSendMail.TabIndex = 2;
            this.TxtSendMail.Text = "Enviar";
            this.TxtSendMail.UseVisualStyleBackColor = true;
            this.TxtSendMail.Click += new System.EventHandler(this.TxtSendMail_Click);
            // 
            // FrmPasswordRecover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 72);
            this.Controls.Add(this.TxtSendMail);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPasswordRecover";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recuperar Contraseña";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPasswordRecover_FormClosing);
            this.Load += new System.EventHandler(this.FrmPasswordRecover_Load);
            this.Shown += new System.EventHandler(this.FrmPasswordRecover_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Button TxtSendMail;
    }
}