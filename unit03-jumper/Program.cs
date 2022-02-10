using System;

namespace unit03_jumper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool guessRight = false;
            Jumper j = new Jumper();
            j.DoUpdate(guessRight);
            j.CutParachuts();
            j.GetDisplayParachuts();
        }
    }
}
