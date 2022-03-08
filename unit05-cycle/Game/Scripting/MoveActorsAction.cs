using System.Collections.Generic;
using unit05_cycle.Casting;


namespace unit05_cycle.Scripting
{
    // TODO: Implement the MoveActorsAction class here

    // 1) Add the class declaration. Use the following class comment. Make sure you
    //    inherit from the Action class.
    public class MoveActorsAction : Action
    {

    /// <summary>
    /// <para>An update action that moves all the actors.</para>
    /// <para>
    /// The responsibility of MoveActorsAction is to move all the actors.
    /// </para>
    /// </summary>

    // 2) Create the class constructor. Use the following method comment.

    /// <summary>
    /// Constructs a new instance of MoveActorsAction.
    /// </summary>
        public MoveActorsAction()
        {

        }

    // 3) Override the Execute(Cast cast, Script script) method. Use the following 
    //    method comment. You custom implementation should do the following:
    //    a) get all the actors from the cast
    //    b) loop through all the actors
    //    c) call the MoveNext() method on each actor.
        public void Execute(Cast cast, Script script)
        {
            Cycle snake = (Cycle)cast.GetFirstActor("cycle");
            Food food = (Food)cast.GetFirstActor("food");
            List<Actor> action = cast.GetAllActors();
            foreach(Actor actor in action)
            {
                actor.MoveNext();
                int points = food.GetPoints();
                snake.GrowTail(points);
                snake.GrowTail(points);
            }
        }
    }
}