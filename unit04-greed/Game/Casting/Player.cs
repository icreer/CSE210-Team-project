using System;
using Unit04.Game.Services;

namespace Unit04.Game.Casting
{
    public class Player: Actor
    {   
        private string _message = "#";

        public Player(int fontSize, Color white)
        {
            // create the player
            Cast cast = new Cast();
            SetText(_message);
            SetFontSize(fontSize);
            SetColor(white);
            SetPosition(new Point(450, 575));
        }
    }
}