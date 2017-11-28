using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Drawing;

namespace WindowsFormsApp2
{
    public abstract class ObjectShape
    {
        public Guid ID { get; set; }

        public DrawingState State
        {
            get
            {
                return this.state;
            }
        }

        private DrawingState state;
        private Graphics graphics;

        public ObjectShape()
        {
            ID = Guid.NewGuid();
            this.ChangeState(PreviewState.GetInstance());
        }

        public abstract bool Add(ObjectShape obj);
        public abstract bool Remove(ObjectShape obj);

        public abstract bool Intersect(int xTest, int yTest);

        public abstract void RenderOnPreview();
        public abstract void RenderOnEditingView();
        public abstract void RenderOnStaticView();

        public void ChangeState(DrawingState state)
        {
            this.state = state;
        }

        public virtual void Draw()
        {
            this.state.Draw(this);
        }

        public virtual void SetGraphics(Graphics graphics)
        {
            this.graphics = graphics;
        }

        public virtual Graphics GetGraphics()
        {
            return this.graphics;
        }

        public void Select()
        {
            Debug.WriteLine("Object id= " + ID.ToString() + "is selected.");
            this.state.Select(this);
        }

        public void Deselect()
        {
            Debug.WriteLine("Object id= " + ID.ToString() + "is deselected");
            this.state.Deselect(this);
        }
    }
}
