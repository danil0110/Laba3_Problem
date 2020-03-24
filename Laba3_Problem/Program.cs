using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Laba3_Problem
{
    class Program
    {
        static void Main(string[] args)
        {
/*
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
*/

            string problem = "-23-2*9/4*2-11";
            string[] result = Parse(problem);
            SolveProblem(result);
        }

        public static string[] Parse(string problem)
        {
            int pos1, pos2, i = 0;
            List<string> result = new List<string>();
            problem += '.';
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
            if (result[0] == "-")
            {
                result.RemoveAt(0);
                result[0] = "-" + result[0];
            }
            return result.ToArray();
        }

        public static void SolveProblem(string[] problem)
        {
            MyStack<float> numbers = new MyStack<float>();
            MyStack<string> symbols = new MyStack<string>();
            foreach (var el in problem)
            {
                float number;
                bool success = float.TryParse(el, out number);
                if (success)
                    numbers.Push(number);
                else if (symbols.IsEmpty)
                    symbols.Push(el);
                else if (el == "*" || el == "/")
                {
                    if (symbols.Peek() == "+" || symbols.Peek() == "-")
                        symbols.Push(el);
                    else
                        while (!symbols.IsEmpty && symbols.Peek() != "+" && symbols.Peek() != "-")
                        {
                            Calculate(numbers, symbols);
                            if (symbols.IsEmpty)
                            {
                                symbols.Push(el);
                                break;
                            }
                            else if (symbols.Peek() == "+" || symbols.Peek() == "-")
                            {
                                symbols.Push(el);
                                break;
                            }
                        }
                }
                else
                    while (!symbols.IsEmpty)
                    {
                        Calculate(numbers, symbols);
                        if (symbols.IsEmpty)
                        {
                            symbols.Push(el);
                            break;
                        }
                    }
                
            }

            while (!symbols.IsEmpty)
            {
                Calculate(numbers, symbols);
            }
            Console.WriteLine($"Result: {numbers.Pop()}");
        }

        public static void Calculate(MyStack<float> numbers, MyStack<string> symbols)
        {
            float b = numbers.Pop();
            float a = numbers.Pop();
            string sym = symbols.Pop();
            float result = 0;
            switch (sym)
            {
                case "+":
                    result = a + b;
                break;
                case "-": result = a - b;
                    break;
                case "*": result = a * b;
                    break;
                case "/": result = a / b;
                    break;
            }
            numbers.Push(result);
        }

    }
}