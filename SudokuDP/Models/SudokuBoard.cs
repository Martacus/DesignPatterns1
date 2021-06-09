using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace SudokuDP.Models
{
    class SudokuBoard : ISudokuBoard
    {

        public ICell[] Cells { get;  set; }
        public ICell[] Rows { get; set; }
        public ICell[] Columns { get; set; }
        public int selected { get; set; }

        public SudokuBoard(int cellsAmount, int size)
        {
            this.Cells = new ICell[cellsAmount];
            this.Rows = new ICell[size * 2];
            this.Columns = new ICell[size];
            this.selected = 11;
        }

        public void drawBoard()
        {

            for(int i = 0; i<Rows.Length; ++i)
            {
                WriteLine(Rows[i].number);
            }

            WriteLine(Rows);
            WriteLine("+-----+-----+-----+");

            for (int i = 1; i < 10; ++i)
            {
                for (int j = 1; j < 10; ++j)
                {
                    int newNumber = Convert.ToInt32(string.Format("{0}{1}", i, j));
                    Write("|");
                    if(newNumber == selected)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                    Write("0");
                    if (newNumber == selected)
                    {
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }

                }
                    

                WriteLine("|");
                if (i % 3 == 0) WriteLine("+-----+-----+-----+");
            }
        }


        public void Run()
        {

            ConsoleKey keyPressed;

            do
            {
                Clear();
                drawBoard();

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    selected -= 10;
                } else if (keyPressed == ConsoleKey.DownArrow)
                {
                    selected += 10;
                } else if (keyPressed == ConsoleKey.RightArrow)
                {
                    selected += 1;
                } else if (keyPressed == ConsoleKey.LeftArrow)
                {
                    selected -= 1;
                }

            } while (keyPressed != ConsoleKey.Enter);
        }
    }
}
