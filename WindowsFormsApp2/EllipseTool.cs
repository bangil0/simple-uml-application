using System;
using System.Windows.Forms;
using WindowsFormsApp2.State;

namespace WindowsFormsApp2
{
    public class EllipseTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Ellipse ellipse;


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
                    int width = e.X - this.ellipse.X;
                    int height = e.Y - this.ellipse.Y;

                    if (width > 0 && height > 0)
                    {
                        this.ellipse.Width = width;
                        this.ellipse.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            //ellipse.ChangeState(StaticState.GetInstance());
            if (ellipse != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.ellipse.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.ellipse);
                }
            }

        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

    }



}
