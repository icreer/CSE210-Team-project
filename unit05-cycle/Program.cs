using System;
using unit05_cycle.Casting;
using unit05_cycle.Directing;
using unit05_cycle.Scripting;
using unit05_cycle.Services;

namespace unit05_cycle
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the cast
            Cast cast = new Cast();
            cast.AddActor("food", new Food());
            cast.AddActor("cycle", new Cycle());

            Score score = new Score();
            score.SetText($"Player One: 0");
            cast.AddActor("score", score );

            Score score2 = new Score();
            score2.SetPosition(new Point(Constants.MAX_X - 100,0));
            score2.SetText($"Player Two: 0");
            cast.AddActor("score2", score2);

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}
