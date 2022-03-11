using System;
using System.Collections.Generic;
using System.Linq;
using unit05_cycle.Scripting;

namespace unit05_cycle.Casting
{
    /// <summary>
    /// <para>A long limbless reptile.</para>
    /// <para>The responsibility of Snake is to move itself.</para>
    /// </summary>
    public class Cycle : Actor
    {
        private List<Actor> segments = new List<Actor>();
        private Color _color;
        // private string _player;

        /// <summary>
        /// Constructs a new instance of a Snake.
        /// </summary>
        public Cycle(string player, Color colorConstant)
        {
            _color = colorConstant;
            PrepareBody(player);
        }

        /// <summary>
        /// Gets the snake's body segments.
        /// </summary>
        /// <returns>The body segments in a List.</returns>
        public List<Actor> GetBody()
        {
            return new List<Actor>(segments.Skip(1).ToArray());
        }

        /// <summary>
        /// Gets the snake's head segment.
        /// </summary>
        /// <returns>The head segment as an instance of Actor.</returns>
        public Actor GetHead()
        {
            return segments[0];
        }

        /// <summary>
        /// Gets the snake's segments (including the head).
        /// </summary>
        /// <returns>A list of snake segments as instances of Actors.</returns>
        public List<Actor> GetSegments()
        {
            return segments;
        }

        /// <summary>
        /// Grows the snake's tail by the given number of segments.
        /// </summary>
        /// <param name="numberOfSegments">The number of segments to grow.</param>
        public void GrowTail(int numberOfSegments)
        {
            for (int i = 0; i < numberOfSegments; i++)
            {
                Actor tail = segments.Last<Actor>();
                Point velocity = tail.GetVelocity();
                Point offset = velocity.Reverse();
                Point position = tail.GetPosition().Add(offset);

                
                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText("#");
                 HandleCollisionsAction collision = new HandleCollisionsAction();
                 if (collision.isGameOver)
                 {
                     _color = Constants.WHITE;
                 }
                segment.SetColor(_color);
                segments.Add(segment);
            }
        }

        /// <inheritdoc/>
        public override void MoveNext()
        {
            GrowTail(1);

            foreach (Actor segment in segments)
            {
                segment.MoveNext();
            }

            for (int i = segments.Count - 1; i > 0; i--)
            {
                Actor trailing = segments[i];
                Actor previous = segments[i - 1];
                Point velocity = previous.GetVelocity();
                trailing.SetVelocity(velocity);
            }
        }

        /// <summary>
        /// Turns the head of the snake in the given direction.
        /// </summary>
        /// <param name="velocity">The given direction.</param>
        public void TurnHead(Point direction)
        {
            if (direction == null)
            {
                throw new ArgumentException("velocity can't be null");
            }
            segments[0].SetVelocity(direction);
            // Console.WriteLine("Turning Head.");
        }

        /// <summary>
        /// Prepares the snake body for moving.
        /// </summary>
        public void PrepareBody(string player)
        {
            
            int x = Constants.MAX_X / 2;
            int y = 1;
            if (player == "player1")
            {
                y = Constants.MAX_Y / 3;
            }
            else if (player == "player2")
            {
                y = Constants.MAX_Y / 3 * 2;
            }

            for (int i = 0; i < Constants.SNAKE_LENGTH; i++)
            {
                Point position = new Point(x - i * Constants.CELL_SIZE, y);
                Point velocity = new Point(1 * Constants.CELL_SIZE, 0);
                string text = i == 0 ? "@" : "#";
                Color color = i == 0 ? _color : _color;

                Actor segment = new Actor();
                segment.SetPosition(position);
                segment.SetVelocity(velocity);
                segment.SetText(text);
                segment.SetColor(color);
                segments.Add(segment);
            }
        }
    }
}