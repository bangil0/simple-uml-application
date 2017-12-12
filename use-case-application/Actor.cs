using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    public class Actor : ObjectShape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;
        private List<ObjectShape> drawingObjects;

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

        public override void RenderOnEditingView()
        {
            throw new NotImplementedException();
        }

        public override void RenderOnPreview()
        {

        }

        public override void RenderOnStaticView()
        {
            throw new NotImplementedException();
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
            objCopy.ChangeState(StaticState.GetInstance());
            return objCopy;
        }
    }
}
