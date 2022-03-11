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
            // // left
            // if (keyboardService.IsKeyDown("a"))
            // {
            //     direction = new Point(-Constants.CELL_SIZE, 0);
            // }
            // if (keyboardService.IsKeyDown("j"))
            // {
            //     direction = new Point(-Constants.CELL_SIZE, 0);
            // }

            // // right
            // if (keyboardService.IsKeyDown("d"))
            // {
            //     direction = new Point(Constants.CELL_SIZE, 0);
            // }
            // if (keyboardService.IsKeyDown("l"))
            // {
            //     direction = new Point(Constants.CELL_SIZE, 0);
            
            // }
            // // up
            // if (keyboardService.IsKeyDown("w"))
            // {
            //     direction = new Point(0, -Constants.CELL_SIZE);
            // }
            // if (keyboardService.IsKeyDown("i"))
            // {
            //     direction = new Point(0, -Constants.CELL_SIZE);
            // }

            // // down
            // if (keyboardService.IsKeyDown("s"))
            // {
            //     direction = new Point(0, Constants.CELL_SIZE);
            // }
            // if (keyboardService.IsKeyDown("k"))
            // {
            //     direction = new Point(0, Constants.CELL_SIZE);
            // }
            
            int i = 1;

            List<Actor> actors = cast.GetActors("cycle");

            foreach (Actor actor in actors)
            {
                if (i == 1)
                {
                    //LeftPlayerControl();
                    if (keyboardService.IsKeyDown("a"))
                    {
                     direction = new Point(-Constants.CELL_SIZE, 0);
                     keyPress = true;
                    }
                     else if (keyboardService.IsKeyDown("d"))
                    {
                     direction = new Point(Constants.CELL_SIZE, 0);
                     keyPress = true;
                    }
                     else if (keyboardService.IsKeyDown("w"))
                    {
                     direction = new Point(0, -Constants.CELL_SIZE);
                     keyPress = true;
                     }
                     else if (keyboardService.IsKeyDown("s"))
                     {
                     direction = new Point(0, Constants.CELL_SIZE);
                     keyPress = true;
                     }
                   

                }
                else if (i == 2 )
                {
                    //RightPlayerControl();
                     if (keyboardService.IsKeyDown("j"))
                     {
                     direction = new Point(-Constants.CELL_SIZE, 0);
                     keyPress = true;
                     }
                    else if (keyboardService.IsKeyDown("l"))
                     {
                     direction = new Point(Constants.CELL_SIZE, 0);
                     keyPress = true;
                     }
                    else if (keyboardService.IsKeyDown("i"))
                    {
                     direction = new Point(0, -Constants.CELL_SIZE);
                    keyPress = true;
                    }
                    else if (keyboardService.IsKeyDown("k"))
                    {
                    direction = new Point(0, Constants.CELL_SIZE);
                    keyPress = true;
                    }
                  

                }

                if (keyPress)
                {
                    Cycle snake = (Cycle)actor;

                    snake.TurnHead(direction);
                }

                i++;
            }
        }

        private void LeftPlayerControl()
        {
            if (keyboardService.IsKeyDown("a"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("d"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("w"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("s"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
                keyPress = true;
            }
            keyPress = false;
           // return direction;
        }

        private void RightPlayerControl()
        {
            if (keyboardService.IsKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
                keyPress = true;
            }
            else if (keyboardService.IsKeyDown("k"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
                keyPress = true;
            }
            keyPress = false;
        }
    }
}