using System.Drawing;
using System.Drawing.Drawing2D;
using GraphViewUI.ViewModel;
using System.Windows;
using System.Windows.Shapes;
using Point = System.Windows.Point;

namespace GraphViewUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            DataContext = new MainViewModel();

        }


        //public void DrawLineToBox()
        //{
        //    for (int i = 0; i < _model.DrawLines().Count; i++)
        //    {
        //        var myLine = new Line
        //        {
        //            Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
        //            StrokeThickness = 29,
        //            X2 = drawPoint.X,
        //            Y2 = drawPoint.Y


        //            CanvasToDrawOn.Children.Add(myLine);

        //        };
        //    }
        
    }
}
