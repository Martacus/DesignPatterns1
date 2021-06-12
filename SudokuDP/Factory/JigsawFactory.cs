﻿using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Factory
{
    class JigsawFactory : AbstractSudokuFactory
    {

        public JigsawFactory(int columns, string sudokuUnparsed) : base(columns, sudokuUnparsed)
        {
        }

        public override ISudokuBoard GetSudokuBoard()
        {
            var strippedSudoku = this.SudokuUnparsed.Split("SumoCueV1=")[1];
            string[] field = strippedSudoku.Split("=");
            ISudokuBoard board = new SudokuBoard(field.Length, columns);
            Dictionary<int, ICell> cells = new Dictionary<int, ICell>();
            for (int i = 0; i < columns; i++)
            {
                cells.Add(i, new Cluster(columns));
            }

            for (int i = 0; i < field.Length; i++)
            {
                var cellNumber = Int32.Parse(field[i].ToString().Split("J")[0]);
                ICell cell = new Cell(cellNumber, (i / columns) + 1, (i % columns) + 1); ;
                board.Cells[i] = cell;

                var columnNummer = Int32.Parse(field[i].ToString().Split("J")[1]);
                cells[columnNummer].addCell(cell);
            }

            for (int i = 0; i < cells.Count; i++)
            {
                board.Columns[i] = cells[i];
            }

            setRows(board);

            return board;

        }






    }
}
