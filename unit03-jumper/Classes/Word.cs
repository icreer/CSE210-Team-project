using System;
using System.Collections.Generic;

namespace unit03_jumper
{
    class Word
    {
        private string word_to_figure_out;
        private int _value;
        private string[] word_list = {"car","pie", "jumper","git","keys","football","game","problem","roma","physics", "mars"};
        private string dashes = "";
        private bool playon;

        private List<String> userguesslist = new List<String>();
        /************************************************************
        * The figure_out_word fuction deals the intro and develoing 
        * The string that the user will see the words with.
        ************************************************************/
        public string figure_out_word()
        {
            word_to_figure_out = word_list[ranmdomwordgenirator()];
            for (int i = 0; i < word_to_figure_out.Length;i++)
            {
                dashes += "_ ";
            }
           return dashes;
        }
        /***********************************************************
        * This function just generates a random number that goes to
        * the word_list of figure out what word the user has to find
        ***********************************************************/
        public int ranmdomwordgenirator()
        {

             Random newnumber = new Random();
             _value = newnumber.Next(0,11);
             return _value;
        }
        
        /***********************************************************
        * This fucntion is an update string to be displayed. 
        ***********************************************************/
        public string is_there_guess_right(string userguess)
        {
            string dashes = "";
            userguesslist.Add(userguess);
            foreach (char letter in word_to_figure_out)
            {
                if( userguesslist.Contains(letter.ToString()) )
                {
                    dashes += letter;
                }
                else 
                {
                    dashes += "_";
                }
                dashes += " ";
            } 
            return dashes;
        }

        /***********************************************************
        * This fuction helps with make sure that the player can keep
        * playing by checking the word_to_figure_out with there
        * guesses.
        ***********************************************************/
            public void GetDisplaydashes()
            {
                Console.Write(this.dashes);
                Console.WriteLine("");
            }
           
    

        public bool can_they_keep_playing()
        {
            string dashes = "";
             foreach (char letter in word_to_figure_out)
            {
                if( userguesslist.Contains(letter.ToString()) )
                {
                    dashes += letter;
                }
                else 
                {
                    dashes += "_";
                }
            }
            if ( dashes == word_to_figure_out)
            {
                playon = false;
            } 
            else
            {
                playon = true;
            }
            return playon;
        }

        
    }

}
