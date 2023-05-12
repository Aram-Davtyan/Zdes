#include <iostream>
#include <fstream>
#define _USE_MATH_DEFINES
#define _USE_GENERIC_MATH1
#include <math.h>
using namespace std;


double f(double x, double y)
{

    return (exp(sin(M_PI * x) + cos(M_PI * y)) + 1) / 16;
}
double func(double a1, double b1, double a2, double b2, int n1, int n2)
{
    double I = 0, h1 , h2 ;
    double I1 = 0,hh1, hh2;
    double eps = 0.001;
    bool is_converged = false;

    do {
        h1 = (b1 - a1) / n1, h2 = (b2 - a2) / n2;
        hh1 = (b1 - a1) / (n1 + n1 / 4), hh2 = (b2 - a2) / (n2 + (n2 + n2 / 4));
        for (double x = a1; x <= b1; x += h1)
        {
            for (double y = a2; y <= b2; y += h1)
                I += h1 * h2 * f(x + h1 / 2, y + h2 / 2);
        }

        for (double x = a1; x <= b1; x += hh1)
        {
            for (double y = a2; y <= b2; y += hh1)
                I1 += hh1 * hh2 * f(x + hh1 / 2, y + hh2 / 2);
        }

        if (fabs(I - I1) > eps)
        {
            n1 += n1 / 4;
            n2 += n2 / 4;
        }
        else
            is_converged = true;


    } while (!is_converged);
    return I;

}
int main() {
    setlocale(LC_ALL, "rus");
    int a1, a2, b1, b2, n1, n2;
    ifstream q;
    q.open("data.txt");
    if (!q.eof())
        q >> a1 >> b1 >> a2 >> b2 >> n1 >> n2;
    q.close();
    cout << a1 << " " << b1 << " " << a2 << " " << b2 << " " << n1 <<" "<<n2<< endl;


    cout << "ОТВЕТ: " << func(a1,b1,a2,b2,n1,n2) << endl;

    cout << "Ответ с онлайн калькулятор для данной функции: " << 41.6467 << endl;

    return 0;
}