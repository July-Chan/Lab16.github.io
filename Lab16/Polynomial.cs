using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab16
{
    class Polynomial
    {
        //Метод для виведення многочленів
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = degree; i >= 0; i--)
            {
               
                if (coefficients[i] != 0)
                {
                    if (coefficients[i] > 0 && sb.Length > 0)
                        sb.Append(" + ");

                    sb.Append(coefficients[i]);

                    if (i > 0)
                        sb.Append("x^").Append(i);
                }
            }

            if (sb.Length == 0)
                sb.Append("0");

            return sb.ToString();
        }
        private int degree; 
        private double[] coefficients; 

        // Конструктор за замовчуванням
        public Polynomial()
        {
            degree = 0;
            coefficients = new double[1];
            coefficients[0] = 0;
        }

        // Конструктор зі зазначенням ступеня та масиву коефіцієнтів
        public Polynomial(int degree, double[] coefficients)
        {
            this.degree = degree;
            this.coefficients = coefficients;
        }

        // Конструктор копіювання
        public Polynomial(Polynomial polynomial)
        {
            this.degree = polynomial.degree;
            this.coefficients = polynomial.coefficients.Clone() as double[];
        }

        // Властивість для доступу до ступеня многочлена
        public int Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        // Метод для обчислення значення многочлена для заданого аргументу
        public double Evaluate(double x)
        {
            double result = 0;
            for (int i = 0; i <= degree; i++)
            {
                result += coefficients[i] * Math.Pow(x, i);
            }
            return result;
        }

        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            int maxDegree = Math.Max(p1.Degree, p2.Degree); 

            double[] resultCoefficients = new double[maxDegree + 1]; 

           
            for (int i = 0; i <= p1.Degree; i++)
            {
                resultCoefficients[i] += p1.coefficients[i];
            }

            
            for (int i = 0; i <= p2.Degree; i++)
            {
                resultCoefficients[i] += p2.coefficients[i];
            }

            return new Polynomial(maxDegree, resultCoefficients); 
        }

        // Метод для обчислення різниці многочленів
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            int maxDegree = Math.Max(p1.degree, p2.degree); 

            double[] resultCoefficients = new double[maxDegree + 1]; 

           
            for (int i = 0; i <= maxDegree; i++)
            {
                double coefficient1 = (i <= p1.degree) ? p1.coefficients[i] : 0; 
                double coefficient2 = (i <= p2.degree) ? p2.coefficients[i] : 0; 

                resultCoefficients[i] = coefficient1 - coefficient2; 
            }

            return new Polynomial(maxDegree, resultCoefficients); 
        }

        // Метод для множення многочленів
        public static Polynomial operator *(Polynomial p1, Polynomial p2)
        {
            int degree1 = p1.Degree;
            int degree2 = p2.Degree;

            double[] resultCoefficients = new double[degree1 + degree2 + 1];

          
            for (int i = 0; i <= degree1; i++)
            {

                for (int j = 0; j <= degree2; j++)
                {
                    resultCoefficients[i + j] += p1.coefficients[i] * p2.coefficients[j];
                }
            }

            Polynomial resultPolynomial = new Polynomial(degree1 + degree2, resultCoefficients);
            return resultPolynomial;
        }


    }
}
