using System;

namespace unit03_jumper
{
    class Word
    {
        private string word_to_figure_out;
        private int _value;
        private string[] word_list = {"car","pie", "jumper","git","keys","football","game","problem","roma"};
        private string dashes = "";
        public void figure_out_word()
        {
            word_to_figure_out = word_list[ranmdomwordgenirator()];
            for (int i = 0; i < word_to_figure_out.Length;i++)
            {
                dashes += "_ ";
            }
            Console.WriteLine(dashes);
            Console.WriteLine(word_to_figure_out);
        }
        public int ranmdomwordgenirator()
        {

             Random newnumber = new Random();
             _value = newnumber.Next(1,10);
             return _value;
        }
        
       /* public void is_there_guess_right()
        {
           for (int i = 0; i < word_to_figure_out.Length;i++)
            {
                if(userguess == word_to_figure_out[i] )
                {
                    dashes[i] = userguess;
                }
            } 
        }
        */
    }

}
