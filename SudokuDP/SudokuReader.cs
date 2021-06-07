using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SudokuDP
{
    class SudokuReader
    {

        public SudokuReader()
        {
            GetSudokuFromFile();
        }

        private void GetSudokuFromFile()
        {
            Console.WriteLine("Pick a Sudoku type: 4x4, 6x6, 9x9, jigsaw or samurai");

            // Create a string variable and get user input from the keyboard and store it in the variable
            // string userName = Console.ReadLine();

            int counter = 0;
            string line;

            string fileName = "puzzle.4x4";
            string path = Path.Combine(Environment.CurrentDirectory, @"Content\Sudoku", fileName);

            // Read the file and display it line by line.  
            StreamReader file = new StreamReader(@"C:\Users\Gebruiker\source\repos\DesignPatterns1\SudokuDP\Content\Sudoku\puzzle.4x4");
            while ((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.  
            Console.ReadLine();

            // Print the value of the variable (userName), which will display the input value
            // Console.WriteLine("Username is: " + userName);
        }
    }
}
