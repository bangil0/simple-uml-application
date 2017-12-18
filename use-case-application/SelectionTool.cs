using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseCaseApp
{
    public class SelectionTool : ToolStripButton, ITool
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

        public SelectionTool()
        {
            this.Name = "Selection tool";
            this.ToolTipText = "Selection tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            this.xInitial = e.X;
            this.yInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    if (canvas.SelectObjectOnCorner(xInitial, yInitial))
                    {
                        selectedObject.ChangeState(PreviewState.GetInstance());
                    }
                    else
                    {
                        int xAmount = e.X - xInitial;
                        int yAmount = e.Y - yInitial;

                        xInitial = e.X;
                        yInitial = e.Y;

                        selectedObject.Translate(e.X, e.Y, xAmount, yAmount);
                    }                   
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    if (canvas.SelectObjectOnCorner(xInitial, yInitial))
                    {
                        selectedObject.ChangeState(EditState.GetInstance());

                        selectedObject.Resize(e.X, e.Y);
                    }

                    canvas.initUndoRedo();
                }
            }
        }

        public void ToolMouseDoubleClick(object sender, MouseEventArgs e)
        {
            string input;
            canvas.DeselectAllObjects();
            selectedObject = canvas.SelectObjectAt(e.X, e.Y);
            
            if (selectedObject != null && selectedObject is Text)
            {
                input = Microsoft.VisualBasic.Interaction.InputBox("Input Text", "Text Box", this.selectedObject.GetText(), 500, 300);

                if (input.Length > 0)
                {
                    this.selectedObject.SetText(input.ToString());
                }
            }
            else
            {
                Text text = new Text();
                input = Microsoft.VisualBasic.Interaction.InputBox("Input Text", "Text Box", "", 500, 300);
                text.Value = input;

                canvas.AddDrawingObject(text);
                text.X = e.X;
                text.Y = e.Y;

            }
           

            Debug.WriteLine("selection tool double click");

            canvas.initUndoRedo();
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
