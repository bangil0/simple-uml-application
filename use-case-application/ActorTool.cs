using System;
using System.Windows.Forms;
using System.Drawing;
using UseCaseApp.State;

namespace UseCaseApp
{
    public class ActorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Actor actor;

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

        public ActorTool()
        {
            this.Name = "Actor tool";
            this.ToolTipText = "Actor";
            this.Image = IconSet.actor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                actor = new Actor(e.X, e.Y);
                this.canvas.AddDrawingObject(this.actor);
                //this.Image = Image.FromFile("E:\\Kuliah\\Semester 7\\KPL\\simple-uml-application\\use-case-application\\resources\\actor.png");

            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.actor != null)
                {
                    int width = e.X - this.actor.X;
                    int height = e.Y - this.actor.Y;

                    if (width > 0 && height > 0)
                    {
                        this.actor.Width = width;
                        this.actor.Height = height;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            actor.ChangeState(PreviewState.GetInstance());
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