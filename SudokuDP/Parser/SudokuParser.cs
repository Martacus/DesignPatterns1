using SudokuDP.Factory;
using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Parser
{
    class SudokuParser
    {
        public string SUDOKU_NINE = "700509001000000000150070063003904100000050000002106400390040076000000000600201004";
        public string FILE_NAME = "sudoku.9x9";

        public void Start()
        {
            var SudokuReader = new SudokuReader();
            string[] sudoku = SudokuReader.GetSudokuFromFile();
            parseSudoku(sudoku[0], sudoku[1]);
            Console.ReadLine();
        }

        public void parseSudoku(string filename, string sudoku)
        {
            AbstractSudokuFactory factory = getFactory(filename.Split(".")[1], sudoku);
            ISudokuBoard board = factory.GetSudokuBoard();
            SudokuGame.GetGame().board = board;
            SudokuGame.GetGame().Start();
        }

        public AbstractSudokuFactory getFactory(string fileExtension, string sudokuUnparsed)
        {
            fileExtension = fileExtension.Split(".txt")[0];
            switch (fileExtension)
            {
                case "4x4":
                    return new SudokuFactory(4, sudokuUnparsed);
                case "6x6":
                    return new SudokuFactory(6, sudokuUnparsed);
                case "9x9":
                    return new SudokuFactory(9, sudokuUnparsed);
                case "jigsaw":
                    return null;
                case "samurai":
                    return null;
            }
            return null;
        }

        #region SINGLETON
        private static SudokuParser INSTANCE = null;

        public static SudokuParser GetParser()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SudokuParser();
            }

            return INSTANCE;
        }
        #endregion
    }
}
