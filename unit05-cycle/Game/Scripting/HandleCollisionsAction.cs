using System;
using System.Collections.Generic;
using System.Data;
using unit05_cycle.Casting;
using unit05_cycle.Services;


namespace unit05_cycle.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        public bool isGameOver = false;

        private Point head1Position;

        private Point head2Position;

        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Sets the game over flag if the snake collides with one of its segments.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {

            Actor message = new Actor();

            int x = Constants.MAX_X / 2;
            int y = Constants.MAX_Y / 2;
            Point position = new Point(x, y);

            Actor actor1 = cast.GetFirstActor("cycle");
            Cycle snake1 = (Cycle)actor1;
            Actor head1 = snake1.GetHead();
            List<Actor> body1 = snake1.GetBody();

            Actor actor2 = cast.GetFirstActor("cycle2");
            Cycle snake2 = (Cycle)actor2;
            Actor head2 = snake2.GetHead();
            List<Actor> body2 = snake2.GetBody();
            head1Position = head1.GetPosition();
            head2Position = head2.GetPosition();

            foreach (Actor segment in body1)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    actor1.SetColor(Constants.WHITE);
                    actor2.SetColor(Constants.WHITE);
                    message.SetText("Player Two Wins!!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                }
                else if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    actor1.SetColor(Constants.WHITE);
                    actor2.SetColor(Constants.WHITE);
                    message.SetText("Player One Wins!!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                }
            }

            foreach (Actor segment in body2)
            {
                if (segment.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    actor1.SetColor(Constants.WHITE);
                    actor2.SetColor(Constants.WHITE);
                    message.SetText("Player Two Wins!!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                }
                else if (segment.GetPosition().Equals(head2.GetPosition()))
                {
                    isGameOver = true;
                    actor1.SetColor(Constants.WHITE);
                    actor2.SetColor(Constants.WHITE);
                    message.SetText("Player One Wins!!");
                    message.SetPosition(position);
                    cast.AddActor("messages", message);
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                List<Actor> actors = cast.GetActors("cycle");
                foreach (Actor actor in actors)
                {
                    Cycle snake = (Cycle)actor;
                    List<Actor> segments = snake.GetSegments();
                    // Food food = (Food)cast.GetFirstActor("food");


                    // make everything white
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                    // food.SetColor(Constants.WHITE);
                }
                List<Actor> actors1 = cast.GetActors("cycle2");
                foreach (Actor actor in actors1)
                {
                    Cycle snake = (Cycle)actor;
                    List<Actor> segments = snake.GetSegments();
                    // Food food = (Food)cast.GetFirstActor("food");

                   

                    // make everything white
                    foreach (Actor segment in segments)
                    {
                        segment.SetColor(Constants.WHITE);
                    }
                    // food.SetColor(Constants.WHITE);
                }
            }
        }

        // private bool PlayerHitThemselves(Cast cast)
        // {
        //     Actor actor1 = cast.GetFirstActor("cycle");
        //     Cycle snake1 = (Cycle)actor1;
        //     Actor head1 = snake1.GetHead();
        //     List<Actor> body1 = snake1.GetBody();

        //     Actor actor2 = cast.GetFirstActor("cycle2");
        //     Cycle snake2 = (Cycle)actor1;
        //     Actor head2 = snake2.GetHead();
        //     List<Actor> body2 = snake2.GetBody();

        //     foreach (Actor segment in body1)
        //     {
        //         if (segment.GetPosition().Equals(head1.GetPosition()))
        //         {
        //             return true;
        //         }
        //     }

        //     foreach (Actor segment in body2)
        //     {
        //         if (segment.GetPosition().Equals(head2.GetPosition()))
        //         {
        //             return true;
        //         }
        //     }

        //     return false;
        // }

        // private bool PlayerHitAnotherPlayer(Cast cast)
        // {
        //     Actor actor1 = cast.GetFirstActor("cycle");
        //     Cycle snake1 = (Cycle)actor1;
        //     Actor head1 = snake1.GetHead();
        //     List<Actor> body1 = snake1.GetBody();

        //     Actor actor2 = cast.GetFirstActor("cycle2");
        //     Cycle snake2 = (Cycle)actor1;
        //     Actor head2 = snake2.GetHead();
        //     List<Actor> body2 = snake2.GetBody();

        //     foreach (Actor segment in body1)
        //     {
        //         if (segment.GetPosition().Equals(head2.GetPosition()))
        //         {
        //             return true;
        //         }
        //     }

        //     foreach (Actor segment in body2)
        //     {
        //         if (segment.GetPosition().Equals(head1.GetPosition()))
        //         {
        //             return true;
        //         }
        //     }

        //     return false;
        // }
    }
}