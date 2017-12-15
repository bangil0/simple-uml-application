using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UseCaseApp.Tools;

namespace UseCaseApp
{
    public partial class UseCaseMaker : Form
    {
        private IEditor editor;
        private IToolbox toolbox;
        private UndoRedo undoRedoObj = null;

        public UseCaseMaker()
        {
            InitializeComponent();
            InitUI();
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyPress;
        }

        private void InitUI()
        {
            //Debug.WriteLine("Initializing UI objects.");
            //this.Menu = new MainMenu();
            //MenuItem undo = new MenuItem("Undo");
            //this.Menu.MenuItems.Add(undo);
            //MenuItem redo = new MenuItem("Redo");
            //this.Menu.MenuItems.Add(redo);

            //undo.Click += new System.EventHandler(this.undo_Click);
            //redo.Click += new System.EventHandler(this.redo_Click);

            #region Editor and Canvas

            Debug.WriteLine("Loading canvas...");
            this.editor = new DefaultEditor();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

            ICanvas canvas1 = new DefaultCanvas();
            this.editor.AddCanvas(canvas1);
            this.undoRedoObj = new UndoRedo(canvas1);
            canvas1.setUndoRedoObj(this.undoRedoObj);
            canvas1.initUndoRedo();

            #endregion

            #region Toolbox

            // Initializing toolbox
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbox);
            this.editor.Toolbox = toolbox;

            #endregion

            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");

            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new RectangleTool());
            this.toolbox.AddTool(new EllipseTool());
            this.toolbox.AddTool(new ActorTool());

            this.toolbox.AddSeparator();

            this.toolbox.AddTool(new SelectionTool());
            this.toolbox.AddTool(new DeletionTool());
            this.toolbox.AddTool(new UndoTool());
            this.toolbox.AddTool(new RedoTool());

            this.toolbox.ToolSelected += Toolbox_ToolSelected;
            this.toolbox.ToolClicked += Toolbox_ToolClicked;
            #endregion
        }

        private void Toolbox_ToolClicked(ITool tool)
        {
            if(tool.Name == "undo")
            {
                undoRedoObj.Undo(1);
            }
            else if(tool.Name == "redo")
            {
                undoRedoObj.Redo(1);
            }
            ICanvas canvas = this.editor.GetSelectedCanvas();
            canvas.Repaint();
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.editor != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.SetActiveTool(tool);
                tool.TargetCanvas = canvas;
                this.Cursor = tool.Cursor;
            }
        }

        //private void undo_Click(object sender, System.EventArgs e)
        //{
        //    undoRedoObj.Undo(1);
        //    ICanvas canvas = this.editor.GetSelectedCanvas();
        //    canvas.Repaint();
        //}

        //private void redo_Click(object sender, System.EventArgs e)
        //{
        //    undoRedoObj.Redo(1);
        //    ICanvas canvas = this.editor.GetSelectedCanvas();
        //    canvas.Repaint();
        //}

        void Form1_KeyPress(object sender, KeyEventArgs e)
        {
            Debug.WriteLine("KEY" + e.KeyCode);
            if (e.Control && e.KeyCode == Keys.Z)
            {
                undoRedoObj.Undo(1);
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.Repaint();
            }

            if (e.Control && e.KeyCode == Keys.Y)
            {
                undoRedoObj.Redo(1);
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.Repaint();
            }
        }

        //void UnDoObject_EnableDisableUndoRedoFeature(object sender, EventArgs e)
        //{
        //    if (undoRedoObj.IsUndoPossible())
        //    {

        //        btnUndo.IsEnabled = true;
        //    }
        //    else
        //    {
        //        btnUndo.IsEnabled = false;

        //    }

        //    if (undoRedoObj.IsRedoPossible())
        //    {
        //        btnRedo.IsEnabled = true;
        //    }
        //    else
        //    {
        //        btnRedo.IsEnabled = false;
        //    }
        //}
    }
}
