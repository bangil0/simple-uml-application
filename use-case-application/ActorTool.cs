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
                initX = e.X;
                initY = e.Y;

                actor = new Actor(e.X, e.Y);
                this.canvas.AddDrawingObject(this.actor);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.actor != null)
                {
                    if (e.X > initX && e.Y > initY)
                    {
                        actor.X = e.X;
                        actor.Y = e.Y;

                        actor.Width = e.X - actor.X;
                        actor.Height = e.Y - actor.Y;
                    }

                    if (e.X < initX && e.Y > initY)
                    {
                        actor.X = e.X;
                        actor.Y = initY;

                        actor.Width = initX - actor.X;
                        actor.Height = e.Y - actor.Y;
                    }

                    if (e.X > initX && e.Y < initY)
                    {
                        actor.X = initX;
                        actor.Y = e.Y;

                        actor.Width = e.X - actor.X;
                        actor.Height = initY - actor.Y;
                    }

                    if (e.X < initX && e.Y < initY)
                    {
                        actor.X = e.X;
                        actor.Y = e.Y;

                        actor.Width = initX - actor.X;
                        actor.Height = initY - actor.Y;
                    }
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            actor.ChangeState(EditState.GetInstance());

            if (this.actor.Height > 0 && this.actor.Width > 0)
            {
                canvas.initUndoRedo();
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