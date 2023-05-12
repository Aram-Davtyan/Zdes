#include <iostream>
#include <fstream>
#include <math.h>

using namespace std;

double F(double x,double y)
{
    return 2*x;
}

    void NewF(double x, double y)
    {
        double  nx, ny;

        double hx = 0.1;
        for (nx = x; nx <= 1.; nx += hx)
        {
            ny = y + hx * F(x, y);

        	    ofstream myfile("сoord.txt", ios::app);

	            if (!myfile)  //если файл неоткрылся
	            {
		            cout << "Sorry" << endl;
		            system("pause");
	            }
	            else 
		            myfile << nx << "       " << ny << endl;


        myfile.close();

        x = nx;
        y = ny;
        }
    }



int main()
{
    NewF(0,0);
}

