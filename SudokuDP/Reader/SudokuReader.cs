using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace SudokuDP
{
    class SudokuReader
    {

        public string[] GetSudokuFromFile()
        {

            string executableLocation = Path.GetDirectoryName(
             Assembly.GetExecutingAssembly().Location);
            string sudokuFolder = Path.Combine(executableLocation, "Content\\Sudoku");

            getFiles(sudokuFolder);

            return getSudoku(sudokuFolder);
        }

        private void getFiles(string path)
        {
            Console.WriteLine("Pick a Sudoku type: 4x4, 6x6, 9x9, jigsaw or samurai");

            string[] filePaths = Directory.GetFiles(path);

            foreach (string f in filePaths)
            {
                int pos = f.LastIndexOf("\\");
                string testFile = f.Substring(pos + 1);
                Console.WriteLine(testFile);
            }
        }

        private string[] getSudoku(string path)
        {
            string sudoku = "";
            string fileName = Console.ReadLine();
            string file = Path.Combine(path, fileName);

            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                sudoku = sudoku + line;
            }

            string[] fileInfo = { fileName, sudoku };
            return fileInfo;
        }
    }
}
