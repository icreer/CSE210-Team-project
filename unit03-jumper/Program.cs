using System;

namespace unit03_jumper
{
    class Program
    {
        static void Main(string[] args)
        {
          /*  bool guessRight = false;
            Jumper j = new Jumper();
            j.CreateParachutes();
            j.DoUpdate(guessRight);
            j.GetDisplayParachuts();
            */
            Director D = new Director();
            D.Game();
            
        }
    }
}
