namespace lab_6_OOP
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;

    class OneDimArray
    {
        private double[] array;

        public OneDimArray(int size) //конструктор 
        {
            array = new double[size];
            FillArrayWithRandomNumbers();
        }

        private void FillArrayWithRandomNumbers() // Метод генерацiї числа вiд -10 до 10
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Math.Round(random.NextDouble() * 20 - 10, 1);
            }
        }

        public double SumBeforeNegative() // метод обчислення суми елементiв масиву до першого вiд'ємного числа
        {
            double sum = 0.0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    break;
                }
                sum += array[i];
            }
            return sum;
        }

        public void Sorting() // метод сортування масиву за спаданням модулiв елементiв
        {
            Array.Sort(array, (x, y) => Math.Abs(y).CompareTo(Math.Abs(x))); // 2й аргумент - це лямбда-вираз за допомогою якого ми вводимо х та у якi є
        }                                                                    // представленням елементiв масиву що порiвнюються мiж собою

        public void PrintArray() //вивiд масиву
        {
            Console.WriteLine("Масив:");
            foreach (double element in array)
            {
                Console.WriteLine(element);
            }
        }
    }
    class Vector
    {
        private double[] elements;

        public Vector(int size) //конструктор
        {
            elements = new double[size];
            FillVectorManually();
        }

        private void FillVectorManually() // Метод вводу елементiв векторiв
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write($"Елемент {i + 1}: ");
                elements[i] = double.Parse(Console.ReadLine());
            }
        }

        public void CalculateVectorC(Vector vectorA, Vector vectorB, Vector vectorC) //формула розрахунку вектора С
        {
            for (int i = 0; i < elements.Length; i++)
            {
                elements[i] = 2 * (vectorA[i] + vectorC[i]) - 3 * (vectorA[i] - vectorB[i]);
            }
        }
        public int Size
        {
            get { return elements.Length; } //геттер для розмiру
        }
        public double this[int index] //геттер та сеттер для значень елементiв вектору
        {
            get { return elements[index]; }
            set { elements[index] = value; }
        }

        public void PrintVector() //метод виводу вектора
        {
            Console.Write("Вектор c=2(a+c)-3(a-b) = ");
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write($"{elements[i]} ");
            }
            Console.WriteLine();
        }
    }

    class Matrix
    {
        private int[,] matrix; // 2-вимірний масив: матриця

        public Matrix(int size) //конструктор
        {
            matrix = new int[size, size];
        }

        public void FillMatrix() //заповнення матриці випадковими значеннями
        {
            Random random = new Random();
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = random.Next(-10, 11);
                }
            }
        }

        public void SortArray() //метод впорядкування елементів матрицi за спаданням модулiв
        {
            int size = matrix.GetLength(0);

            int[] oneDimArray = new int[size * size]; //створимо 1-вимірний масив і запишемо в нього значення матриці для зручного сортування
            int index = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    oneDimArray[index++] = matrix[i, j];
                }
            }

            Array.Sort(oneDimArray, (x, y) => Math.Abs(y).CompareTo(Math.Abs(x))); // лямбда-вираз для сортування масиву за спаданням значень по модулю

            index = 0; 
            for (int i = 0; i < size; i++) // цикл заповнення двомірного масиву(матриці) сортованими значеннями одновимірного масиву
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = oneDimArray[index++];
                }
            }
        }
        public void MoveNegativeElements()
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i += 2)
            {
                List<int> negatives = new List<int>(); // масив для збереження від'ємних елементів

                for (int j = 0; j < cols; j++) // запис знайдених від'ємних елементів в масив
                {
                    if (matrix[i, j] < 0)
                    {
                        negatives.Add(matrix[i, j]);
                    }
                }

                int index = cols - 1; // змінна яка вказує на останній стовпець
                for (int j = cols - 1; j >= 0; j--) //метод переміщення елементів вправо, щоб звільнити місце для від'ємних елементів
                {
                    if (matrix[i, j] >= 0) // якщо елемент не від'ємний то він лишиться на своєму місці
                    {
                        matrix[i, index] = matrix[i, j];
                        index--;
                    }
                }

                for (int j = negatives.Count - 1; j >= 0; j--) //розміщення негативних елементів на початку рядка
                {
                    matrix[i, j] = negatives[negatives.Count - 1 - j];
                }
            }
        }
        public int CountSortedRows() // метод що раху кількість рядків вже впорядкованих за зростанням
        {
            int count = 0;
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                bool isSorted = true;

                for (int j = 0; j < cols - 1; j++)
                {
                    if (matrix[i, j] > matrix[i, j + 1])
                    {
                        isSorted = false;
                        break;
                    }
                }

                if (isSorted)
                {
                    count++;
                }
            }

            return count;
        }

        public void PrintMatrix() //метод виводу матриці
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            OneDimArray array = null; //створення екземплярiв класу для наших завдань
            Vector vectorA = null;
            Vector vectorB = null;
            Vector vectorC = null;
            Matrix matrix = null;

            while (true)
            {
                Console.WriteLine("Оберiть завдання:");
                Console.WriteLine("1. Ввести кiлькiсть елементiв одновимiрного масиву");
                Console.WriteLine("2. Вивести суму елементiв до першого вiд'ємного числа");
                Console.WriteLine("3. Вiдсортувати масив за спаданням за абсолютним значенням");
                Console.WriteLine("4. Розрахувати вектор С");
                Console.WriteLine("5. Створити квадратну матрицю");
                Console.WriteLine("6. Заповнити матрицю випадковими числами");
                Console.WriteLine("7. Впорядкувати елементи матрицi за спаданням модулiв");
                Console.WriteLine("8. Перемiстити вiд'ємнi елементи парних(0,2,4...) рядкiв налiво");
                Console.WriteLine("9. Визначити кiлькiсть рядкiв з елементами, що упорядкованi за зростанням");
                Console.WriteLine("10. Вивести матрицю");
                Console.WriteLine("11. Вийти з програми");

                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Введiть кiлькiсть елементiв одновимiрного масиву:");
                            int quantity = int.Parse(Console.ReadLine());
                            array = new OneDimArray(quantity);
                            array.PrintArray();
                            Console.WriteLine();
                            break;
                        case 2:
                            if (array == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 1");
                                Console.WriteLine();
                            }
                            else
                            {
                                double sum = array.SumBeforeNegative();
                                Console.WriteLine("Сума елементiв до першого вiд'ємного числа: " + sum);
                                Console.WriteLine();
                            }
                            break;
                        case 3:
                            if (array == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 1");
                                Console.WriteLine();
                            }
                            else
                            {
                                array.Sorting();
                                array.PrintArray();
                                Console.WriteLine();
                            }
                            break;
                        case 4:
                            Console.WriteLine("Введiть розмiрнiсть простору векторiв:");
                            int size = int.Parse(Console.ReadLine());

                            Console.WriteLine("Введiть елементи вектора А:");
                            vectorA = new Vector(size);
                            Console.WriteLine("Введiть елементи вектора B:");
                            vectorB = new Vector(size);
                            Console.WriteLine("Введiть елементи вектора C:");
                            vectorC = new Vector(size);

                            vectorC.CalculateVectorC(vectorA, vectorB, vectorC);
                            vectorC.PrintVector();
                            Console.WriteLine();
                            break;

                        case 5:
                            Console.WriteLine("Введiть розмiрнiсть квадратної матрицi:");
                            int matrixSize = int.Parse(Console.ReadLine());
                            matrix = new Matrix(matrixSize);
                            Console.WriteLine("Матриця створена.");
                            Console.WriteLine();
                            break;
                        case 6:
                            if (matrix == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 5");
                                Console.WriteLine();
                            }
                            else
                            {
                                matrix.FillMatrix();
                                Console.WriteLine("Матриця заповнена випадковими числами.");
                                Console.WriteLine();
                            }
                            break;
                        case 7:
                            if (matrix == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 5");
                                Console.WriteLine();
                            }
                            else
                            {
                                matrix.SortArray();
                                Console.WriteLine("Елементи матрицi впорядкованi за спаданням модулiв.");
                                Console.WriteLine();
                            }
                            break;
                        case 8:
                            if (matrix == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 5");
                                Console.WriteLine();
                            }
                            else
                            {
                                matrix.MoveNegativeElements();
                                Console.WriteLine("Вiд'ємнi елементи парних рядкiв перемiщенi налiво.");
                                Console.WriteLine();
                            }
                            break;
                        case 9:
                            if (matrix == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 5");
                                Console.WriteLine();
                            }
                            else
                            {
                                int sortedRows = matrix.CountSortedRows();
                                Console.WriteLine($"Кiлькiсть рядкiв з елементами, що упорядкованi за зростанням: {sortedRows}");
                                Console.WriteLine();
                            }
                            break;
                        case 10:
                            if (matrix == null)
                            {
                                Console.WriteLine("Спочатку оберiть опцiю 5");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Матриця:");
                                matrix.PrintMatrix();
                                Console.WriteLine();
                            }
                            break;
                        case 11:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Помилка! Оберiть значення iз списку меню");
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
    }
}