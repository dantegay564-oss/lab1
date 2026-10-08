using System.Collections.Generic;
using System.IO;

namespace GeneticSearch
{
    static class CommandHandler
    {
        public static void Handle(List<Protein> proteins, List<Command> commands, string outputFilename, string authorName)
        {
            using (StreamWriter writer = new StreamWriter(outputFilename))
            {
                writer.WriteLine(authorName);
                writer.WriteLine("Genetic Searching");
                writer.WriteLine("--------------------------------------------------------------------------");

                int commandNumber = 1;
                for (int i = 0; i < commands.Count; i++)
                {
                    Command cmd = commands[i];
                    string number = commandNumber.ToString("D3");
                    string param1 = cmd.name == "search" ? Decoder.Decoding(cmd.parameter1) : cmd.parameter1;
                    string commandLine = number + "   " + cmd.name + "   " + param1;
                    if (!string.IsNullOrEmpty(cmd.parameter2))
                        commandLine += "   " + cmd.parameter2;

                    if (cmd.name == "diff") commandLine += " ";
                    if (cmd.name == "mode") commandLine += "  ";

                    writer.WriteLine(commandLine);

                    if (cmd.name == "search")
                    {
                        Handlers.HandleSearch(proteins, cmd.parameter1, writer);
                    }
                    else if (cmd.name == "diff")
                    {
                        Handlers.HandleDiff(proteins, cmd.parameter1, cmd.parameter2, writer);
                    }
                    else if (cmd.name == "mode")
                    {
                        Handlers.HandleMode(proteins, cmd.parameter1, writer);
                    }

                    writer.WriteLine("--------------------------------------------------------------------------");
                    commandNumber++;
                }
            }
        }
    }
}