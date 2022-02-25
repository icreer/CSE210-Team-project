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
        Score score = new Score();
         Cast cast = new Cast();
         Random random = new Random();
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int FONT_SIZE = 15;

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
                if (random.Next(1,3) == 1 )
                {
                    set_create_gems();
                }
                else
                {
                    set_create_rocks();
                }
                GetInputs(cast);
                Getgem(cast);
                Getrocks(cast);
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
            Actor player = cast.GetFirstActor("player");
            Point velocity = keyboardService.GetDirection();
            player.SetVelocity(velocity);     
        }
         
        private void Getgem(Cast cast)
        {
            Random rand = new Random();
            Actor gems = cast.GetFirstActor("gems");
            int y = rand.Next(1, 5);
            Point velocity = new Point(0,y);
            gems.SetVelocity(velocity);
        }
        private void Getrocks(Cast cast)
        {
            Random rand = new Random();
            Actor rocks = cast.GetFirstActor("rocks");
            int y = rand.Next(1, 13);
            Point velocity = new Point(0,y);
            rocks.SetVelocity(velocity);
        }
        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            
            Actor banner = cast.GetFirstActor("banner");
            Actor robot = cast.GetFirstActor("robot");
            Actor player = cast.GetFirstActor("player");
            List<Actor> gems = cast.GetActors("gems");
            List<Actor> rocks = cast.GetActors("rocks");
            banner.SetText($"Score: {score.getScore()}");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
           
            for(int x = 0; x < gems.Count; x++)
            {

            if (player.GetPosition().Equals(gems[x].GetPosition()))
            {

                for(int r = 0; r < rocks.Count; r++)
                {
                 if(gems[x].GetPosition().GetY() == maxY)
                 {
                       cast.RemoveActor("gems",  gems[x]);
                 }
                 gems[x].MoveNext(maxX,maxY);
                }
            }   
            //    
            // }
            
            // robot.MoveNext(maxX, maxY);

                if (player.GetPosition().Equals(gems[x].GetPosition()))

                {
                    score.setscore(true);
                    break;
                }
                if ( maxY == 0)
                {
                    x = gems.Count;
                }
                else
                {
                    gems[x].MoveNext(maxX,maxY);
                }
                
            }
            for(int x = 0; x < rocks.Count; x++)
            {
                if (player.GetPosition().Equals(rocks[x].GetPosition()))
                {
                    score.setscore(false);
                    x = rocks.Count;
                    break;
                }
                if ( maxY == 0)
                {
                    x = rocks.Count;
                }
                else
                {
                    rocks[x].MoveNext(maxX,maxY);
                }
                
            }

            player.MoveNext(maxX, maxY); 

            player.MoveNext(maxX, maxY);


            // foreach (Actor actor in artifacts)
            // {
            //    if (robot.GetPosition().Equals(actor.GetPosition()))
            //     {
            //         Artifact artifact = (Artifact) actor;
            //         string message = artifact.GetMessage();
            //         banner.SetText(message);
            //     }
            // } 


            // Actor banner = cast.GetFirstActor("banner");
             //Actor player = cast.GetFirstActor("player");
             List<Actor> artifacts = cast.GetActors("artifacts");

            // banner.SetText("");
           // int maxX = videoService.GetWidth();
            //int maxY = videoService.GetHeight();
            player.MoveNext(maxX, maxY);
            
            
            foreach (Actor actor in artifacts)
            {
                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                    Artifact artifact = (Artifact) actor;
                    string message = artifact.GetMessage();
                    
                }
            } 

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
        public void set_create_gems()
        {
            Actor gems = new Actor();
            gems.SetText("*");
            gems.SetFontSize(FONT_SIZE);
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            Color color = new Color(r, g, b);
            gems.SetColor(color);
            gems.SetPosition(new Point(MAX_X/2 , MAX_Y ));
            cast.AddActor("gems", gems);
        }

        public void set_create_rocks()
        {
            Actor rocks = new Actor();
            rocks.SetText("[]");
            rocks.SetFontSize(FONT_SIZE);
            int rr = random.Next(0, 256);
            int gr = random.Next(0, 256);
            int br = random.Next(0, 256);
            Color color_rock = new Color(rr, gr, br);
            rocks.SetColor(color_rock);
            rocks.SetPosition(new Point(MAX_X/3,MAX_Y ));
            cast.AddActor("rocks", rocks);
        }

    }
}