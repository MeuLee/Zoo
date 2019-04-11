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
            TP2.LeReste.Enclos enclos1 = new TP2.LeReste.Enclos();
            TP2.LeReste.Enclos enclos2 = new TP2.LeReste.Enclos();
            TP2.LeReste.Enclos enclos3 = new TP2.LeReste.Enclos();
            TP2.LeReste.Enclos enclos4 = new TP2.LeReste.Enclos();
            this.zoo1 = new TP2.LeReste.Zoo();
            this.SuspendLayout();
            // 
            // zoo1
            // 
            Zoo.ListeEntites = null;
            enclos1.AnimauxPresents = null;
            enclos1.Espece = TP2.Entités.Animal.TypeAnimal.Mouton;
            enclos2.AnimauxPresents = null;
            enclos2.Espece = TP2.Entités.Animal.TypeAnimal.Mouton;
            enclos3.AnimauxPresents = null;
            enclos3.Espece = TP2.Entités.Animal.TypeAnimal.Mouton;
            enclos4.AnimauxPresents = null;
            enclos4.Espece = TP2.Entités.Animal.TypeAnimal.Mouton;
            Zoo.ListeEnclos = new TP2.LeReste.Enclos[] {
        enclos1,
        enclos2,
        enclos3,
        enclos4};
            this.zoo1.Location = new System.Drawing.Point(0, 0);
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
            this.ClientSize = new System.Drawing.Size(1024, 928);
            this.Controls.Add(this.zoo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmZoo";
            this.Text = "le zoo";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmZoo_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private LeReste.Zoo zoo1;
    }
}
