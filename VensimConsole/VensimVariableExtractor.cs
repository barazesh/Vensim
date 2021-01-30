using System;
using System.Collections.Generic;
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
            Regex variableRegex = new Regex(@"\((\d{3})\)\s+(.+)\=\n?([\s\S]+?)\s+Units\:\s+(.+)");
            Regex whitespace = new Regex(@"\s{2,}");
            var matches = variableRegex.Matches(fileText);
            System.Console.WriteLine($"{matches.Count} matches found");
            List<VensimVariable> variables = new List<VensimVariable>();
            foreach (Match item in matches)
            {
                VensimVariable temp = new VensimVariable
                {
                    Number = int.Parse(item.Groups[1].Value),
                    Name = item.Groups[2].Value.Replace("\r\n", "").Trim(),
                    Value = whitespace.Replace(item.Groups[3].Value,""),
                    Unit = item.Groups[4].Value.Replace("\r\n", "").Trim()
                };
                System.Console.WriteLine($"{temp.Number}--{temp.Name}--{temp.Value}--{temp.Unit}");
                System.Console.WriteLine("---------------------------------------------");


            }


        }
    }
}