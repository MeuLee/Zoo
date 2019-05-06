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
            this.components = new System.ComponentModel.Container();
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.LblDate = new System.Windows.Forms.Label();
            this.zoo1 = new TP2.LeReste.Zoo();
            this.TmrTemps = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Location = new System.Drawing.Point(12, 844);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(91, 23);
            this.BtnNouvellePartie.TabIndex = 1;
            this.BtnNouvellePartie.Text = "Nouvelle partie";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnNouvellePartie_Click);
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(109, 844);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(0, 13);
            this.LblDate.TabIndex = 2;
            // 
            // zoo1
            // 
            this.zoo1.Location = new System.Drawing.Point(0, 0);
            this.zoo1.MaximumSize = new System.Drawing.Size(1025, 833);
            this.zoo1.MinimumSize = new System.Drawing.Size(1025, 833);
            this.zoo1.Name = "zoo1";
            this.zoo1.Size = new System.Drawing.Size(1025, 833);
            this.zoo1.TabIndex = 3;
            this.zoo1.Text = "zoo1";
            // 
            // TmrTemps
            // 
            this.TmrTemps.Enabled = true;
            this.TmrTemps.Interval = 822;
            this.TmrTemps.Tick += new System.EventHandler(this.TmrTemps_Tick);
            // 
            // FrmZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 876);
            this.Controls.Add(this.zoo1);
            this.Controls.Add(this.LblDate);
            this.Controls.Add(this.BtnNouvellePartie);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmZoo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "le zoo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmZoo_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmZoo_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnNouvellePartie;
        private System.Windows.Forms.Label LblDate;
        private Zoo zoo1;
        public System.Windows.Forms.Timer TmrTemps;
    }
}
