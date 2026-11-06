namespace lab4
{
    public class Punctuation : Token
    {
        public Punctuation() : base() { }
        public Punctuation(string value) : base(value) { }

        public override string ToString()
        {
            return Value;
        }
    }
}