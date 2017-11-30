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
        /*
        private IToolbox toolbox;
        private IToolbar toolbar;
        private IMenubar menubar;
        private IPlugin[] plugins;*/

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
            canvas1.Name = "Untitled-1";
            this.editor.AddCanvas(canvas1);

            #endregion

            //#region Toolbox

            // Initializing toolbox
            /*
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

            if (plugins != null)
            {
                for (int i = 0; i < this.plugins.Length; i++)
                {
                    this.toolbox.Register(plugins[i]);
                }
            }

            this.toolbox.ToolSelected += Toolbox_ToolSelected;

            #endregion
            */
        }
    } 
}
