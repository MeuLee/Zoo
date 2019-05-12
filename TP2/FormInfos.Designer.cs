namespace TP2
{
    partial class FormInfos
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
            this.LblGenre = new System.Windows.Forms.Label();
            this.LblAge = new System.Windows.Forms.Label();
            this.LblFaim = new System.Windows.Forms.Label();
            this.LblEnceinte = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(81, 22);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(41, 42);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // LblType
            // 
            this.LblType.BackColor = System.Drawing.Color.Transparent;
            this.LblType.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblType.Location = new System.Drawing.Point(44, 89);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(118, 35);
            this.LblType.TabIndex = 10;
            this.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblGenre
            // 
            this.LblGenre.BackColor = System.Drawing.Color.Transparent;
            this.LblGenre.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGenre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblGenre.Location = new System.Drawing.Point(44, 149);
            this.LblGenre.Name = "LblGenre";
            this.LblGenre.Size = new System.Drawing.Size(118, 35);
            this.LblGenre.TabIndex = 11;
            this.LblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAge
            // 
            this.LblAge.BackColor = System.Drawing.Color.Transparent;
            this.LblAge.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAge.Location = new System.Drawing.Point(44, 208);
            this.LblAge.Name = "LblAge";
            this.LblAge.Size = new System.Drawing.Size(118, 35);
            this.LblAge.TabIndex = 12;
            this.LblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblFaim
            // 
            this.LblFaim.BackColor = System.Drawing.Color.Transparent;
            this.LblFaim.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFaim.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblFaim.Location = new System.Drawing.Point(44, 265);
            this.LblFaim.Name = "LblFaim";
            this.LblFaim.Size = new System.Drawing.Size(118, 35);
            this.LblFaim.TabIndex = 13;
            this.LblFaim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblEnceinte
            // 
            this.LblEnceinte.BackColor = System.Drawing.Color.Transparent;
            this.LblEnceinte.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEnceinte.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblEnceinte.Location = new System.Drawing.Point(44, 321);
            this.LblEnceinte.Name = "LblEnceinte";
            this.LblEnceinte.Size = new System.Drawing.Size(118, 35);
            this.LblEnceinte.TabIndex = 14;
            this.LblEnceinte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(64, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(203, 435);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LblEnceinte);
            this.Controls.Add(this.LblFaim);
            this.Controls.Add(this.LblAge);
            this.Controls.Add(this.LblGenre);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.PicImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInfos";
            this.Text = "Informations";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox PicImage;
        public System.Windows.Forms.Label LblType;
        public System.Windows.Forms.Label LblGenre;
        public System.Windows.Forms.Label LblAge;
        public System.Windows.Forms.Label LblFaim;
        public System.Windows.Forms.Label LblEnceinte;
        private System.Windows.Forms.Button button1;
    }
}