using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public class DefaultCanvas : Control, ICanvas
    {
        //private ITool activeTool;
        private List<ObjectShape> objectShapes = new List<ObjectShape>();
        List<Rectangle> rectangles = new List<Rectangle>();

        Rectangle rectangle;

        //public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            this.MouseUp += DefaultCanvas_MouseUp;
            this.MouseMove += DefaultCanvas_MouseMove;
            this.MouseDoubleClick += DefaultCanvas_MouseDoubleClick;
            this.KeyDown += DefaultCanvas_KeyDown;
            this.KeyUp += DefaultCanvas_KeyUp;
            this.PreviewKeyDown += DefaultCanvas_PreviewKeyDown;
        }

        private void DefaultCanvas_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    e.IsInputKey = true;
                    break;
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
                case Keys.Down:
                    e.IsInputKey = true;
                    break;
                case Keys.Left:
                    e.IsInputKey = true;
                    break;
                case Keys.Right:
                    e.IsInputKey = true;
                    break;
            }
        }

        private void DefaultCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyUp(sender, e);
            }*/
        }

        private void DefaultCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolKeyDown(sender, e);
            }*/
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                switch (keyData)
                {
                    case Keys.Control | Keys.G:
                        Console.WriteLine("<CTRL> + G Captured");
                        /*
                        if (this.activeTool != null)
                        {
                            this.activeTool.ToolHotKeysDown(this, Keys.Control | Keys.G);
                            this.Repaint();
                        }*/
                        break;
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DefaultCanvas_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDoubleClick(sender, e);
                this.Repaint();
            }*/
        }

        private void DefaultCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            this.rectangle = new Rectangle(e.X, e.Y);
            this.objectShapes.Add(rectangle);

            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseDown(sender, e);
                this.Repaint();
            }*/
        }

        private void DefaultCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.rectangle != null)
                {
                    int width = e.X - this.rectangle.X;
                    int height = e.Y - this.rectangle.Y;

                    if (width > 0 && height > 0)
                    {
                        this.rectangle.Width = width;
                        this.rectangle.Height = height;
                    }
                }
            }

            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseMove(sender, e);
                this.Repaint();
            }*/
        }

        private void DefaultCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            /*
            if (this.activeTool != null)
            {
                this.activeTool.ToolMouseUp(sender, e);
                this.Repaint();
            }*/
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
            this.Invalidate();
            this.Update();
        }
        /*
        public void SetActiveTool(ITool tool)
        {
            this.activeTool = tool;
        }
        
        public ITool GetActiveTool()
        {
            return this.activeTool;
        }*/

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
        /*
        public void AddDrawingObject(ObjectShape drawingObject)
        {
            throw new NotImplementedException();
        }

        public void RemoveDrawingObject(ObjectShape drawingObject)
        {
            throw new NotImplementedException();
        }*/

        ObjectShape ICanvas.GetObjectAt(int x, int y)
        {
            throw new NotImplementedException();
        }

        ObjectShape ICanvas.SelectObjectAt(int x, int y)
        {
            throw new NotImplementedException();
        }
    }
}