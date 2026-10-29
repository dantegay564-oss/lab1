public static class RegexPatterns
{
    public const string Sentence = @"[^.!?]+(?:[.!?]+|$)";
    public const string Word = @"[\p{L}\p{N}]+(?:[-'][\p{L}\p{N}]+)*";
    public const string LettersOnlyWord = @"\b[\p{L}]+\b";
    public const string Punctuation = @"[^\p{L}\p{N}\s]";
    public const string ExtraSpaces = @"\s+";
    public const string Whitespace = @"\s+";
}