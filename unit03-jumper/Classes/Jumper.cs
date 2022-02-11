using System;
using System.Collections.Generic;

namespace unit03_jumper
{
    /*************************************************************************************
    * The Jumper class deals with the guy and the parachute. This class deals with all things
    * to generating the parachute and the guy. There is four fuction in this program.
    * The main develper is Yat Lam.
    ************************************************************************************/
    class Jumper
    {
        private bool cutParachute = false;
        private bool canplay = true;

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
        
        public bool DoUpdate(bool guessRight)
        { 
             if (guessRight)
            {
                cutParachute = false;
            }
            else
            {
                cutParachute = true;
            }
             canplay= CutParachuts();
             return canplay;
        }

        private bool CutParachuts()
        {
            if(cutParachute)
            {
                parachuteList.RemoveAt(0);
                canplay = true;
            }
            
            if (parachuteList[0] == "   o")
            {
                parachuteList[0] = "   x";
                canplay = false;
            }
            return canplay;
        }

        public void GetDisplayParachuts()
        {
            foreach(string part in parachuteList)
            {
                Console.WriteLine(part);
            }
            Console.WriteLine(" ");
            Console.WriteLine("^^^^^^^^^^^");
        }

    }

}
