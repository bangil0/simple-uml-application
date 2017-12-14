using System;
using System.Windows.Forms;
using UseCaseApp.State;

namespace UseCaseApp
{
    public class LineTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private LineSegment lineSegment;

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

        public LineTool()
        {
            this.Name = "Relation Tool";
            this.ToolTipText = "Relation";
            this.Image = IconSet.relation;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                lineSegment = new LineSegment(new System.Drawing.Point(e.X, e.Y));
                lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                canvas.AddDrawingObject(lineSegment);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.lineSegment != null)
                {
                    lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            lineSegment.ChangeState(EditState.GetInstance());
            if(this.lineSegment.Startpoint != this.lineSegment.Endpoint)
            {
                canvas.initUndoRedo();
            }

            if (this.lineSegment != null)
            {
                lineSegment.Endpoint = new System.Drawing.Point(e.X, e.Y);
                lineSegment.Select();
            }
            else if (e.Button == MouseButtons.Right)
            {
                canvas.RemoveDrawingObject(this.lineSegment);
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, MouseEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}