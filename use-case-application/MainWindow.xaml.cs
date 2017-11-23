using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UseCaseApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Point initPoint;
        Point endPoint;

        int shape = 1;

        Rectangle rectangle;
        Ellipse ellipse;
        Line line;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ButtonState == MouseButtonState.Pressed)
            {
                initPoint = e.GetPosition(canvas);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if(shape == 1) //brush
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    Line line = new Line
                    {
                        Stroke = SystemColors.WindowFrameBrush,

                        X1 = initPoint.X,
                        Y1 = initPoint.Y,
                        X2 = e.GetPosition(canvas).X,
                        Y2 = e.GetPosition(canvas).Y
                    };

                    initPoint = e.GetPosition(canvas);

                    canvas.Children.Add(line);
                }
            }
        }

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(shape == 2) //rectangle
            {
                endPoint = e.GetPosition(canvas);

                rectangle = new Rectangle();
                rectangle.Stroke = SystemColors.WindowFrameBrush;
                              
                double rect_width = e.GetPosition(canvas).X - initPoint.X;
                double rect_height = e.GetPosition(canvas).Y - initPoint.Y;
                
                if(rect_width > 0 && rect_height > 0)
                {
                    Canvas.SetLeft(rectangle, initPoint.X);
                    Canvas.SetTop(rectangle, initPoint.Y);

                    rectangle.Width = rect_width;
                    rectangle.Height = rect_height;
                }
                else if(rect_width > 0 && rect_height < 0)
                {
                    Canvas.SetLeft(rectangle, initPoint.X);
                    Canvas.SetTop(rectangle, endPoint.Y);

                    rectangle.Width = rect_width;
                    rectangle.Height = rect_height * -1;
                }
                else if(rect_width < 0 && rect_height > 0)
                {
                    Canvas.SetLeft(rectangle, endPoint.X);
                    Canvas.SetTop(rectangle, initPoint.Y);

                    rectangle.Width = rect_width* -1;
                    rectangle.Height = rect_height;
                }
                else if(rect_width < 0 && rect_height < 0)
                {
                    Canvas.SetLeft(rectangle, endPoint.X);
                    Canvas.SetTop(rectangle, endPoint.Y);

                    rectangle.Width = rect_width * -1;
                    rectangle.Height = rect_height * -1;
                }                

                canvas.Children.Add(rectangle);
            }
            else if (shape == 3) //ellipse
            {
                endPoint = e.GetPosition(canvas);

                ellipse = new Ellipse();
                ellipse.Stroke = SystemColors.WindowFrameBrush;

                double ellipse_width = e.GetPosition(canvas).X - initPoint.X;
                double ellipse_height = e.GetPosition(canvas).Y - initPoint.Y;

                if (ellipse_width > 0 && ellipse_height > 0)
                {
                    Canvas.SetLeft(ellipse, initPoint.X);
                    Canvas.SetTop(ellipse, initPoint.Y);

                    ellipse.Width = ellipse_width;
                    ellipse.Height = ellipse_height;
                }
                else if (ellipse_width > 0 && ellipse_height < 0)
                {
                    Canvas.SetLeft(ellipse, initPoint.X);
                    Canvas.SetTop(ellipse, endPoint.Y);

                    ellipse.Width = ellipse_width;
                    ellipse.Height = ellipse_height * -1;
                }
                else if (ellipse_width < 0 && ellipse_height > 0)
                {
                    Canvas.SetLeft(ellipse, endPoint.X);
                    Canvas.SetTop(ellipse, initPoint.Y);

                    ellipse.Width = ellipse_width * -1;
                    ellipse.Height = ellipse_height;
                }
                else if (ellipse_width < 0 && ellipse_height < 0)
                {
                    Canvas.SetLeft(ellipse, endPoint.X);
                    Canvas.SetTop(ellipse, endPoint.Y);

                    ellipse.Width = ellipse_width * -1;
                    ellipse.Height = ellipse_height * -1;
                }

                canvas.Children.Add(ellipse);
            }
            else if (shape == 4) //line
            {
                endPoint = e.GetPosition(canvas);

                line = new Line();
                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = initPoint.X;
                line.Y1 = initPoint.Y;
                line.X2 = endPoint.X;
                line.Y2 = endPoint.Y;

                canvas.Children.Add(line);
            }
            
        }

        private void buttonLine_Click(object sender, RoutedEventArgs e)
        {
            shape = 4;
        }

        private void buttonCircle_Click(object sender, RoutedEventArgs e)
        {
            shape = 3;
        }

        private void buttonRectangle_Click(object sender, RoutedEventArgs e)
        {
            shape = 2;
        }

        private void buttonBrush_Click(object sender, RoutedEventArgs e)
        {
            shape = 1;
        }

    }
}
