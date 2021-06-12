using SudokuDP.States;
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
        public ISudokuBoard solvedBoard { get; set; }

        public SudokuBoard(int cellsAmount, int size)
        {
            this.Cells = new ICell[cellsAmount];
            this.Rows = new ICell[size * 2];
            this.Columns = new ICell[size];
            this.xCoord = 0;
            this.yCoord = 0;
        }

        public void drawBoard(string CurrentState)
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

            WriteLine($"Current state: {CurrentState}");
            WriteLine(wall);

            for (int i = 0; i < Rows.Length/2; ++i)
            {
                for (int j = 0; j < Rows[i].children.Length; ++j)
                {
                    string num = Rows[i].children[j].number == 0 ? " " : Rows[i].children[j].number.ToString();
                    Write("|");
                    if (Rows[i].children[j].isPermanent)
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    if (Rows[i].children[j].IsHelper && !string.IsNullOrWhiteSpace(num))
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.Yellow;
                    }
                    if (Rows[i].children[j].IsValid && !Rows[i].children[j].IsHelper)
                    {
                        BackgroundColor = ConsoleColor.Green;
                    }
                    if (i == xCoord && j == yCoord)
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                    
                    Write(num);
                   
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                }
                    
                WriteLine("|");

                if (i % divider == rest) WriteLine(wall);
            }

            WriteLine("Space        = Change mode;");
            WriteLine("ArrowKeys    = Move;");
            WriteLine("S            = Solve;");
            WriteLine("C            = Check;");
            WriteLine("NumberKeys   = Put in number;");
        }


        public bool solve()
        {
            var cell = firstEmptyCell();
            if (cell != null)
            {
                for (int i = 1; i < 10; i++)
                {
                    if (valid(cell, i))
                    {
                        cell.number = i;
                        cell.isPermanent = true;
                        if (solve())
                        {
                            return true;
                        }
                        cell.number = 0;
                        cell.isPermanent = false;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        public void check()
        {
           
        }

        public bool valid(ICell cell, int number)
        {
            var x = cell.xCoord;
            var y = cell.yCoord;
            List<ICell> cells = new List<ICell>();
            foreach (ICell cellRow in this.Rows)
            {
                if (cellRow.hasCell(x, y))
                {
                    cells.Add(cellRow);
                }
            }

            foreach (ICell cluster in this.Columns)
            {
                if (cluster.hasCell(x, y))
                {
                    cells.Add(cluster);
                }
            }

            foreach (ICell cluster in cells)
            {
                if (!cluster.numberFits(number))
                {
                    return false;
                }
            }

            return true;
        }

        public ICell firstEmptyCell()
        {
            foreach(ICell cell in this.Cells)
            {
                if (!cell.isPermanent || cell.number == 0) {
                    return cell;
                }
            }
            return null;
        }

    }
}
