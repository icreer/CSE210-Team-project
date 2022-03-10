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

            foreach (Actor actor in actors)
            {
                Cycle snake = (Cycle)actor;
                List<Actor> segments = snake.GetSegments();
                Actor score = cast.GetFirstActor("score");
                // Actor food = cast.GetFirstActor("food");
                List<Actor> messages = cast.GetActors("messages");

            
            
                videoService.ClearBuffer();
                videoService.DrawActors(segments);
                videoService.DrawActor(score);
                // videoService.DrawActor(food);
                videoService.DrawActors(messages);
                videoService.FlushBuffer();
            }
        }
    }
}