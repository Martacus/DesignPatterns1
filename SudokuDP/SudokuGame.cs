using SudokuDP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP
{
    class SudokuGame
    {
        public ISudokuBoard board { get; set; }

        public void Start()
        {
            board.Run();
        }

        #region SINGLETON
        private static SudokuGame INSTANCE = null;

        public static SudokuGame GetGame()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SudokuGame();
            }

            return INSTANCE;
        }
        #endregion
    }
}
