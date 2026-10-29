using System;
using System.Linq;

public class ParserTest
{
    public static void Run()
    {
        Console.WriteLine("=== ЗАПУСК ТЕСТОВ ===");
        int passed = 0;
        int failed = 0;
        var text = new TextParser().Parse("Привет, мир! Это тест. Как дела?");
        Check("Количество предложений", 3, text.Sentences.Count);
        Check("Первое предложение", "Привет, мир!", text.Sentences[0].Content);
        Check("Второе предложение", "Это тест.", text.Sentences[1].Content);
        var sentence = new Sentence("Привет, мир!");
        Check("Количество слов", 2, sentence.WordCount());
        Check("Первое слово", "Привет", sentence.Words[0].Value);
        Check("Второе слово", "мир", sentence.Words[1].Value);
        Check("Количество знаков", 2, sentence.PunctuationMarks.Count);
        Check("Первый знак", ",", sentence.PunctuationMarks[0].Value);
        var complexSentence = new Sentence("Мама-и-папа, 2024 год.");
        Check("Слово с дефисом", "Мама-и-папа", complexSentence.Words[0].Value);
        Check("Число как слово", "2024", complexSentence.Words[1].Value);

        
        var stopWords = new System.Collections.Generic.HashSet<string> { "и", "в", "на" };
        string before = "Мама и папа в доме на горе.";
        string after = StopWords.Remove(before, stopWords);
        Check("Стоп-слова удалены", "Мама  папа  доме  горе.", after); 

        
        var sortText = new TextParser().Parse("Привет! Как дела? Хорошо.");
        var sortedSentences = sortText.Sentences.OrderBy(s => s.WordCount()).ToList();
        Check("Самое короткое предложение", "Привет!", sortedSentences[0].Content);

        Console.WriteLine($"\n=== ИТОГ: {passed} пройдено, {failed} провалено ===");
        if (failed == 0)
            Console.WriteLine(" ВСЕ ТЕСТЫ УСПЕШНО ПРОЙДЕНЫ!");
        else
            Console.WriteLine(" ЕСТЬ ОШИБКИ!");

        Console.ReadKey();
    }

    
    private static void Check<T>(string name, T expected, T actual)
    {
        if (Equals(expected, actual))
        {
            Console.WriteLine($"[OK] {name}");
        }
        else
        {
            Console.WriteLine($"[FAIL] {name}. Ожидалось: '{expected}', получено: '{actual}'");
        }
    }
}