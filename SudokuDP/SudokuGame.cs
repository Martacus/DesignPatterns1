using SudokuDP.Models;
using SudokuDP.States;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace SudokuDP
{
    class SudokuGame : IGameStateContext
    {

        public ISudokuBoard board { get; set; }
        public string CurrentState { get; set; }
        public IGameState State { get; set; }

        public void Start()
        {
            Run();
        }

        public void Run()
        {

            ConsoleKey keyPressed;

            do
            {
                Clear();
                board.drawBoard(CurrentState);

                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                ICell cell = board.Rows[board.xCoord].children[board.yCoord];

                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        if (board.xCoord != 0) board.xCoord -= 1;
                        break;
                    case ConsoleKey.DownArrow:
                        if (board.xCoord != board.Columns.Length - 1) board.xCoord += 1;
                        break;
                    case ConsoleKey.RightArrow:
                        if (board.yCoord != board.Columns.Length - 1) board.yCoord += 1;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (board.yCoord != 0) board.yCoord -= 1;
                        break;
                    case ConsoleKey.S:
                        board.solve();
                        break;
                    case ConsoleKey.C:
                        board.check();
                        break;
                    case ConsoleKey.Spacebar:
                        this.State.RegisterInput(keyPressed);
                        break;
                    case ConsoleKey.D1:
                    case ConsoleKey.D2:
                    case ConsoleKey.D3:
                    case ConsoleKey.D4:
                    case ConsoleKey.D5:
                    case ConsoleKey.D6:
                    case ConsoleKey.D7:
                    case ConsoleKey.D8:
                    case ConsoleKey.D9:
                        if (cell.isPermanent) break;

                        State.CellInput(cell, keyInfo.KeyChar);
                        break;
                }

            } while (keyPressed != ConsoleKey.Enter);
        }

        #region SINGLETON
        private static SudokuGame INSTANCE = null;

        public SudokuGame()
        {
            this.State = new PlayState(this);
        }

        public static SudokuGame GetGame()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new SudokuGame();
            }

            return INSTANCE;
        }

        public void SetState(IGameState newState)
        {
            this.State = newState;
        }

        public void SetCurrentState(string state)
        {
            this.CurrentState = state;
        }
        #endregion
    }
}
