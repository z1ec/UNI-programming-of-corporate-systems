using System;
using System.Globalization;

namespace calculator_c_sharp
{
    class Program
    {
        private static double memory = 0;
        
        static void Main(string[] args)
        {
            string value = "y";
            
            do
            {
                try
                {
                    Console.Write("Enter first number:");
                    double num1 = ReadNumberWithLimit();
                    
                    Console.Write("Enter second number (if needed, enter 0):");
                    double num2 = ReadNumberWithLimit();
                    
                    Console.Write("Enter symbol(/,+,-,*, %, r(1/x), s(x^2), q(√x), M+, M-, MR):");
                    string symbol = Console.ReadLine();
                    
                    double result = 0;
                    
                    switch (symbol)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num1 - num2;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Error: Division by zero is not allowed!");
                            }
                            result = num1 / num2;
                            break;
                        case "%":
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Error: Division by zero in modulo operation!");
                            }
                            result = num1 % num2;
                            break;
                        case "r": // 1/x reciprocal
                            if (num1 == 0)
                            {
                                throw new DivideByZeroException("Error: Cannot calculate reciprocal of zero!");
                            }
                            result = 1 / num1;
                            break;
                        case "s": // x^2 - square
                            result = num1 * num1;
                            break;
                        case "q": // x square root
                            if (num1 < 0)
                            {
                                throw new ArgumentException("Error: Cannot calculate square root of negative number!");
                            }
                            result = Math.Sqrt(num1);
                            break;
                        case "M+": // Memory add
                            memory += num1;
                            result = memory;
                            Console.WriteLine($"Memory value: {FormatNumber(memory)}");
                            break;
                        case "M-": // Memory subtract
                            memory -= num1;
                            result = memory;
                            Console.WriteLine($"Memory value: {FormatNumber(memory)}");
                            break;
                        case "MR": // Memory recall
                            result = memory;
                            Console.WriteLine($"Memory value: {FormatNumber(memory)}");
                            break;
                        default:
                            Console.WriteLine("Wrong input");
                            continue;
                    }
                    
                    //checking for out of range
                    if (result < -10000000 || result > 10000000)
                    {
                        throw new OverflowException($"Error: Result {result} is out of range (-10,000,000 to 10,000,000)!");
                    }
                    
                    Console.WriteLine($"Result: {FormatNumber(result)}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
                Console.ReadLine();
                Console.Write("Do you want to continue(y/n):");
                value = Console.ReadLine();
            }
            while (value == "y" || value == "Y");
            
            Console.WriteLine("Goodbye!");
        }
        
        // func for checking symbols out of comma
        private static double ReadNumberWithLimit()
        {
            string input = Console.ReadLine();
            
            if (string.IsNullOrEmpty(input))
            {
                return 0;
            }
            
            if (input.Contains('.'))
            {
                string[] parts = input.Split('.');
                if (parts.Length > 1 && parts[1].Length > 5)
                {
                    Console.WriteLine("Warning: More than 5 decimal places detected. Truncating to 5 decimal places.");
                    input = parts[0] + "." + parts[1].Substring(0, 5);
                }
            }
            else if (input.Contains(','))
            {
                string[] parts = input.Split(',');
                if (parts.Length > 1 && parts[1].Length > 5)
                {
                    Console.WriteLine("Warning: More than 5 decimal places detected. Truncating to 5 decimal places.");
                    input = parts[0] + "," + parts[1].Substring(0, 5);
                }
            }
            
            return Convert.ToDouble(input);
        }
        
        private static string FormatNumber(double number)
        {
            // limit for 5 symbols out of comma 
            return number.ToString("0.#####", CultureInfo.InvariantCulture);
        }
    }
}