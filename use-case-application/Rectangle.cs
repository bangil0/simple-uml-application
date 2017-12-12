using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using UseCaseApp.State;

namespace UseCaseApp
{
    class Rectangle : ObjectShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;
        private List<ObjectShape> drawingObjects;

        public Rectangle()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
            drawingObjects = new List<ObjectShape>();
        }

        public Rectangle(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
        }

        public Rectangle(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnStaticView();
            }
        }

        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
            }

        }

        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            GetGraphics().DrawRectangle(this.pen, X, Y, Width, Height);

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnPreview();
            }
        }


        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.Translate(x, y, xAmount, yAmount);
            }
        }

        public override bool Add(ObjectShape obj)
        {
            drawingObjects.Add(obj);

            return true;
        }

        public override bool Remove(ObjectShape obj)
        {
            drawingObjects.Remove(obj);

            return true;
        }

        public override object Clone()
        {
            Rectangle objRectCopy = new Rectangle();
            objRectCopy.X = this.X;
            objRectCopy.Y = this.Y;
            objRectCopy.Width = this.Width;
            objRectCopy.Height = this.Height;
            objRectCopy.pen = this.pen;
            objRectCopy.drawingObjects = this.drawingObjects;
            objRectCopy.ID = this.ID;
            objRectCopy.ChangeState(StaticState.GetInstance());

            return objRectCopy;
        }
    }
}
