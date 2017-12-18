using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace HitboxEditor01
{
    class CircleHitShape : HitShape
    {
        public CircleHitShape()
            :base( Shape.SH_CIRCLE)
        {
            drawRect = new Rectangle();
        }
        
        public override void Draw( Graphics g, Brush b )
        {
            drawRect.X = centerPos.X - radius;
            drawRect.Y = centerPos.Y - radius;
            drawRect.Width = radius * 2;
            drawRect.Height = radius * 2;
            g.FillEllipse(b, drawRect);
        }

        public override void Save(StreamWriter sw, Point gCenter )
        {
            sw.WriteLine((int)Shape.SH_CIRCLE);
            sw.WriteLine(centerPos.X - gCenter.X );
            sw.WriteLine(centerPos.Y - gCenter.Y );
            sw.WriteLine(radius);
        }

        public Point centerPos;
        public int radius;
        Rectangle drawRect;
    }
}
