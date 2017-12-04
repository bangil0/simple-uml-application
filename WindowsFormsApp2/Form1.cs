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

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private IEditor editor;
        private IToolbox toolbox;
        //private IPlugin[] plugins;
        //private IToolbar toolbar;
        //private IMenubar menubar;
        

        public Form1()
        {
            InitializeComponent();

            InitUI();
        }

        private void InitUI()
        {
            Debug.WriteLine("Initializing UI objects.");

            #region Editor and Canvas

            Debug.WriteLine("Loading canvas...");
            this.editor = new DefaultEditor();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.editor);

            ICanvas canvas1 = new DefaultCanvas();
            this.editor.AddCanvas(canvas1);

            #endregion

            #region Toolbox

            // Initializing toolbox
            
            Button button = new Button();
            
            Debug.WriteLine("Loading toolbox...");
            this.toolbox = new DefaultToolbox();
            this.toolStripContainer1.LeftToolStripPanel.Controls.Add((Control)this.toolbox);
            this.editor.Toolbox = toolbox;

            #endregion

            
            #region Tools

            // Initializing tools
            Debug.WriteLine("Loading tools...");
            this.toolbox.AddSeparator();
            this.toolbox.AddTool(new RectangleTool());
            /*
            if (plugins != null)
            {
                for (int i = 0; i < this.plugins.Length; i++)
                {
                    this.toolbox.Register(plugins[i]);
                }
            }*/

            //this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion
        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.editor != null)
            {
                Debug.WriteLine("Tool " + tool.Name + " is selected");
                ICanvas canvas = this.editor.GetSelectedCanvas();
                canvas.SetActiveTool(tool);
                tool.TargetCanvas = canvas;
            }
        }
    } 
}
