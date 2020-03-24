using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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

            string[] result = Parse(problem);
            foreach (var el in result)
            {
                Console.WriteLine(el);
            }

        }

        public static string[] Parse(string problem)
        {
            int pos1, pos2, i = 0;
            List<string> result = new List<string>();
            problem += '+';
            while (i < problem.Length)
            {
                pos1 = i;
                pos2 = pos1;
                if (Char.IsDigit(problem[i]))
                {
                    for (int j = i + 1; j < problem.Length; j++)
                    {
                        if (Char.IsDigit(problem[j]))
                            pos2 = j;
                        else
                        {
                            result.Add(problem.Substring(pos1, pos2 - pos1 + 1));
                            break;
                        }

                    }
                }
                else
                    result.Add(Convert.ToString(problem[i]));

                i = pos2 + 1;
            }
            result.RemoveAt(result.Count - 1);

            return result.ToArray();
        }
        
    }
}