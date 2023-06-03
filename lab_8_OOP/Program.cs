namespace lab_8_OOP //Варіант завдання: 3
{
    using System;
    using System.IO;
    using System.Text;
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            PunctuationCounter punctuationCounter = new PunctuationCounter();

            while (true)
            {
                Console.WriteLine("Обчислення кількості знаків пунктуації");
                Console.WriteLine("1. Зчитати текст з файлу");
                Console.WriteLine("2. Ввести текст вручну");
                Console.WriteLine("0. Вийти з програми");
                Console.Write("Виберіть опцію: ");

                string input = Console.ReadLine();
                if (int.TryParse(input, out int option))
                {
                    switch (option)
                    {
                        case 1:
                            punctuationCounter.CountFromFile();
                            break;
                        case 2:
                            punctuationCounter.CountManually();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                }

                Console.WriteLine();
            }
        }
    }

    class PunctuationCounter
    {
        private int CountPunctuation(IEnumerable<char> symbols) // використовуємо інтерфейс IEnumerable<char> що визначає метод GetEnumerator()
        {                                                       // Цей метод у свою чергу повертає об'єкт, що реалізує інтерфейс IEnumerable<char>
            int punctuationCount = 0;                           // Реалізація відбувається правильним чином гнучко в залежності чи ми передаємо <List>char чи char[]

            foreach (char c in symbols)
            {
                if (char.IsPunctuation(c)) // можна додати || char.IsSymbol(c) якщо ми хочемо до пунктуаційних знаків враховувати такі символи як $, ^, *, + і подібне
                {
                    punctuationCount++;
                }
            }

            return punctuationCount;
        }
        public void CountFromFile()
        {
            string filePath = @"E:\STU_DYING\C# ООП 4 сем Шолохов-Білий\lab_8_OOP\text.txt";
            string text = File.ReadAllText(filePath);

            // List<char> symbols = new List<char>(text); // Варіант з List<char> (щоб змінити, приберіть коментар у цьому рядку і закоментуйте інший варіант)
            char[] symbols = text.ToCharArray(); // Варіант з char[]

            int punctuationCount = CountPunctuation(symbols); //використання методу CountPunctuation, що проходить по всьому масиву/списку symbols, і виконує перевірку кожного символу, записує результат в змінну

            Console.WriteLine("Кількість знаків пунктуації в файлі: " + punctuationCount);
        }

        public void CountManually()
        {
            Console.Write("Введіть текст: ");
            string inputText = Console.ReadLine();

            //List<char> symbols = new List<char>(inputText); // Варіант з List<char> (щоб змінити, приберіть коментар у цьому рядку і закоментуйте інший варіант)
            char[] symbols = inputText.ToCharArray(); // Варіант з char[]

            int punctuationCount = CountPunctuation(symbols); //використання методу CountPunctuation, що проходить по всьому масиву/списку symbols, і виконує перевірку кожного символу, записує результат в змінну

            Console.WriteLine("Кількість знаків пунктуації в тексті: " + punctuationCount);
        }

    }

}
