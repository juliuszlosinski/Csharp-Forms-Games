using _Snake_.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Snake_
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
        public CSnake() : base(Resources.Player)
        {
            vitals.X = Left;
            vitals.Y = Top;
            vitals.Width = 20;
            vitals.Height = 20;
        }
        public void Update(int x,int y)
        {
            Left = x;
            Top = y;
            vitals.X = Left;
            vitals.Y = Top;
        }
        public bool isTouched(Rectangle hitSpot)
        {
            if (vitals.IntersectsWith(hitSpot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => vitals;
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Blue), vitals);
    }

    class CFood : CImageBase
    {
        Rectangle hitBody = new Rectangle();
        public CFood() : base(Resources.Food)
        {
            hitBody.X = Left;
            hitBody.Y = Top;
            hitBody.Width = 20;
            hitBody.Height = 20;
        }
        public void Update(int x,int y)
        {
            Left = x;
            Top = y;
            hitBody.X = Left;
            hitBody.Y = Top;
        }
        public bool isTouched(Rectangle hitspot)
        {
            if (hitBody.IntersectsWith(hitspot))
            {
                return true;
            }
            return false;
        }
        public Rectangle getColision() => hitBody;
        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Blue), hitBody);
    }
}
