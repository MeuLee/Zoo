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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmZoo));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouvellePartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LblJour = new System.Windows.Forms.Label();
            this.LblArgent = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LblAnimaux = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PnlJour = new System.Windows.Forms.Panel();
            this.PnlArgent = new System.Windows.Forms.Panel();
            this.PnlAnimaux = new System.Windows.Forms.Panel();
            this.PnlPoubelle = new System.Windows.Forms.Panel();
            this.TmrTemps = new System.Windows.Forms.Timer(this.components);
            this.zoo1 = new TP2.LeReste.Zoo();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PnlJour.SuspendLayout();
            this.PnlArgent.SuspendLayout();
            this.PnlAnimaux.SuspendLayout();
            this.PnlPoubelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1341, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvellePartieToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.fichierToolStripMenuItem.Text = "Fichier";
            // 
            // nouvellePartieToolStripMenuItem
            // 
            this.nouvellePartieToolStripMenuItem.Name = "nouvellePartieToolStripMenuItem";
            this.nouvellePartieToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.nouvellePartieToolStripMenuItem.Text = "Nouvelle Partie";
            this.nouvellePartieToolStripMenuItem.Click += new System.EventHandler(this.BtnNouvellePartie_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // LblJour
            // 
            this.LblJour.AutoSize = true;
            this.LblJour.BackColor = System.Drawing.Color.Transparent;
            this.LblJour.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblJour.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblJour.Location = new System.Drawing.Point(47, 17);
            this.LblJour.Name = "LblJour";
            this.LblJour.Size = new System.Drawing.Size(148, 23);
            this.LblJour.TabIndex = 5;
            this.LblJour.Text = "24 mai 2019";
            // 
            // LblArgent
            // 
            this.LblArgent.AutoSize = true;
            this.LblArgent.BackColor = System.Drawing.Color.Transparent;
            this.LblArgent.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblArgent.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblArgent.Location = new System.Drawing.Point(48, 16);
            this.LblArgent.Name = "LblArgent";
            this.LblArgent.Size = new System.Drawing.Size(151, 35);
            this.LblArgent.TabIndex = 6;
            this.LblArgent.Text = "450.07$";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(51, -13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // LblAnimaux
            // 
            this.LblAnimaux.AutoSize = true;
            this.LblAnimaux.BackColor = System.Drawing.Color.Transparent;
            this.LblAnimaux.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAnimaux.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.LblAnimaux.Location = new System.Drawing.Point(31, 87);
            this.LblAnimaux.Name = "LblAnimaux";
            this.LblAnimaux.Size = new System.Drawing.Size(207, 35);
            this.LblAnimaux.TabIndex = 8;
            this.LblAnimaux.Text = "23 animaux";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(65, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(124, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(31, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 35);
            this.label1.TabIndex = 10;
            this.label1.Text = "15 déchets";
            // 
            // PnlJour
            // 
            this.PnlJour.BackColor = System.Drawing.Color.Transparent;
            this.PnlJour.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlJour.Controls.Add(this.LblJour);
            this.PnlJour.Location = new System.Drawing.Point(1056, 84);
            this.PnlJour.Name = "PnlJour";
            this.PnlJour.Size = new System.Drawing.Size(259, 60);
            this.PnlJour.TabIndex = 11;
            // 
            // PnlArgent
            // 
            this.PnlArgent.BackColor = System.Drawing.Color.Transparent;
            this.PnlArgent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlArgent.Controls.Add(this.LblArgent);
            this.PnlArgent.Location = new System.Drawing.Point(1056, 237);
            this.PnlArgent.Name = "PnlArgent";
            this.PnlArgent.Size = new System.Drawing.Size(259, 71);
            this.PnlArgent.TabIndex = 12;
            // 
            // PnlAnimaux
            // 
            this.PnlAnimaux.BackColor = System.Drawing.Color.Transparent;
            this.PnlAnimaux.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlAnimaux.Controls.Add(this.LblAnimaux);
            this.PnlAnimaux.Controls.Add(this.pictureBox1);
            this.PnlAnimaux.Location = new System.Drawing.Point(1056, 397);
            this.PnlAnimaux.Name = "PnlAnimaux";
            this.PnlAnimaux.Size = new System.Drawing.Size(259, 143);
            this.PnlAnimaux.TabIndex = 13;
            // 
            // PnlPoubelle
            // 
            this.PnlPoubelle.BackColor = System.Drawing.Color.Transparent;
            this.PnlPoubelle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PnlPoubelle.Controls.Add(this.pictureBox2);
            this.PnlPoubelle.Controls.Add(this.label1);
            this.PnlPoubelle.Location = new System.Drawing.Point(1056, 624);
            this.PnlPoubelle.Name = "PnlPoubelle";
            this.PnlPoubelle.Size = new System.Drawing.Size(259, 151);
            this.PnlPoubelle.TabIndex = 14;
            // 
            // TmrTemps
            // 
            this.TmrTemps.Enabled = true;
            this.TmrTemps.Interval = 50;
            this.TmrTemps.Tick += new System.EventHandler(this.TmrTemps_Tick);
            // 
            // zoo1
            // 
            this.zoo1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.zoo1.Location = new System.Drawing.Point(0, 25);
            this.zoo1.MaximumSize = new System.Drawing.Size(1025, 833);
            this.zoo1.MinimumSize = new System.Drawing.Size(1025, 833);
            this.zoo1.Name = "zoo1";
            this.zoo1.Size = new System.Drawing.Size(1025, 833);
            this.zoo1.TabIndex = 2;
            this.zoo1.Text = "zoo1";
            // 
            // FrmZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1341, 858);
            this.Controls.Add(this.PnlPoubelle);
            this.Controls.Add(this.PnlAnimaux);
            this.Controls.Add(this.PnlArgent);
            this.Controls.Add(this.PnlJour);
            this.Controls.Add(this.zoo1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmZoo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "le zoo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmZoo_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmZoo_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PnlJour.ResumeLayout(false);
            this.PnlJour.PerformLayout();
            this.PnlArgent.ResumeLayout(false);
            this.PnlArgent.PerformLayout();
            this.PnlAnimaux.ResumeLayout(false);
            this.PnlAnimaux.PerformLayout();
            this.PnlPoubelle.ResumeLayout(false);
            this.PnlPoubelle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Zoo zoo1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nouvellePartieToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.Label LblJour;
        private System.Windows.Forms.Label LblArgent;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label LblAnimaux;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel PnlJour;
        private System.Windows.Forms.Panel PnlArgent;
        private System.Windows.Forms.Panel PnlAnimaux;
        private System.Windows.Forms.Panel PnlPoubelle;
        public System.Windows.Forms.Timer TmrTemps;
    }
}
