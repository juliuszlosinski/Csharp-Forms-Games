using DogFly.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogFly
{
    class CImageBase
    {
        int X, Y;
        Bitmap bitmap;
        public int Left { get => X; set { X = value; } }
        public int Top { get => Y; set { Y = value; } }
        public CImageBase(Bitmap source) => bitmap = new Bitmap(source);
        public void ChangeBitmap(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
    }

    class CPlayer : CImageBase
    {
        Rectangle vitals = new Rectangle();
        public CPlayer() : base(Resources.DogGuy)
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
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.White, 2), vitals);
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
        public CFood() : base(Resources.Coin)
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
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Red, 2), bodySpots);
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
