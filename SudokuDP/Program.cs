using SudokuDP.Parser;
using System;
using System.IO;
using System.Reflection;

namespace SudokuDP
{
    class Program
    {
        static void Main(string[] args)
        {
            string executableLocation = Path.GetDirectoryName(
             Assembly.GetExecutingAssembly().Location);
            string xslLocation = Path.Combine(executableLocation, "Content\\Sudoku");

            //DirectoryInfo uninstalldir = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "Content/Sudoku"));
            //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"");
            //string[] files = File.ReadAllLines(xslLocation);
            SudokuParser.GetParser().Start();
        }
    }
}
