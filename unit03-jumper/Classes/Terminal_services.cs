using System;
using System.Collections.Generic;
namespace unit03_jumper.Classes
{
    class Terminal_services
    {
        private string userguess = " ";
        public Terminal_services()
        {
            
        }
        public string GetGuess()
        {
            Console.Write("Guess a letter [a-z]: ");
            userguess = Console.ReadLine();
            return userguess;
        }

        
        
    }

}
