using System;

namespace GeneticSearch
{
    class RLETest
    {
        static void Test(string input, string expected)
        {
            string actual = Decoder.Decoding(input);
            if (actual == expected)
                Console.WriteLine("OK   " + input + "  ->  " + actual);
            else
                Console.WriteLine("FAIL " + input + "  ->  " + actual + "  (ждали " + expected + ")");
        }

        public static void Run()
        {
            Console.WriteLine("Проверка декодера");
            Test("ACDEF", "ACDEF");
            Test("AA", "AA");
            Test("3A", "AAA");
            Test("9A", "AAAAAAAAA");
            Test("FK3I", "FKIII");
            Test("AAGAT4AGTG3TC", "AAGATAAAAGTGTTTC");
            Test("KLSQ3LVN", "KLSQLLLVN");
            Console.WriteLine();
        }
    }
}