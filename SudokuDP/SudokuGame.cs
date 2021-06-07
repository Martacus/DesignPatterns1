﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP
{
    class SudokuGame
    {


        public void Start()
        {

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
