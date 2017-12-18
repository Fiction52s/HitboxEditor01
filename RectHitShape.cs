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

        public RectHitShape(RectHitShape rhs)
            : base(Shape.SH_CIRCLE)
        {
            points = new PointF[4];
            centerPos = rhs.centerPos;
            width = rhs.width;
            height = rhs.height;
            angle = rhs.angle;
            UpdateRect();
        }

        public override void Draw(Graphics g, Brush b)
        {
            g.FillPolygon(b, points);
        }

        public override HitShape Copy()
        {
            RectHitShape rhs = new RectHitShape(this);
            return rhs;
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

        public override bool HasPoint(PointF p)
        {
            PointF p0 = GetPoint(0);
            PointF p1 = GetPoint(1);
            PointF p3 = GetPoint(3);
            PointF axisA = new PointF(p1.X - p0.X, p1.Y - p0.Y);
            PointF axisB = new PointF(p3.X - p0.X, p3.Y - p0.Y);
            PointF oldAxisA = new PointF(axisA.X, axisA.Y);
            PointF oldAxisB = new PointF(axisB.X, axisB.Y);
            Editor.Normalize(ref axisA);
            Editor.Normalize(ref axisB);

            PointF diff = new PointF(p.X - p0.X, p.Y - p0.Y);

            float dA = Editor.Dot(diff, axisA);
            float dB = Editor.Dot(diff, axisB);

            float axisALen = Editor.Length(oldAxisA);
            float axisBLen = Editor.Length(oldAxisB);

            bool aOkay = dA >= 0 && dA <= axisALen;
            bool bOkay = dB >= 0 && dB <= axisBLen;

            return aOkay && bOkay;
        }

        float GetRadians(int degreeAngle)
        {
            return (degreeAngle / 180.0f) * (float)Math.PI;
        }

        public PointF GetPoint(int index)
        {
            return points[index];
        }

        public override bool IsSame(HitShape hShape)
        {
            if (hShape.sh != sh)
                return false;

            RectHitShape rhs = hShape as RectHitShape;
            return rhs.width == width && rhs.height == height && rhs.angle == angle && rhs.centerPos.X == centerPos.X && rhs.centerPos.Y == centerPos.Y;
        }


        public int width;
        public int height;
        public int angle;
        PointF[] points;
        public Point centerPos;
    }
}
