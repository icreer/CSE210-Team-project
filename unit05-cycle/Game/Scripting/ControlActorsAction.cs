using System.Collections.Generic;
using unit05_cycle.Casting;
using unit05_cycle.Services;


namespace unit05_cycle.Scripting
{
    /// <summary>
    /// <para>An input action that controls the snake.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move the snake's head.
    /// </para>
    /// </summary>
    public class ControlActorsAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);
        private Point direction2 = new Point(Constants.CELL_SIZE, 0);
        private bool keyPress = false;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlActorsAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public async void Execute(Cast cast, Script script)
        {
            

            List<Actor> actors = cast.GetActors("cycle");

            foreach (Actor actor in actors)
            {
                //Left Player Control Keys
                if (keyboardService.IsKeyDown("a"))
                {
                    direction = new Point(-Constants.CELL_SIZE, 0);                    
                }
                else if (keyboardService.IsKeyDown("d"))
                {
                    direction = new Point(Constants.CELL_SIZE, 0);
                }
                else if (keyboardService.IsKeyDown("w"))
                {
                    direction = new Point(0, -Constants.CELL_SIZE);                     
                }
                else if (keyboardService.IsKeyDown("s"))
                {
                    direction = new Point(0, Constants.CELL_SIZE);                  
                }
                Cycle snake = (Cycle)cast.GetFirstActor("cycle");

                snake.TurnHead(direction);
            }

            List<Actor> actors1 = cast.GetActors("cycle2");
            foreach (Actor actor in actors1)
            {
                // Right Player Control Keys
                if (keyboardService.IsKeyDown("j"))
                {
                    direction2 = new Point(-Constants.CELL_SIZE, 0);                    
                }
                else if (keyboardService.IsKeyDown("l"))
                {
                    direction2 = new Point(Constants.CELL_SIZE, 0);                     
                }
                else if (keyboardService.IsKeyDown("i"))
                {
                    direction2 = new Point(0, -Constants.CELL_SIZE);                   
                }
                else if (keyboardService.IsKeyDown("k"))
                {
                    direction2 = new Point(0, Constants.CELL_SIZE);                 
                }
                Cycle snake2 = (Cycle)cast.GetFirstActor("cycle2");

                snake2.TurnHead(direction2);
            } 
        }
    }
}