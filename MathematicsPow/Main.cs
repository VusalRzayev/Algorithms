using System;
using Utils;

namespace MathematicsPow
{
    public class Main
    {
        private static string number;
        private static int pow;
        private static int[] num;

        public static void Init()
        {
            Console.WriteLine("This is algorithm about the mathematics pow");
            Console.WriteLine("Please Enter Number");
            number = Console.ReadLine();
            Console.WriteLine("Please Enter Pow");
            pow = int.Parse(Console.ReadLine());

           
            num = new int[number.Length];

            for (int i = 0; i < number.Length; i++)
            {
                num[i] = int.Parse(number[i].ToString());
            }
        }


        public static void Solve()
        {
            int[] result = new int[num.Length];
            for (int i = 0; i < num.Length; i++)
            {
                result[i] = num[i];
            }


            for (int i = 0; i < pow-1; i++)
            {
                result = ArithmeticUtils.ArithmeticMultiplication(result, num);
            }

            Console.WriteLine("Result:");
            Console.WriteLine(string.Join("",result));


        }

    }
}
