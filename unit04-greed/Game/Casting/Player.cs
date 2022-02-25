using System;
using Unit04.Game.Services;

namespace Unit04.Game.Casting
{
    /*************************************************************************************
    * The Player class deals with the player. This class deals 
    * with all things to generating the player "#" moving left and right. 
    * The main develper is Yat Lam.
    ************************************************************************************/
    
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