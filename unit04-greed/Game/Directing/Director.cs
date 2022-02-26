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
        private static int FONT_SIZE = 30;
        private static int CELL_SIZE = 30;  

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
         
        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void DoUpdates(Cast cast)
        {
            
            if(random.Next(1,10) == 4) 
            {  
                Actor gem = new Actor();
                gem.SetText("*");
                gem.SetFontSize(FONT_SIZE);
                int rg = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(rg, g, b);
                gem.SetColor(color);
                int xg = random.Next(1, 5);
                int y = 0;
                int dx = 0;
                int dy = random.Next(1, 5);
                Point position = new Point(xg, y);
                gem.SetPosition(new Point (random.Next(0,900),MAX_Y));
                Point velocity = new Point(dx,dy);
                gem.SetVelocity(velocity);
                cast.AddActor("gems", gem);
            }
            
            if (random.Next(1,10) == 7)
            {
                Actor rock = new Actor();
                rock.SetText("o");
                rock.SetFontSize(FONT_SIZE);
                int rr = random.Next(0, 256);
                int gr = random.Next(0, 256);
                int br = random.Next(0, 256);
                Color color_rock = new Color(rr, gr, br);
                rock.SetColor(color_rock);
                int rx = random.Next(1, 5);
                int ry = 0;
                int rdx = 0;
                int rdy = random.Next(1, 5);
                Point rposition = new Point(rx, ry);
                rock.SetPosition(new Point(random.Next(0,900),MAX_Y));
                Point rvelocity = new Point(rdx,rdy);
                rock.SetVelocity(rvelocity);
                cast.AddActor("rocks", rock);
            }

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

                if (IsCollionsion(player,gems[x]))
                {
                    score.setscore(true);
                    cast.RemoveActor("gems",  gems[x]);
                    break;
                }
                else if( gems[x].GetPosition().GetY() == 0)
                {
                    cast.RemoveActor("gems", gems[x]);
                }
                else
                {
                    gems[x].MoveNext(maxX,maxY);
                }
                
            }
            
            for(int x = 0; x < rocks.Count; x++)
            {
                if (IsCollionsion(player,rocks[x]))
                {
                    score.setscore(false);
                    cast.RemoveActor("rocks",  rocks[x]);
                    break;
                }
                else if( rocks[x].GetPosition().GetY() == 0)
                {
                    cast.RemoveActor("rocks", rocks[x]);
                }
                else
                {
                    rocks[x].MoveNext(maxX,maxY);
                }
                
            }

            player.MoveNext(maxX, maxY); 

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
       
        public bool IsCollionsion(Actor One,Actor Two)
        {
            int size = CELL_SIZE;
            int x1 = One.GetPosition().GetX();
            int y1 = One.GetPosition().GetY();

            int x2 = Two.GetPosition().GetX();
            int y2 = Two.GetPosition().GetY();

            bool collionsion = false;
            if (Math.Abs(x1-x2) < size && Math.Abs(y1-y2) < size)
            {
                collionsion = true;
            }
            return collionsion;
        }

    }
}