using System;

namespace unit03_jumper
{
    class Program
    {
        static void Main(string[] args)
        {
            bool guessRight = false;
            Classes.Jumper j = new Classes.Jumper();
            j.CreateParachutes();
            j.DoUpdate(guessRight);
            j.GetDisplayParachuts();
            
        }
    }
}
