//#define MyDebug
using Platformer_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Platformer_
{
    public partial class Game : Form
    {
        //Debug:
        int cursX, cursY;

        //Background:
        Bitmap background;
        Bitmap coinPoints;

        //Score:
        int points;

        //Player:
        CPlayer player;
        int playerSpeed;
        int playerJumpSpeed;

        //Player's movement
        int jumpFrames = 0;
        bool jump = false;

        bool goTop = false;
        bool goDown = false;
        bool goLeft = false;
        bool goRight = false;

        //Enemies:
        CEnemy[] enemies;
        List<int> visitedEnemies;

        //Components:
        Graphics g;
        Directions userDirection;
        
        enum Directions
        {
            Left,Right,Top,Down,
        }

        public Game()
        {
            InitializeComponent();
            setProlog();
        }

        public void setProlog()
        {
            coinPoints = new Bitmap(Resources.coinsPoints);
            background = new Bitmap(Resources.Background);
            userDirection = new Directions();
            this.MaximumSize = new Size(700, 500);
            this.MinimumSize= new Size(700, 500);
            this.DoubleBuffered = true;
            points = 0;
            playerSpeed = 10;
            playerJumpSpeed = 45;
            player = new CPlayer { Left = 10, Top = 250 };
            player.Update(player.Left++, player.Top++);
            setEnemiesProlog();
            g = this.CreateGraphics();
            GameLoop.Interval = 50;
            GameLoop.Start();
        }

        public void setEnemiesProlog()
        {
            visitedEnemies = new List<int>();
            Random rand = new Random();
            enemies = new CEnemy[3];
            for(int x = 0; x < enemies.Length; x++)
            {
                enemies[x] = new CEnemy {Left=rand.Next(1,500),Top=rand.Next(100,250)};
                enemies[x].Update(enemies[x].Left, enemies[x].Top);
            }
        }

        public void setEnemiesDraw()
        {
            for(int x = 0; x < enemies.Length; x++)
            {
                if (visitedEnemies.Contains(x))
                {
                    continue;
                }
                else
                {
                    enemies[x].DrawImage(g);
#if MyDebug
                    enemies[x].DrawDebugRectangle(g);
#endif
                }
            }
        }

        public void getEnemiesColisions()
        {
            if (visitedEnemies.Count == enemies.Length)
            {
                setEnemiesProlog();
            }
            else
            {
                for (int x = 0; x < enemies.Length; x++)
                {
                    if (visitedEnemies.Contains(x))
                    {
                        continue;
                    }
                    else if (enemies[x].isTouched(player.getColision()))
                    {
                        points++;
                        visitedEnemies.Add(x);
                        axEatMusic.Ctlcontrols.play();
                    }
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            cursX = e.X;
            cursY = e.Y;
            base.OnMouseMove(e);
        }


        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData.Equals(Keys.W))
            {
                userDirection = Directions.Top;
                goTop = false;
            }
            else if (keyData.Equals(Keys.S))
            {
                userDirection = Directions.Down;
                goDown = false;
            }
            else if (keyData.Equals(Keys.A))
            {
                userDirection = Directions.Left;
                goLeft = false;
            }
            
            if (keyData.Equals(Keys.D))
            {
                userDirection = Directions.Right;
                goRight = false;
            }

            else if (keyData.Equals(Keys.Space))
            {
                if (!jump)
                {
                    player.Update(player.Left, player.Top -= playerJumpSpeed);
                    jump = true;
                }
            }
            return base.IsInputKey(keyData);
        }
       
        public void jumpDelay()
        {
            if (jump)
            {
                if (jumpFrames >= 25)
                {
                    jump = false;
                    jumpFrames = 0;
                    player.Update(player.Left, player.Top += playerJumpSpeed);
                }
                jumpFrames++;
            }
        }

        public void setUserInputKey()
        {
            jumpDelay();
            
            switch (userDirection)
            {
                case Directions.Top:
                    if (!goTop)
                    {
                        goTop = true;
                        //player.Update(player.Left, player.Top -= playerSpeed);
                    }
                    break;
                case Directions.Down:
                    if (!goDown)
                    {
                        goDown = true;
                        //player.Update(player.Left, player.Top += playerSpeed);
                    }
                    break;
                case Directions.Left:
                    if (!goLeft)
                    {
                        goLeft = true;
                        player.Update(player.Left -= playerSpeed, player.Top);
                    }
                    break;
                case Directions.Right:
                    if (!goRight)
                    {
                        goRight = true;
                        player.Update(player.Left += playerSpeed, player.Top);
                    }
                    break;
            }
        }

        public void setUserDraw()
        {
            g.DrawImage(background, 0, 0);
            player.DrawImage(g);
#if MyDebug
            player.DrawDebugRectangle(g);
            g.DrawString($"X: {cursX}, Y: {cursY}", new Font("stencil", 12), Brushes.Black, 400, 20);
#endif
            g.DrawString($"{points}", new Font("stencil", 20), Brushes.White, 40, 3);
            g.DrawImage(coinPoints, 0, 0);

            g.DrawString($"PixelGuy", new Font("stencil", 20), Brushes.White, 40, 400);
        }

        public void getEnviromenntColisions()
        {
            if (!jump)
            {

                if (player.Left >= 0 && player.Left < 120 && player.Top > 200 && player.Top < 300)
                {
                    player.Update(player.Left,player.Top = 210);
                }
                else if (player.Left >= 191 && player.Left < 321 && player.Top > 200 && player.Top < 300)
                {
                    player.Update(player.Left, player.Top = 230);
                }
                else if (player.Left >= 370 && player.Left < 520 && player.Top > 180 && player.Top < 250)
                {
                    player.Update(player.Left, player.Top = 190);
                }
                else if (player.Left >= 570 && player.Left < 679 && player.Top > 160 && player.Top < 343)
                {
                    player.Update(player.Left, player.Top = 280);
                }
                else
                {
                    player.Update(0, 240);
                    setEnemiesProlog();
                }
            }

        }

        //Heart//
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            setUserInputKey();
            setUserDraw();

            setEnemiesDraw();
            getEnemiesColisions();

            getEnviromenntColisions();
        }
        //------//
    }
}
