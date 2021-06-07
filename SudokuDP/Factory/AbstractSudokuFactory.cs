using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Factory
{
    abstract class AbstractSudokuFactory
    {
        protected string SudokuUnparsed { get; }

        public AbstractSudokuFactory(string sudoku)
        {
            SudokuUnparsed = sudoku;
        }

        public abstract ISudokuBoard GetSudokuBoard();

        
    }
}
