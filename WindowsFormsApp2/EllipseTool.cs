using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class EllipseTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private Rectangle rectangle;

        //public Cursor Cursor;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }

            set
            {
                this.canvas = value;
            }
        }

        public EllipseTool()
        {
            this.Name = "Rectangle tool";
            this.ToolTipText = "Rectangle tool";
            //this.CheckOnClick = true;
            this.Image = IconSet.usecase;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MessageBox.Show("eyyy");

                //tadinya yang rectangle dengan 2 parameter ini dikomen
                rectangle = new Rectangle(e.X, e.Y);
                //rectangle = new Rectangle(e.X, e.Y, 100, 100);
                this.canvas.AddDrawingObject(this.rectangle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
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

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            //rectangle.ChangeState(StaticState.GetInstance());
            if (rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.rectangle.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.rectangle);
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }
    }
}