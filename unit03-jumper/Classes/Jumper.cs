using System;
using System.Collections.Generic;

namespace unit03_jumper
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

            CutParachuts();

            if (parachuteList[0] == "   o")
            {
                parachuteList[0] = "   x";
            }
        }

        private void CutParachuts()
        {


            //if (cutParachute)


            //for (int i = 0; i < _parachuteList.length; i++)
            //{
            //    
             
            //   _parachuteList.RemoveAt(0);
        
            //    if (_parachuteList[0] == "o")
            //   {
            //    _parachuteList[0] = "x";
            //   }
            //  else
            //  {
            //        cutParachute = false;
            //   }
            //    break;
            //}

           /* if(cutParachute)
           // if (_cutParachute)

            {
                parachuteList.RemoveAt(0);
            }
            
            if (parachuteList[0] == "   o")
            {
                parachuteList[0] = "   x";
            }
            */
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
