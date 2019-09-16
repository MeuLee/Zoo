namespace TP2
{
    partial class FrmInfos
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
            this.PicImage = new System.Windows.Forms.PictureBox();
            this.LblType = new System.Windows.Forms.Label();
            this.LblSexe = new System.Windows.Forms.Label();
            this.LblAge = new System.Windows.Forms.Label();
            this.LblFaim = new System.Windows.Forms.Label();
            this.LblEnceinte = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(129, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(42, 42);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // LblType
            // 
            this.LblType.BackColor = System.Drawing.Color.Transparent;
            this.LblType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblType.Location = new System.Drawing.Point(0, 89);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(282, 35);
            this.LblType.TabIndex = 10;
            this.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSexe
            // 
            this.LblSexe.BackColor = System.Drawing.Color.Transparent;
            this.LblSexe.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblSexe.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblSexe.Location = new System.Drawing.Point(0, 149);
            this.LblSexe.Name = "LblSexe";
            this.LblSexe.Size = new System.Drawing.Size(282, 35);
            this.LblSexe.TabIndex = 11;
            this.LblSexe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAge
            // 
            this.LblAge.BackColor = System.Drawing.Color.Transparent;
            this.LblAge.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAge.Location = new System.Drawing.Point(0, 208);
            this.LblAge.Name = "LblAge";
            this.LblAge.Size = new System.Drawing.Size(282, 35);
            this.LblAge.TabIndex = 12;
            this.LblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblFaim
            // 
            this.LblFaim.BackColor = System.Drawing.Color.Transparent;
            this.LblFaim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFaim.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblFaim.Location = new System.Drawing.Point(0, 265);
            this.LblFaim.Name = "LblFaim";
            this.LblFaim.Size = new System.Drawing.Size(282, 35);
            this.LblFaim.TabIndex = 13;
            this.LblFaim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEnceinte
            // 
            this.LblEnceinte.BackColor = System.Drawing.Color.Transparent;
            this.LblEnceinte.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnceinte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblEnceinte.Location = new System.Drawing.Point(0, 321);
            this.LblEnceinte.Name = "LblEnceinte";
            this.LblEnceinte.Size = new System.Drawing.Size(282, 35);
            this.LblEnceinte.TabIndex = 14;
            this.LblEnceinte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnOk
            // 
            this.BtnOk.BackColor = System.Drawing.SystemColors.HighlightText;
            this.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOk.Location = new System.Drawing.Point(113, 374);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(76, 39);
            this.BtnOk.TabIndex = 15;
            this.BtnOk.Text = "OK";
            this.BtnOk.UseVisualStyleBackColor = false;
            this.BtnOk.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FrmInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(282, 435);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblEnceinte);
            this.Controls.Add(this.LblFaim);
            this.Controls.Add(this.LblAge);
            this.Controls.Add(this.LblSexe);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.PicImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmInfos";
            this.Text = "Informations";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PicImage;
        public System.Windows.Forms.Label LblType;
        public System.Windows.Forms.Label LblSexe;
        public System.Windows.Forms.Label LblAge;
        public System.Windows.Forms.Label LblFaim;
        public System.Windows.Forms.Label LblEnceinte;
        private System.Windows.Forms.Button BtnOk;
    }
}