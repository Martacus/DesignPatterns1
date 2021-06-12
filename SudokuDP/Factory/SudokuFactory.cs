using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Factory
{
    class SudokuFactory : AbstractSudokuFactory
    {
        Dictionary<int, int[]> offsets = new Dictionary<int, int[]>();

        public SudokuFactory(int columns, string sudokuUnparsed) : base(columns, sudokuUnparsed)
        {
            offsets.Add(9, new int[] { 3, 3, 3 });
            offsets.Add(6, new int[] { 3, 2, 3 });
            offsets.Add(4, new int[] { 2, 2, 2 });
        }

        public override ISudokuBoard GetSudokuBoard()
        {
            char[] chars = this.SudokuUnparsed.ToCharArray();

            ISudokuBoard board = new SudokuBoard(chars.Length, columns);
            ISudokuBoard solvedBoard = new SudokuBoard(chars.Length, columns);

            setCells(chars, board);
            setCells(chars, solvedBoard);

            setRows(board);
            setRows(solvedBoard);

            setColumns(board);
            setColumns(solvedBoard);

            solvedBoard.solve();

            board.solvedBoard = solvedBoard;
            
            return board;

        }

        public void setCells(char[] chars, ISudokuBoard board)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                var cellNumber = Int32.Parse(chars[i].ToString());
                board.Cells[i] = new Cell(cellNumber, (i / columns) + 1, (i % columns) + 1);
                if (board.Cells[i].number > 0) board.Cells[i].isPermanent = true;
            }
        }

        public void setColumns(ISudokuBoard board)
        {
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

                    ICell column = new Cluster(columns);
                    for (int k = 0; k < offsetTwo; k++)
                    {
                        for (int p = 0; p < offsetThree; p++)
                        {
                            Console.WriteLine(k * offsetTwo + p);
                            column.children[k * offsetThree + p] = board.Cells[p + (k * columns) + columnOffset + columnRowOffset];
                        }
                    }
                    columnOffset = columnOffset + offsetOne;
                    board.Columns[filledColumns] = column;
                    filledColumns++;
                }
                columnRowOffset += board.Cells.Length / offsetOne;
            }
        }
    }
}
