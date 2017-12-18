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

        private ICanvas canvas;
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
               12,
               FontStyle.Regular,
               GraphicsUnit.Pixel);
        }

        public override bool Add(ObjectShape obj)
        {
            return false;
        }

        public override bool Intersect(int xTest, int yTest)
        {
            /*
            Text text = new Text();
            if ((xTest >= X && xTest <= X + textSize.Width) && (yTest >= Y && yTest <= Y + textSize.Height))
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Input Text", "Text Box", text.Value, 0, 0);

                //Text text = new Text();
                text.X = xTest;
                text.Y = yTest;

                text.Value = input;
                canvas.RemoveDrawingObject(text);
                canvas.AddDrawingObject(text);
                Debug.WriteLine("selection tool double click");

                canvas.initUndoRedo();

                Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;*/

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

        public override string GetText()
        {
            return Value;
            //throw new NotImplementedException();
        }

        public override void SetText(string value)
        {
            this.Value = value;
        }
    }
}
