using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace HitboxEditor01
{
    abstract public class HitShape
    {
        public enum Shape
        {
            SH_TRI,
            SH_RECT,
            SH_CIRCLE,
        }

        //public enum HitType
        //{
        //    H_HIT,
        //    H_HURT
        //}

        public HitShape( Shape s )//, HitType ht )
        {
            sh = s;
         //   hitType = ht;

        }

        abstract public bool HasPoint(PointF p);
        abstract public void Draw( Graphics g, Brush b );
        abstract public void Save( StreamWriter sw, Point gCenter );
        static public HitShape Load(StreamReader sr, Point gCenter)
        {
            int shapeType = Convert.ToInt32(sr.ReadLine());

            Shape sha = (Shape)shapeType;
            switch (sha)
            {
                case Shape.SH_CIRCLE:
                    {
                        int centerX = Convert.ToInt32(sr.ReadLine());
                        int centerY = Convert.ToInt32(sr.ReadLine());
                        int radius = Convert.ToInt32(sr.ReadLine());

                        CircleHitShape chs = new CircleHitShape();
                        chs.radius = radius;
                        chs.centerPos.X = centerX + gCenter.X;
                        chs.centerPos.Y = centerY + gCenter.Y;
                        return chs;

                        break;
                    }
                case Shape.SH_RECT:
                    {

                        int centerX = Convert.ToInt32(sr.ReadLine());
                        int centerY = Convert.ToInt32(sr.ReadLine());

                        centerX = centerX + gCenter.X;
                        centerY = centerY + gCenter.Y;

                        int width = Convert.ToInt32(sr.ReadLine());
                        int height = Convert.ToInt32(sr.ReadLine());
                        int angle = Convert.ToInt32(sr.ReadLine());

                        RectHitShape rhs = new RectHitShape();
                        rhs.SetRect(new Point(centerX, centerY), width, height, angle);

                        return rhs;
                        break;
                    }
            }

            return null;
        }
        abstract public HitShape Copy();
        abstract public bool IsSame(HitShape hShape);

        public Shape sh;
       // HitType hitType;
    }
}
