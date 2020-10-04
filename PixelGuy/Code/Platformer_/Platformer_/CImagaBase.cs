using Platformer_.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer_
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

    class CPlayer : CImageBase 
    {
        Rectangle vitals = new Rectangle();
        public CPlayer() : base(Resources.PixelGuy)
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
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Blue), vitals);
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

    class CEnemy : CImageBase
    {
        Rectangle bodySpots = new Rectangle();
        public CEnemy() : base(Resources.Coin)
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
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Black), bodySpots);
        public bool isTouched(Rectangle hitSpot)
        {
            if (bodySpots.IntersectsWith(hitSpot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => bodySpots;
    }
}
