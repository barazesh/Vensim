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
            Regex rg = new Regex(@"\(\d{3}\)");
            var matches = rg.Matches(fileText);
            foreach (var item in matches)
            {
                System.Console.WriteLine(item.ToString());
            }


        }
    }
}