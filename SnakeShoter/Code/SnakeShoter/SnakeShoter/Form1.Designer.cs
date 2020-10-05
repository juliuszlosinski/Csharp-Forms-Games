namespace SnakeShoter
{
    partial class SnakeShoter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnakeShoter));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.axBackgroundMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.axShotMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.axDeathMusic = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShotMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDeathMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // axBackgroundMusic
            // 
            this.axBackgroundMusic.Enabled = true;
            this.axBackgroundMusic.Location = new System.Drawing.Point(12, 415);
            this.axBackgroundMusic.Name = "axBackgroundMusic";
            this.axBackgroundMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBackgroundMusic.OcxState")));
            this.axBackgroundMusic.Size = new System.Drawing.Size(75, 23);
            this.axBackgroundMusic.TabIndex = 0;
            this.axBackgroundMusic.Visible = false;
            // 
            // axShotMusic
            // 
            this.axShotMusic.Enabled = true;
            this.axShotMusic.Location = new System.Drawing.Point(109, 415);
            this.axShotMusic.Name = "axShotMusic";
            this.axShotMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axShotMusic.OcxState")));
            this.axShotMusic.Size = new System.Drawing.Size(75, 23);
            this.axShotMusic.TabIndex = 1;
            this.axShotMusic.Visible = false;
            // 
            // axDeathMusic
            // 
            this.axDeathMusic.Enabled = true;
            this.axDeathMusic.Location = new System.Drawing.Point(209, 415);
            this.axDeathMusic.Name = "axDeathMusic";
            this.axDeathMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDeathMusic.OcxState")));
            this.axDeathMusic.Size = new System.Drawing.Size(75, 23);
            this.axDeathMusic.TabIndex = 2;
            this.axDeathMusic.Visible = false;
            // 
            // SnakeShoter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axDeathMusic);
            this.Controls.Add(this.axShotMusic);
            this.Controls.Add(this.axBackgroundMusic);
            this.DoubleBuffered = true;
            this.Name = "SnakeShoter";
            this.Text = "SnakeShoter";
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axShotMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDeathMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private AxWMPLib.AxWindowsMediaPlayer axBackgroundMusic;
        private AxWMPLib.AxWindowsMediaPlayer axShotMusic;
        private AxWMPLib.AxWindowsMediaPlayer axDeathMusic;
    }
}

