using SnakeShoter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeShoter
{
    public partial class SnakeShoter : Form
    {
        //Score
        int points;

        //User input
        enum Directions
        {
            Left,Right,Top,Down
        }
        Directions userDirection;

        //Components
        Graphics g;
        Color background;

        //Snake
        CSnake snakeHead;
        List<CSnake> snakeBody;
        int snakeSpeed;

        //Foods
        CFood[] foods;
        List<int> visitedFoods;

        //Walls
        CWall[] walls;
        List<int> visitedWalls;

        //Background:
        Bitmap backgroundImage;

        public SnakeShoter()
        {
            InitializeComponent();
            setProlog();
        }

        public void setProlog()
        {
            axBackgroundMusic.Ctlcontrols.play();

            this.Cursor = new Cursor(Resources.Scope.GetHicon());
            this.DoubleBuffered = true;
            this.MaximumSize = new Size(700, 500);
            this.MinimumSize = new Size(700, 500);

            points = 0;

            userDirection = new Directions();

            g = this.CreateGraphics();
            background = Color.Black;

            snakeHead = new CSnake { Left = 100, Top = 300 };
            snakeHead.Update(snakeHead.Left, snakeHead.Top);
            snakeBody = new List<CSnake>();
            snakeSpeed = 5;

            setFoods();
            setWalls();

            backgroundImage = new Bitmap(Resources.Background);

            GameLoop.Interval = 50;
            GameLoop.Start();
        }

        public void setFoods()
        {
            Random rand = new Random();
            visitedFoods = new List<int>();
            foods = new CFood[5];
            for(int x = 0; x < foods.Length; x++)
            {
                foods[x] = new CFood { Left = rand.Next(1, 500), Top = rand.Next(1, 500) };
                foods[x].Update(foods[x].Left, foods[x].Top);
            }
        }

        public void setWalls()
        {
            Random rand = new Random();
            walls = new CWall[30];
            visitedWalls = new List<int>();
            for(int x = 0; x < walls.Length; x++)
            {
                walls[x] = new CWall { Left = rand.Next(1, 600), Top = rand.Next(1, 600) };
                walls[x].Update(walls[x].Left, walls[x].Top);
            }

        }

        public void setUserInputKey()
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
                    snakeHead.Update(snakeHead.Left-=snakeSpeed,snakeHead.Top);
                    break;
                case Directions.Right:
                    snakeHead.Update(snakeHead.Left += snakeSpeed, snakeHead.Top);
                    break;
            }
        }

        protected override bool IsInputKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.W:
                    snakeHead.ChangeBitmap(Resources.Tank_TOP);
                    userDirection = Directions.Top;
                    break;
                case Keys.S:
                    snakeHead.ChangeBitmap(Resources.Tank_DOWN);
                    userDirection = Directions.Down;
                    break;
                case Keys.A:
                    snakeHead.ChangeBitmap(Resources.Tank_LEFT);
                    userDirection = Directions.Left;
                    break;
                case Keys.D:
                    snakeHead.ChangeBitmap(Resources.Tank_RIGHT);
                    userDirection = Directions.Right;
                    break;
                case Keys.R:
                    setProlog();
                    break;
                case Keys.Tab:
                    GameLoop.Start();
                    break;
                case Keys.Space:
                    GameLoop.Stop();
                    break;
            }
            return base.IsInputKey(keyData);
        }


        public void setUserDraw()
        {
            g.Clear(background);
            g.DrawImage(backgroundImage, 0, 0);
            
            snakeHead.DrawImage(g);
            snakeHead.DrawRectangleDebug(g);

            int xLast = snakeHead.Left;
            int yLast = snakeHead.Top;

            snakeBody.Add(new CSnake { Left = xLast, Top = yLast });

            if (points > 0)
            {
                int barier = 0;
                snakeBody.Reverse();
                foreach(CSnake skin in snakeBody)
                {
                    if (barier <= points)
                    {
                        skin.Update(skin.Left, skin.Top);
                        skin.ChangeBitmap(Resources.Tank_TOP);
                        skin.DrawImage(g);
                        skin.DrawRectangleDebug(g);
                        barier++;
                        if (barier >= 10)
                        {
                            if (snakeHead.isTouched(skin.getColision()))
                            {
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

            g.DrawString($"Points: {points}", new Font("stencil", 20), Brushes.White, 0, 0);
            g.DrawString($"SNAKE SHOTER", new Font("stencil", 20), Brushes.Blue, 200, 0);
            g.DrawString($"R - restart", new Font("stencil", 15), Brushes.Red, 0, 435);
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
                    foods[x].Update(foods[x].Left, foods[x].Top);
                }
            }
        }

        public void setWallsDraw()
        {
            if (visitedWalls.Count() == walls.Length)
            {
                setWalls();
            }
            else
            {
                for (int x = 0; x < walls.Length; x++)
                {
                    if (visitedWalls.Contains(x))
                    {
                        continue;
                    }
                    else
                    {
                        walls[x].DrawImage(g);
                        walls[x].DrawDebugRectangle(g);
                    }
                }
            }
        }

        public void getColisions()
        {
            if (visitedFoods.Count == foods.Length)
            {
                setFoods();
                setWalls();
            }
            else
            {
                for(int w = 0; w < walls.Length; w++)
                {
                    if (snakeHead.isTouched(walls[w].getColision())&&!visitedWalls.Contains(w))
                    {
                        axDeathMusic.Ctlcontrols.play();
                        GameLoop.Stop();
                    }
                }

                for(int x = 0; x < foods.Length; x++)
                {
                    if (visitedFoods.Contains(x))
                    {
                        continue;
                    }
                    else
                    {
                        if (snakeHead.isTouched(foods[x].getColision()))
                        {
                            points++;
                            visitedFoods.Add(x);
                        }
                    }
                }
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            axShotMusic.Ctlcontrols.play();
            for(int x = 0; x < walls.Length; x++)
            {
                if (walls[x].isShoted(e.X, e.Y))
                {
                    visitedWalls.Add(x);
                }
            }
            base.OnMouseClick(e);
        }

        public void setWeaponDraw()
        {
            int xPositionSnakeHead = snakeHead.Left;
            int yPositionSnakeHead = snakeHead.Top;

            int offSet = 30;
            int secodOffSet = 7;

            Rectangle weapon = new Rectangle();

            switch (userDirection)
            {
                case Directions.Top:
                    weapon = new Rectangle(xPositionSnakeHead+ secodOffSet, yPositionSnakeHead - offSet, 25, 50);
                    break;
                case Directions.Down:
                    weapon = new Rectangle(xPositionSnakeHead + secodOffSet, yPositionSnakeHead+ secodOffSet, 25, 50);
                    break;
                case Directions.Left:
                    weapon = new Rectangle(xPositionSnakeHead - offSet, yPositionSnakeHead+ secodOffSet, 50, 25);
                    break;
                case Directions.Right:
                    weapon = new Rectangle(xPositionSnakeHead+ secodOffSet, yPositionSnakeHead+ secodOffSet, 50, 25);
                    break;
            }
            g.FillRectangle(Brushes.White,weapon);
            g.DrawRectangle(new Pen(Brushes.Indigo, 3), weapon);
        }
        
        /*
        protected override void OnMouseMove(MouseEventArgs e)
        {
            int xPositionSnakeHead = snakeHead.Left;
            int yPositionSnakeHead = snakeHead.Top;

            int offSet = 30;
            int secodOffSet = 7;

            Rectangle weapon = new Rectangle();

            if (e.Y >= 0 && e.Y <= 300)
            {
                if (e.X <= 300)
                {
                    weapon = new Rectangle(xPositionSnakeHead - offSet, yPositionSnakeHead + secodOffSet, 50, 25);
                }
                else
                {
                    weapon = new Rectangle(xPositionSnakeHead + secodOffSet, yPositionSnakeHead - offSet, 25, 50);
                }
            }
            else if (e.Y >= 300 && e.Y <= 500)
            {
                if (e.X >= 300)
                {
                    weapon = new Rectangle(xPositionSnakeHead + secodOffSet, yPositionSnakeHead + secodOffSet, 50, 25);

                }
                else
                {
                    weapon = new Rectangle(xPositionSnakeHead + secodOffSet, yPositionSnakeHead + secodOffSet, 25, 50);
                }
            }

            g.FillRectangle(Brushes.White, weapon);
            g.DrawRectangle(new Pen(Brushes.Indigo, 3), weapon);

            base.OnMouseMove(e);
        }
        */

        //Heart
        private void GameLoop_Tick(object sender, EventArgs e)
        {
            setUserInputKey();
            setUserDraw();

            //setWeaponDraw();

            setFoodsDraw();

            setWallsDraw();

            getColisions();
        }
    }
}
