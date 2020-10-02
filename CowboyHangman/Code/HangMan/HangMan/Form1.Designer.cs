namespace HangMan
{
    partial class Hangman
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hangman));
            this.GameLoop = new System.Windows.Forms.Timer(this.components);
            this.WordBox = new System.Windows.Forms.TextBox();
            this.axFirst = new AxWMPLib.AxWindowsMediaPlayer();
            this.axSecond = new AxWMPLib.AxWindowsMediaPlayer();
            this.axClickSound = new AxWMPLib.AxWindowsMediaPlayer();
            ((System.ComponentModel.ISupportInitialize)(this.axFirst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSecond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClickSound)).BeginInit();
            this.SuspendLayout();
            // 
            // GameLoop
            // 
            this.GameLoop.Enabled = true;
            this.GameLoop.Tick += new System.EventHandler(this.GameLoop_Tick);
            // 
            // WordBox
            // 
            this.WordBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.WordBox.Font = new System.Drawing.Font("Toledo", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WordBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.WordBox.Location = new System.Drawing.Point(611, 269);
            this.WordBox.MaxLength = 1;
            this.WordBox.Name = "WordBox";
            this.WordBox.Size = new System.Drawing.Size(123, 39);
            this.WordBox.TabIndex = 0;
            this.WordBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WordBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WordBox_KeyDown);
            // 
            // axFirst
            // 
            this.axFirst.Enabled = true;
            this.axFirst.Location = new System.Drawing.Point(684, 424);
            this.axFirst.Name = "axFirst";
            this.axFirst.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFirst.OcxState")));
            this.axFirst.Size = new System.Drawing.Size(75, 23);
            this.axFirst.TabIndex = 1;
            this.axFirst.Visible = false;
            // 
            // axSecond
            // 
            this.axSecond.Enabled = true;
            this.axSecond.Location = new System.Drawing.Point(541, 424);
            this.axSecond.Name = "axSecond";
            this.axSecond.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axSecond.OcxState")));
            this.axSecond.Size = new System.Drawing.Size(75, 23);
            this.axSecond.TabIndex = 2;
            this.axSecond.Visible = false;
            // 
            // axClickSound
            // 
            this.axClickSound.Enabled = true;
            this.axClickSound.Location = new System.Drawing.Point(611, 424);
            this.axClickSound.Name = "axClickSound";
            this.axClickSound.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axClickSound.OcxState")));
            this.axClickSound.Size = new System.Drawing.Size(75, 23);
            this.axClickSound.TabIndex = 3;
            this.axClickSound.Visible = false;
            // 
            // Hangman
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.axClickSound);
            this.Controls.Add(this.axSecond);
            this.Controls.Add(this.axFirst);
            this.Controls.Add(this.WordBox);
            this.DoubleBuffered = true;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Hangman";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hangman";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Hangman_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hangman_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Hangman_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Hangman_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.axFirst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axSecond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axClickSound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameLoop;
        private System.Windows.Forms.TextBox WordBox;
        private AxWMPLib.AxWindowsMediaPlayer axFirst;
        private AxWMPLib.AxWindowsMediaPlayer axSecond;
        private AxWMPLib.AxWindowsMediaPlayer axClickSound;
    }
}

