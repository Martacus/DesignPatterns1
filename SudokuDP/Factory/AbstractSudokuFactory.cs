using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Factory
{
    abstract class AbstractSudokuFactory
    {
        protected string SudokuUnparsed { get; }
        protected int columns { get; set; }

        public AbstractSudokuFactory(int columns, string sudoku)
        {
            SudokuUnparsed = sudoku;
            this.columns = columns;
        }

        public abstract ISudokuBoard GetSudokuBoard();

        public void setRows(ISudokuBoard board)
        {
            for (int i = 0; i < columns; i++)
            {
                ICell row = new Row(columns);
                for (int j = 0; j < columns; j++)
                {
                    row.children[j] = board.Cells[(i * columns) + j];
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
        }

        
    }
}
