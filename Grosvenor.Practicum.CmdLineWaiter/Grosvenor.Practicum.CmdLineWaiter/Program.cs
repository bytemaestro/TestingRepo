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
            //input/output vars
            string timeOfDayArg;
            List<string> dishArgs;
            string output = string.Empty;

            //ninject vars
            var kernel = new StandardKernel(new LibraryBindings());
            IFoodServer waiter = kernel.Get<FoodServer>();
            Order inputedOrder; //order to be displayed


            //begin
            Console.WriteLine("Welcome to the CmdLine Waiter!");

            //get args
            if (args.Count() > 0 )
            {
                //inputed from the command line, the first must be the time of day arg "MORNING" or "NIGHT"
                List<string> cmdLineArgs = args.ToList();
                timeOfDayArg = cmdLineArgs[0];
                dishArgs = cmdLineArgs[1].ToString().Split(',').ToList();
               
            }
            else
            {
                //inputed from the console window
                Console.Write("What is your order input:");
                var input = Console.ReadLine().Split(',');

                timeOfDayArg = input[0].ToString();
                dishArgs = input.ToList().GetRange(1,input.Count() -1);
            }

  
            //call waiter and order
            inputedOrder = waiter.TakeOrder(timeOfDayArg, dishArgs.ToArray());


            //gather output from order
            foreach (String itemsOut in inputedOrder.GetReciept().OutputAsList())
            {
                output = output + itemsOut + ",";
            }

            //remove last comma
            output = output.TrimEnd(',');

            Console.WriteLine("Output: " + output);
            
            Console.WriteLine("Press any key to end...");
            Console.ReadKey();
            
        }
       
     
    }
}
