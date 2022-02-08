using System;

namespace unit03_jumper
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            // Word word = new Word();
            // word.figure_out_word();
            bool guessRight = false;
            Jumper j = new Jumper();
            j.DoUpdate(guessRight);
            j.CutParachuts();
            j.GetDisplayParachuts();
        }
    }
}
