using System;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGlConsole {
    internal class Program {

        static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Tao Example");

            init_graphics();
            Glut.glutDisplayFunc(on_display);
            Glut.glutMainLoop();

        }

        private static void init_graphics() {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            var lightPos = new float[3] { 1, 0.5F, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(1, 1, 1, 1);
        }

        private static void on_display() {

            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_PROJECTION);

            Gl.glLoadIdentity();

            const float left = -50;
            const float bottom = -5;
            const float top = 20;
            const float right = 50;

            Gl.glOrtho(left, right, bottom, top, -1.0, 1.0);

            //Draw XY
            Gl.glColor3d(0, 0, 0);

            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2f(0, bottom);
            Gl.glVertex2f(0, top);
            Gl.glVertex2f(left, 0);
            Gl.glVertex2f(right, 0);

            Gl.glEnd();

            //Draw plot
            DrawPlot();

            Gl.glEnd();

        }

        private static void DrawPlot() {
            Gl.glColor3d(0, 0, 1);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (float x = -100; x < 100; x += 0.5f) {
                var y = 0.25f * x + 3 * (float)Math.Cos(100 * x) * (float)Math.Sin(x);
                var negative = y < 0;
                if (negative)
                    y = y * -1;
                Gl.glVertex2f(x, y);
            }
        }
    }
}
