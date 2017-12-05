using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        private Rectangle rectangle;

        public Cursor Cursor;

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

        public RectangleTool()
        {            
            this.Name = "Rectangle tool";
            this.ToolTipText = "Rectangle tool";
            this.CheckOnClick = true;
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public void ToolHotKeysDown(object sender, Keys e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                MessageBox.Show("eyyy");
                //rectangle = new Rectangle(e.X, e.Y);
                rectangle = new Rectangle(e.X, e.Y, 100, 100);
                this.canvas.AddDrawingObject(rectangle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (rectangle != null)
                {
                    int width = e.X - rectangle.X;
                    int height = e.Y - rectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        rectangle.Width = width;
                        rectangle.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            rectangle.ChangeState(StaticState.GetInstance());

        }
    }
}