//#define MyDebug
using HangMan.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangMan
{
    public partial class Hangman : Form
    {
        //Foregrond----------------------
        CForeGround foreGround;
        //-------------------------------

        //Levels-------------------------
        bool FIRST_LEVEL = true;
        bool SECOND_LEVEL = false;
        //-------------------------------

        //Debug--------------------------
        int cursX, cursY;
        Font f = new Font("stencil", 13);
        //-------------------------------

        //Score system-------------------
        CDialogFrame menu;
        CScoreFrame scoreFrame;
        Random rand = new Random();
        String[] words = new String[] {"Jack","Hanry","Mark","Mike"};
        String word, lastword;
        bool winEnable = false;
        bool loseEnable = false;
        int loseFrames = 0;
        int winFrames = 0;
        int plusPoints, negPoints, MaxPoints;
        int Record = 0;
        bool resetPicture = false;
        bool startResetPicture = false;
        int startResetFrames = 0;
        //-------------------------------

        //Body elements------------------
        CStand stand;
        CImageVersionOut LeftLeg;
        CImageVersionOut RightLeg;
        CImageVersionOut LeftHand;
        CImageVersionOut RightHand;
        CImageVersionOut Head;
        //-------------------------------

        //Timer--------------------------
        int time = 60;
        int timeFrames = 0;
        //-------------------------------
        public void restartStats()
        {
            LeftLeg = null;
            RightLeg = null;
            LeftHand = null;
            Head = null;
            RightHand = null;

            int index = rand.Next(0, words.Length - 1);
            word = words[index];

            plusPoints = 0;
            negPoints = 0;
            MaxPoints = word.Length;
            //Record = 0;

            time = 60;
        }

        public Hangman()
        {
            InitializeComponent();
            restartStats();
            foreGround = new CForeGround { Left = 0, Top = 0 };
            scoreFrame = new CScoreFrame { Left = 420, Top = -55 };
            stand = new CStand { Left = 20, Top = 10 };
            menu = new CDialogFrame { Left=467,Top=150};
            this.Cursor = new Cursor(Resources.Cursor_Hat.GetHicon());
            WordBox.Cursor = this.Cursor;
        }

        //Heart//
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (SECOND_LEVEL)
            {
                if (timeFrames == 10)
                {
                    time--;
                    timeFrames = 0;
                    if (time == 0)
                    {
                        Record--;
                        time = 60;
                    }
                }
                else if (winEnable)
                {
                    winFrames++;
                    if (winFrames >= 15)
                    {
                        winFrames = 0;
                        winEnable = false;
                    }
                }
                else if (loseEnable)
                {
                    loseFrames++;
                    if (loseFrames >= 15)
                    {
                        loseFrames = 0;
                        loseEnable = false;
                    }
                }
                if (startResetPicture)
                {
                    if (startResetFrames >= 5)
                    {
                        startResetFrames = 0;
                        startResetPicture = false;                        
                        restartStats();
                    };
                    startResetFrames++;
                }
                timeFrames++;
            }
            this.Refresh();
        }

        private void Hangman_KeyDown(object sender, KeyEventArgs e)
        {
            if (FIRST_LEVEL)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
            else if (SECOND_LEVEL)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    FIRST_LEVEL = true;
                    SECOND_LEVEL = false;
                }
            }
        }

        //-----//

        //Graphics//
        private void Hangman_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            if (FIRST_LEVEL)
            {
                WordBox.Visible = false;
                foreGround.DrawImage(g);
            }

            if (SECOND_LEVEL)
            {
                if (resetPicture)
                    restartStats();
                WordBox.Visible = true;
                scoreFrame.DrawImage(g);
                stand.DrawImage(g);
                menu.DrawImage(g);
#if MyDebug
                g.DrawString($"X: {cursX}, Y: {cursY}", f, Brushes.Black, 0, 0);
#endif
                if (winEnable)
                    g.DrawString($"You win !\nTime: {time}    Record: {Record}\nThe word was: {lastword}", f, Brushes.Green, 500, 20);
                else if (loseEnable)
                    g.DrawString($"You lose !\nTime: {time}   Record: {Record}\nThe word was: {lastword}", f, Brushes.Red, 500, 20);
                else
                    g.DrawString($"Time: {time}\n\nRecord: {Record}", f, Brushes.Black, 500, 20);

                if (negPoints >= 1)
                {
                    if (negPoints >= 1)
                    {
                        Head = new CImageVersionOut(Resources.Head) { Left = 260, Top = 15 };
                        Head.DrawImage(g);
                        //First picture
                        if (MaxPoints == 1)
                        {
                            LeftLeg = new CImageVersionOut(Resources.Left_Leg_and_Torso) { Left = 210, Top = 185 };
                            LeftLeg.DrawImage(g);
                            LeftHand = new CImageVersionOut(Resources.Left_Hand) { Left = 185, Top = 228 };
                            LeftHand.DrawImage(g);
                            RightHand = new CImageVersionOut(Resources.Right_Hand) { Left = 315, Top = 228 };
                            RightHand.DrawImage(g);
                            RightLeg = new CImageVersionOut(Resources.Right_Leg) { Left = 320, Top = 305 };
                            RightLeg.DrawImage(g);
                        }
                    }
                    if (negPoints >= 2)
                    {
                        LeftLeg = new CImageVersionOut(Resources.Left_Leg_and_Torso) { Left = 210, Top = 185 };
                        LeftLeg.DrawImage(g);
                        //Second picture
                        if (MaxPoints == 2)
                        {
                            LeftHand = new CImageVersionOut(Resources.Left_Hand) { Left = 185, Top = 228 };
                            LeftHand.DrawImage(g);
                            RightHand = new CImageVersionOut(Resources.Right_Hand) { Left = 315, Top = 228 };
                            RightHand.DrawImage(g);
                        }
                    }
                    if (negPoints >= 3)
                    {
                        LeftHand = new CImageVersionOut(Resources.Left_Hand) { Left = 185, Top = 228 };
                        LeftHand.DrawImage(g);
                        //third picture
                        if (MaxPoints == 3)
                        {
                            RightHand = new CImageVersionOut(Resources.Right_Hand) { Left = 315, Top = 228 };
                            RightHand.DrawImage(g);
                            RightLeg = new CImageVersionOut(Resources.Right_Leg) { Left = 320, Top = 305 };
                            RightLeg.DrawImage(g);
                        }
                    }
                    if (negPoints >= 4)
                    {
                        RightHand = new CImageVersionOut(Resources.Right_Hand) { Left = 315, Top = 228 };
                        RightHand.DrawImage(g);
                        //fourth picture
                        if (MaxPoints == 4)
                        {
                            RightLeg = new CImageVersionOut(Resources.Right_Leg) { Left = 320, Top = 305 };
                            RightLeg.DrawImage(g);
                        }
                    }
                    if (negPoints >= 5)
                    {
                        RightLeg = new CImageVersionOut(Resources.Right_Leg) { Left = 320, Top = 305 };
                        RightLeg.DrawImage(g);
                        //third picture
                        if (MaxPoints == 5)
                        {
                            //others
                        }
                    }
                    if (negPoints >= 6)
                    {
                        //fourth picture
                        if (MaxPoints == 6)
                        {
                            //others
                        }
                    }
                }
            }
        }
        //-------//

        private void Hangman_MouseMove(object sender, MouseEventArgs e)
        {
            cursX = e.X;
            cursY = e.Y;
        }

        private void WordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (FIRST_LEVEL)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                    this.Close();
            }
            if (SECOND_LEVEL)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    restartStats();
                    FIRST_LEVEL = true;
                    SECOND_LEVEL = false;
                    axSecond.Ctlcontrols.stop();
                    axFirst.Ctlcontrols.play();
                }
                try
                {
                    if (e.KeyCode.Equals(Keys.Enter))
                    {
                        char[] array = WordBox.Text.ToCharArray();
                        if (word.Contains(array[0]))
                        {
                            plusPoints++;
                            if (plusPoints == MaxPoints)
                            {
                                lastword = word;
                                winEnable = true;
                                loseEnable = false;
                                Record++;
                                Thread.Sleep(100);
                                restartStats();
                            }
                        }
                        else
                        {
                            negPoints++;
                            if (negPoints == MaxPoints)
                            {
                                Record--;
                                lastword = word;
                                winEnable = false;
                                loseEnable = true;
                                Thread.Sleep(100);
                                startResetPicture = true;
                            }
                        }
                        WordBox.Text = "";
                    }
                }
                catch (Exception)
                {
                    restartStats();
                    FIRST_LEVEL = true;
                    FIRST_LEVEL = false;
                }
            }
        }

        private void Hangman_MouseClick(object sender, MouseEventArgs e)
        {
            axClickSound.Ctlcontrols.play();
            if (FIRST_LEVEL)
            {
                if (e.X > 316 && e.X < 507 && e.Y > 143 && e.Y < 180)  //Start
                {
                    FIRST_LEVEL = false;
                    SECOND_LEVEL = true;
                    axFirst.Ctlcontrols.stop();
                    axSecond.Ctlcontrols.play();
                }
                else if (e.X > 316 && e.X < 507 && e.Y > 180 && e.Y < 270)
                {
                    //Options
                }
                else if (e.X > 316 && e.X < 507 && e.Y > 270 && e.Y < 367)   //Exit
                {
                    this.Close();
                }
            }
            if (SECOND_LEVEL)
            {
                if (e.X > 522 & e.X < 597 && e.Y > 342 && e.Y < 389)  //Reset
                {
                    restartStats();
                    Record = 0;
                }
                else if (e.X > 715 && e.X < 790 && e.Y > 339 && e.Y < 388)  //Exit
                {
                    restartStats();
                    Record = 0;
                    FIRST_LEVEL = true;
                    SECOND_LEVEL = false;
                    axSecond.Ctlcontrols.stop();
                    axFirst.Ctlcontrols.play();
                }
            }
        }
    }
}
