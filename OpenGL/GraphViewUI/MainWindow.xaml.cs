using System;
using System.Drawing.Drawing2D;
using GraphViewUI.ViewModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using SharpGL.SceneGraph;
using SharpGL;
using SharpGL.WPF;

namespace GraphViewUI {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            DataContext = new MainViewModel();
        }

        private void openGLControl_OpenGLDraw(object sender, OpenGLEventArgs e) {
            SharpGL.OpenGL gl = e.OpenGL;

            gl.MatrixMode(SharpGL.OpenGL.GL_PROJECTION);

            gl.LoadIdentity();

            const float left = -5;
            const float right = 5;
            const float bottom = -5;
            const float top = 5;

            gl.Ortho2D(left, right, bottom, top);

            gl.Color(1, 1, 1);

            gl.Begin(SharpGL.OpenGL.GL_LINES);

            gl.Vertex(0, bottom);
            gl.Vertex(0, top);
            gl.Vertex(left, 0);
            gl.Vertex(right, 0);

            gl.End();

            gl.Color(0.0f, 0.0f, 1.0f);
            gl.Begin(SharpGL.OpenGL.GL_LINE_STRIP);

            for (var x = -4.0; x < 4; x += 0.1)
                gl.Vertex(x, Math.Sin(x));

            gl.Viewport(20, 20, 200, 200);

            gl.End();
            gl.Flush();

        }

    }
}
