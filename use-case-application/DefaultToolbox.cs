using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace UseCaseApp
{
    public class DefaultToolbox : ToolStrip, IToolbox
    {
        private ITool activeTool;

        public ITool ActiveTool
        {
            get
            {
                return this.activeTool;
            }

            set
            {
                this.activeTool = value;
            }
        }

        public event ToolSelectedEventHandler ToolSelected;

        public void AddSeparator()
        {
            this.Items.Add(new ToolStripSeparator());
        }

        public void AddTool(ITool tool)
        {
            if (tool is ToolStripButton)
            {
                ToolStripButton toggleButton = (ToolStripButton)tool;

                if (toggleButton.CheckOnClick)
                {
                    toggleButton.CheckedChanged += toggleButton_CheckedChanged;
                }

                this.Items.Add(toggleButton);
            }
        }

        public void RemoveTool(ITool tool)
        {
            throw new NotImplementedException();
        }

        private void toggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton button = (ToolStripButton)sender;

                if (button.Checked)
                {
                    if (button is ITool)
                    {
                        this.activeTool = (ITool)button;
                        Debug.WriteLine(this.activeTool.Name + " is activated.");

                        ToolSelected?.Invoke(this.activeTool);

                        UncheckInactiveToggleButtons();
                    }
                    else
                    {
                        throw new InvalidCastException("The tool is not an instance of ITool.");
                    }
                }
            }
        }

        private void UncheckInactiveToggleButtons()
        {
            foreach (ToolStripItem item in this.Items)
            {
                if (item != this.activeTool)
                {
                    if (item is ToolStripButton)
                    {
                        ((ToolStripButton)item).Checked = false;
                    }
                }
            }
        }
        
        public void Register(IPlugin plugin)
        {
            if (plugin != null)
            {
                Debug.WriteLine("Loading plugin: " + plugin.Name + "...");

                if (plugin is ITool)
                {
                    ITool pluginTool = (ITool)plugin;
                    AddTool(pluginTool);
                }

                Debug.WriteLine("Plugin " + plugin.Name + " is loaded successfuly.");
            }

        }
    }
}