using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        ParserTest.Run();
        Console.WriteLine("Введите текст:");
        string source = ReadTextFromConsole();

        if (string.IsNullOrWhiteSpace(source))
        {
            Console.WriteLine("Пустой текст. Выход.");
            return;
        }

        Text text = new TextParser().Parse(source);

        while (true)
        {
            Console.Clear(); 
            Console.WriteLine("ТЕКСТ:");
            Console.WriteLine(text);
            Console.WriteLine("\n1. Сортировать предложения по количеству слов");
            Console.WriteLine("2. Сортировать предложения по длине");
            Console.WriteLine("3. Уникальные слова заданной длины в вопросительных предложениях");
            Console.WriteLine("4. Удалить слова заданной длины, начинающиеся с согласной");
            Console.WriteLine("5. Заменить слова заданной длины в предложении");
            Console.WriteLine("6. Удалить стоп-слова");
            Console.WriteLine("7. Сохранить текст в XML");
            Console.WriteLine("0. Выход");
            Console.Write("Выбор: ");

            string choice = Console.ReadLine();
            if (choice == "0") break;
            switch (choice)
            {
                case "1": TextActions.SortByWordCount(text); break;
                case "2": TextActions.SortByLength(text); break;
                case "3": TextActions.ShowUniqueWordsInQuestions(text); break;
                case "4": TextActions.RemoveConsonantWords(text); break;
                case "5": TextActions.ReplaceWords(text); break;
                case "6": TextActions.RemoveStopWords(text); break;
                case "7": TextActions.SaveToXml(text); break;
                default:
                    Console.WriteLine("Нет такого пункта меню.");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static string ReadTextFromConsole()
    {
        var lines = new List<string>();
        string line;
        while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            lines.Add(line);
        return string.Join(" ", lines);
    }
}