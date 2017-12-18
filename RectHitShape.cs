using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;

namespace HitboxEditor01
{
    class RectHitShape : HitShape
    {
        public RectHitShape()
            :base( Shape.SH_RECT)
        {
            points = new PointF[4];
        }

        public override void Draw(Graphics g, Brush b)
        {
            g.FillPolygon(b, points);
        }

        public override void Save(StreamWriter sw, Point gCenter)
        {
            sw.WriteLine((int)Shape.SH_RECT);
            sw.WriteLine(centerPos.X - gCenter.X);
            sw.WriteLine(centerPos.Y - gCenter.Y);
            sw.WriteLine(width);
            sw.WriteLine(height);
            sw.WriteLine(angle);
        }

        public void SetRect( Point gPos, int p_w, int p_h, int p_angle )
        {
            centerPos = gPos;
            width = p_w;
            height = p_h;
            angle = p_angle;
            UpdateRect();
        }

        public void UpdateRect()
        {
            Matrix m = new Matrix();
          //  float rAngle = GetRadians(angle);
            m.Rotate(angle);

            points[0].X = -width;
            points[0].Y = -height;

            points[1].X = width;
            points[1].Y = -height;

            points[2].X = width;
            points[2].Y = height;

            points[3].X = -width;
            points[3].Y = height;

            m.TransformPoints(points);

            for (int i = 0; i < 4; ++i)
            {
                points[i].X += centerPos.X;
                points[i].Y += centerPos.Y;
            }
        }

        float GetRadians(int degreeAngle)
        {
            return (degreeAngle / 180.0f) * (float)Math.PI;
        }

        public PointF GetPoint(int index)
        {
            return points[index];
        }


        public int width;
        public int height;
        public int angle;
        PointF[] points;
        public Point centerPos;
    }
}
