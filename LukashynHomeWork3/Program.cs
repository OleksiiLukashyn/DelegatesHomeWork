using System;
using System.Collections.Generic;

namespace LukashynHomeWork3
{
    public delegate int MyHandler(List<int> numbers, List<char> operators);
    class Program
    {
        static void Main()
        {
            MyHandler myHandler;
            Console.WriteLine("Solution maked with delegates(you can use +, -, *, /)");
            while (true)
            {
                try
                {
                    var input = Calculator.ReadInput();
                    Calculator.ParseInput(input, out List<int> numbers, out List<char> operators);
                    myHandler = Calculator.Count;
                    var answer = myHandler(numbers, operators);
                    Console.WriteLine(answer);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Solution maked with anonymous methods(you can use only +, -)");
            while (true)
            {
                try
                {
                    var input = Calculator.ReadInput();
                    Calculator.ParseInput(input, out List<int> numbers, out List<char> operators);
                    myHandler = delegate (List<int> aNumbers, List<char> aOperators)
                    {
                        for (int i = 0; i < aOperators.Count; i++)
                        {
                            switch (aOperators[i])
                            {
                                case '+':
                                    try
                                    {
                                        checked
                                        {
                                            aNumbers[i] = aNumbers[i] + aNumbers[i + 1];
                                        }
                                        for (int j = i; j < aOperators.Count - 1; j++)
                                        {
                                            aOperators[j] = aOperators[j + 1];
                                            aNumbers[j + 1] = aNumbers[j + 2];
                                        }
                                        aNumbers.RemoveAt(aNumbers.Count - 1);
                                        aOperators.RemoveAt(aOperators.Count - 1);
                                        i--;
                                    }
                                    catch (OverflowException)
                                    {
                                        throw;
                                    }
                                    break;
                                case '-':
                                    try
                                    {
                                        checked
                                        {
                                            aNumbers[i] = aNumbers[i] - aNumbers[i + 1];
                                        }
                                        for (int j = i; j < aOperators.Count - 1; j++)
                                        {
                                            aOperators[j] = aOperators[j + 1];
                                            aNumbers[j + 1] = aNumbers[j + 2];
                                        }
                                        aNumbers.RemoveAt(aNumbers.Count - 1);
                                        aOperators.RemoveAt(aOperators.Count - 1);
                                        i--;
                                    }
                                    catch (OverflowException)
                                    {
                                        throw;
                                    }
                                    break;
                                default:
                                    throw new ArgumentException("Incorrect operator. Only + and - allowed");
                            }
                        }
                        if (aNumbers.Count == 1)
                        {
                            return aNumbers[0];
                        }
                        else
                        {
                            throw new ArgumentException("Argument Exception. Something goes wrong");
                        }
                    };
                    var answer = myHandler(numbers, operators);
                    Console.WriteLine(answer);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("Solution maked with lambda(you can use only *, /)");
            while (true)
            {
                try
                {
                    var input = Calculator.ReadInput();
                    Calculator.ParseInput(input, out List<int> numbers, out List<char> operators);
                    myHandler = (List<int> aNumbers, List<char> aOperators) =>
                    {
                        for (int i = 0; i < aOperators.Count; i++)
                        {
                            switch (aOperators[i])
                            {
                                case '*':
                                    try
                                    {
                                        checked
                                        {
                                            aNumbers[i] = aNumbers[i] * aNumbers[i + 1];
                                        }
                                        for (int j = i; j < aOperators.Count - 1; j++)
                                        {
                                            aOperators[j] = aOperators[j + 1];
                                            aNumbers[j + 1] = aNumbers[j + 2];
                                        }
                                        aNumbers.RemoveAt(aNumbers.Count - 1);
                                        aOperators.RemoveAt(aOperators.Count - 1);
                                        i--;
                                    }
                                    catch (OverflowException)
                                    {
                                        throw;
                                    }
                                    break;
                                case '/':
                                    try
                                    {
                                        checked
                                        {
                                            aNumbers[i] = aNumbers[i] / aNumbers[i + 1];
                                        }
                                        for (int j = i; j < aOperators.Count - 1; j++)
                                        {
                                            aOperators[j] = aOperators[j + 1];
                                            aNumbers[j + 1] = aNumbers[j + 2];
                                        }
                                        aNumbers.RemoveAt(aNumbers.Count - 1);
                                        aOperators.RemoveAt(aOperators.Count - 1);
                                        i--;
                                    }
                                    catch (DivideByZeroException)
                                    {
                                        throw;
                                    }
                                    break;
                                default:
                                    throw new ArgumentException("Incorrect operator. Only * and / allowed");
                            }
                        }
                        if (aNumbers.Count == 1)
                        {
                            return aNumbers[0];
                        }
                        else
                        {
                            throw new ArgumentException("Argument Exception. Something goes wrong");
                        }
                    };
                    var answer = myHandler(numbers, operators);
                    Console.WriteLine(answer);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
