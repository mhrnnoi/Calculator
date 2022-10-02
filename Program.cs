using System;

namespace net_3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool onOff;

            double num1;
            double num2;

            string operation;
            string yesOrNo;

            do
            {
                try
                {
                    Console.Clear();

                    Greeting();

                    Console.WriteLine("Enter number 1: ");
                    num1 = Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Enter number 2: ");
                    num2 = Convert.ToDouble(Console.ReadLine());

                    Options();

                    Console.WriteLine("Enter an option: ");
                    operation = Console.ReadLine();

                    Console.WriteLine(Calculate(num1, num2, operation));

                    Console.WriteLine("Would you like to continue? (Y = yes, N = No): ");
                    yesOrNo = Console.ReadLine();

                    onOff = Continue(yesOrNo);
                }

                catch (FormatException)
                {
                    throw new FormatException("You entered incorrect format maybe you entered letter instead of number !");
                }

                catch (DivideByZeroException)
                {
                    throw new DivideByZeroException("You cant divide by zero !");
                }

                catch (ArgumentException)
                {
                    throw new ArgumentException("you entered wrong arguman maybe you entered something instead of \"y\" or \"n\" ");
                }

                catch (Exception)
                {
                    throw new Exception("an error occured!");
                }

            } while (onOff);

            Console.WriteLine("Bye!");

        }

        private static bool Continue(string yesOrNo)
        {
            switch (yesOrNo.ToLower())
            {
                case "y":
                    return true;

                case "n":
                    return false;

                default:
                    throw new ArgumentException("thats not n or y");

            }
        }

        private static string Calculate(double num1, double num2, string operation)
        {
            switch (operation)
            {
                case "*":
                    return string.Format($"Your result: {num1} {operation} {num2} = {num1 * num2}");

                case "+":
                    return string.Format($"Your result: {num1} {operation} {num2} = {num1 + num2}");

                case "-":
                    return string.Format($"Your result: {num1} {operation} {num2} = {num1 - num2}");

                case "/":
                    if (num2 == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return string.Format($"Your result: {num1} {operation} {num2} = {num1 / num2}");

                default:
                    return "That was not a valid option";
            }
        }

        private static void Options()
        {
            Console.WriteLine("Options:");
            Console.WriteLine("\t + : Add");
            Console.WriteLine("\t - : Subtract");
            Console.WriteLine("\t * : Multiply");
            Console.WriteLine("\t / : Divide");
        }

        private static void Greeting()
        {
            var greeting = "Calculator Program";
            for (int i = 0; i < greeting.Length; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();

            Console.WriteLine(greeting);
            for (int i = 0; i < greeting.Length; i++)
            {
                Console.Write('-');
            }
            Console.WriteLine();
        }
    }
}
