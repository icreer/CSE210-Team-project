using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
using System;

namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;
        

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            
            
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                Getgem(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor robot = cast.GetFirstActor("robot");
            Point velocity = keyboardService.GetDirection();
            robot.SetVelocity(velocity);     
        }
         
        private void Getgem(Cast cast)
        {
            Random rand = new Random();
            Actor gems = cast.GetFirstActor("gems");
            int y = rand.Next(1, 13);
            Point velocity = new Point(0,y);
            gems.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            List<Actor> gems = cast.GetActors("gems");
            banner.SetText("");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            for(int x = 0; x < gems.Count; x++)
            {
                gems[x].MoveNext(maxX,maxY);
            }
            
            robot.MoveNext(maxX, maxY);

            // foreach (Actor actor in artifacts)
            // {
            //     if (robot.GetPosition().Equals(actor.GetPosition()))
            //     {
            //         Artifact artifact = (Artifact) actor;
            //         string message = artifact.GetMessage();
            //         banner.SetText(message);
            //     }
            // } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}