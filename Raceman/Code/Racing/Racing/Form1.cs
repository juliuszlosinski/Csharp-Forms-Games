//#define MyDebug

using Racing.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Racing
{
    public partial class RacingGame : Form
    {
        //SCENES----------
        bool FIRST_SCENE = true;
        bool SECOND_SCENE = false;


        //Debug-----------
        Random rand = new Random();
        int cursX, cursY;
        Font myFont = new Font("stencil", 12);
        Brush myBrush = Brushes.White;
        int MAX_WIDTH = 847;
        int LOWEST_WIDTH = 0;
        //--------------

        //Objects--------
        CForeground foreground;
        CBackground background;
        CSteps[] steps;
        CScoreFrame scoreFrame;
        CMenu menu;
        //Cars:----------
        CCar enemy, enemySecond;
        int enemyFrames = 0;
        int secondEnemyFrames = 0;
        int FIRST_POSITION_ENEMY_X = 847;
        int FIRST_POSITION_ENEMY_Y = 425;
        //--------------

        //Player:-------
        CPlayer player;
        int FIRST_POSITION_PLAYER_X=5;
        int FIRST_POSITION_PLAYER_Y=510;
        //--------------

        //Score system:-----
        int record = 0;
        int time = 60;
        int timeFrames = 100;
        bool Start = false;
        int Level = 0;
        //-------------------
        
        public RacingGame()
        {
            InitializeComponent();
            this.Cursor = new Cursor(Resources.HandCursor.GetHicon());
            axBackground.Ctlcontrols.stop();
            axForeGround.Ctlcontrols.play();
            record = 1;
            steps = new CSteps[15];
            for(int x = 0,y=0; x < steps.Length; x++,y+=150)
                steps[x] = new CSteps { Left = y, Top = 501 };
            menu = new CMenu { Left = 680, Top = -10 };
            foreground = new CForeground { Left = 0, Top = 0 };
            scoreFrame = new CScoreFrame { Left=261,Top=106};
            background = new CBackground { Left = -5, Top = -300 };
            enemy = new CCar { Left = FIRST_POSITION_ENEMY_X, Top =FIRST_POSITION_ENEMY_Y };
            player = new CPlayer { Left =FIRST_POSITION_PLAYER_X, Top =FIRST_POSITION_PLAYER_Y };
            enemySecond = new CCar { Left = FIRST_POSITION_ENEMY_X, Top = 517 };
        }
        
        public void restartAll()   //+
        {
            time = 60;
            enemyFrames = 0;
            enemy.Update(FIRST_POSITION_ENEMY_X, FIRST_POSITION_ENEMY_Y);
            player.Update(FIRST_POSITION_PLAYER_X, FIRST_POSITION_PLAYER_Y);
        }

        public void updateEnemy(CCar car)   //+
        {
            if (car.Equals(enemySecond))
            {
                int[] numbers = new int[] { 517, 517, 517, 427, 517, 517, 517, 517, 517, 427 };
                    int index = rand.Next(0, numbers.Length);
                    int number = numbers[index];
                    enemySecond.Update(enemySecond.Left -= 20, number);
            }
            else if (car.Equals(enemy))
            {
                int[] numbers = new int[] { 427, 517, 427, 517, 427, 427, 427, 427, 427, 427, 517 };
                int index = rand.Next(0, numbers.Length);
                int number = numbers[index];
                enemy.Update(enemy.Left -= 70, number);
            }
        }

        //Heart//
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            if (SECOND_SCENE)
            {
                if (record == 5)
                {
                    //change background
                    restartAll();
                }
                if (player.isHit(enemy.getTouchSpot()) || player.Top <= 380 || player.Top >=550)
                {
                    record--;
                    restartAll();
                }
                if (timeFrames < 0)
                {
                    time--;
                    timeFrames = 100;
                    if (time == 0)
                    {
                        record++;
                    }
                }
                if (enemy.Left <= 0)
                {
                    enemy.Update(FIRST_POSITION_ENEMY_X, FIRST_POSITION_ENEMY_Y);
                }
                if (enemySecond.Left <= 0)
                {
                    enemySecond.Update(FIRST_POSITION_ENEMY_X, FIRST_POSITION_ENEMY_Y);
                }
                if (enemyFrames >= 45)
                {
                    updateEnemy(enemy);
                    updateEnemy(enemySecond);
                    enemyFrames = 0;
                }
                timeFrames--;
                enemyFrames++;
            }
            this.Refresh();
        }
        //-----------------

        //Graphics//
        private void RacingGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (FIRST_SCENE)
            {
                foreground.DrawImage(g);
#if MyDebug
                g.DrawString($"X: {cursX}, Y: {cursY}", myFont, myBrush, 0, 0);
#endif
            }
            if (SECOND_SCENE)
            {
                background.DrawImage(g);
                scoreFrame.DrawImage(g);

                for (int x = 0; x < steps.Length; x++)
                {
                    steps[x].Left += 5;
                }
                for (int x = 0; x < steps.Length; x++)
                {
                    if (steps[x].Left >= 847)
                        steps[x].Left = 0;
                }
                for (int x = 0; x < steps.Length; x++)
                    steps[x].DrawImage(g);

                enemy.DrawImage(g);
                player.DrawImage(g);
                enemySecond.DrawImage(g);
#if MyDebug
                enemySecond.DrawDebugRectangle(g);
                enemy.DrawDebugRectangle(g);
#endif
                player.DrawDebugRectangle(g);

                menu.DrawImage(g);

                
                if(record>1)
                    g.DrawString($"Level: {Level}\n\nScore: {record}\n\nTime: {time}", new Font("stencil", 13), Brushes.Green, 310, 150);
                else if(record<0)
                    g.DrawString($"Level: {Level}\n\nScore: {record}\n\nTime: {time}", new Font("stencil", 13), Brushes.Red, 310, 150);
                else
                    g.DrawString($"Level: {Level}\n\nScore: {record}\n\nTime: {time}", new Font("stencil", 13), Brushes.Black, 310, 150);
#if MyDebug
                g.DrawString($"X: {cursX}, Y: {cursY}", myFont, myBrush, 0, 0);
                g.DrawString($"TOUCH X: {enemy.touchSpot.X}, Y: {enemy.touchSpot.Y}", myFont, myBrush, 0, 20);
#endif    
            }

            
        }

        //-----------------

        private void RacingGame_KeyDown(object sender, KeyEventArgs e)
        {
            if (FIRST_SCENE)
            {
                if (e.KeyCode.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
            if (SECOND_SCENE)
            {
                if (e.KeyCode.Equals(Keys.W))
                {
                    player.Update(player.Left, player.Top -= 10);
                }
                else if (e.KeyCode.Equals(Keys.S))
                {
                    player.Update(player.Left, player.Top += 10);
                }
                else if (e.KeyCode.Equals(Keys.A))
                {
                    player.Update(player.Left -= 10, player.Top);
                }
                else if (e.KeyCode.Equals(Keys.D))
                {
                    player.Update(player.Left += 10, player.Top);
                }
                else if (e.KeyCode.Equals(Keys.Escape))
                {
                    FIRST_SCENE = true;
                    SECOND_SCENE = false;
                    
                    axForeGround.Ctlcontrols.play();
                }
            }
        }

        private void RacingGame_MouseMove(object sender, MouseEventArgs e)
        {
                cursX = e.X;
                cursY = e.Y;
        }

        private void RacingGame_MouseClick(object sender, MouseEventArgs e)
        {
            axClick.Ctlcontrols.play();
            if (FIRST_SCENE)
            {
                if (e.X > 360 && e.X < 612 && e.Y > 265 && e.Y < 305)
                {
                    axForeGround.Ctlcontrols.stop();
                    axBackground.Ctlcontrols.play();
                    FIRST_SCENE = false;
                    SECOND_SCENE = true;
                    
                }
                else if (e.X > 360 && e.X < 612 && e.Y > 305 && e.Y < 402)
                {
                    //Options
                }
                else if (e.X > 360 && e.X < 612 && e.Y > 402 && e.Y < 500)
                {
                    this.Close();
                }
            }
            if (SECOND_SCENE)
            {
                if (e.X > 733 && e.X < 896 && e.Y > 77 && e.Y < 113)
                {
                    restartAll();
                }
                else if (e.X > 733 & e.X < 896 && e.Y > 113 & e.Y < 196)
                {
                    axBackground.Ctlcontrols.stop();
                    axForeGround.Ctlcontrols.play();
                    FIRST_SCENE = true;
                    SECOND_SCENE = false;
                }
            }
        }

    }
}
