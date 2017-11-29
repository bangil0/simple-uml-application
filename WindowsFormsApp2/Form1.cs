using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private IEditor editor;
        /*
        private IToolbox toolbox;
        private IToolbar toolbar;
        private IMenubar menubar;
        private IPlugin[] plugins;*/

        Point initPoint;
        Point currentPoint;

        private Rectangle rectangle;

        int Shape = 2;

        bool drawing;

        List<ObjectShape> objectShape = new List<ObjectShape>();

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

            InitUI();

            //panel1.Paint += new PaintEventHandler(panel1_Paint);
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Editor and Canvas

            Debug.WriteLine("Loading canvas...");
            this.editor = new DefaultEditor();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

            ICanvas canvas1 = new DefaultCanvas();
            canvas1.Name = "Untitled-1";
            this.editor.AddCanvas(canvas1);

            /*
            ICanvas canvas2 = new DefaultCanvas();
            canvas2.Name = "Untitled-2";
            this.editor.AddCanvas(canvas2);
            */

            #endregion

            //#region Toolbox

            // Initializing toolbox
            /*
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
            this.editor.Toolbox = toolbox;

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new RectangleTool());

            if (plugins != null)
            {
                for (int i = 0; i < this.plugins.Length; i++)
                {
                    this.toolbox.Register(plugins[i]);
                }
            }

            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            foreach(ObjectShape shape in objectShape)
            {
                shape.SetGraphics(e.Graphics);

                shape.Draw();
            }
            /*
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
            }*/
        }

        private void panel1_onMouseDown(object sender, MouseEventArgs e)
        {
            if (Shape != 1)
            {
                if(Shape == 2)
                {
                    this.rectangle = new Rectangle(e.X, e.Y);
                    objectShape.Add(this.rectangle);
                }
                /*
                if (e.Button == MouseButtons.Left)
                {                  
                    initPoint = currentPoint = e.Location;

                    Drawing = true;
                }*/
            }
        }

        private void panel1_onMouseMove(object sender, MouseEventArgs e)
        {
            if (Shape != 1)
            {
                if(Shape == 2)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        if (this.rectangle != null)
                        {
                            int width = e.X - this.rectangle.X;
                            int height = e.Y - this.rectangle.Y;

                            if (width > 0 && height > 0)
                            {
                                this.rectangle.Width = width;
                                this.rectangle.Height = height;
                            }
                        }
                    }
                }
                /*
                if (e.Button == MouseButtons.Left)
                {
                    currentPoint = e.Location;

                    if (Drawing)
                    {
                        panel1.Invalidate();
                    }
                }*/
            }
        }

        private void panel1_onMouseUp(object sender, MouseEventArgs e)
        {
            if (Shape == 2)
            {
                if (rectangle != null)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        this.rectangle.Select();
                    }                    
                }
            }
            /*
            if (Drawing)
            {
                Drawing = false;
                
                var rc = getRectangle();

                if (rc.Width > 0 && rc.Height > 0)
                {
                    if (Shape == 2)
                    {
                        objectShape.Add(rc);
                    }

                    if (Shape == 3)
                    {
                        circles.Add(rc);
                    }                    
                }*/

                /*
                if (Shape == 4)
                {
                    points.Add();
                }*/

                //panel1.Invalidate();
            }
            
        //}
    /*
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
        */
    } 
}
