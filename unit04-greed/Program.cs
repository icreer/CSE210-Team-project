﻿using System;
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
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 25;
        private static int COLS = 60;
        private static int ROWS = 40;

        private static string CAPTION = "Greed";
        private static string DATA_PATH = "messages.txt";
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

        //     // create the robot
        //     Actor robot = new Actor();
        //     robot.SetText("#");
        //     robot.SetFontSize(FONT_SIZE);
        //     robot.SetColor(WHITE);
        //     robot.SetPosition(new Point(MAX_X / 2, MAX_Y / 2));
        //     cast.AddActor("robot", robot);
            //bool creat = true;
            int count = 0;
            Random rand = new Random();
            //while(creat)
            for(count = 0; count <= 20; count++)
            {
                
                //if(count == 100)
               // {
                   // creat = false;
               // }
                    Actor gem = new Actor();
                    gem.SetText("*");
                    gem.SetFontSize(FONT_SIZE);
                    gem.SetColor(WHITE);
                    int x = rand.Next(1, 5);
                    int y = 0;
                    int dx = rand.Next(1, 5);
                    int dy = rand.Next(1, 5);
                    Point position = new Point(x, y);
                    gem.SetPosition(position);
                    Point velocity = new Point(dx,dy);
                    gem.SetVelocity(velocity);
                    //count++;
                    cast.AddActor("gems", gem);
            }

           
            int add = 0;
           // Random random = new Random();
                for(add = 0; add <= 50; add++)
                {
                    Actor rock = new Actor();
                    rock.SetText("o");
                    rock.SetFontSize(FONT_SIZE);
                    rock.SetColor(WHITE);
                    int rx = rand.Next(1, 5);
                    int ry = 0;
                    int rdx = random.Next(1, 5);
                    int rdy = random.Next(1, 5);
                    Point rposition = new Point(rx, ry);
                    rock.SetPosition(new Point(random.Next(0,900),MAX_Y));
                    //Point rvelocity = new Point(rdx,rdy);
                    //rock.SetVelocity(rvelocity);
                   // add++;
                    cast.AddActor("rocks", rock);
                }
                    
            // load the messages
           // List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

        //     // load the messages
        //    List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

            Actor robot = new Actor();
        /*     robot.SetText("#");
             robot.SetFontSize(FONT_SIZE);
             robot.SetColor(WHITE);
             robot.SetPosition(new Point(MAX_X / 2, MAX_Y / 2));
            cast.AddActor("robot", robot);
        */
             int error = 1;

            Actor gems = new Actor();
            gems.SetText("*");
            gems.SetFontSize(FONT_SIZE);
            int r = random.Next(0, 256);
            int g = random.Next(0, 256);
            int b = random.Next(0, 256);
            Color color = new Color(r, g, b);
            int place = MAX_X/random.Next(1,10);
            gems.SetColor(color);
            gems.SetPosition(new Point(place , MAX_Y ));
            cast.AddActor("gems", gems);

            Actor rocks = new Actor();
            rocks.SetText("o");
            rocks.SetFontSize(FONT_SIZE);
            int rr = random.Next(0, 256);
            int gr = random.Next(0, 256);
            int br = random.Next(0, 256);
            Color color_rock = new Color(rr, gr, br);
            rocks.SetColor(color_rock);
            int place_rock = MAX_X/random.Next(1,10);
            rocks.SetPosition(new Point( place_rock,MAX_Y ));
            cast.AddActor("rocks", rocks);


            // load the messages
           // List<string> messages = File.ReadAllLines(DATA_PATH).ToList<string>();

        //     // create the artifacts
            
        //     for (int i = 0; i < DEFAULT_ARTIFACTS; i++)
        //      {
        //          string text = ((char)random.Next(33, 126)).ToString();
        //          string message = messages[i];

        //          int x = random.Next(1, COLS);
        //          int y = random.Next(1, ROWS);
        //          Point position = new Point(x, y);
        //          position = position.Scale(CELL_SIZE);

        //          int r = random.Next(0, 256);
        //          int g = random.Next(0, 256);
        //          int b = random.Next(0, 256);
        //          Color color = new Color(r, g, b);

        //          Artifact artifact = new Artifact();
        //          artifact.SetText(text);
        //          artifact.SetFontSize(FONT_SIZE);
        //          artifact.SetColor(color);
        //          artifact.SetPosition(position);
        //          artifact.SetMessage(message);
        //          cast.AddActor("artifacts", artifact);
        //      }

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