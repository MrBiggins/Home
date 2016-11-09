using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace OpenGlConsole {
    class Program {
        static void Main(string[] args) {
            Glut.glutInit();
            Glut.glutInitWindowSize(500, 500);
            Glut.glutCreateWindow("Tao Example");

            init_graphics();
            Glut.glutDisplayFunc(on_display);
            //   Glut.glutReshapeFunc(on_reshape);
            Glut.glutMainLoop();




        }

        static void init_graphics() {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] lightPos = new float[3] { 1, 0.5F, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, lightPos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(1, 1, 1, 1);
        }

        private static void on_display() {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();

            const float left = -5;
            const float bottom = -5;
            const float top = 5;
            const float right = 5;

            //Gl.glOrtho(left, right, bottom, top, -9.9, -9.9);

            Gl.glColor3d(0, 0, 0);

            Gl.glBegin(Gl.GL_LINES);

            Gl.glVertex2f(0, bottom);
            Gl.glVertex2f(0, top);
            Gl.glVertex2f(left, 0);
            Gl.glVertex2f(right, 0);
            Gl.glEnd();

            Gl.glColor3d(0, 0, 1);
            Gl.glBegin(Gl.GL_LINE_STRIP);
            for (float x = -45; x < 45; x += 0.1f)
                Gl.glVertex2f(x, (float) Math.Sin(x));
            Gl.glViewport(20, 20, 200, 200);
            Gl.glEnd();


        }


    }
}
