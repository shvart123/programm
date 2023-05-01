using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void DerivatCalc()  // метод для работы с производной;
        {
            Console.CursorVisible = false;
            string[] menuItems = { "  f(x) = a*x^n+c  ", "  f(x) = a^x+c  ", "  f(x) = 1/x  ", "  f(x) = exp^x  ",
                "  f(x) = sin(x)   ", "  f(x) = cos(x)   ", "  Выход                   " };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите функцию для которой необходимо вычислть значение производной:");
                Console.WriteLine();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItemIndex++;
                        break;
                    case ConsoleKey.Enter:
                        if (selectedItemIndex == 6) return;
                        Console.Clear();
                        Console.WriteLine(menuItems[selectedItemIndex]);
                        Console.WriteLine();
                        Console.WriteLine("Для приближенного вычисления первой производной введите  1");
                        Console.WriteLine("Для приближенного вычисления второй производной введите  2");
                        string pr = Console.ReadLine();
                        if ((pr != "1") && (pr != "2"))
                        {
                            Console.WriteLine("Ошибка ввода!");
                            Console.ReadKey();
                            return;
                        }
                        Console.WriteLine("Введите  значение x:");
                            
                        double input;
                        while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
    {
                          
                            Console.WriteLine("Ошибка ввода,значение  х должно быть числовым");
                            Console.Write("Введите значение х");
                        }
                        double x1 = input;
                        Console.WriteLine("Введите точность вычислений h:");
                        while (!Double.TryParse(Console.ReadLine(), out input))
    {

                            Console.WriteLine("Ошибка ввода, значение h - должен быть числовым");
                            Console.Write("введите точность вычислений");
                        }
                        double h = input;
                        Func<double, double> f = x => x;
                        double a, n, c;
                        switch (selectedItemIndex)
                        {
                            case 0:
                                Console.WriteLine("Введите значение a:");
                                
                                while (!Double.TryParse(Console.ReadLine(), out input))
    {
                           
                                    Console.WriteLine("Ошибка ввода, значение а - должен быть числовым");
                                    Console.Write("введите значение a");
                                }
                                a = input;
                                Console.WriteLine("Введите значение n:");
                               
                                while (!Double.TryParse(Console.ReadLine(), out input))
                                {
                                
                                    Console.WriteLine("Ошибка ввода, значени n - должно быть числовым");
                                    Console.Write("введите значение n");
                                }
                                n =input;
                                Console.WriteLine("Введите значение c:");
                               
                                while (!Double.TryParse(Console.ReadLine(), out input))
                                {
                                
                                    Console.WriteLine("Ошибка ввода, значение с должно быть числовым");
                                    Console.Write("введите значение с");
                                }
                                c = input;
                                f = x => a * Math.Pow(x, n) + c;
                                break;
                            case 1:
                                Console.WriteLine("Введите значение а:");
                                while (!Double.TryParse(Console.ReadLine(), out input))
                                {
                                 
                                    Console.WriteLine("Ошибка ввода, значение а - должно быть числовым");
                                    Console.Write("Введите значение a");
                                }
                              
                                a = input;
                                Console.WriteLine("Введите значение c:");
                              
                                while (!Double.TryParse(Console.ReadLine(), out input))
                                {
                                  
                                    Console.WriteLine("Ошибка ввода, значение с  должно быть числовым");
                                    Console.Write("введите значение c");
                                }
                                c = input;
                                f = x => Math.Pow(a, x) + c;
                                break;
                            case 2:
                                f = x => 1 / x;
                                break;
                            case 3:
                                f = x => Math.Exp(x);
                                break;
                            case 4:
                                f = x => Math.Sin(x);
                                break;
                            case 5:
                                f = x => Math.Cos(x);
                                break;
                            default:
                                return;
                        }
                        double df;
                        if (pr == "1") df = CentralDifference1(f, x1, h);
                        else df = CentralDifference2(f, x1, h);
                        Console.WriteLine("Результат: " + df);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                if (selectedItemIndex < 0)
                {
                    selectedItemIndex = 0;
                }
                else if (selectedItemIndex >= menuItems.Length)
                {
                    selectedItemIndex = menuItems.Length - 1;
                }
            }

        }

        static void IntegralCalc() // метод для работы с интегралом
        {
            Console.CursorVisible = false;
            string[] menuItems = { "  f(x) = a*x^n+c  ", "  f(x) = a^x+c  ", "  f(x) = 1/x  ", "  f(x) = exp^x  ",
                "  f(x) = sin(x)   ", "  f(x) = cos(x)   ", "  Выход                   " };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите функцию для которой необходимо вычислить интеграл по формуле трапеций:");
                Console.WriteLine();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItemIndex++;
                        break;
                    case ConsoleKey.Enter:
                        if (selectedItemIndex == 6) return;
                        Console.Clear();
                        Console.WriteLine(menuItems[selectedItemIndex]);
                        Console.WriteLine();
                        Console.WriteLine("Введите начальное значение интервала для расчета значений:");
                        //  string input = Console.ReadLine();
                        double input;
                        while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                        {

                            Console.WriteLine("Ошибка ввода,значение начального интервала должно быть числовым");
                            Console.WriteLine("Введите начальное значение интервала для расчета значений:");
                        }
                        double x1 = input;
                        Console.WriteLine("Введите конечное значение интервала для расчета значений:");
                        // input = Console.ReadLine();
                        while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                        {

                            Console.WriteLine("Ошибка ввода,значение конечного интервала должно быть числовым");
                            Console.WriteLine("Введите конечное значение интервала для расчета значений:");
                        }
                       
                        double x2 = input;
                        Console.WriteLine("Введите точность вычислений:");
                        while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                        {

                            Console.WriteLine("Ошибка ввода,значение точности вычислений должно быть числовым:");
                            Console.WriteLine("Введите точность вычислений:");
                        }
                       
                        double ee = input;
                        Func<double, double> f = x => x;
                        double a, n, c;
                        switch (selectedItemIndex)
                        {
                            case 0:
                                Console.WriteLine("Введите значение a:");
                                while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                                {

                                    Console.WriteLine("Ошибка ввода,значение a должно быть числовым:");
                                    Console.WriteLine("Введите значение a");
                                }
                                a =input;
                                Console.WriteLine("Введите значение n:");
                                while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                                {

                                    Console.WriteLine("Ошибка ввода,значение n должно быть числовым:");
                                    Console.WriteLine("Введите значение n");
                                }
                                n = input;
                                Console.WriteLine("Введите значение c:");
                                while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                                {

                                    Console.WriteLine("Ошибка ввода,значение c должно быть числовым:");
                                    Console.WriteLine("Введите значение c");
                                }
                                c = input;
                                f = x => a * Math.Pow(x, n) + c;
                                break;
                            case 1:
                                Console.WriteLine("Введите значение a:");
                                while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                                {

                                    Console.WriteLine("Ошибка ввода,значение a должно быть числовым:");
                                    Console.WriteLine("Введите значение a");
                                }
                                a = input;
                                Console.WriteLine("Введите значение c:");
                                while (!Double.TryParse(Console.ReadLine(), out input)) // проверка ввода данных переменной input
                                {

                                    Console.WriteLine("Ошибка ввода,значение c должно быть числовым:");
                                    Console.WriteLine("Введите значение c");
                                }
                                c = input;
                                f = x => Math.Pow(a, x) + c;
                                break;
                            case 2:
                                f = x => 1 / x;
                                break;
                            case 3:
                                f = x => Math.Exp(x);
                                break;
                            case 4:
                                f = x => Math.Sin(x);
                                break;
                            case 5:
                                f = x => Math.Cos(x);
                                break;
                            default:
                                return;
                        }
                        double integral = IntegrateWithAccuracy(f, x1, x2, ee);
                        Console.WriteLine("Результат: " + integral);
                        Console.ReadKey();
                        break;
                    default:
                        break;
                }

                if (selectedItemIndex < 0)
                {
                    selectedItemIndex = 0;
                }
                else if (selectedItemIndex >= menuItems.Length)
                {
                    selectedItemIndex = menuItems.Length - 1;
                }
            }
        }
        static double CentralDifference1(Func<double, double> f, double x, double h) // функция вычисления производной первого порядка
        {
            double df = (f(x + h) - f(x - h)) / (2 * h);
            return df;
        }

        static double CentralDifference2(Func<double, double> f, double x, double h) // функция вычисления проводной второго порядка
        {
            double df = (f(x + h) - (2 * f(x)) + f(x - h)) / (Math.Pow(h, 2));
            return df;
        }
        static double TrapezoidalRule(double a, double b, int n, Func<double, double> f) // функция вычисления интеграла по заданому количеству разбиений отрезка
        {
            double h = (b - a) / n;
            double integral = 0.5 * f(a) + 0.5 * f(b);
            for (int i = 1; i < n; i++)
            {
                double x = a + i * h;
                integral += f(x);
            }
            integral *= h;
            return integral;
        }
        static double IntegrateWithAccuracy(Func<double, double> f, double a, double b, double accuracy) //  функция вычисления интеграла с заданой точностью
        {
            double previous_result = TrapezoidalRule(a, b, 1, f);
            for (int n = 2; ; n *= 2)
            {
                double current_result = TrapezoidalRule(a, b, n, f);
                if (Math.Abs(current_result - previous_result) < accuracy)
                {
                    Console.WriteLine("Число разбиений отрезка равно: " + n);
                    return current_result;
                }
                previous_result = current_result;
            }
        }



        static void Main(string[] args)
        {


            Console.CursorVisible = false;
            string[] menuItems = { "  Вычисление производных  ", "  Вычисление интегралов   ", "  Выход                   " };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите пункт меню, используя стрелки:");
                Console.WriteLine();

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == selectedItemIndex)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    }
                    Console.WriteLine(menuItems[i]);
                    Console.ResetColor();
                }

                ConsoleKey key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItemIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedItemIndex++;
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        if (selectedItemIndex == 0) DerivatCalc(); // вызов метода для работы с производной 
                        if (selectedItemIndex == 1) IntegralCalc();// вызов метода для работы с интегралом
                        if (selectedItemIndex == 2) return;
                      
                        break;
                    default:
                        break;
                }

                if (selectedItemIndex < 0)
                {
                    selectedItemIndex = 0;
                }
                else if (selectedItemIndex >= menuItems.Length)
                {
                    selectedItemIndex = menuItems.Length - 1;
                }
            }
        }
    }
}
