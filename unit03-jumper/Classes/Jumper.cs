using System;
using System.Collections.Generic;

namespace unit03_jumper
{
    class Jumper
    {
        private bool _cutParachute = false;

        private List<string> _parachuteList = new List<string>();

        // add the parts of parachute into the parachute list.
        public void CreateParachutes()
        {
            _parachuteList.Add("  ___");
            _parachuteList.Add(" /___\\");
            _parachuteList.Add(" \\   /");
            _parachuteList.Add("  \\ /");
            _parachuteList.Add("   o");
            _parachuteList.Add("  /|\\");
            _parachuteList.Add("  / \\");
        }
        
        public void DoUpdate(bool guessRight)
        {
            if (guessRight)
            {
                _cutParachute = false;
            }
            else
            {
                _cutParachute = true;
            }
        }

        public void CutParachuts()
        {
            if (_cutParachute)
            {
                _parachuteList.RemoveAt(0);
            }
            
            if (_parachuteList[0] == "o")
            {
                _parachuteList[0] = "x";
            }
        }

        public void GetDisplayParachuts()
        {
            foreach(string part in _parachuteList)
            {
                Console.WriteLine(part);
            }
            Console.WriteLine("");
        }

    }

}
