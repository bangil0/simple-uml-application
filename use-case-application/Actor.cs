using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace UseCaseApp
{
    public class Actor : ObjectShape
    {
        private Ellipse ellipse;
        private LineSegment LineBody;
        private LineSegment LineHand;
        private LineSegment LineRightLeg;
        private LineSegment LineLeftLeg;

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;
        private List<ObjectShape> drawingObjects;

        private Point startPoint;
        private Point endPoint;

        public Actor()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;

            drawingObjects = new List<ObjectShape>();
        }

        public Actor(int x, int y) : this()
        {
            this.X = x;
            this.Y = y;
            this.Width = 20;
            this.Height = 60;
            this.ellipse = new Ellipse(X, Y, 20, 20);

            startPoint.X = X + 10;
            startPoint.Y = Y + 20;
            endPoint.X = X + 10;
            endPoint.Y = Y + 40;
            this.LineBody = new LineSegment(startPoint, endPoint);

            startPoint.X = X - 5;
            startPoint.Y = Y + 30;
            endPoint.X = X + 25;
            endPoint.Y = Y + 30;
            this.LineHand = new LineSegment(startPoint, endPoint);

            startPoint.X = X + 10;
            startPoint.Y = Y + 40;
            endPoint.X = X - 5;
            endPoint.Y = Y + 60;
            this.LineLeftLeg = new LineSegment(startPoint, endPoint);

            startPoint.X = X + 10;
            startPoint.Y = Y + 40;
            endPoint.X = X + 25;
            endPoint.Y = Y + 60;
            this.LineRightLeg = new LineSegment(startPoint, endPoint);

            this.Add(ellipse);
            this.Add(LineBody);
            this.Add(LineHand);
            this.Add(LineLeftLeg);
            this.Add(LineRightLeg);
        }

        public Actor(int x, int y, int width, int height) : this(x, y)
        {
            this.Width = width;
            this.Height = height;
        }

        public override bool Add(ObjectShape obj)
        {
            drawingObjects.Add(obj);

            return true;
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

        public override bool Remove(ObjectShape obj)
        {
            drawingObjects.Remove(obj);

            return true;
        }

        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnPreview();
            }
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;

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

            foreach (ObjectShape obj in drawingObjects)
            {
                obj.SetGraphics(GetGraphics());
                obj.RenderOnEditingView();
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

        public override object Clone()
        {
            Actor objCopy = new Actor();

            objCopy.X = this.X;
            objCopy.Y = this.Y;

            objCopy.Width = this.Width;
            objCopy.Height = this.Height;
            objCopy.pen = this.pen;

            objCopy.drawingObjects = this.drawingObjects;
            objCopy.ID = this.ID;

            objCopy.ChangeState(StaticState.GetInstance());

            return objCopy;
        }

        public override bool IsSelectedOnCorner(int x, int y)
        {
            return false;
        }

        public override void Resize(int x, int y)
        {

        }

        public override string GetText()
        {
            return "";
        }

        public override void SetText(string value)
        {

        }
    }
}
