using System;

namespace VensimConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to the Vensim PLE Variable Extractor");
            System.Console.WriteLine("Please enter file name containing vensim variable data");
            var filePath = Console.ReadLine();
            // string filePath ="Vensim-Variables.txt";
            VensimVariableExtractor.Extract(filePath);
        }
    }
}
