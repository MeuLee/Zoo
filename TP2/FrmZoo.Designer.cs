﻿using TP2.LeReste;

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
            this.BtnNouvellePartie = new System.Windows.Forms.Button();
            this.zoo1 = new TP2.LeReste.Zoo();
            this.SuspendLayout();
            // 
            // BtnNouvellePartie
            // 
            this.BtnNouvellePartie.Location = new System.Drawing.Point(-2, 0);
            this.BtnNouvellePartie.Name = "BtnNouvellePartie";
            this.BtnNouvellePartie.Size = new System.Drawing.Size(91, 23);
            this.BtnNouvellePartie.TabIndex = 1;
            this.BtnNouvellePartie.Text = "Nouvelle partie";
            this.BtnNouvellePartie.UseVisualStyleBackColor = true;
            this.BtnNouvellePartie.Click += new System.EventHandler(this.BtnNouvellePartie_Click);
            // 
            // zoo1
            // 
            this.zoo1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.zoo1.Location = new System.Drawing.Point(-2, 12);
            this.zoo1.MaximumSize = new System.Drawing.Size(1025, 929);
            this.zoo1.MinimumSize = new System.Drawing.Size(1025, 929);
            this.zoo1.Name = "zoo1";
            this.zoo1.Size = new System.Drawing.Size(1025, 929);
            this.zoo1.TabIndex = 2;
            this.zoo1.Text = "zoo1";
            // 
            // FrmZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1142, 871);
            this.Controls.Add(this.zoo1);
            this.Controls.Add(this.BtnNouvellePartie);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmZoo";
            this.Text = "ZOO";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmZoo_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnNouvellePartie;
        private Zoo zoo1;
    }
}
