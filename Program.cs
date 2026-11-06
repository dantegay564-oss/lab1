using System;

namespace lab4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // Вызываем наш отдельный класс с тестом
            Console.WriteLine("=== ЗАПУСК АВТОМАТИЧЕСКОГО ТЕСТА ===");
            TestRunner.Run();
            Console.WriteLine("=====================================\n");

            // Дальше идет обычный режим работы программы
            Console.WriteLine("Теперь запустим программу в обычном режиме.");
            Console.Write("Введите количество строк: ");

            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.WriteLine("Введено неверное количество строк. Программа завершена.");
                Console.ReadLine();
                return;
            }

            string source = "";
            Console.WriteLine("Введите текст построчно:");

            for (int i = 0; i < n; i++)
            {
                source += Console.ReadLine();
                if (i < n - 1)
                {
                    source += Environment.NewLine;
                }
            }

            TextParser parser = new TextParser();
            Text text = parser.Parse(source);

            Console.WriteLine();
            Console.WriteLine("КОНКОРДАНС:");
            Console.WriteLine(text.GetConcordanceText());

            Console.ReadLine();
        }
    }
}