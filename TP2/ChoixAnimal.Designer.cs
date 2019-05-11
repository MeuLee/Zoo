namespace TP2
{
    partial class ChoixAnimal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoixAnimal));
            this.BtnLicorne = new System.Windows.Forms.Button();
            this.LblMessage = new System.Windows.Forms.Label();
            this.BtnMouton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnLicorne
            // 
            this.BtnLicorne.BackColor = System.Drawing.Color.White;
            this.BtnLicorne.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnLicorne.BackgroundImage")));
            this.BtnLicorne.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnLicorne.Location = new System.Drawing.Point(12, 62);
            this.BtnLicorne.Name = "BtnLicorne";
            this.BtnLicorne.Size = new System.Drawing.Size(123, 117);
            this.BtnLicorne.TabIndex = 0;
            this.BtnLicorne.UseVisualStyleBackColor = false;
            this.BtnLicorne.Click += new System.EventHandler(this.BtnLicorne_Click);
            // 
            // LblMessage
            // 
            this.LblMessage.BackColor = System.Drawing.Color.Transparent;
            this.LblMessage.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblMessage.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblMessage.Location = new System.Drawing.Point(6, 11);
            this.LblMessage.Name = "LblMessage";
            this.LblMessage.Size = new System.Drawing.Size(267, 35);
            this.LblMessage.TabIndex = 9;
            this.LblMessage.Text = "Sélection";
            this.LblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnMouton
            // 
            this.BtnMouton.BackColor = System.Drawing.Color.Snow;
            this.BtnMouton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BtnMouton.BackgroundImage")));
            this.BtnMouton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnMouton.Location = new System.Drawing.Point(147, 62);
            this.BtnMouton.Name = "BtnMouton";
            this.BtnMouton.Size = new System.Drawing.Size(123, 117);
            this.BtnMouton.TabIndex = 10;
            this.BtnMouton.UseVisualStyleBackColor = false;
            this.BtnMouton.Click += new System.EventHandler(this.BtnMouton_Click);
            // 
            // ChoixAnimal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Moccasin;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(285, 194);
            this.ControlBox = false;
            this.Controls.Add(this.BtnMouton);
            this.Controls.Add(this.LblMessage);
            this.Controls.Add(this.BtnLicorne);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChoixAnimal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Choix Animal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnLicorne;
        private System.Windows.Forms.Label LblMessage;
        private System.Windows.Forms.Button BtnMouton;
    }
}