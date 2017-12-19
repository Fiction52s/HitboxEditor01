using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;

namespace HitboxEditor01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadedHitboxes = null;
        }

        Point gCenter;
        private void LoadSpriteSheet( string str )
        {
            int index = str.LastIndexOf('x');

            int startNumberIndex = index - 1;
            int endNumberIndex = index + 1;
            while (Char.IsNumber(str[startNumberIndex]))
            {
                --startNumberIndex;
            }

            while (Char.IsNumber(str[endNumberIndex]))
            {
                ++endNumberIndex;
            }

            ++startNumberIndex;
            --endNumberIndex;

            string numx = str.Substring(startNumberIndex, index - startNumberIndex);
            string numy = str.Substring(index + 1, endNumberIndex - index);

            tileWidthBox.Text = numx;
            tileHeightBox.Text = numy;

            Image im = Image.FromFile(currFileName);
            int tw = Convert.ToInt32(tileWidthBox.Text);
            int th = Convert.ToInt32(tileHeightBox.Text);

            //560x560 currently
            gCenter.X = 560 / 2;//tw / 2;
            gCenter.Y = 560 / 2;//th / 2;

            int numTilesX = im.Size.Width / tw;
            int numTilesY = im.Size.Height / th;

            startIndexBox.Text = "0";
            numTilesBox.Text = (numTilesX * numTilesY).ToString();
        }

        private void getSpriteSheetButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                spriteNameLabel.Text = openFileDialog1.SafeFileName;

                currFileName = openFileDialog1.FileName;

                string str = openFileDialog1.SafeFileName;
                LoadSpriteSheet(str);
            }
        }

        private string currFileName;
        public Image[] ims;
        
       

        private List<Tuple<int,List<HitShape>>> loadedHitboxes;
        

        private void StartEditor()
        {
            Image im = Image.FromFile(currFileName);
            Bitmap bm = new Bitmap(im);

            int tw = Convert.ToInt32(tileWidthBox.Text);
            int th = Convert.ToInt32(tileHeightBox.Text);

            int numTiles = Convert.ToInt32(numTilesBox.Text);
            int startTile = Convert.ToInt32(startIndexBox.Text);

            int numTilesX = im.Size.Width / tw;
            int numTilesY = im.Size.Height / th;
            ims = new Image[numTiles];


            System.Drawing.Imaging.PixelFormat format = bm.PixelFormat;
            for (int y = 0; y < numTilesY; ++y)
            {
                for (int x = 0; x < numTilesX; ++x)
                {
                    Rectangle subRect = new Rectangle(x * tw, y * th, tw, th);
                    Bitmap clone = bm.Clone(subRect, format);
                    ims[y * numTilesX + x] = clone;
                }
            }

            Editor ed = new Editor(loadedHitboxes, currFileName, this, startTile, startTile + (numTiles - 1), tw, th);
            ed.ShowDialog();
        }

        private void startEditorButton_Click(object sender, EventArgs e)
        {
            StartEditor();
        }

        public string GetHitboxFileName()
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return openFileDialog1.FileName;
            }
            return "";
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            string hitboxFileName = GetHitboxFileName();
            if ( !hitboxFileName.Equals("") )
            {
                //spriteNameLabel.Text = openFileDialog1.SafeFileName;

                //string str = openFileDialog1.SafeFileName;

                using (StreamReader sr = new StreamReader(hitboxFileName))
                {
                   // int nameLen = Convert.ToInt32(sr.ReadLine());
                    string tilesetName = sr.ReadLine();

                    currFileName = tilesetName;

                    LoadSpriteSheet(tilesetName);

                    int numPopulatedFrames = Convert.ToInt32(sr.ReadLine());
                    loadedHitboxes = new List<Tuple<int, List<HitShape>>>();
                    for (int i = 0; i < numPopulatedFrames; ++i)
                    {
                        int frameIndex = Convert.ToInt32(sr.ReadLine());
                        int numHitboxes = Convert.ToInt32(sr.ReadLine());
                        List<HitShape> hList = new List<HitShape>();

                        for (int h = 0; h < numHitboxes; ++h)
                        {
                            hList.Add(HitShape.Load(sr, gCenter));
                        }

                        Tuple<int, List<HitShape>> t = new Tuple<int, List<HitShape>>(frameIndex, hList);
                        loadedHitboxes.Add(t);
                    }
                }
                StartEditor();
            }
        }
    }
}
