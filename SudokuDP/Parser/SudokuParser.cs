using System;
using System.Collections.Generic;
using System.Text;

namespace SudokuDP.Parser
{
    class SudokuParser
    {
        public void Start()
        {
            var pressedKey = Console.ReadKey();
            Console.WriteLine(pressedKey);
            Console.ReadLine();
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
