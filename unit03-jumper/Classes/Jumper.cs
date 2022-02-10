using System;
using System.Collections.Generic;

namespace unit03_jumper.Classes
{
    class Jumper
    {
        private bool cutParachute = false;

        private List<string> parachuteList = new List<string>();

        // add the parts of parachute into the parachute list.
        public void CreateParachutes()
        {
            parachuteList.Add("  ___");
            parachuteList.Add(" /___\\");
            parachuteList.Add(" \\   /");
            parachuteList.Add("  \\ /");
            parachuteList.Add("   o");
            parachuteList.Add("  /|\\");
            parachuteList.Add("  / \\");
        }
        
        public void DoUpdate(bool guessRight)
        {
            if (guessRight)
            {
                cutParachute = false;
            }
            else
            {
                cutParachute = true;
            }
        }

        public void CutParachuts()
        {
            if (cutParachute)
            {
                parachuteList.RemoveAt(0);
            }
        }

        public void GetDisplayParachuts()
        {
            foreach(string part in parachuteList)
            {
                Console.WriteLine(part);
            }
            Console.WriteLine("");
        }

    }

}
