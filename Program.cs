﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NjutonMethod
{
    class Program
    {

        static void Main(string[] args)
        {
            Func<double, double> func = (x) => Math.Pow(x, 2) - 4;

            List<double> initialValues = ChooseInitialValues(func, 0.51, -10, 10);

            foreach (double value in initialValues)
            {

                double? root = Calculation(func, 0.01, value, 0.01);

                Console.WriteLine(" root это {0}", root);
            }

            Console.Read();
        }
        static double Calculation(Func<double, double> f, double delta, double x0, double epsilum)
        {
            double tmpValue = 1000000;
            double derivative;
            double nextX = x0;
            double root = double.MaxValue;

            while (Math.Abs(tmpValue) > epsilum)
            {

                derivative = (f(nextX + delta) - f(nextX))/delta;

                root = nextX - f(nextX)/derivative  ;

                tmpValue = f((double)root);

                nextX = (double)root;
            }


            return root;
        }


        public static List<double> ChooseInitialValues(Func<double, double> f, double step, double leftEdge, double rightEdge)
        {
            List<double> values = new List<double>();

            while (leftEdge < rightEdge)
            {

                int firstTestValue = Math.Sign(f(leftEdge));

                leftEdge += step;


                int secondTestValue = Math.Sign(f(leftEdge));


                if(firstTestValue != secondTestValue)
                    values.Add(leftEdge);
            }

            return values;
        }

    }


}
