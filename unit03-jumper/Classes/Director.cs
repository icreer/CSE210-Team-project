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


        public void Game()
    
            word.figure_out_word();
           
            jumper.CreateParachutes();
           
            while (isPlaying)
            {
                 word.GetDisplaydashes();
                 jumper.GetDisplayParachuts();
                 
                 userguess = terminalService.GetGuess();

                 word.is_there_guess_right(userguess);
            }   
            jumper.CreateParachutes();
            displaystring1 = word.figure_out_word();
            while (isPlaying)
             { 
                 terminalService._Terminal_services(displaystring1); 
                 userguess = terminalService.GetGuess();
                 displaystring2 = word.is_there_guess_right(userguess);
                 terminalService.do_they_keep_playing(displaystring1, displaystring2);
                 displaystring1 = displaystring2;
                 isPlaying = word.can_they_keep_playing(); 
             }   

        }


    }

}


