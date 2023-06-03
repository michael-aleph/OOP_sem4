namespace lab_7_OOP
{
    using System;

        interface IProgression //інтерфейс із функціонаналом для прогресій без реалізації самих методів
        {
            double GetXn(int n);
            double GetSum(int n);
        }

        class ArithmeticProgression : IProgression
        {
            private double startNumber; //початкове число прогресії
            private double difference; // різниця між сусідніми членами (d)

            public ArithmeticProgression(double startNumber, double difference) // конструктор з параметрами
            {
                this.startNumber = startNumber;
                this.difference = difference;
            }

            public double GetXn(int n) // реалізація методу знаходження n-го числа прогресії
            {
                return startNumber + (n - 1) * difference;
            }

            public double GetSum(int n) // реалізація методу знаходження суми n членів прогресії
            {
                return (n / 2.0) * (2 * startNumber + (n - 1) * difference);
            }
        }

        class GeometricProgression : IProgression
        {
            private double startNumber; // початкове число прогресії
            private double coefficient; // коефіцієнт (співвідношеня сусідних членів прогресії де Xn / (Xn-1) 

            public GeometricProgression(double startNumber, double coefficient) // конструктор з параметрами
            {
                this.startNumber = startNumber;
                this.coefficient = coefficient;
            }

            public double GetXn(int n) // реалізація методу знаходження n-го числа прогресії
            {
                return startNumber * Math.Pow(coefficient, n - 1);
            }

            public double GetSum(int n) // реалізація методу знаходження суми n членів прогресії
            {
                if (coefficient == 1)
                {
                    return n * startNumber;
                }
                else
                {
                    return startNumber * (Math.Pow(coefficient, n) - 1) / (coefficient - 1);
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                IProgression arithmeticProgression = null;
                IProgression geometricProgression = null;

                while (true)
                {
                    Console.WriteLine("Виберіть опцію:");
                    Console.WriteLine("1. Задати арифметичну прогресію");
                    Console.WriteLine("2. Знайти n-й член арифметичної прогресії");
                    Console.WriteLine("3. Знайти суму n членів арифметичної прогресії");
                    Console.WriteLine("4. Задати геометричну прогресію");
                    Console.WriteLine("5. Знайти n-й член геометричної прогресії");
                    Console.WriteLine("6. Знайти суму n членів геометричної прогресії");
                    Console.WriteLine("7. Вийти");

                    int option = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();

                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Введіть початковий член арифметичної прогресії:");
                            double startNumberArithmetic = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введіть різницю арифметичної прогресії:");
                            double difference = Convert.ToDouble(Console.ReadLine());
                            arithmeticProgression = new ArithmeticProgression(startNumberArithmetic, difference);
                            Console.WriteLine("Арифметична прогресія задана.");
                            break;

                        case 2:
                            if (arithmeticProgression != null)
                            {
                                Console.WriteLine("Введіть номер члена, який потрібно знайти:");
                                int nArithmetic = Convert.ToInt32(Console.ReadLine());
                                double XnArithmetic = arithmeticProgression.GetXn(nArithmetic);
                                Console.WriteLine($"n-й член арифметичної прогресії: {XnArithmetic}");
                            }
                            else
                            {
                                Console.WriteLine("Арифметична прогресія не задана.");
                            }
                            break;

                        case 3:
                            if (arithmeticProgression != null)
                            {
                                Console.WriteLine("Введіть кількість членів, суму яких потрібно знайти:");
                                int nSumArithmetic = Convert.ToInt32(Console.ReadLine());
                                double sumOfValuesArithmetic = arithmeticProgression.GetSum(nSumArithmetic);
                                Console.WriteLine($"Сума перших n членів арифметичної прогресії: {sumOfValuesArithmetic}");
                            }
                            else
                            {
                                Console.WriteLine("Арифметична прогресія не задана.");
                            }
                            break;

                        case 4:
                            Console.WriteLine("Введіть початковий член геометричної прогресії:");
                            double startNumberGeometric = Convert.ToDouble(Console.ReadLine());
                            Console.WriteLine("Введіть співвідношення геометричної прогресії:");
                            double coefficient = Convert.ToDouble(Console.ReadLine());
                            geometricProgression = new GeometricProgression(startNumberGeometric, coefficient);
                            Console.WriteLine("Геометрична прогресія задана.");
                            break;

                        case 5:
                            if (geometricProgression != null)
                            {
                                Console.WriteLine("Введіть номер члена, який потрібно знайти:");
                                int nGeometric = Convert.ToInt32(Console.ReadLine());
                                double XnGeometric = geometricProgression.GetXn(nGeometric);
                                Console.WriteLine($"n-й член геометричної прогресії: {XnGeometric}");
                            }
                            else
                            {
                                Console.WriteLine("Геометрична прогресія не задана.");
                            }
                            break;

                        case 6:
                            if (geometricProgression != null)
                            {
                                Console.WriteLine("Введіть кількість членів, суму яких потрібно знайти:");
                                int nSumGeometric = Convert.ToInt32(Console.ReadLine());
                                double sumOfValuesGeometric = geometricProgression.GetSum(nSumGeometric);
                                Console.WriteLine($"Сума перших n членів геометричної прогресії: {sumOfValuesGeometric}");
                            }
                            else
                            {
                                Console.WriteLine("Геометрична прогресія не задана.");
                            }
                            break;

                        case 7:
                            return;

                        default:
                            Console.WriteLine("Невірний вибір. Будь ласка, спробуйте ще раз.");
                            break;
                    }
                    Console.WriteLine();
                }
            }
        }
    }
