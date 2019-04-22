using System;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        public static Dictionary<int, string> tasks;
        

        static void Main(string[] args)
        {



            Console.WriteLine("Algorithms");
            Console.WriteLine("Choose :");

            tasks = new Dictionary<int, string>();
            ///
            tasks.Add(0, "Rebus");
            tasks.Add(1, "SameSumSubSequence");











            //////
            foreach (KeyValuePair<int, string> entry in tasks)
            {
                Console.Write(entry.Key +"  "+entry.Value);
                Console.WriteLine();
            }

            Console.WriteLine();
            int ch= Convert.ToInt32(Console.ReadLine()); ;

            string NameAlgorithm = "";

            tasks.TryGetValue(ch,out NameAlgorithm);

            Console.WriteLine("---------------");
            string path = NameAlgorithm + ".dll";
            Assembly assembly = Assembly.LoadFile(Path.GetFullPath(path));
            Type type = assembly.GetType(NameAlgorithm+".Main");

            MethodInfo methodInit = type.GetMethod("Init");
            methodInit.Invoke(null, null);

            MethodInfo method = type.GetMethod("Solve");
            method.Invoke(null, null);


            Console.ReadKey();
        }
    }
}
