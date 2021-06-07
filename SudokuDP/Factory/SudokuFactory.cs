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

        }

        public override ISudokuBoard GetSudokuBoard()
        {
            int rows = this.SudokuUnparsed.Length / this.columns;
            for (int i = 0; i < rows; i++)
            {

            }
            throw new NotImplementedException();
        }
    }
}
