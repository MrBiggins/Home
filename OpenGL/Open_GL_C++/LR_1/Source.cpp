#include<GL/glut.h>;
#include<math.h>

void display();
void reshape(int w, int h);

	int main(int argc, char * argv[]) {
		glutInit(&argc, argv);
		glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGBA);
		glutInitWindowSize(800, 600);
		glutCreateWindow("OpenGL labwork 1.1");
		glutReshapeFunc(reshape);
		glutDisplayFunc(display);
		glutMainLoop();
		return 0;
	}

//настройка системы координат
	void reshape(int w, int h) {
		glClearColor(1, 1, 1, 0); // zadatj cvet
		glViewport(0, 0, w, h);
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		gluOrtho2D(0, w, 0, h);
		glMatrixMode(GL_MODELVIEW);
		glLoadIdentity();
	}
//рисование осей
	void display() {
		glMatrixMode(GL_PROJECTION);
		glLoadIdentity();
		float left = -100, right = 100, bottom = -150, top = 150;
		gluOrtho2D(left, right, bottom, top);
		glClear(GL_COLOR_BUFFER_BIT); // ochistka
									  //рисование осей
		glColor3d(0, 0, 0);
		glBegin(GL_LINES);
		glVertex2f(0, bottom);
		glVertex2f(0, top);
		glVertex2f(left, 0);
		glVertex2f(right, 0);
		glEnd();

		//рисование графика
		glColor3d(0, 0, 1);
		glBegin(GL_LINE_STRIP);
		for (float x = -100; x < 100; x += 0.5)
			glVertex2f(x, fabs(x / 4.0 + 3 * cos(100 * x)* sin(x)));
		glEnd();
		glutSwapBuffers(); // vivesti iz bufera

	}