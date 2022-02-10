using System;

namespace unit03_jumper
{
    class Director
    {
        private Jumper jumper = new Jumper();
        private bool isPlaying = true;
        private Word word = new Word();
        private string userguess;
        private Terminal_services terminalService = new Terminal_services();
        private string displaystring1;
        private string displaystring2;

        public Director()
        {

        }

        /************************************************************************************
        * This game function job is to run the game by calling fuction in classes that run
        * parts of the game. The three class our a Word, Terminal_services, and Jumper class.
        * Each class a a certen job.
        *************************************************************************************/
        public void Game()
        {   
            jumper.CreateParachutes();
            displaystring1 = word.figure_out_word();
            while (isPlaying)
             { 
                 terminalService.get_Terminal_services(displaystring1); 
                 userguess = terminalService.GetGuess();
                 displaystring2 = word.is_there_guess_right(userguess);
                 displaystring1 = displaystring2;
                 // This if else section is to see if the player can keep playing by going to the word class and the jumper class
                 // Could be changed to work with just checking with the Jumper class
                 if(!word.get_can_they_keep_playing() )
                 {
                     isPlaying = false;
                     terminalService.get_Terminal_services(displaystring1);
                 }
                 else
                 {
                     isPlaying = true;
                 } 
             } 
         }


    }

}


