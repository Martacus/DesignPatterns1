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
            
            ISudokuBoard board = new SudokuBoard(chars.Length);
            for (int i = 0; i < ints.Length; i++)
            {
                var cellNumber = Int32.Parse(chars[i].ToString());
                //board.Cells[i] = new ;
            }

            int rows = this.SudokuUnparsed.Length / this.columns;



            throw new NotImplementedException();
        }
    }
}
