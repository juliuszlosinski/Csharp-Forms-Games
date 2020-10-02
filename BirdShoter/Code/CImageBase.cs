using BirdShooter.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdShooter
{
    class CImageBase
    {
        int X, Y;
        Bitmap bitmap;
        public int Left { get => X; set { X = value; } }
        public int Top { get => Y; set { Y = value; } }
        public CImageBase(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
    }
    class CBird : CImageBase
    {
        public Rectangle vitals = new Rectangle();
        public CBird() : base(Resources.Bird)
        {
            vitals.X = Left + 30;
            vitals.Y = Top;
            vitals.Height = 100;
            vitals.Width = 100;
        }
        public void Update(int x, int y)
        {
            Left = x;
            Top = y;
            vitals.X = Left + 30;
            vitals.Y = Top;
        }
        public bool Hit(int x ,int y)
        {
            Rectangle hitSpot = new Rectangle(x, y, 1, 1);
            if (vitals.Contains(hitSpot))
                return true;
            return false;
        }
    }
    class CScoreFrame : CImageBase
    {
        public CScoreFrame() : base(Resources.ScoreFrame) { }
    }
    class CMenu : CImageBase
    {
        public CMenu() : base(Resources.Menu) { }
    }
    class CForeground : CImageBase
    {
        public CForeground() : base(Resources.Foreground) { }
    }
}
