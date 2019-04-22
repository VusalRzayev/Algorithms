using System;
using System.Collections;
using System.Linq;
using Utils;

namespace Rebus
{
    public class Main
    {
        private static int[] array;
        private static int maxIndexOfCharInArray;

        //This array for save user's first element. Example ab  [a,b]
        private static char[] num1;
        //This array for save user's second element.
        private static char[] num2;
        //This array for save user's result element
        private static char[] sum;
        //This array for save previous numbers.If in combination have this number, 
        //then in this array the index becomes true;Example if combination is 45 then hor[4]=true and hor[5]=true 
        private static bool[] hor;

        public static void Init()
        {
            Console.WriteLine("This is algorithm about the logic game Rebus.Example: ab + aa = ca Result a = 1 b = 2 c = 3");


            //This is array used for save chars.Array element count is 26 because count of chars a to z is 26
            //Before adding element to array calculated the int equivalent of chars.example equivalent of a is 97.
            //After calculated index of this element.For this used mod 26 for unique index.97 mod 26=19
            //After this i add into the 19 th index of array value 1
            array = new int[26];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = -1;
            }

        }


        public static void Solve()
        {
            

            Console.WriteLine("First Element");

            string str1 = Console.ReadLine();

            Console.WriteLine("Second Element");

            string str2 = Console.ReadLine();

            Console.WriteLine("Sum : ");

            string strSum = Console.ReadLine();

            num1 = str1.ToArray();

            num2 = str2.ToArray();

            sum = strSum.ToArray();

            hor = new bool[10];
            

            for (int i = 0; i < num1.Length; i++)
            {
                AddElementToArray(num1[i]);
            }

            for (int i = 0; i < num2.Length; i++)
            {
                AddElementToArray(num2[i]);
            }

            for (int i = 0; i < sum.Length; i++)
            {
                AddElementToArray(sum[i]);
            }

            maxIndexOfCharInArray = Array.LastIndexOf(array, 0);


            Next(0);

            Console.WriteLine("Done");
        }

        //This is method used for adding element to array. 
        private static void AddElementToArray(char element)
        {
            int index = (int)element % 26;

            array[index] = 0;
        }


        private static bool CompareSum(int[] num1, int[] num2, int[] sum)
        {
            int[] tempSum = ArithmeticUtils.ArithmeticSum(num1, num2);
            return tempSum.SequenceEqual(sum);
        }

        private static char GetCharByIndex(int index)
        {

            for (int i = 0; i < num1.Length; i++)
            {
                if (((int)num1[i]) % 26 == index)
                {
                    return num1[i];
                }
            }

            for (int i = 0; i < num2.Length; i++)
            {
                if (((int)num2[i]) % 26 == index)
                {
                    return num2[i];
                }
            }

            for (int i = 0; i < sum.Length; i++)
            {
                if (((int)sum[i]) % 26 == index)
                {
                    return sum[i];
                }
            }

            return '0';
        }



        //This recursive function is used for calculate all combinations in array and compare
        //Example of one combination:
        public static void Next(
            int index)
        {

            if (array[index] != -1)
            {
                if (index == maxIndexOfCharInArray)

                {
                    for (int i = 0; i < 10; i++)
                    {
                        if (!hor[i])
                        {
                            array[index] = i;
                            int[] numArray1 = GetCurrentCombination(num1);
                            int[] numArray2 = GetCurrentCombination(num2);
                            int[] sumArray = GetCurrentCombination(sum);

                            if (CompareSum(numArray1, numArray2, sumArray))
                            {
                                string result = "";
                                for (int j = 0; j <= maxIndexOfCharInArray; j++)
                                {
                                    if (array[j] != -1)
                                    {
                                        result = result + $"{GetCharByIndex(j)} = {array[j]} ";
                                        

                                    }
                                }
                                Console.WriteLine(result);
                            }



                        }

                    }
                    return;
                }
                else
                {

                    for (int i = index == 0 ? 1 : 0; i < 10; i++)
                    {
                        if (!hor[i])
                        {
                            array[index] = i;
                            hor[i] = true;
                            Next(index + 1);
                            hor[i] = false;
                        }

                    }
                }
            }
            else
            {
                if (index == maxIndexOfCharInArray)
                {
                    return;
                }
                else
                {
                    Next(index + 1);
                }
            }





        }

        
        private static int GetCurrentElementInArrayByChar(char element)
        {
            int index = (int)element % 26;
            return array[index];
        }


        //This method return current combination example : for ab return [1,4]
        private static int[] GetCurrentCombination(char[] charArray)
        {
            int[] array = new int[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                int element = GetCurrentElementInArrayByChar(charArray[i]);
                array[i] = element;
            }
            return array;
        }
    }
}
