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
        public int xCoord { get; set; }
        public int yCoord { get; set; }

        public SudokuBoard(int cellsAmount, int size)
        {
            this.Cells = new ICell[cellsAmount];
            this.Rows = new ICell[size * 2];
            this.Columns = new ICell[size];
            this.xCoord = 0;
            this.yCoord = 0;
        }

        public void drawBoard()
        {
            int divider;
            int rest;
            string wall;

            switch (Columns.Length)
            {
                case 9:
                case 6:
                    divider = 3;
                    rest = 2;
                    wall = "+-----+-----+-----+";
                    break;
                case 4:
                    divider = 2;
                    rest = 1;
                    wall = "+---+---+";
                    break;
                default:
                    divider = 3;
                    rest = 2;
                    wall = "+-----+-----+-----+";
                    break;
            }

            WriteLine(wall);

            for (int i = 0; i < Rows.Length/2; ++i)
            {
                for (int j = 0; j < Rows[i].children.Length; ++j)
                {
                    string num = Rows[i].children[j].number == 0 ? " " : Rows[i].children[j].number.ToString();
                    Write("|");
                    if(i == xCoord && j == yCoord)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                    Write(num);
                    if (i == xCoord && j == yCoord)
                    {
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }

                }
                    
                WriteLine("|");

                if (i % divider == rest) WriteLine(wall);
            }

            WriteLine("Space = Change mode:");
            WriteLine("ArrowKeys = Move;");
            WriteLine("S = Solve;");
            WriteLine("C = Check;");
            WriteLine("NumberKeys = Put in number;");
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

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        if (xCoord != 0) xCoord -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (xCoord != Columns.Length - 1) xCoord += 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (yCoord != Columns.Length-1) yCoord += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (yCoord != 0) yCoord -= 1;
                        break;
                }

            } while (keyPressed != ConsoleKey.Enter);
        }
    }
}
