using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public delegate void ToolSelectedEventHandler(ITool tool);

    public interface IToolbox : IPluginHost
    {
        event ToolSelectedEventHandler ToolSelected;
        void AddTool(ITool tool);
        void RemoveTool(ITool tool);
        void AddSeparator();
        ITool ActiveTool { get; set; }
    }
}