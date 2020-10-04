namespace _Snake_
{
    partial class SnakeGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SnakeGame));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.axMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.axEatMusic = new AxWMPLib.AxWindowsMediaPlayer();
            this.axDeathMusic = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axEatMusic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDeathMusic)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // axMusic
            // 
            this.axMusic.Enabled = true;
            this.axMusic.Location = new System.Drawing.Point(759, 431);
            this.axMusic.Name = "axMusic";
            this.axMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMusic.OcxState")));
            this.axMusic.Size = new System.Drawing.Size(29, 17);
            this.axMusic.TabIndex = 0;
            this.axMusic.Visible = false;
            // 
            // axEatMusic
            // 
            this.axEatMusic.Enabled = true;
            this.axEatMusic.Location = new System.Drawing.Point(641, 431);
            this.axEatMusic.Name = "axEatMusic";
            this.axEatMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axEatMusic.OcxState")));
            this.axEatMusic.Size = new System.Drawing.Size(29, 17);
            this.axEatMusic.TabIndex = 1;
            this.axEatMusic.Visible = false;
            // 
            // axDeathMusic
            // 
            this.axDeathMusic.Enabled = true;
            this.axDeathMusic.Location = new System.Drawing.Point(709, 431);
            this.axDeathMusic.Name = "axDeathMusic";
            this.axDeathMusic.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axDeathMusic.OcxState")));
            this.axDeathMusic.Size = new System.Drawing.Size(29, 17);
            this.axDeathMusic.TabIndex = 2;
            this.axDeathMusic.Visible = false;
            // 
            // SnakeGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axDeathMusic);
            this.Controls.Add(this.axEatMusic);
            this.Controls.Add(this.axMusic);
            this.DoubleBuffered = true;
            this.Name = "SnakeGame";
            this.Text = "SnakeGame";
            ((System.ComponentModel.ISupportInitialize)(this.axMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axEatMusic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axDeathMusic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private AxWMPLib.AxWindowsMediaPlayer axMusic;
        private AxWMPLib.AxWindowsMediaPlayer axEatMusic;
        private AxWMPLib.AxWindowsMediaPlayer axDeathMusic;
    }
}

