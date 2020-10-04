//#define MyDebug
using _Snake_.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Snake_
{
    public partial class SnakeGame : Form
    {
        //Snake---------------------
        CSnake snakeHead;
        List<CSnake> snakeBody;
        int snakeSpeed;
        //----------------------------


        //Foods-----------------------
        CFood[] foods;
        List<int> visitedFoods;
        //-----------------------

        //Score system------
        int points;
        bool flagPoint;
        //-----------------

        int cursX, cursY;
        Graphics g;
        Directions userDirection;

        enum Directions
        {
            Left,Right,Top,Down
        }

        public SnakeGame()
        {
            InitializeComponent();
            setProlog();
        }

        public void setProlog()
        {
            this.MaximumSize = new Size(850, 510);
            this.Cursor = new Cursor(Resources.cursorPixel.GetHicon());
            flagPoint = false;
            snakeSpeed = 4;
            userDirection = Directions.Right;
            points = 0;
            snakeHead = new CSnake { Left = 100, Top = 200 };
            snakeHead.Update(snakeHead.Left++, snakeHead.Top++);
            snakeBody = new List<CSnake>();
            g = this.CreateGraphics();
            setFoods();
            GameLoop.Interval = 20;
            GameLoop.Start();
        }

        public void setFoods()
        {
            visitedFoods = new List<int>();
            Random rand = new Random();
            foods = new CFood[5];
            for(int x = 0; x < foods.Length; x++)
            {
                foods[x] = new CFood { Left = rand.Next(1, 400), Top = rand.Next(1, 350) };
                foods[x].Update(foods[x].Left++, foods[x].Top++);
            }
        }


        public void setUserKeyInput()
        {
            switch (userDirection)
            {
                case Directions.Top:
                    snakeHead.Update(snakeHead.Left, snakeHead.Top -= snakeSpeed);
                    break;
                case Directions.Down:
                    snakeHead.Update(snakeHead.Left, snakeHead.Top += snakeSpeed);
                    break;
                case Directions.Left:
                    snakeHead.Update(snakeHead.Left -= snakeSpeed, snakeHead.Top);
                    break;
                case Directions.Right:
                    snakeHead.Update(snakeHead.Left += snakeSpeed, snakeHead.Top);
                    break;
            }
        }
       
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData.Equals(Keys.W))
            {
                if (!userDirection.Equals(Directions.Down))
                {
                    userDirection = Directions.Top;
                    flagPoint = false;
                }
            }
            else if (keyData.Equals(Keys.A))
            {
                if (!userDirection.Equals(Directions.Right))
                {
                    userDirection = Directions.Left;
                    flagPoint = false;
                }
            }
            else if (keyData.Equals(Keys.S))
            {
                if (!userDirection.Equals(Directions.Top))
                {
                    userDirection = Directions.Down;
                    flagPoint = false;
                }
            }
            else if (keyData.Equals(Keys.D))
            {
                if(!userDirection.Equals(Directions.Left))
                {
                    userDirection = Directions.Right;
                    flagPoint = false;
                }
            }
            else if (keyData.Equals(Keys.Tab))
            {
                if (!flagPoint)
                {
                    points++;
                    flagPoint = true;
                }
            }
            else if (keyData.Equals(Keys.R))
            {
                setProlog();
            }
            return base.IsInputKey(keyData);
        }

        public void setUserDraw()
        {
            g.Clear(Color.Black);
            snakeHead.DrawImage(g);
            snakeHead.DrawDebugRectangle(g);

            int xLastPosition = snakeHead.Left;
            int yLastPosition = snakeHead.Top;

            snakeBody.Add(new CSnake { Left = xLastPosition, Top = yLastPosition });

            if (points > 0)
            {
                int barier = 0;
                snakeBody.Reverse();
                foreach(CSnake skin in snakeBody)
                {
                    if (barier <= points)
                    {
                        skin.Update(skin.Left, skin.Top);
                        skin.DrawImage(g);
                        skin.DrawDebugRectangle(g);
                        barier++;
                        if (barier >= 10)
                        {
                            if (snakeHead.isTouched(skin.getColision()))
                            {
                                axDeathMusic.Ctlcontrols.play();
                                GameLoop.Stop();
                            }
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                snakeBody.Reverse();
            }

            if (snakeBody.Count >= 1000)
            {
                snakeBody = new List<CSnake>();
            }

            g.DrawString($"Points: {points}", new Font("Stencil", 12), Brushes.White, 0, 0);
#if MyDebug
            g.DrawString($"X: {cursX}\nY: {cursY}", new Font("Stencil", 12), Brushes.Ivory, 0,20);
#endif
            g.DrawString($"SNAKE-GAME", new Font("Stencil", 30), Brushes.White, 500, 0);
            g.DrawString($"START", new Font("Stencil", 31), Brushes.Khaki, 545, 80);
            g.DrawString($"STOP", new Font("Stencil", 31), Brushes.Blue, 560, 160);
            g.DrawString($"RESET", new Font("Stencil", 31), Brushes.Yellow, 545, 240);
            g.DrawString($"EXIT", new Font("Stencil", 31), Brushes.Red, 560, 320);

            g.DrawRectangle(new Pen(Brushes.White, 5), new Rectangle(450, 0, 350, 450));
        }

        public void getColisions()
        {
            if (snakeHead.Left >= 430 || snakeHead.Left <= 0 || snakeHead.Top>=448 || snakeHead.Top<=0)  
            {
                GameLoop.Stop();
                axDeathMusic.Ctlcontrols.play();
            }
            if (visitedFoods.Count() == foods.Length)
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
                    else if (foods[x].isTouched(snakeHead.getColision()))
                    {
                        axEatMusic.Ctlcontrols.play();
                        points++;
                        visitedFoods.Add(x);
                    }
                }
            }
        }

        public void setFoodsDraw()
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
                    foods[x].DrawDebugRectangle(g);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            cursX = e.X;
            cursY = e.Y;
            base.OnMouseMove(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (e.X > 548 && e.X < 680 && e.Y > 90 && e.Y < 122)
            {
                GameLoop.Start();
            }
            else if (e.X > 548 && e.X < 680 && e.Y > 172 && e.Y < 199)
            {
                GameLoop.Stop();
            }
            else if (e.X > 548 && e.X < 680 && e.Y > 253 && e.Y < 284)
            {
                setProlog();
            }
            else if (e.X > 548 && e.X < 680 && e.Y > 328 && e.Y < 366)
            {
                this.Close();
            }
            base.OnMouseClick(e);
        }

        //Heart
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            setUserKeyInput();
            setUserDraw();

            setFoodsDraw();
            getColisions();
        }
        //------------
    }
}
