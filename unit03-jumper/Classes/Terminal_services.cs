using System;
using System.Collections.Generic;
namespace unit03_jumper
{
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
