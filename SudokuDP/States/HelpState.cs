using SudokuDP.Models;
using System;

namespace SudokuDP.States
{
    public class HelpState : BaseGameState
    {

        public HelpState(IGameStateContext context) : base(context)
        {
            Context.SetCurrentState("HelpState");
        }

        public override void RegisterInput(ConsoleKey key)
        {
            Context.SetState(new PlayState(Context));
        }

        public override void CellInput(ICell cell, char key)
        {
            if (cell.number == (int)Char.GetNumericValue(key) && cell.IsHelper)
            {
                cell.number = 0;
            }
            else if (cell.IsHelper || cell.number == 0)
            {
                cell.number = (int)Char.GetNumericValue(key);
                cell.IsHelper = true;
            }
        }
    }
}