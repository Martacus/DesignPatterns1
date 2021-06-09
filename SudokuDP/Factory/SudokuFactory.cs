using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Factory
{
    class SudokuFactory : AbstractSudokuFactory
    {
        private int columns { get; set; }

        public SudokuFactory(int columns, string sudokuUnparsed) : base(sudokuUnparsed)
        {
            this.columns = columns;
        }

        public override ISudokuBoard GetSudokuBoard()
        {
            char[] chars = this.SudokuUnparsed.ToCharArray();
            int[] ints = new int[chars.Length];

            ISudokuBoard board = new SudokuBoard(chars.Length, columns);
            for (int i = 0; i < ints.Length; i++)
            {
                var cellNumber = Int32.Parse(chars[i].ToString());
                board.Cells[i] = new Cell(cellNumber);
            }

            
            for (int i = 0; i < columns; i++)
            {
                ICell row = new Row(columns);
                for (int j = 0; j < 9; j++)
                {
                    row.children[j] = board.Cells[(i * 9) + j];
                }
                board.Rows[i] = row;
            }

            for (int i = 0; i < columns; i++)
            {
                ICell row = new Row(columns);
                for (int j = 0; j < 9; j++)
                {
                    row.children[j] = board.Cells[(j * 9) + i];
                }
                board.Rows[9 + i] = row;
            }

            int columnOffset = 0;
            for (int i = 0; i < columns; i++)
            {
                ICell column = new Column(columns);
                int next = 0;
                for (int j = 0; j < columns; j++)
                {
                    
                    //column.children[j] = board.Cells[(next * 9) + i];
                    Console.WriteLine((next * 9) + j + columnOffset + (i / 3 * 27));
                    if ((j + 1) % 3 == 0)
                    {
                        next++;
                    }
                }
                board.Columns[i] = column;
                columnOffset += 3;

                if (columnOffset == 9)
                {
                    columnOffset = 0;
                }
            }

            board.Run();

            Console.ReadLine();

            throw new NotImplementedException();
        }
    }
}
