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
            this.zoo1 = new TP2.LeReste.Zoo();
            this.SuspendLayout();
            // 
            // zoo1
            // 
            this.zoo1.EntitesPresentes = null;
            this.zoo1.Location = new System.Drawing.Point(0, 0);
            this.zoo1.MaximumSize = new System.Drawing.Size(1025, 513);
            this.zoo1.MinimumSize = new System.Drawing.Size(1025, 513);
            this.zoo1.Name = "zoo1";
            this.zoo1.Size = new System.Drawing.Size(1025, 513);
            this.zoo1.TabIndex = 0;
            this.zoo1.Terrain = null;
            this.zoo1.Text = "zoo1";
            // 
            // FrmZoo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 513);
            this.Controls.Add(this.zoo1);
            this.Name = "FrmZoo";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private LeReste.Zoo zoo1;
    }
}

