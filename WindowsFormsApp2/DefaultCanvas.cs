using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class DefaultCanvas : Control, ICanvas
    {
        private ITool activeTool;
        private List<ObjectShape> objectShapes = new List<ObjectShape>();

        public DefaultCanvas()
        {
            Init();
        }

        private void Init()
        {
            this.objectShapes = new List<ObjectShape>();
            this.DoubleBuffered = true;

            this.BackColor = Color.White;
            this.Dock = DockStyle.Fill;

            this.Paint += DefaultCanvas_Paint;
            this.MouseDown += DefaultCanvas_MouseDown;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseDoubleClick += DefaultCanvas_MouseDoubleClick;    
        }
       
        private void DefaultCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDoubleClick(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (objectShapes.Count > 0)
            {
                foreach(ObjectShape obj in objectShapes)
                {
                    obj.Deselect();
                }
            }
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {            
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }
        }

        private void DefaultCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (ObjectShape obj in objectShapes)
            {
                obj.SetGraphics(e.Graphics);
                obj.Draw();
            }
        }

        public void Repaint()
        {
            Invalidate();
            Update();
        }
        
        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }
        
        public ITool GetActiveTool()
        {
            return this.activeTool;
        }

        public void SetBackgroundColor(Color color)
        {
            this.BackColor = color;
        }

        public void AddDrawingObject(ObjectShape drawingObject)
        {
            this.objectShapes.Add(drawingObject);
        }

        public void RemoveDrawingObject(ObjectShape drawingObject)
        {
            this.objectShapes.Remove(drawingObject);
        }

        public ObjectShape GetObjectAt(int x, int y)
        {
            foreach (ObjectShape obj in objectShapes)
            {
                if (obj.Intersect(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        public ObjectShape SelectObjectAt(int x, int y)
        {
            ObjectShape obj = GetObjectAt(x, y);

            if (obj != null)
            {
                obj.Select();
            }

            return obj;
        }

        public void DeselectAllObjects()
        {
            foreach (ObjectShape drawObj in objectShapes)
            {
                drawObj.Deselect();
            }
        }

        ObjectShape ICanvas.GetObjectAt(int x, int y)
        {
            foreach (ObjectShape obj in objectShapes)
            {
                if (obj.Intersect(x, y))
                {
                    return obj;
                }
            }
            return null;
        }

        ObjectShape ICanvas.SelectObjectAt(int x, int y)
        {
            ObjectShape obj = GetObjectAt(x, y);

            if (obj != null)
            {
                obj.Select();
            }

            return obj;
        }
    }
}