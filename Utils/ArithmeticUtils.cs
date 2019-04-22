using System;
using System.Linq;

namespace Utils
{
    public class ArithmeticUtils
    {

        //This function used for arithmetic sum 2 elements 
        //Example for 45 and 34 this function return 79
        //If you want to use this function at first you must convert this element to int[] array
        public static int[] ArithmeticSum(int[] a, int[] b)
        {
            int[] c = new int[(a.Length >= b.Length ? a.Length : b.Length) + 1];

            int indexa = a.Length - 1;
            int indexb = b.Length - 1;
            int indexc = c.Length - 1;
            int q = 0;
            int d = 0;
            int sum = 0;

            do
            {
                int num1 = indexa >= 0 ? a[indexa] : 0;
                int num2 = indexb >= 0 ? b[indexb] : 0;

                sum = num1 + num2;


                q = sum % 10;

                c[indexc] = q + d;

                d = sum / 10;


                --indexa;
                --indexb;
                --indexc;

                if ((indexa < 0 || indexb < 0) && d > 0)
                {
                    c[indexc] = d;

                }

            } while (indexa >= 0 && indexb >= 0);

            if (c[0] == 0)
                c = c.Skip(1).ToArray();
            return c;

        }


        //This function used for arithmetic  multiplication 2 elements 
        //Example for 45 and 34 this function return 1530
        //If you want to use this function at first you must convert this element to int[] array
        public static int[] ArithmeticMultiplication(int[] a, int[] b)
        {
            int[] c = new int[a.Length + b.Length];


            int m = 0;
            int d = 0;
            int q = 0;
            int index = 0;

            for (int y = b.Length - 1; y >= 0; y--)
            {
                for (int x = a.Length - 1; x >= 0; x--)
                {
                    m = a[x] * b[y];



                    q = m % 10;
                    index = x + y + 1;




                    c[index] = c[index] + q + d;
                    d = m / 10;

                    if (c[index] >= 10)
                    {
                        int cq = c[index] % 10;
                        int cd = c[index] / 10;
                        d = d + cd;
                        c[index] = cq;

                    }

                }

                if (d > 0)
                {
                    c[index - 1] = d;
                    d = 0;
                }
            }

            if (c[0] == 0)
                c = c.Skip(1).ToArray();

            return c;

        }


    }
}
