using System;
using System.Collections.Generic;

namespace LukashynHomeWork3
{
    class Calculator
    {
        public static List<char> ReadInput()
        {
            var input = new List<char>();
            while (true)
            {
                for (int i = 0; ; i++)
                {
                    var t = Console.ReadKey();
                    if ((t.KeyChar >= '0' && t.KeyChar <= '9') || t.KeyChar == '*' || t.KeyChar == '/' || t.KeyChar == '+' || t.KeyChar == '-' || t.KeyChar == '=')
                    {
                        input.Add(t.KeyChar);
                        if (t.KeyChar == '=')
                        {
                            if (i >= 1 && input[i - 1] >= '0' && input[i - 1] <= '9')
                            {
                                return input;
                            }
                            else
                            {
                                throw new ArgumentException("Argument Exception. Incorrect use of =");
                            }
                        }
                        if (t.KeyChar == '*' || t.KeyChar == '/' || t.KeyChar == '+' || t.KeyChar == '-')
                        {
                            if (i >= 1 && input[i - 1] >= '0' && input[i - 1] <= '9')
                            {
                            }
                            else
                            {
                                throw new ArgumentException("Argument Exception. Incorrect use of operators");
                            }
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Argument Exception. Unsupported symbol");
                    }
                }
            }
        }
        public static void ParseInput(List<char> input, out List<int> numbers, out List<char> operators)
        {
            numbers = new List<int>();
            operators = new List<char>();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i] == '*' || input[i] == '/' || input[i] == '+' || input[i] == '-')
                {
                    operators.Add(input[i]);
                }
                else if (input[i] == '=')
                {

                }
                else
                {
                    if (i >= 1 && input[i - 1] >= '0' && input[i - 1] <= '9')
                    {
                        try
                        {
                            numbers[numbers.Count - 1] = int.Parse(numbers[numbers.Count - 1].ToString() + (input[i] - '0').ToString());
                        }
                        catch (OverflowException)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        numbers.Add(input[i] - '0');
                    }
                }
            }
        }
        public static int Count(List<int> numbers, List<char> operators)
        {
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {

                    if (operators[i] == '*')
                    {
                        try
                        {
                            checked
                            {
                                numbers[i] = numbers[i] * numbers[i + 1];
                            }
                            for (int j = i; j < operators.Count - 1; j++)
                            {
                                operators[j] = operators[j + 1];
                                numbers[j + 1] = numbers[j + 2];
                            }
                            numbers.RemoveAt(numbers.Count - 1);
                            operators.RemoveAt(operators.Count - 1);
                            i--;
                        }
                        catch (OverflowException)
                        {
                            throw;
                        }
                    }
                    else if (operators[i] == '/')
                    {
                        try
                        {
                            numbers[i] = numbers[i] / numbers[i + 1];
                            for (int j = i; j < operators.Count - 1; j++)
                            {
                                operators[j] = operators[j + 1];
                                numbers[j + 1] = numbers[j + 2];
                            }
                            numbers.RemoveAt(numbers.Count - 1);
                            operators.RemoveAt(operators.Count - 1);
                            i--;
                        }
                        catch (DivideByZeroException)
                        {
                            throw;
                        }
                    }
                }
            }
            for (int i = 0; i < operators.Count; i++)
            {
                if (operators[i] == '+')
                {
                    try
                    {
                        checked
                        {
                            numbers[i] = numbers[i] + numbers[i + 1];
                        }
                        for (int j = i; j < operators.Count - 1; j++)
                        {
                            operators[j] = operators[j + 1];
                            numbers[j + 1] = numbers[j + 2];
                        }
                        numbers.RemoveAt(numbers.Count - 1);
                        operators.RemoveAt(operators.Count - 1);
                        i--;
                    }
                    catch (OverflowException)
                    {
                        throw;
                    }
                }
                else if (operators[i] == '-')
                {
                    try
                    {
                        checked
                        {
                            numbers[i] = numbers[i] - numbers[i + 1];
                        }
                        for (int j = i; j < operators.Count - 1; j++)
                        {
                            operators[j] = operators[j + 1];
                            numbers[j + 1] = numbers[j + 2];
                        }
                        numbers.RemoveAt(numbers.Count - 1);
                        operators.RemoveAt(operators.Count - 1);
                        i--;
                    }
                    catch (OverflowException)
                    {
                        throw;
                    }
                }
            }
            if (numbers.Count == 1)
            {
                return numbers[0];
            }
            else
            {
                throw new ArgumentException("Argument Exception. Something goes wrong");
            }
        }
    }
}
