using System;
using System.Collections.Generic;
using System.Linq;

namespace unit03_jumper
{
    class Word
    {
        private string word_to_figure_out;
        private int _value;
        private string[] word_list = {"car","pie", "jumper","git","keys","football","game","problem","roma"};
        private string dashes = "";

        private string userword;
        private bool playon;



        private List<String> userguesslist = new List<String>();

        


        public string figure_out_word()
        {
            word_to_figure_out = word_list[ranmdomwordgenirator()];
            for (int i = 0; i < word_to_figure_out.Length;i++)
            {
                dashes += "_ ";
            }
           return dashes;
        }
        public int ranmdomwordgenirator()
        {

             Random newnumber = new Random();
             _value = newnumber.Next(0,9);
             return _value;
        }
        
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
