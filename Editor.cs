﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace HitboxEditor01
{
    public partial class Editor : Form
    {

        enum State
        {
            S_DRAWTRI,
            S_DRAWRECT1,
            S_DRAWRECT2,
            S_DRAWCIRCLE,
            S_Count
        }

        State state;
        public int currFrame;
        public int maxFrame;
        public int minFrame;
        public Form1 parentForm;
        System.Drawing.SolidBrush hitboxBrush;
        int minCircleRadius;
        List<HitShape>[] hitboxLists;
        HitShape currHitShape;
        Point centerPos;
        string tilesetName;
        bool move;
        List<HitShape> copiedShapes;

        void PasteShapes()
        {
            List<HitShape> hList = hitboxLists[currFrame - minFrame];
            bool paste;
            foreach( HitShape hShape in copiedShapes )
            {
                paste = true;
                foreach (HitShape tShape in hList)
                {
                    if(hShape.IsSame(tShape))
                    {
                        paste = false;
                        break;
                    }
                }

                if( paste )
                {
                    hList.Add(hShape.Copy());
                }
            }
        }

        void CopyShapes()
        {
            copiedShapes = hitboxLists[currFrame - minFrame];
        }

        public Editor(List<Tuple<int, List<HitShape>>> loadedHitboxes, string p_tilesetName, Form1 p_parentForm, int startTile, int maxTile, int tw, int th  )
        {
            InitializeComponent();
            move = false;
            centerPos.X = pictureBox.Width / 2;//tw / 2;
            centerPos.Y = pictureBox.Height / 2;//th / 2;
            tilesetName = p_tilesetName;
            currHitShape = null;
            //state = State.S_DRAWRECT1;
            state = State.S_DRAWCIRCLE;
            parentForm = p_parentForm;
            minFrame = startTile;
            maxFrame = maxTile;
            currFrame = minFrame;
            pictureBox.Image = parentForm.ims[currFrame - minFrame];
            pictureBox.Refresh();
            currFrameLabel.Text = (currFrame - startTile).ToString() + " / " + (maxTile - startTile).ToString();
            Color c = Color.FromArgb(80, 255, 0, 0);
            hitboxBrush = new System.Drawing.SolidBrush(c);
            minCircleRadius = 2;
            hitboxLists = new List<HitShape>[(maxTile - startTile) + 1];
            for( int i = 0; i < hitboxLists.Length; ++i )
            {
                hitboxLists[i] = new List<HitShape>();
            }
            LoadHitboxes(loadedHitboxes);
        }

        private void LoadHitboxes(List<Tuple<int, List<HitShape>>> loadedHitboxes)
        {
            if ( loadedHitboxes == null)
                return;

            foreach( var v in loadedHitboxes )
            {
                int frame = v.Item1;
                List<HitShape> hList = v.Item2;

                foreach( HitShape h in hList )
                {
                    hitboxLists[frame].Add(h);
                }
            }
        }

        private void SaveFile()
        {
            saveFileDialog1.RestoreDirectory = false;
            saveFileDialog1.Filter = "Hitboxes (*.hit) |*.hit";
            Stream myStream;
           
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    StreamWriter sw = new StreamWriter(myStream);

                    //frame index
                    //number of hitboxes
                    //hitboxes
                    //  hitbox type and info

                    //int nameLen = tilesetName.Length;
                    //sw.WriteLine(nameLen);
                    sw.WriteLine(tilesetName);

                    int numFrames = (maxFrame - minFrame)+1;
                    sw.WriteLine(minFrame);
                    sw.WriteLine(numFrames);

                    int numPopulatedFrames = 0;
                    foreach( List<HitShape> hList in hitboxLists )
                    {
                        if (hList.Count > 0)
                            numPopulatedFrames++;
                    }

                    

                    sw.WriteLine(numPopulatedFrames);
                    for( int i = 0; i < numFrames; ++i )
                    {
                        int numHitboxes = hitboxLists[i].Count;
                        if( numHitboxes > 0 )
                        {
                            sw.WriteLine(i);
                            sw.WriteLine(numHitboxes);
                            foreach( HitShape hs in hitboxLists[i] )
                            {
                                hs.Save( sw, centerPos );
                            }
                        }
                    }

                    sw.Flush();

                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }
        }

        private void Editor_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ShiftKey:
                    {
                        move = false;
                        break;
                    }
            }
        }

        private void Editor_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (currFrame > minFrame)
                        --currFrame;
                    break;
                case Keys.Right:
                    if (currFrame < maxFrame)
                        ++currFrame;
                    break;
                case Keys.S:
                    {
                        if( e.Control )
                        {
                            SaveFile();
                        }
                        break;
                    }
                case Keys.ShiftKey:
                    {
                        move = true;
                        break;
                    }
                case Keys.C:
                    {
                        if( e.Control )
                        {
                            CopyShapes();
                        }
                        break;
                    }
                case Keys.V:
                    {
                        if (e.Control)
                        {
                            PasteShapes();
                        }
                        break;
                    }
                case Keys.Q:
                    {
                        state = State.S_DRAWCIRCLE;
                        break;
                    }
                case Keys.R:
                    {
                        state = State.S_DRAWRECT1; 
                        break;
                    }
                    //case Keys.H:
                    //    {
                    //        List<HitShape> hList = hitboxLists[currFrame - minFrame];
                    //        foreach (HitShape ht in hList.Reverse<HitShape>())
                    //        {
                    //            if (ht.HasPoint(mPos))
                    //            {
                    //                hList.Remove(ht);
                    //            }
                    //            //if contains mouse position, then remove the hitbox
                    //        }
                    //        break;
                    //    }
            }

            pictureBox.Image = parentForm.ims[currFrame - minFrame];
            pictureBox.Refresh();

            currFrameLabel.Text = (currFrame - minFrame).ToString() + " / " + (maxFrame - minFrame).ToString();
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            Point mPos = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                switch (state)
                {
                    case State.S_DRAWCIRCLE:
                        {
                            currHitShape = new CircleHitShape();
                            CircleHitShape chs = (CircleHitShape)currHitShape;
                            chs.centerPos.X = e.X;
                            chs.centerPos.Y = e.Y;
                            chs.radius = minCircleRadius;
                            break;
                        }
                    case State.S_DRAWRECT1:
                        {
                            currHitShape = new RectHitShape();
                            RectHitShape rhs = (RectHitShape)currHitShape;
                            rhs.SetRect(mPos, minCircleRadius, minCircleRadius, 0);
                            break;
                        }
                }
            }
            else if( e.Button == MouseButtons.Right )
            {
                if( currHitShape != null )
                {
                    currHitShape = null;
                    if (state == State.S_DRAWRECT2)
                        state = State.S_DRAWRECT1;
                }
                else
                {
                    List<HitShape> hList = hitboxLists[currFrame - minFrame];
                    foreach (HitShape ht in hList.Reverse<HitShape>() )
                    {
                        if( ht.HasPoint(mPos))
                        {
                            hList.Remove(ht);
                        }
                        //if contains mouse position, then remove the hitbox
                    }
                    pictureBox.Refresh();
                }
            }
        }

        private void pictureBox_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            Point localMousePos = new Point(e.X - pictureBox.Left, e.Y - pictureBox.Top);
            if( localMousePos.X < 0 )
            {
                localMousePos.X = 0;
            }
            if( localMousePos.Y < 0 )
            {
                localMousePos.Y = 0;
            }
            labelMousePos.Text = "(" + localMousePos.X + ", " + localMousePos.Y + ")";



            Point localOffset = new Point(localMousePos.X - pictureBox.Width / 2, localMousePos.Y - pictureBox.Height / 2);

            labelCenterOffset.Text = "Offset from Center: (" + localOffset.X + ", " + localOffset.Y + ")";

            if ( move )
            {
                Point mPos = new Point(e.X, e.Y);
                switch (state)
                {
                    case State.S_DRAWCIRCLE:
                        {
                            if (currHitShape != null)
                            {
                                CircleHitShape chs = currHitShape as CircleHitShape;
                                chs.centerPos = mPos;
                            }
                            break;
                        }
                    case State.S_DRAWRECT1:
                    case State.S_DRAWRECT2:
                        {
                            if (currHitShape != null)
                            {
                                RectHitShape rhs = currHitShape as RectHitShape;

                                rhs.centerPos = mPos;
                                rhs.UpdateRect();
                            }
                            break;
                        }
                }
                pictureBox.Refresh();
            }
            else
                switch (state)
                {
                    case State.S_DRAWCIRCLE:
                        {
                            if (currHitShape != null)
                            {
                                CircleHitShape chs = currHitShape as CircleHitShape;
                                Point mPos = new Point(e.X, e.Y);
                                Point diff = new Point(mPos.X - chs.centerPos.X, mPos.Y - chs.centerPos.Y);
                                double length = Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y);
                                chs.radius = Math.Max((int)length, minCircleRadius);
                                pictureBox.Refresh();
                            }
                            break;
                        }
                    case State.S_DRAWRECT1:
                        {
                            if (currHitShape != null)
                            {
                                RectHitShape rhs = currHitShape as RectHitShape;
                                Point mPos = new Point(e.X, e.Y);
                                Point diff = new Point(mPos.X - rhs.centerPos.X, mPos.Y - rhs.centerPos.Y);
                                double length = Math.Sqrt(diff.X * diff.X + diff.Y * diff.Y);

                                float max = Math.Max((int)length, minCircleRadius);

                                rhs.width = (int)max;
                                rhs.height = minCircleRadius;//(int)max;

                                float xDiff = diff.X;
                                float yDiff = diff.Y;
                                int angle = (int)(Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI);
                                rhs.angle = angle;

                                rhs.UpdateRect();
                                pictureBox.Refresh();
                            }
                            break;
                        }
                    case State.S_DRAWRECT2:
                        {
                            if (currHitShape != null)
                            {
                                RectHitShape rhs = currHitShape as RectHitShape;
                                PointF mPos = new PointF(e.X, e.Y);
                                PointF diff = new PointF(mPos.X - rhs.centerPos.X, mPos.Y - rhs.centerPos.Y);

                                PointF p0 = rhs.GetPoint(0);
                                PointF p1 = rhs.GetPoint(1);
                                PointF p2 = rhs.GetPoint(2);
                                PointF axisA = new PointF(p1.X - p0.X, p1.Y - p0.Y);
                                PointF axisB = new PointF(p2.X - p1.X, p2.Y - p1.Y);
                                Normalize(ref axisA);
                                Normalize(ref axisB);

                                float d = Math.Abs(Dot(diff, axisA));
                                float d1 = Math.Abs(Dot(diff, axisB));

                                d = Math.Max(d, minCircleRadius);
                                d1 = Math.Max(d1, minCircleRadius);
                                //d = Math.Min(d, 400);
                                //d1 = Math.Min(d1, 400);

                                rhs.width = (int)d;
                                rhs.height = (int)d1;


                                rhs.UpdateRect();
                                pictureBox.Refresh();
                            }
                            break;
                        }
                }
        }

        static public float Dot( PointF a, PointF b )
        {
            return a.X * b.X + a.Y * b.Y;
        }

        static public float Length( PointF a )
        {
            return (float)Math.Sqrt(a.X * a.X + a.Y * a.Y);
        }

        static public void Normalize( ref PointF a )
        {
            float len = Length(a);
            a.X /= len;
            a.Y /= len;
        }

        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            switch (state)
            {
                case State.S_DRAWRECT1:
                case State.S_DRAWRECT2:
                case State.S_DRAWCIRCLE:
                    {
                        if (currHitShape != null )
                        {
                            currHitShape.Draw(e.Graphics, hitboxBrush);
                        }
                        break;
                    }
            }

            List<HitShape> hList = hitboxLists[currFrame - minFrame];
            foreach (HitShape ht in hList)
            {
                ht.Draw(e.Graphics, hitboxBrush);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            switch( e.Button )
            {
                case MouseButtons.Left:
                    {
                        switch (state)
                        {
                            case State.S_DRAWRECT2:
                                {
                                    state = State.S_DRAWRECT1;

                                    hitboxLists[currFrame - minFrame].Add(currHitShape);
                                    currHitShape = null;
                                    pictureBox.Refresh();
                                    break;
                                }
                            case State.S_DRAWCIRCLE:
                                {
                                    hitboxLists[currFrame - minFrame].Add(currHitShape);
                                    currHitShape = null;
                                    pictureBox.Refresh();
                                    break;
                                }
                            case State.S_DRAWRECT1:
                                {
                                    state = State.S_DRAWRECT2;
                                    break;
                                }
                        }
                        break;
                    }
                case MouseButtons.Right:
                    {
                        
                        break;
                    }
                    
            }
            
        }

        
    }

}
