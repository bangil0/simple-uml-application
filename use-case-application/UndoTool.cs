using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UseCaseApp
{
    public class UndoTool : ToolStripButton, ITool
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

        public UndoTool()
        {
            this.Name = "undo";
            this.ToolTipText = "Undo";
            this.Image = IconSet.undo;
            this.CheckOnClick = false;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {

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
