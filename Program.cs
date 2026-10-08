using System;
using System.Collections.Generic;

namespace GeneticSearch
{
    class Program
    {
        static void PrintStartupInfo(string sequencesFile, string commandsFile, string outputFile, int proteinsCount, int commandsCount)
        {
            Console.WriteLine("=== GENETIC SEARCH ===");
            Console.WriteLine($"Input sequences: {sequencesFile}");
            Console.WriteLine($"Input commands: {commandsFile}");
            Console.WriteLine($"Output file: {outputFile}");
            Console.WriteLine();
            Console.WriteLine($"Loaded {proteinsCount} proteins");
            Console.WriteLine($"Loaded {commandsCount} commands");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            RLETest.Run();
            string sequencesFile = "sequences.0.txt";
            string commandsFile = "commands.0.txt";
            string outputFile = "genedata.txt";
            string authorName = "Yan";

            if (args.Length >= 1)
                sequencesFile = args[0];
            if (args.Length >= 2)
                commandsFile = args[1];
            if (args.Length >= 3)
                outputFile = args[2];
            if (args.Length >= 4)
                authorName = args[3];

            List<Protein> data = FileReader.ReadData(sequencesFile);
            List<Command> commands = FileReader.ReadCommands(commandsFile);

            PrintStartupInfo(sequencesFile, commandsFile, outputFile, data.Count, commands.Count);

            CommandHandler.Handle(data, commands, outputFile, authorName);

            Console.WriteLine($"Done! Output written to {outputFile}");
        }
    }
}