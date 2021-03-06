﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace UseCaseApp
{
    public class LineSegment : ObjectShape
    {
        private const double EPSILON = 3.0;

        public Point Startpoint { get; set; }
        public Point Endpoint { get; set; }

        private Pen pen;

        public LineSegment()
        {
            this.pen = new Pen(Color.Black);
            pen.Width = 1.5f;
        }

        public LineSegment(Point startpoint) :
            this()
        {
            this.Startpoint = startpoint;
        }

        public LineSegment(Point startpoint, Point endpoint) :
            this(startpoint)
        {
            this.Endpoint = endpoint;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            this.GetGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
        }

        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

            this.GetGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);

        }

        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;

            this.GetGraphics().SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.GetGraphics().DrawLine(pen, this.Startpoint, this.Endpoint);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = Endpoint.Y - m * Endpoint.X;
            double y_point = m * xTest + b;

            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                System.Diagnostics.Debug.WriteLine("Object " + ID + " is selected.");
                return true;
            }
            return false;
        }

        public double GetSlope()
        {
            double m = (double)(Endpoint.Y - Startpoint.Y) / (double)(Endpoint.X - Startpoint.X);
            return m;
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.Startpoint = new Point(this.Startpoint.X + xAmount, this.Startpoint.Y + yAmount);
            this.Endpoint = new Point(this.Endpoint.X + xAmount, this.Endpoint.Y + yAmount);
        }

        public override bool Add(ObjectShape obj)
        {
            return false;
        }

        public override bool Remove(ObjectShape obj)
        {
            return false;
        }

        public override object Clone()
        {
            LineSegment objCopy = new LineSegment();
            objCopy.Startpoint = this.Startpoint;
            objCopy.Endpoint = this.Endpoint;
            objCopy.pen = this.pen;
            objCopy.ID = this.ID;
            objCopy.ChangeState(StaticState.GetInstance());
            Debug.WriteLine("Cloning LINE " + objCopy.ID);
            return objCopy;
        }

        public override bool IsSelectedOnCorner(int x, int y)
        {
            if ((Startpoint.X == x && Startpoint.Y == y) || (Endpoint.X == x && Endpoint.Y == y))
            {
                MessageBox.Show("line selected on corner");
                return true;
            }

            return false;
        }

        public override void Resize(int x, int y)
        {
            //Endpoint.X = x;
            //Endpoint.Y = y;
        }

        public override string GetText()
        {
            return "";
            //throw new NotImplementedException();
        }

        public override void SetText(string value)
        {
            throw new NotImplementedException();
        }
    }
}