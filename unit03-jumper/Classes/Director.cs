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

        public Director()
        {

        }


        public void Game()
        {
            word.figure_out_word();
           
            jumper.CreateParachutes();
           
            while (isPlaying)
            {
                 word.GetDisplaydashes();
                 jumper.GetDisplayParachuts();
                 
                 userguess = terminalService.GetGuess();

                 word.is_there_guess_right(userguess);
                 
                 

                 
            }   

        }


    }

}


