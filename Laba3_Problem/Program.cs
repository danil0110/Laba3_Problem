using System;
using System.Collections.Generic;

namespace Laba3_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            string problem = "";
            if (args.Length > 0)
                foreach (var el in args)
                {
                    foreach (var symbol in el)
                    {
                        if (symbol != ' ')
                            problem += symbol;
                    }
                }
            Console.WriteLine(problem);
        }
    }
}