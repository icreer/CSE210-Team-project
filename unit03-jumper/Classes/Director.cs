using System;

namespace unit03_jumper
{
    /*************************************************************************************
    * The Director Class cordinates all information from all other classes. In a sence this
    * class is the mangarer of the game.
    ************************************************************************************/
    class Director
    {
        private Jumper jumper = new Jumper();
        private bool isPlaying = true;
        private bool guessRight;
        private Word word = new Word();
        private string userguess;
        private Terminal_services terminalService = new Terminal_services();
        private string displaystring1;
        private string displaystring2;


        /************************************************************************************
        * This game function job is to run the game by calling fuction in classes that run
        * parts of the game. The three class our a Word, Terminal_services, and Jumper class.
        * Each class a a certen job.
        *************************************************************************************/
        public void Game()
        {   
            // These two statementes our to help with the start of game information
            jumper.CreateParachutes();
            displaystring1 = word.figure_out_word();

            // This while loop is to be able to play the game. 
            // As long as is playing is true then the user can keep playing the game.
            while (isPlaying)
             { 
                 terminalService.get_Terminal_services(displaystring1); 
                 jumper.GetDisplayParachuts();
                 userguess = terminalService.GetGuess();

                 // The display strings our a way to check if the user guessed part of the word to find correctly
                 displaystring2 = word.is_there_guess_right(userguess);
                 if (displaystring1 != displaystring2)
                 {
                     guessRight = true;
                    isPlaying = jumper.DoUpdate(guessRight);
                 }
                 else 
                 {
                     guessRight = false;
                     isPlaying = jumper.DoUpdate(guessRight);
                 }
                 displaystring1 = displaystring2;


                 // This if else section is to see if the player can keep playing by going to the word class and the jumper class
                 // Could be changed to work with just checking with the Jumper class
                 if(!word.get_can_they_keep_playing() || !isPlaying )
                 {
                     isPlaying = false;
                     terminalService.get_Terminal_services(displaystring1);
                     jumper.GetDisplayParachuts();
                 }
                 else
                 {
                     isPlaying = true;
                 } 
             } 
         }
    }
}


