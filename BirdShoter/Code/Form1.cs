//#define MyDebug
using BirdShooter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirdShooter
{
    public partial class BirdShooter : Form
    {
        //SECENS:
        bool FIRST_SCENE_ENABLE = true;
        bool SECOND_SCENE_ENABLE = false;
        CForeground firstForeground;


        //PATHS-------------------
        String BACKGROUND_PATH = "C:/Users/PanCh/source/repos/BirdShooter/Resources/backgroundMusic.wav";
        String BIRD_PATH = "C:/Users/PanCh/source/repos/BirdShooter/Resources/birdSound.wav";
        //------------------------
        
        //Generic-----------------
          Random rand = new Random();
        int cursX, cursY;
        Font font = new Font("stencil", 12);
        //-------------------------

        //Bird-----
        CBird bird;
        int birdFrames = 0;
        int[] XcorBird = new int[]
        {
            40,350,510,280,40
        };
        int[] YcorBird = new int[]
        {
           240,280,250,120,240
        };
        bool birdEnable = false;
        int LEVEL = 7;
        //----------------------

        //Health----------------
        int fillHealth = 300;
        int health = 300;
        bool healthVisible = false;
        //----------------------

        //Score-----------------
        CScoreFrame scoreFrame;
        int shots = 0, misses = 0, hits = 0;
        double avg = 0;
        int TIMER_FRAMES = 0;
        int TIMER = 60;
        //-----------------------


        CMenu menu;

        public BirdShooter()
        {
            InitializeComponent();
            bird = new CBird { Left = 250, Top = 100 };
            menu = new CMenu { Left =630, Top = 250 };
            scoreFrame = new CScoreFrame { Left = 550, Top = -10 };
            firstForeground = new CForeground { };
            axBackground.Ctlcontrols.play();
            axBird.URL = BIRD_PATH;
            this.Cursor = new Cursor(Resources.Cursor.GetHicon());
        }

        void birdUpdate()
        {
            int indexRANDOM = rand.Next(0, XcorBird.Length);
            bird.Update(XcorBird[indexRANDOM], YcorBird[indexRANDOM]);
        }

        //HEART//
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (TIMER == 0)
            {
                TIMER = 60;
                LEVEL++;
            }
            if (SECOND_SCENE_ENABLE)
            {
                if (birdEnable)
                {
                    if (birdFrames >= LEVEL)
                    {
                        birdFrames = 0;
                        birdUpdate();
                    }
                    birdFrames++;
                }
            }
            if (TIMER_FRAMES >= 10)
            {
                TIMER_FRAMES = 0;
                TIMER--;
            }
            TIMER_FRAMES++;
            this.Refresh();
        }
        //--------//

        //Graphics//
        private void BirdShooter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (FIRST_SCENE_ENABLE)
            {
                firstForeground.Left = -20;
                firstForeground.Top = 0;
                firstForeground.DrawImage(g);
#if MyDebug
                g.DrawString($"X: {cursX}, Y: {cursY}", font, Brushes.Black, 0, 0);
#endif
            }
            if (SECOND_SCENE_ENABLE)
            {
                scoreFrame.DrawImage(g);
                menu.DrawImage(g);

                g.DrawString($"Shots: {shots}     Time: {TIMER}\n\nHits: {hits}\n\nMisses: {misses}\n\nAVG: {avg}%", font, Brushes.Black, 635, 50);
#if MyDebug
                g.DrawString($"X: {cursX}, Y: {cursY}", font, Brushes.Black, 0, 0);
                g.DrawString($"X: {bird.vitals.X}, Y: {bird.vitals.Y}", font, Brushes.Black, 0, 20);
#endif
                if (birdEnable)
                {
                    bird.DrawImage(g);
                }
                if (healthVisible)
                {
                    g.DrawRectangle(new Pen(Brushes.Black), 180, 10, 300, 30);
                    g.FillRectangle(Brushes.Crimson, 180, 10, health, 30);
                    if (health == 0)
                    {
                        health = 300;
                        misses -= 5;
                    }
                }
            }
        }
        //--------//

        private void BirdShooter_MouseMove(object sender, MouseEventArgs e)
        {
            if (FIRST_SCENE_ENABLE)
            {
                cursX = e.X;
                cursY = e.Y;
            }
            if (SECOND_SCENE_ENABLE)
            {
                cursX = e.X;
                cursY = e.Y;
            }
        }

        private void BirdShooter_MouseClick(object sender, MouseEventArgs e) { 
            if (FIRST_SCENE_ENABLE)
            {
                if (e.X > 370 && e.X < 615 && e.Y > 246 && e.Y < 287)
                {
                    FIRST_SCENE_ENABLE = false;
                    SECOND_SCENE_ENABLE = true;
                    restart();
                }
                else if (e.X > 370 && e.X < 615 && e.Y > 287 && e.Y < 405)
                {

                }
                else if (e.X > 370 && e.X < 615 && e.Y > 405 && e.Y < 515)
                {
                    this.Close();
                }
            }
            if (SECOND_SCENE_ENABLE)
            {
                if (birdEnable)
                {
                    if (bird.Hit(e.X, e.Y))
                    {
                        hits++;
                        health -= 50;
                        axBird.Ctlcontrols.play();
                    }
                    else
                    {
                        misses++;
                        shots = misses + hits;
                        avg = (double)hits / (double)shots * 100;
                    }
                }
                if (e.X > 725 && e.X < 870 && e.Y > 290 && e.Y < 345) //50     --------START
                {
                    restart();
                    healthVisible = true;
                    GameLoop.Start();
                    birdEnable = true;
                    birdFrames *= 0;
                    health = fillHealth;
                }
                if (e.X > 725 && e.X < 870 && e.Y > 350 && e.Y < 408)    //          -------STOP
                {
                    GameLoop.Stop();
                }
                if (e.X > 725 && e.X < 870 && e.Y > 410 && e.Y < 490)   //       -------RESET
                {
                    birdFrames *= 0;
                    GameLoop.Stop();
                    restart();
                    birdEnable = true;
                    health = fillHealth;
                    this.Refresh();
                }
                if (e.X > 725 && e.X < 870 && e.Y > 490 && e.Y < 544) //         -------EXIT
                {
                    SECOND_SCENE_ENABLE = false;
                    FIRST_SCENE_ENABLE = true;
                    healthVisible = false;
                    birdEnable = false;

                    health = fillHealth;
                    birdFrames *= 0;
                    restart();
                }                   
            }
        }
        public void restart()
        {
            misses = 0;
            shots = 0;
            avg = 0;
            hits = 0;
        }
    }
}
