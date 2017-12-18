using System;
using System.Windows.Forms;
using UseCaseApp.State;

namespace UseCaseApp
{
    public class EllipseTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Ellipse ellipse;
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
        public EllipseTool()
        {
            this.Name = "Ellipse tool";
            this.ToolTipText = "Ellipse";
            this.CheckOnClick = true;
            this.Image = IconSet.usecase;
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
        }
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                initX = e.X;
                initY = e.Y;

                ellipse = new Ellipse(e.X, e.Y);
                this.canvas.AddDrawingObject(ellipse);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.ellipse != null)
                {
                    if (e.X > initX && e.Y > initY)
                    {
                        ellipse.Width = e.X - ellipse.X;
                        ellipse.Height = e.Y - ellipse.Y;
                    }

                    if (e.X < initX && e.Y > initY)
                    {
                        ellipse.X = e.X;
                        ellipse.Y = initY;

                        ellipse.Width = initX - ellipse.X;
                        ellipse.Height = e.Y - ellipse.Y;
                    }

                    if (e.X > initX && e.Y < initY)
                    {
                        ellipse.X = initX;
                        ellipse.Y = e.Y;

                        ellipse.Width = e.X - ellipse.X;
                        ellipse.Height = initY - ellipse.Y;
                    }

                    if (e.X < initX && e.Y < initY)
                    {
                        ellipse.X = e.X;
                        ellipse.Y = e.Y;

                        ellipse.Width = initX - ellipse.X;
                        ellipse.Height = initY - ellipse.Y;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (ellipse != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.ellipse.ChangeState(EditState.GetInstance());
                    if (this.ellipse.Width > 0 && this.ellipse.Height > 0)
                    {
                        canvas.initUndoRedo();
                    }
                }
            }

        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            Text text = new UseCaseApp.Text();
        }

    }



}
