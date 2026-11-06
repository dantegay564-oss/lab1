using System;

namespace lab4
{
    public class TestRunner
    {
        public static void Run()
        {
           
            string testText = "Кот увидел мышь.\nМышь убежала в нору.\nКот съел сыр!\nСыр был вкусным.";

            
            string nl = Environment.NewLine;
            string expected =
                "был — количество: 1, строки: 4" + nl +
                "в — количество: 1, строки: 2" + nl +
                "вкусным — количество: 1, строки: 4" + nl +
                "кот — количество: 2, строки: 1, 3" + nl +
                "мышь — количество: 2, строки: 1, 2" + nl +
                "нору — количество: 1, строки: 2" + nl +
                "съел — количество: 1, строки: 3" + nl +
                "сыр — количество: 2, строки: 3, 4" + nl +
                "убежала — количество: 1, строки: 2" + nl +
                "увидел — количество: 1, строки: 1";

            TextParser parser = new TextParser();
            Text text = parser.Parse(testText);
            string actual = text.GetConcordanceText().Trim();

            Console.WriteLine("Входной текст для теста:");
            Console.WriteLine(testText);
            Console.WriteLine("\nОжидаемый результат:");
            Console.WriteLine(expected);
            Console.WriteLine("\nФактический результат (что выдала программа):");
            Console.WriteLine(actual);

            Console.WriteLine("\n--- ВЕРДИКТ ---");
            if (actual == expected)
            {
                
                Console.WriteLine("СОВПАЛО! Тест пройден.");
            }
            else
            {
            
                Console.WriteLine("НЕ СОВПАЛО! Есть ошибки в коде.");
            }
            Console.ResetColor();
        }
    }
}