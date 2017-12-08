using System;
using System.Diagnostics;
using System.Windows.Forms;
using WindowsFormsApp2.State;

namespace WindowsFormsApp2.Tools
{
    public class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;
        private ObjectShape selectedObject;

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

        public RectangleTool()
        {            
            this.Name = "Rectangle tool";
            this.ToolTipText = "Rectangle tool";
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                rectangle = new Rectangle(e.X, e.Y);
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
            rectangle.ChangeState(EditState.GetInstance());
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Text text = new WindowsFormsApp2.Text();

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