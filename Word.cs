namespace lab4
{
    public class Word : Token
    {
        public Word() : base() { }
        public Word(string value) : base(value) { }

        public override string ToString()
        {
            return Value;
        }
    }
}