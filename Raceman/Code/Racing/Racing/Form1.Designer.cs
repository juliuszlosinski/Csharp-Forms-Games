namespace Racing
{
    partial class RacingGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RacingGame));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.axBackground = new AxWMPLib.AxWindowsMediaPlayer();
            this.axForeGround = new AxWMPLib.AxWindowsMediaPlayer();
            this.axClick = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axForeGround)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClick)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Interval = 1;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // axBackground
            // 
            this.axBackground.Enabled = true;
            this.axBackground.Location = new System.Drawing.Point(269, 536);
            this.axBackground.Name = "axBackground";
            this.axBackground.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axBackground.OcxState")));
            this.axBackground.Size = new System.Drawing.Size(75, 23);
            this.axBackground.TabIndex = 0;
            this.axBackground.Visible = false;
            // 
            // axForeGround
            // 
            this.axForeGround.Enabled = true;
            this.axForeGround.Location = new System.Drawing.Point(161, 536);
            this.axForeGround.Name = "axForeGround";
            this.axForeGround.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axForeGround.OcxState")));
            this.axForeGround.Size = new System.Drawing.Size(75, 23);
            this.axForeGround.TabIndex = 1;
            this.axForeGround.Visible = false;
            // 
            // axClick
            // 
            this.axClick.Enabled = true;
            this.axClick.Location = new System.Drawing.Point(535, 536);
            this.axClick.Name = "axClick";
            this.axClick.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axClick.OcxState")));
            this.axClick.Size = new System.Drawing.Size(75, 23);
            this.axClick.TabIndex = 2;
            this.axClick.Visible = false;
            // 
            // RacingGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 584);
            this.Controls.Add(this.axClick);
            this.Controls.Add(this.axForeGround);
            this.Controls.Add(this.axBackground);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(956, 623);
            this.MinimumSize = new System.Drawing.Size(956, 623);
            this.Name = "RacingGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RacingGame";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.RacingGame_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RacingGame_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RacingGame_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.RacingGame_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.axBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axForeGround)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private AxWMPLib.AxWindowsMediaPlayer axBackground;
        private AxWMPLib.AxWindowsMediaPlayer axForeGround;
        private AxWMPLib.AxWindowsMediaPlayer axClick;
    }
}

