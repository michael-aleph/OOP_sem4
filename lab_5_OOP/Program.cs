using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace lab_5_OOP
{
    class TSMatrix
    {
        public int[,]? array = null; // ініціалізація 2-вимірного масиву
        protected int size = 0;
        public TSMatrix() { } //конструктор без параметрів
        public TSMatrix(int[,] arr) //конструктор з параметрами
        {
            size = arr.GetLength(0);
            array = new int[size, size];
            Array.Copy(arr, 0, array, 0, arr.Length);
        }
        public TSMatrix(TSMatrix tS) //конструктор копіювання
        {
            size = tS.size;
            array = new int[tS.size, tS.size];
            Array.Copy(tS.array, 0, array, 0, tS.size);
        }
        public void Input() //метод вводу інформації
        {
            try
            {
                String[] str;
                Console.Write("Enter size of matrix: ");
                size = int.Parse(Console.ReadLine());
                array = new int[size, size];
                Console.WriteLine("Enter values of matrix: ");
                for (int i = 0; i < size; ++i)
                {
                    str = (Console.ReadLine()).Split();
                    for (int j = 0; j < size; ++j)
                    {
                        array[i, j] = int.Parse(str[j]);
                    }
                }
            }
            catch
            {
                Console.WriteLine("Error! Wrong input");
                Environment.Exit(1);
            };

        }
        public void Print() //метод виводу інформації
        {
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    Console.Write($"{array[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public int Max() //метод пошуку максимального значення
        {
            int result = 0;
            if (size != 0)
            {
                result = array[0, 0];
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        if (array[i, j] > result)
                        {
                            result = array[i, j];
                        }
                    }
                }
            }
            return result;
        }
        public int Min() //метод пошуку мінімального значення
        {
            int result = 0;
            if (size != 0)
            {
                result = array[0, 0];
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        if (array[i, j] < result)
                        {
                            result = array[i, j];
                        }
                    }
                }
            }
            return result;
        }
        public int Sum() //метод пошуку суми
        {
            int result = 0;
            if (size != 0)
            {
                for (int i = 0; i < size; ++i)
                {
                    for (int j = 0; j < size; ++j)
                    {
                        result += array[i, j];
                    }
                }
            }
            return result;
        }
        public static TSMatrix operator +(TSMatrix matrix1, TSMatrix matrix2) //метод перевантаження оператору +
        {
            TSMatrix result = new TSMatrix();
            if (matrix1.size == matrix2.size && (matrix1.size != 0))
            {
                result.size = matrix1.size;
                result.array = new int[matrix1.size, matrix1.size];
                for (int i = 0; i < matrix1.size; ++i)
                {
                    for (int j = 0; j < matrix1.size; ++j)
                    {
                        result.array[i, j] = matrix1.array[i, j] + matrix2.array[i, j];
                    }
                }
            }
            return result;
        }
        public static TSMatrix operator -(TSMatrix matrix1, TSMatrix matrix2) //метод перевантаження оператору -
        {
            TSMatrix result = new TSMatrix();
            if (matrix1.size == matrix2.size && (matrix1.size != 0))
            {
                result.size = matrix1.size;
                result.array = new int[matrix1.size, matrix1.size];
                for (int i = 0; i < matrix1.size; ++i)
                {
                    for (int j = 0; j < matrix1.size; ++j)
                    {
                        result.array[i, j] = matrix1.array[i, j] - matrix2.array[i, j];
                    }
                }
            }
            return result;
        }

    }
    class TDeterminant : TSMatrix
    {
        public TDeterminant() : base() { }

        public TDeterminant(int[,] arr) : base(arr) {
        }

        public TDeterminant(TDeterminant tD) : base(tD) { }

        public int CalculateDeterminant(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                Console.WriteLine("Error! Wrong size of matrix");
                return 0;
            }
        }
    }

    class Program
    {  
        public static void PrintHelp()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("1 - display menu");
            Console.WriteLine("2 - set matrix1 elements");
            Console.WriteLine("3 - print matrix1 elements");
            Console.WriteLine("4 - MAX from matrix1 elements");
            Console.WriteLine("5 - MIN from matrix1 elements");
            Console.WriteLine("6 - SUM of matrix1 elements");
            Console.WriteLine("7 - set matrix2 elements");
            Console.WriteLine("8 - print matrix2 elements");
            Console.WriteLine("9 - matrix2 = matrix1 + matrix2");
            Console.WriteLine("10 - matrix2 = matrix1 - matrix2");
            Console.WriteLine("11 - determinant of matrix1");
            Console.WriteLine("12 - exit");
        }
        public static void Main(string[] args)
        {     
            TSMatrix matrix1 = new(), matrix2 = new();
            TDeterminant determinant = new();

            string[] str;
            int size;
            int[,]? array;
            int command = 0;

            PrintHelp();
            while (command != 12)
            {
                Console.Write("Enter command: ");
                try
                {
                    command = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong input");
                    continue;
                }

                switch (command)
                {
                    case 1:
                        PrintHelp();
                        break;
                    case 2:
                        matrix1.Input();
                        break;
                    case 3:
                        if (matrix1.array != null)
                        {
                            matrix1.Print();
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix1 is not initialized.");
                        }
                        break;
                    case 4:
                        if (matrix1.array != null)
                        {
                            Console.WriteLine($"Matrix1 maximum element is {matrix1.Max()}");
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix1 is not initialized.");
                        }
                        break;
                    case 5:
                        if (matrix1.array != null)
                        {
                            Console.WriteLine($"Matrix1 minimum element is {matrix1.Min()}");
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix1 is not initialized.");
                        }
                        break;
                    case 6:
                        if (matrix1.array != null)
                        {
                            Console.WriteLine($"Matrix1 sum of elements is {matrix1.Sum()}");
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix1 is not initialized.");
                        }
                        break;
                    case 7:
                        matrix2.Input();
                        break;
                    case 8:
                        if (matrix2.array != null)
                        {
                            matrix2.Print();
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix2 is not initialized.");
                        }
                        break;
                    case 9:
                        if (matrix1.array != null && matrix2.array != null)
                        {
                            matrix2 = matrix1 + matrix2;
                        }
                        else
                        {
                            Console.WriteLine("Error! Both matrices must be initialized.");
                        }
                        break;
                    case 10:
                        if (matrix1.array != null && matrix2.array != null)
                        {
                            matrix2 = matrix1 - matrix2;
                        }
                        else
                        {
                            Console.WriteLine("Error! Both matrices must be initialized.");
                        }
                        break;
                    case 11:
                        if (matrix1.array != null)
                        {
                            int result = determinant.CalculateDeterminant(matrix1.array);
                            Console.WriteLine("Determinant of matrix1 is: " + result);
                        }
                        else
                        {
                            Console.WriteLine("Error! Matrix1 is not initialized.");
                        }
                        break;
                    case 12:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please type correct value from the list");
                        break;
                }
            }
        }
    }
}
