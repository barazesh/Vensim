using System;
using System.IO;
using System.Text.RegularExpressions;

namespace VensimConsole
{
    public class VensimVariableExtractor
    {
        public static void Extract(string filePath)
        {
            string fileText = string.Empty;
            try
            {
                fileText = File.ReadAllText(filePath);

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex.Message);

            }
            Regex rg = new Regex(@"\((\d{3})\)\s+((\w+\s)*\w*)=");
            var matches = rg.Matches(fileText);
            System.Console.WriteLine($"{matches.Count} matches found");
            foreach (Match item in matches)
            {
                System.Console.WriteLine($"{item.Groups[1]}--{item.Groups[2]}");
            }


        }
    }
}