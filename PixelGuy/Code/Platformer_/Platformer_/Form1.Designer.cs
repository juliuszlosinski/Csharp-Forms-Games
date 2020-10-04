namespace Platformer_
{
    partial class Game
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.axEatMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.axBackgroundMusic = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axEatMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // axEatMusic
            // 
            this.axEatMusic.Enabled = true;
            this.axEatMusic.Location = new System.Drawing.Point(629, 415);
            this.axEatMusic.Name = "axEatMusic";
            this.axEatMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEatMusic.OcxState")));
            this.axEatMusic.Size = new System.Drawing.Size(75, 23);
            this.axEatMusic.TabIndex = 0;
            this.axEatMusic.Visible = false;
            // 
            // axBackgroundMusic
            // 
            this.axBackgroundMusic.Enabled = true;
            this.axBackgroundMusic.Location = new System.Drawing.Point(548, 415);
            this.axBackgroundMusic.Name = "axBackgroundMusic";
            this.axBackgroundMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBackgroundMusic.OcxState")));
            this.axBackgroundMusic.Size = new System.Drawing.Size(75, 23);
            this.axBackgroundMusic.TabIndex = 1;
            this.axBackgroundMusic.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axBackgroundMusic);
            this.Controls.Add(this.axEatMusic);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            ((System.ComponentModel.ISupportInitialize)(this.axEatMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axBackgroundMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private AxWMPLib.AxWindowsMediaPlayer axEatMusic;
        private AxWMPLib.AxWindowsMediaPlayer axBackgroundMusic;
    }
}

