using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 30;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;

        private static string CAPTION = "Greed";
       
        private static Color WHITE = new Color(255, 255, 255);
        private static int DEFAULT_ARTIFACTS = 40;



        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            Score score = new Score();
            Random random = new Random();
            
            // create the player
            Player player = new Player(FONT_SIZE, WHITE);
            cast.AddActor("player", player);

             // create the banner
            Actor banner = new Actor();
            banner.SetText($"Score: {score.getScore()}");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

            int count = 0;
            Random rand = new Random();
            //while(creat)
            /*
            for(count = 0; count <= 20; count++)
            {
                
                    Actor gem = new Actor();
                    gem.SetText("*");
                    gem.SetFontSize(FONT_SIZE);
                    int r = random.Next(0, 256);
                    int g = random.Next(0, 256);
                    int b = random.Next(0, 256);
                    Color color = new Color(r, g, b);
                    gem.SetColor(color);
                    int x = rand.Next(1, 5);
                    int y = 0;
                    int dx = 0;
                    int dy = rand.Next(1, 5);
                    Point position = new Point(x, y);
                    gem.SetPosition(new Point (random.Next(0,900),MAX_Y));
                    Point velocity = new Point(dx,dy);
                    gem.SetVelocity(velocity);
                    //count++;
                    cast.AddActor("gems", gem);
            }

           */
            int add = 0;
           // Random random = new Random();
              /*  for(add = 0; add <= 50; add++)
                {
                    Actor rock = new Actor();
                    rock.SetText("o");
                    rock.SetFontSize(FONT_SIZE);
                    int rr = random.Next(0, 256);
                    int gr = random.Next(0, 256);
                    int br = random.Next(0, 256);
                    Color color_rock = new Color(rr, gr, br);
                    rock.SetColor(color_rock);
                    int rx = rand.Next(1, 5);
                    int ry = 0;
                    int rdx = 0;
                    int rdy = random.Next(1, 5);
                    Point rposition = new Point(rx, ry);
                    rock.SetPosition(new Point(random.Next(0,900),MAX_Y));
                    Point rvelocity = new Point(rdx,rdy);
                    rock.SetVelocity(rvelocity);
                    cast.AddActor("rocks", rock);
                }
             */       
            // start the game
            KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
            VideoService videoService 
                = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
            Director director = new Director(keyboardService, videoService);
            director.StartGame(cast);

            // test comment
        }
    }
}