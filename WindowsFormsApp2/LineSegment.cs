using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp2
{
    public class LineSegment : ObjectShape
    {
        public Point startPoint { get; set; }
        public Point endPoint { get; set; }

        private Pen pen;

        public LineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.startPoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.endPoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.startPoint, this.endPoint);
            }
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            if (this.GetGraphics() != null)
            {
                this.GetGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                this.GetGraphics().DrawLine(pen, this.startPoint, this.endPoint);
            }
        }

        public override void RenderOnPreview()
        {
            
        }
    }
}