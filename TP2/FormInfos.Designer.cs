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
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).BeginInit();
            this.SuspendLayout();
            // 
            // PicImage
            // 
            this.PicImage.Location = new System.Drawing.Point(144, 12);
            this.PicImage.Name = "PicImage";
            this.PicImage.Size = new System.Drawing.Size(115, 118);
            this.PicImage.TabIndex = 0;
            this.PicImage.TabStop = false;
            // 
            // LblType
            // 
            this.LblType.BackColor = System.Drawing.Color.Transparent;
            this.LblType.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblType.Location = new System.Drawing.Point(67, 156);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(267, 35);
            this.LblType.TabIndex = 10;
            this.LblType.Text = "Sélection";
            this.LblType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblGenre
            // 
            this.LblGenre.BackColor = System.Drawing.Color.Transparent;
            this.LblGenre.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblGenre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblGenre.Location = new System.Drawing.Point(66, 218);
            this.LblGenre.Name = "LblGenre";
            this.LblGenre.Size = new System.Drawing.Size(267, 35);
            this.LblGenre.TabIndex = 11;
            this.LblGenre.Text = "Sélection";
            this.LblGenre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblAge
            // 
            this.LblAge.BackColor = System.Drawing.Color.Transparent;
            this.LblAge.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAge.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblAge.Location = new System.Drawing.Point(66, 283);
            this.LblAge.Name = "LblAge";
            this.LblAge.Size = new System.Drawing.Size(267, 35);
            this.LblAge.TabIndex = 12;
            this.LblAge.Text = "Sélection";
            this.LblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormInfos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(398, 469);
            this.Controls.Add(this.LblAge);
            this.Controls.Add(this.LblGenre);
            this.Controls.Add(this.LblType);
            this.Controls.Add(this.PicImage);
            this.Name = "FormInfos";
            this.Text = "Informations";
            ((System.ComponentModel.ISupportInitialize)(this.PicImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PicImage;
        private System.Windows.Forms.Label LblType;
        private System.Windows.Forms.Label LblGenre;
        private System.Windows.Forms.Label LblAge;
    }
}