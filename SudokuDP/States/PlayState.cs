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

            if (key == ConsoleKey.Spacebar)
            {
                Context.SetState(new HelpState(Context));
            }
        }
    }
}
