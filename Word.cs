public class Word : Sentence
{
    public string Value
    {
        get => Content;
        set => Content = value;
    }

    public Word() : base() { }

    public Word(string value) : base(value) { }
}