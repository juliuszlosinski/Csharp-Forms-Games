using SnakeShoter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeShoter
{
    class CImageBase
    {
        int X, Y;
        Bitmap bitmap;
        public int Left { get => X; set { X = value; } }
        public int Top { get => Y; set { Y = value; } }
        public CImageBase(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
        public void ChangeBitmap(Bitmap source) => bitmap = new Bitmap(source);
    }
    class CSnake : CImageBase
    {
        Rectangle vitals = new Rectangle();
        public CSnake() : base(Resources.Snake)
        {
            vitals.X = Left;
            vitals.Y = Top;
            vitals.Width = 40;
            vitals.Height = 40;
        }
        public void Update(int x,int y)
        {
            Left = x;
            Top = y;
            vitals.X = Left;
            vitals.Y = Top;
        }
        public void DrawRectangleDebug(Graphics g) => g.DrawRectangle(new Pen(Brushes.Blue), vitals);
        public bool isTouched(Rectangle hitSpot)
        {
            if (vitals.IntersectsWith(hitSpot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => vitals;
    }
    class CFood : CImageBase
    {
        Rectangle bodySpots = new Rectangle();
        public CFood() : base(Resources.Ammo)
        {
            bodySpots.X = Left;
            bodySpots.Y = Top;
            bodySpots.Width = 40;
            bodySpots.Height = 40;
        }
        public void Update(int x,int y)
        {
            Left = x;
            Top = y;
            bodySpots.X = Left;
            bodySpots.Y = Top;
        }

        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Goldenrod), bodySpots);
        public bool isTouched(Rectangle hitSpot)
        {
            if (bodySpots.IntersectsWith(hitSpot))
            {
                return true;
            }
            return false;
        }
        public bool isShoted(int x,int y)
        {
            Rectangle hitSpot = new Rectangle(x, y, 1, 1);
            if (bodySpots.Contains(hitSpot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => bodySpots;
    }

    class CWall : CImageBase
    {
        Rectangle bodySpots = new Rectangle();
        public CWall() : base(Resources.Rock)
        {
            bodySpots.X = Left;
            bodySpots.Y = Top;
            bodySpots.Width = 40;
            bodySpots.Height = 40;
        }
        public void Update(int x,int y)
        {
            Left = x;
            Top = y;
            bodySpots.X = Left;
            bodySpots.Y = Top;
        }
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Yellow), bodySpots);
        public bool isTouched(Rectangle hitSpot)
        {
            if (bodySpots.IntersectsWith(hitSpot))
            {
                return true;
            }
            return false;
        }
        public bool isShoted(int x,int y)
        {
            Rectangle hitSpot = new Rectangle(x, y, 1, 1);
            if (bodySpots.Contains(hitSpot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => bodySpots;
    }
}
