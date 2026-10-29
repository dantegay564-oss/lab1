using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public static class TextActions
{
    public static void SortByWordCount(Text text)
    {
        text.Sentences = text.Sentences.OrderBy(s => s.WordCount()).ToList();
        ShowResult(text);
    }

    public static void SortByLength(Text text)
    {
        text.Sentences = text.Sentences.OrderBy(s => s.Content.Length).ToList();
        ShowResult(text);
    }

    public static void ShowUniqueWordsInQuestions(Text text)
    {
        int length = ReadNumber("Длина слова: ");
        if (length <= 0) { Console.WriteLine("Неверная длина."); Console.ReadKey(); return; }

        var words = text.Sentences
            .Where(s => s.Content.TrimEnd().EndsWith("?"))
            .SelectMany(s => s.Words)
            .Select(w => w.Value)
            .Where(w => w.Length == length)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        var list = words.ToList();
        Console.WriteLine(list.Count == 0
            ? "Подходящих слов нет."
            : string.Join(" ", list));
        Console.ReadKey();
    }

    public static void RemoveConsonantWords(Text text)
    {
        int length = ReadNumber("Длина слова: ");
        if (length <= 0) { Console.WriteLine("Неверная длина."); Console.ReadKey(); return; }

        foreach (Sentence sentence in text.Sentences)
        {
            sentence.Content = Regex.Replace(sentence.Content,
                RegexPatterns.LettersOnlyWord, m =>
                {
                    string word = m.Value;
                    return word.Length == length && IsConsonant(word[0]) ? "" : word;
                });
            sentence.Content = Regex.Replace(sentence.Content, RegexPatterns.ExtraSpaces, " ").Trim();
        }
        ShowResult(text);
    }

    public static void ReplaceWords(Text text)
    {
        if (text.Sentences.Count == 0)
        {
            Console.WriteLine("Нет предложений.");
            Console.ReadKey();
            return;
        }

        int index = ReadNumber($"Номер предложения (1-{text.Sentences.Count}): ");
        int length = ReadNumber("Длина заменяемого слова: ");
        if (length <= 0) { Console.WriteLine("Неверная длина."); Console.ReadKey(); return; }
        if (index < 1 || index > text.Sentences.Count)
        {
            Console.WriteLine("Неверный номер.");
            Console.ReadKey();
            return;
        }

        Console.Write("На какую подстроку заменить: ");
        string replacement = Console.ReadLine() ?? "";

        text.Sentences[index - 1].Content = Regex.Replace(
            text.Sentences[index - 1].Content,
            RegexPatterns.LettersOnlyWord,
            m => m.Value.Length == length ? replacement : m.Value);

        text.Sentences[index - 1].Content =
            Regex.Replace(text.Sentences[index - 1].Content, RegexPatterns.ExtraSpaces, " ").Trim();

        ShowResult(text);
    }

    public static void RemoveStopWords(Text text)
    {
        HashSet<string> stopWords = StopWords.Load("stopwords_ru.txt");
        stopWords.UnionWith(StopWords.Load("stopwords_en.txt"));

        foreach (Sentence sentence in text.Sentences)
        {
            sentence.Content = StopWords.Remove(sentence.Content, stopWords);
            sentence.Content = Regex.Replace(sentence.Content, RegexPatterns.ExtraSpaces, " ").Trim();
        }
        ShowResult(text);
    }

    public static void SaveToXml(Text text)
    {
        try
        {
            XmlExporter.Save(text, "text.xml");
            Console.WriteLine("Сохранено в файл text.xml");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Не удалось сохранить XML: " + ex.Message);
        }
        Console.ReadKey();
    }
    private static void ShowResult(Text text)
    {
        Console.WriteLine("\nРезультат:");
        Console.WriteLine(text);
        Console.WriteLine("\nНажмите любую клавишу...");
        Console.ReadKey();
    }

    private static int ReadNumber(string message)
    {
        Console.Write(message);
        return int.TryParse(Console.ReadLine(), out int number) ? number : -1;
    }

    private static bool IsConsonant(char c)
    {
        const string vowels = "аеёиоуыэюяaeiouy";
        return char.IsLetter(c) && !vowels.Contains(char.ToLower(c));
    }
}