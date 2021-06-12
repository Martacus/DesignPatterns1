using SudokuDP.Models;
using System;

namespace SudokuDP.States
{
    public class PlayState : BaseGameState
    {

        public PlayState(IGameStateContext context) : base(context)
        {
            Context.SetCurrentState("PlayState");
        }

        public override void RegisterInput(ConsoleKey key)
        {
            Context.SetState(new HelpState(Context));
        }

        public override void CellInput(ICell cell, char keychar)
        {
            if (cell.number == (int)Char.GetNumericValue(keychar))
            {
                cell.number = 0;
            }
            else
            {
                cell.number = (int)Char.GetNumericValue(keychar);
                cell.IsHelper = false;
            }
        }
    }
}
