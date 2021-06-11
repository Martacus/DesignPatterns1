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
            if (key == ConsoleKey.Spacebar)
            {
                Context.SetState(new PlayState(Context));
            }
        }
    }
}