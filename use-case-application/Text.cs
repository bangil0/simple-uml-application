using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCaseApp
{
    public class Text : ObjectShape
    {
        public string Value { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        private Brush brush;
        private Font font;
        private SizeF textSize;
        internal string Cancel;

        public Text()
        {
            this.brush = new SolidBrush(Color.Black);

            FontFamily fontFamily = new FontFamily("Arial");
            font = new Font(
               fontFamily,
               16,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public override bool Add(ObjectShape obj)
        {
            return false;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            if ((xTest >= X && xTest <= X + textSize.Width) && (yTest >= Y && yTest <= Y + textSize.Height))
            {
                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public override bool Remove(ObjectShape obj)
        {
            return false;
        }

        public override void RenderOnEditingView()
        {
            GetGraphics().DrawString(Value, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(Value, font);
        }

        public override void RenderOnPreview()
        {
            GetGraphics().DrawString(Value, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(Value, font);
        }

        public override void RenderOnStaticView()
        {
            GetGraphics().DrawString(Value, font, brush, new PointF(X, Y));
            textSize = GetGraphics().MeasureString(Value, font);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            X += xAmount;
            Y += yAmount;
        }

        public override object Clone()
        {
            Text copyObj = new Text();
            copyObj.Value = this.Value;
            copyObj.X = this.X;
            copyObj.Y = this.Y;
            copyObj.brush = this.brush;
            copyObj.font = this.font;
            copyObj.textSize = this.textSize;
            copyObj.ChangeState(StaticState.GetInstance());
            Debug.WriteLine("Cloning TEXT " + copyObj.ID);
            return copyObj;
        }

        public override bool IsSelectedOnCorner(int x, int y)
        {
            return false;
        }

        public override void Resize(int x, int y)
        {
           
        }
    }
}
