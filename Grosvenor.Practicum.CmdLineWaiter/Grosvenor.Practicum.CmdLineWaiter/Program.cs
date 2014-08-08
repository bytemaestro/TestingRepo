using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Grosvenor.Practicum.GrovsnerDiner;


namespace Grosvenor.Practicum.CmdLineWaiter
{
    /// <summary>
    /// Takes an Order Time of Day, as well as the number of some dishes, then get served.
    /// CommandlineUsage = CmdLineWaiter.exe morning 1,2,3 or CmdLineWaiter.exe night 1,3,4 (steak, wine, cake)
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            //input vars
            string timeOfDayArg;
            List<string> dishArgs;
            

            //begin
            Console.WriteLine("--------------------------------");
            Console.WriteLine("      The Grovsner Diner ");
            Console.WriteLine("--------------------------------");

            //get order input args
            if (args.Count() > 0 )
            {
                //inputed from the command line, the first must be the time of day arg "Morning" or "Night"
                List<string> cmdLineArgs = args.ToList();
                timeOfDayArg = cmdLineArgs[0];
                dishArgs = cmdLineArgs[1].ToString().Split(',').ToList();             
            }
            else
            {
                
                //inputed from the console window
                do 
                {
                    Console.Write("Please enter your food order input:");
                    var input = Console.ReadLine().Split(',');

                    timeOfDayArg = input[0].ToString();
                    dishArgs = input.ToList().GetRange(1, input.Count() - 1);
                }
                while (String.IsNullOrEmpty(timeOfDayArg) && dishArgs.Count == 0);
               
            }

            //display results of input 
            DisplayServer.DisplayOrder(timeOfDayArg, dishArgs);

            //end app
            Console.WriteLine("\r\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
