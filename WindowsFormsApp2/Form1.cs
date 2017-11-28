using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Point initPoint;
        Point currentPoint;

        Bitmap bitmap;

        int Shape = 1;

        bool drawing;

        List<Rectangle> rectangles = new List<Rectangle>();
        List<Rectangle> circles = new List<Rectangle>();
        List<Line> points = new List<Line>();

        public bool Drawing { get => drawing; set => drawing = value; }

        private Rectangle getRectangle()
        {
            return new Rectangle(
                Math.Min(initPoint.X, currentPoint.X),
                Math.Min(initPoint.Y, currentPoint.Y),
                Math.Abs(initPoint.X - currentPoint.X),
                Math.Abs(initPoint.Y - currentPoint.Y));
        }

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(panel1.Width, panel1.Height);

            panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(Rectangle rect in rectangles)
            {
                e.Graphics.DrawRectangles(Pens.Black, rectangles.ToArray());
            }

            foreach(Rectangle circle in circles)
            {
                e.Graphics.DrawEllipse(Pens.Black, circle);
            }

            foreach(Line line in points)
            {
                e.Graphics.DrawLine(Pens.Black, initPoint.X, initPoint.Y, currentPoint.X, currentPoint.Y);
            }

            if (Drawing)
            {
                Pen pen = new Pen(Color.Red);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;

                if (Shape == 2)
                {
                    e.Graphics.DrawRectangle(pen, getRectangle());
                }
                if (Shape == 3)
                {
                    e.Graphics.DrawEllipse(pen, getRectangle());
                }
                if (Shape == 4)
                {
                    e.Graphics.DrawLine(pen, initPoint.X, initPoint.Y, currentPoint.X, currentPoint.Y);
                }
            }
        }

        private void panel1_onMouseDown(object sender, MouseEventArgs e)
        {
            if (Shape != 1)
            {
                if (e.Button == MouseButtons.Left)
                {                  
                    initPoint = currentPoint = e.Location;

                    Drawing = true;
                }
            }
        }

        private void panel1_onMouseMove(object sender, MouseEventArgs e)
        {
            if (Shape != 1)
            {
                if (e.Button == MouseButtons.Left)
                {
                    currentPoint = e.Location;

                    if (Drawing)
                    {
                        panel1.Invalidate();
                    }
                }
            }
        }

        private void panel1_onMouseUp(object sender, MouseEventArgs e)
        {
            if (Drawing)
            {
                Drawing = false;
                
                var rc = getRectangle();

                if (rc.Width > 0 && rc.Height > 0)
                {
                    if (Shape == 2)
                    {
                        rectangles.Add(rc);
                    }

                    if (Shape == 3)
                    {
                        circles.Add(rc);
                    }                    
                }
                /*
                if (Shape == 4)
                {
                    points.Add();
                }*/

                panel1.Invalidate();
            }
            
        }

        private void buttonNone_Click(object sender, EventArgs e)
        {
            Shape = 1;
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            Shape = 2;
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            Shape = 3;
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            Shape = 4;
        }
    }
}
