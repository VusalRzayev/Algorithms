using System;

namespace SameSumSubSequence
{
    public class Main
    {

        private static int N;
        private static int[,] array;

        public static void Init()
        {
            Console.WriteLine("This is algorithm about subsequences which sums are equal." +
                "Need divide  sequence to N sum equal subsequences.Example if N=3 then " +
                "sequence will 1,2,3,4,5,6,7,8,9.And subSequences will [1 5 9],[2,6,7],[3,4,8].There " +
                "are two method to solve this problem.");

        }

        public static void Solve()
        {
            Console.WriteLine("Please Enter N");
            
            N = Convert.ToInt32(Console.ReadLine());
           


            SolveProblemByArray();

            Console.ReadKey();
        }


        //this is method solve this problem with array.
        //At first, elements of sequence  are set to multidimensional array and read subsequences from dioqonals
        public static void SolveProblemByArray()
        {
            array = new int[N, N];
            int count = 1;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    array[i, j] = count++;
                }
            }

            Next();
        }


        //This is method solve this problem without array.It uses a numerical sequence increase.
        // One element differs from the other to N + 1
        public static void SolveProblemWithoutArray()
        {
            NextWithoutArray();
        }


        private static void Next()
        {
            int i = 0;
            for (int j = 0; j < N; j++)
            {
                i = 0;

                do
                {
                    Console.Write(array[i, j] + " ");
                    i = i + 1;
                    j = GetNextColumn(j);
                } while (i < N);

                Console.WriteLine();


            }
        }

        private static int GetNextColumn(int j)
        {
            if (j + 1 == N)
            {
                return 0;
            }
            else
            {
                return j + 1;
            }
        }

        private static void NextWithoutArray()
        {
            int k = 0;
            for (int i = 1; i <= N; i++)
            {
                k = i; Console.Write(k + " ");
                while (k <= N * N)
                {
                    if (k % N == 0)
                    {
                        k = k + 1;
                    }
                    else
                    {
                        k = k + N + 1;
                    }
                    if (k <= N * N) Console.Write(k + " ");
                }
                Console.WriteLine();
            }
        }


    }
}
