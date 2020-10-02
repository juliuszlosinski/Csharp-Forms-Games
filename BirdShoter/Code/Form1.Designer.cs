namespace BirdShooter
{
    partial class BirdShooter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BirdShooter));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.axBackground = new AxWMPLib.AxWindowsMediaPlayer();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.axBird = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBird)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // axBackground
            // 
            this.axBackground.Enabled = true;
            this.axBackground.Location = new System.Drawing.Point(392, 342);
            this.axBackground.Name = "axBackground";
            this.axBackground.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBackground.OcxState")));
            this.axBackground.Size = new System.Drawing.Size(75, 23);
            this.axBackground.TabIndex = 0;
            this.axBackground.Visible = false;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 753);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // axBird
            // 
            this.axBird.Enabled = true;
            this.axBird.Location = new System.Drawing.Point(554, 365);
            this.axBird.Name = "axBird";
            this.axBird.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBird.OcxState")));
            this.axBird.Size = new System.Drawing.Size(75, 23);
            this.axBird.TabIndex = 2;
            this.axBird.Visible = false;
            // 
            // BirdShooter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BirdShooter.Properties.Resources.Background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1182, 753);
            this.Controls.Add(this.axBird);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axBackground);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "BirdShooter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BirdShooter";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.BirdShooter_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BirdShooter_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BirdShooter_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.axBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBird)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private AxWMPLib.AxWindowsMediaPlayer axBackground;
        private System.Windows.Forms.Splitter splitter1;
        private AxWMPLib.AxWindowsMediaPlayer axBird;
    }
}

