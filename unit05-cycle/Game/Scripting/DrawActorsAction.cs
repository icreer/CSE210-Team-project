using System.Collections.Generic;
using unit05_cycle.Casting;
using unit05_cycle.Services;


namespace unit05_cycle.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetActors("cycle");
            List<Actor> actor2 = cast.GetActors("cycle2");
            foreach (Actor actor in actors)
            {
                Cycle snake = (Cycle)actor;
                List<Actor> segments = snake.GetSegments();
                Actor score = cast.GetFirstActor("score");
                Actor score2 = cast.GetFirstActor("score2");
                // Actor food = cast.GetFirstActor("food");
                List<Actor> messages = cast.GetActors("messages");

                foreach (Actor actor1 in actor2)
                {
                    Cycle snake2 = (Cycle)actor1;
                    List<Actor> segment2 = snake2.GetSegments();
                    videoService.ClearBuffer();
                    videoService.DrawActors(segment2);
                     videoService.DrawActors(segments);
                
                     videoService.DrawActor(score);
                    videoService.DrawActor(score2);
                    // videoService.DrawActor(food);
                    videoService.DrawActors(messages);
                     videoService.FlushBuffer();
                }
               
                
                
            }
        }
    }
}