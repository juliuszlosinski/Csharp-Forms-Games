//#define MyDebug
using DogFly.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DogFly
{
    public partial class DogFly : Form
    {
        //Components:
        Graphics g;
        Color backGround;
        Bitmap background;
        int cursX, cursY;
        enum Directions
        {
            Left, Right,Jump
        }

        Directions userDirection;

        //Player:
        CPlayer player;
        int playerSpeed;
        int jumpSpeed;
        int jumpFrames;

        bool left, right, jump;

        //Foods:
        CFood[] foods;
        List<int> visitedFoods;

        //Score:
        int points;

        public DogFly()
        {
            InitializeComponent();
            setProlog();
        }

        void setProlog()
        {
            this.MaximumSize = new Size(700, 500);
            this.MinimumSize = new Size(700, 500);
            this.DoubleBuffered = true;

            userDirection = new Directions();

            g = this.CreateGraphics();
            backGround = Color.Bisque;
            background = new Bitmap(Resources.Background);
            cursX = 0;
            cursY = 0;

            player = new CPlayer { Left =20, Top = 252 };
            player.Update(player.Left, player.Top);
            playerSpeed = 10;
            jumpSpeed = 55;
            jumpFrames = 0;

            left = false;
            right = false;
            jump = false;

            setFoods();

            points = 0;

            GameLoop.Interval = 50;
            GameLoop.Start();
        }

        void setFoods()
        {
            Random rand = new Random();
            foods = new CFood[5];
            for(int x = 0; x < foods.Length; x++)
            {
                foods[x] = new CFood { Left =rand.Next(0,683), Top =rand.Next(200,320)};
                foods[x].Update(foods[x].Left, foods[x].Top);
            }
            visitedFoods = new List<int>();
        }

        void setUserInputKey()
        {
            switch (userDirection)
            {
                case Directions.Left:
                    if (!left)
                    {
                        player.Update(player.Left -= playerSpeed, player.Top);
                        left = true;
                    }
                    break;
                case Directions.Right:
                    if (!right)
                    {
                        player.Update(player.Left += playerSpeed, player.Top);
                        right = true;
                    }
                    break;
                case Directions.Jump:
                    if (!jump)
                    {
                        player.Update(player.Left, player.Top -= jumpSpeed);
                        jump = true;
                    }
                    break;
                 
            }
        }

        void setUserDraw()
        {
            g.Clear(Color.Transparent); 
            g.DrawImage(background, 0, 0);

            player.DrawImage(g);
#if MyDebug
            player.DrawDebugRectangle(g);
#endif

            //g.DrawString($"X: {cursX}, Y: {cursY}", new Font("stencil", 12), Brushes.Black, 0, 0);
            g.DrawString($"Points: {points}", new Font("stencil", 25), Brushes.Black, 0, 0);
            g.DrawString($"DogFly", new Font("stencil", 30), Brushes.Green, 520, 0);
        }

        void setFoodsDraw()
        {
            for(int x = 0; x < foods.Length; x++)
            {
                if (visitedFoods.Contains(x))
                {
                    continue;
                }
                else
                {
                    foods[x].DrawImage(g);
#if MyDebug
                    foods[x].DrawDebugRectangle(g);
#endif
                }
            }
        }

        void getColisions()
        {
            setBariers();
            if (visitedFoods.Count == foods.Length)
            {
                setFoods();
            }
            else
            {
                for(int x = 0; x < foods.Length; x++)
                {
                    if (visitedFoods.Contains(x))
                    {
                        continue;
                    }
                    else
                    {
                        if(player.isTouched(foods[x].getColision()))
                        {
                            points++;
                            visitedFoods.Add(x);
                            axCoinMusic.Ctlcontrols.play();
                        }
                    }
                }
            }
        }

        void setBariers()
        {
            if (!jump)
            {
                if (player.Left > 0 && player.Left < 90 && player.Top > 0 && player.Top < 350)
                {
                    player.Update(player.Left, 252);
                }
                else if (player.Left > 154 && player.Left < 315 && player.Top > 0 && player.Top < 350)
                {
                    player.Update(player.Left, 297);
                }
                else if (player.Left > 379 && player.Left < 540 && player.Top > 0 && player.Top < 300)
                {
                    player.Update(player.Left, 253);
                }
                else if (player.Left > 584 && player.Left < 683 && player.Top > 0 && player.Top < 340)
                {
                    player.Update(player.Left, 299);
                }
                else
                {
                    player.Update(0, 252);
                }
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.D:
                    userDirection = Directions.Right;
                    setResetKeys();
                    break;
                case Keys.A:
                    userDirection = Directions.Left;
                    setResetKeys();
                    break;
                case Keys.Space:
                    userDirection = Directions.Jump;
                    setResetKeys();
                    break;
                case Keys.R:
                    setProlog();
                    break;
            }
            return base.IsInputKey(keyData);
        }

        void setResetKeys()
        {
            right = false;
            left = false;
        }
        void setJumpDelay()
        {
            if (jump)
            {
                if (jumpFrames >= 40)
                {
                    jump = false;
                    jumpFrames = 0;
                    player.Update(player.Left, player.Top += jumpSpeed);
                }
                jumpFrames++;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            cursX = e.X;
            cursY = e.Y;
            base.OnMouseMove(e);
        }

        /// <summary>
        /// Hear of the game
        /// </summary>
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            setUserInputKey();
            setUserDraw();
            setJumpDelay();

            setFoodsDraw();

            getColisions();
        }
    }
}
