using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    public interface ICanvas
    {
        String Name { get; set; }
        ITool GetActiveTool();
        void SetActiveTool(ITool tool);
        void Repaint();
        void SetBackgroundColor(Color color);

        void AddDrawingObject(ObjectShape drawingObject);
        void RemoveDrawingObject(ObjectShape drawingObject);

        ObjectShape GetObjectAt(int x, int y);
        ObjectShape SelectObjectAt(int x, int y);
        void DeselectAllObjects();
        List<ObjectShape> getObjectShapes();
        void setObjectShapes(List<ObjectShape> objShapes);
        void setUndoRedoObj(UndoRedo undoRedoObj);
    }
}