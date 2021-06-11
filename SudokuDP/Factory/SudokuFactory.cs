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

            ISudokuBoard board = new SudokuBoard(chars.Length, columns);
            for (int i = 0; i < chars.Length; i++)
            {
                var cellNumber = Int32.Parse(chars[i].ToString());
                board.Cells[i] = new Cell(cellNumber, (i / columns) + 1, (i % columns) + 1);
                if (board.Cells[i].number > 0) board.Cells[i].isPermanent = true;
            }


            for (int i = 0; i < columns; i++)
            {
                ICell row = new Row(columns);
                for (int j = 0; j < columns; j++)
                {
                    row.children[j] = board.Cells[(i * columns) + j];
                    row.children[j].xCoord = i;
                    row.children[j].yCoord = j;
                }
                board.Rows[i] = row;
            }

            for (int i = 0; i < columns; i++)
            {
                ICell row = new Row(columns);
                for (int j = 0; j < columns; j++)
                {
                    row.children[j] = board.Cells[(j * columns) + i];
                }
                board.Rows[columns + i] = row;
            }

            Dictionary<int, int[]> offsets = new Dictionary<int, int[]>();
            offsets.Add(9, new int[] { 3, 3, 3 });
            offsets.Add(6, new int[] { 3, 2, 3 });
            offsets.Add(4, new int[] { 2, 2, 2 });

            board.Columns = new ICell[columns];
            int filledColumns = 0;
            int columnRowOffset = 0;
            for (int i = 0; i < offsets[columns][0]; i++)
            {
                var offsetOne = offsets[columns][0];
                var offsetTwo = offsets[columns][1];
                var offsetThree = offsets[columns][2];
                int columnOffset = 0;
                for (int j = 0; j < offsetTwo; j++)
                {
                    
                    ICell column = new Column(columns);
                    for (int k = 0; k < offsetThree; k++)
                    {
                        for (int p = 0; p < offsetThree; p++)
                        {
                            column.children[k * offsetThree + p] = board.Cells[p + (k * columns) + columnOffset + columnRowOffset];
                        }
                    }
                    columnOffset = columnOffset + offsetOne;
                    board.Columns[filledColumns] = column;
                    filledColumns++;
                }
                columnRowOffset += board.Cells.Length / offsetOne;
            }

            return board;

        }
    
           


          
        
    }
}
