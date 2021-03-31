namespace Widok
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nextKloc = new System.Windows.Forms.PictureBox();
            this.klocLabel = new System.Windows.Forms.Label();
            this.labelMan = new System.Windows.Forms.Label();
            this.manual = new System.Windows.Forms.Label();
            this.punktyLabel = new System.Windows.Forms.Label();
            this.labelPunkty = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nextKloc)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nextKloc
            // 
            this.nextKloc.Location = new System.Drawing.Point(360, 210);
            this.nextKloc.Name = "nextKloc";
            this.nextKloc.Size = new System.Drawing.Size(10, 10);
            this.nextKloc.TabIndex = 0;
            this.nextKloc.TabStop = false;
            // 
            // klocLabel
            // 
            this.klocLabel.AutoSize = true;
            this.klocLabel.Location = new System.Drawing.Point(390, 207);
            this.klocLabel.Name = "klocLabel";
            this.klocLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.klocLabel.Size = new System.Drawing.Size(0, 13);
            this.klocLabel.TabIndex = 1;
            // 
            // labelMan
            // 
            this.labelMan.AutoSize = true;
            this.labelMan.Location = new System.Drawing.Point(390, 30);
            this.labelMan.Name = "labelMan";
            this.labelMan.Size = new System.Drawing.Size(0, 13);
            this.labelMan.TabIndex = 2;
            // 
            // manual
            // 
            this.manual.AutoSize = true;
            this.manual.Location = new System.Drawing.Point(390, 60);
            this.manual.Name = "manual";
            this.manual.Size = new System.Drawing.Size(0, 13);
            this.manual.TabIndex = 3;
            // 
            // punktyLabel
            // 
            this.punktyLabel.AutoSize = true;
            this.punktyLabel.Location = new System.Drawing.Point(390, 173);
            this.punktyLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.punktyLabel.Name = "punktyLabel";
            this.punktyLabel.Size = new System.Drawing.Size(0, 13);
            this.punktyLabel.TabIndex = 4;
            // 
            // labelPunkty
            // 
            this.labelPunkty.AutoSize = true;
            this.labelPunkty.Location = new System.Drawing.Point(396, 157);
            this.labelPunkty.Name = "labelPunkty";
            this.labelPunkty.Size = new System.Drawing.Size(0, 13);
            this.labelPunkty.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 526);
            this.Controls.Add(this.labelPunkty);
            this.Controls.Add(this.punktyLabel);
            this.Controls.Add(this.manual);
            this.Controls.Add(this.labelMan);
            this.Controls.Add(this.klocLabel);
            this.Controls.Add(this.nextKloc);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.nextKloc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox nextKloc;
        private System.Windows.Forms.Label klocLabel;
        private System.Windows.Forms.Label labelMan;
        private System.Windows.Forms.Label manual;
        private System.Windows.Forms.Label punktyLabel;
        private System.Windows.Forms.Label labelPunkty;
    }
}

