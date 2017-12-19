using System;
using System.Diagnostics;
using System.Windows.Forms;
using UseCaseApp.State;

namespace UseCaseApp.Tools
{
    public class RectangleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Rectangle rectangle;
        int initX;
        int initY;

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
                initX = e.X;
                initY = e.Y;

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
                    if (e.X > initX && e.Y > initY)
                    {
                        rectangle.Width = e.X - rectangle.X;
                        rectangle.Height = e.Y - rectangle.Y;
                    }

                    if (e.X < initX && e.Y > initY)
                    {
                        rectangle.X = e.X;
                        rectangle.Y = initY;

                        rectangle.Width = initX - rectangle.X;
                        rectangle.Height = e.Y - rectangle.Y;
                    }

                    if (e.X > initX && e.Y < initY)
                    {
                        rectangle.X = initX;
                        rectangle.Y = e.Y;

                        rectangle.Width = e.X - rectangle.X;
                        rectangle.Height = initY - rectangle.Y;
                    }

                    if (e.X < initX && e.Y < initY)
                    {
                        rectangle.X = e.X;
                        rectangle.Y = e.Y;

                        rectangle.Width = initX - rectangle.X;
                        rectangle.Height = initY - rectangle.Y;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            rectangle.ChangeState(EditState.GetInstance());

            if (this.rectangle.Height > 0 && this.rectangle.Width > 0)
            {
                canvas.initUndoRedo();
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Text text = new UseCaseApp.Text();

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