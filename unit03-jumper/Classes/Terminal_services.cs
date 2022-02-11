using System;
using System.Collections.Generic;

namespace unit03_jumper
{
    /*************************************************************************************
    * The Terminal services class job is to deal with anything in the terminal. 
    * There is two fuction in the terminal Services class both with there own discription
    * The main develper is Daniel Akalws
    ************************************************************************************/
    class Terminal_services
    {
        private string userguess = " ";
        public void get_Terminal_services(string displaystring1 )
        {
           Console.WriteLine(displaystring1);
           Console.WriteLine(" "); 
        }
       
        public string GetGuess()
        {
            Console.Write("Guess a letter [a-z]: ");
            userguess = Console.ReadLine();
            return userguess;
        }

        
        
    }

}
