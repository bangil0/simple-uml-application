using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UseCaseApp
{
    public class RedoTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private ObjectShape selectedObject;
        private int xInitial;
        private int yInitial;

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

        public RedoTool()
        {
            this.Name = "redo";
            this.ToolTipText = "Redo";
            this.Image = IconSet.redo;
            this.CheckOnClick = false;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                canvas.RemoveDrawingObject(selectedObject);
            }

        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {

        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        public void ToolKeyUp(object sender, KeyEventArgs e)
        {

        }

        public void ToolKeyDown(object sender, KeyEventArgs e)
        {

        }

        public void ToolHotKeysDown(object sender, Keys e)
        {

        }
    }
}
