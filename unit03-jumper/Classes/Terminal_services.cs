using System;
using System.Collections.Generic;
namespace unit03_jumper
{
    class Terminal_services
    {
        private string userguess = " ";
        public void _Terminal_services(string displaystring1 )
        {
           Console.WriteLine(displaystring1); 
        }
        public void do_they_keep_playing(string displaystring1, string displaystring2)
        {
            if(displaystring1 == displaystring2)
            {
                
            }
            else
            {

            }
        }
        public string GetGuess()
        {
            Console.Write("Guess a letter [a-z]: ");
            userguess = Console.ReadLine();
            return userguess;
        }

        
        
    }

}
