using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

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
            var matches = variableRegex.Matches(fileText);
            System.Console.WriteLine($"{matches.Count} variables found");
            List<VensimVariable> variables = new List<VensimVariable>();
            Regex whitespace = new Regex(@"\s{2,}");
            foreach (Match item in matches)
            {
                VensimVariable temp = new VensimVariable
                {
                    Number = int.Parse(item.Groups[1].Value),
                    Name = item.Groups[2].Value.Replace("\r\n", "").Trim(),
                    Value = whitespace.Replace(item.Groups[3].Value,""),
                    Unit = item.Groups[4].Value.Replace("\r\n", "").Trim()
                };
                variables.Add(temp);
            }
            File.WriteAllText("Variables.json",JsonConvert.SerializeObject(variables));
        }
    }
}