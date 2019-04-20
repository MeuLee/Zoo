using TP2.LeReste;

namespace TP2
{
    partial class FrmZoo
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
            this.MnuStrip = new System.Windows.Forms.MenuStrip();
            this.MnuFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.MnuNouvellePartie = new System.Windows.Forms.ToolStripMenuItem();
            this.zoo1 = new TP2.LeReste.Zoo();
            this.MnuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // MnuStrip
            // 
            this.MnuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuFichier});
            this.MnuStrip.Location = new System.Drawing.Point(0, 0);
            this.MnuStrip.Name = "MnuStrip";
            this.MnuStrip.Size = new System.Drawing.Size(1024, 24);
            this.MnuStrip.TabIndex = 1;
            this.MnuStrip.Text = "menuStrip1";
            // 
            // MnuFichier
            // 
            this.MnuFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MnuNouvellePartie});
            this.MnuFichier.Name = "MnuFichier";
            this.MnuFichier.Size = new System.Drawing.Size(54, 20);
            this.MnuFichier.Text = "&Fichier";
            // 
            // MnuNouvellePartie
            // 
            this.MnuNouvellePartie.Name = "MnuNouvellePartie";
            this.MnuNouvellePartie.Size = new System.Drawing.Size(154, 22);
            this.MnuNouvellePartie.Text = "&Nouvelle partie";
            this.MnuNouvellePartie.Click += new System.EventHandler(this.MnuNouvellePartie_Click);
            // 
            // zoo1
            // 
            this.zoo1.Location = new System.Drawing.Point(0, 24);
            this.zoo1.MaximumSize = new System.Drawing.Size(1025, 929);
            this.zoo1.MinimumSize = new System.Drawing.Size(1025, 929);
            this.zoo1.Name = "zoo1";
            this.zoo1.Size = new System.Drawing.Size(1025, 929);
            this.zoo1.TabIndex = 0;
            this.zoo1.Text = "zoo1";
            // 
            // FrmZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 953);
            this.Controls.Add(this.zoo1);
            this.Controls.Add(this.MnuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MainMenuStrip = this.MnuStrip;
            this.MaximizeBox = false;
            this.Name = "FrmZoo";
            this.Text = "le zoo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmZoo_KeyDown);
            this.MnuStrip.ResumeLayout(false);
            this.MnuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Zoo zoo1;
        private System.Windows.Forms.MenuStrip MnuStrip;
        private System.Windows.Forms.ToolStripMenuItem MnuFichier;
        private System.Windows.Forms.ToolStripMenuItem MnuNouvellePartie;
    }
}
