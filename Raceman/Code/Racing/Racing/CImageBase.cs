using Racing.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing
{
   public class CImageBase
    {
        Bitmap bitmap;
        int X, Y;
        public int Left { get => X; set { X = value; } }
        public int Top { get => Y; set { Y = value; } }
        public CImageBase(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
        public void changeBitmap(Bitmap source) => bitmap = new Bitmap(source);
    }

    class CPlayer:CImageBase
    {
        Rectangle vitals = new Rectangle();        //body
       
        public CPlayer() : base(Resources.Player)
        {
            vitals.X = Left;
            vitals.Y = Top;
            vitals.Height = 65;
            vitals.Width = 145;
        }

        public void DrawDebugRectangle(Graphics g) => g.DrawRectangle(new Pen(Brushes.Red), vitals);

        public void Update(int x ,int y)
        {
            Left = x;
            Top = y;
            vitals.X = Left;
            vitals.Y = Top;
        } 

        public bool isHit(Rectangle hitspot)
        {
            if (vitals.IntersectsWith(hitspot))
                return true;
            return false;
        }
    }

    public class CCar : CImageBase
    {
        public Rectangle touchSpot = new Rectangle();
        public CCar() : base(Resources.Car)
        {
            touchSpot.X = Left+15;
            touchSpot.Y = Top+10;
            touchSpot.Height = 50;
            touchSpot.Width =120;
        }

        public void DrawDebugRectangle(Graphics g)
        {
            g.DrawRectangle(new Pen(Brushes.White), touchSpot);
        }

        public void Update(int x, int y)
        {
            Left = x;
            Top = y;
            touchSpot.X = Left+15;
            touchSpot.Y = Top + 10;
        }
        public Rectangle getTouchSpot() => touchSpot;
    }

    class CBackground : CImageBase
    {
        public CBackground() : base(Resources.Background) { }
    }

    class CSteps : CImageBase
    {
        public CSteps() : base(Resources.Step) { }
    }

    class CScoreFrame : CImageBase
    {
        public CScoreFrame() : base(Resources.ScoreFrame) { }
    }

    class CForeground : CImageBase
    {
        public CForeground() : base(Resources.Foreground) { }
    }

    class CMenu : CImageBase
    { 
        public CMenu() : base(Resources.Menu) { }
    }
}
