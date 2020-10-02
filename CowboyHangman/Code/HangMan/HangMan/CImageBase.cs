using HangMan.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class CImageBase
    {
        int X, Y;
        Bitmap bitmap;
        public int Left { get => X; set {X = value; }}
        public int Top { get => Y; set { Y = value; }}
        public CImageBase(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
    }
    class CSkeleton : CImageBase
    {
        Rectangle vitals = new Rectangle();
        public CSkeleton() : base(Resources.Background)
        {
            vitals.X = Left + 10;
            vitals.Y = Top - 15;
            vitals.Width = 50;
            vitals.Height = 50;
        }
        public void Update(int x, int y)
        {
            Left = x;
            Top = y;
            vitals.X = Left + 10;
            vitals.Y = Top - 15;
        }
        public bool Hit(int x ,int y)
        {
            Rectangle hitspot = new Rectangle(x, y, 3, 3);
            if (vitals.Contains(hitspot))
                return true;
            return false;
        }
    }
    class CImageVersionOut
    {
        Bitmap bitmap;
        int X, Y;
        public int Left { get => X;set { X = value; }}
        public int Top { get => Y; set { Y = value;}}
        public CImageVersionOut(Bitmap source) => bitmap = new Bitmap(source);
        public void DrawImage(Graphics g) => g.DrawImage(bitmap, X, Y);
    }
    class CStand : CImageBase 
    { 
        public CStand() : base(Resources.Stand) { }
    }
    class CScoreFrame : CImageBase
    { 
        public CScoreFrame() : base(Resources.ScoreFrame) { }
    }
    class CDialogFrame : CImageBase
    {
        public CDialogFrame() : base(Resources.DialogFrame) { }
    }
    class CForeGround : CImageBase
    {
        public CForeGround() : base(Resources.Foreground) { }
    }
}
