using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject;
using Grosvenor.Practicum.GrovsnerDiner;

namespace Grosvenor.Practicum.CmdLineWaiter
{
    public static class DisplayServer
    {
        
        public static void DisplayOrder(string servingTime, List<string> inputList)
        {
            //arrange ninject
            var kernel = new StandardKernel(new LibraryBindings()); 
            IFoodServer waiter = kernel.Get<FoodServer>(); 

            Order newOrder; //order to be displayed
            string output = string.Empty; //output that will display
            string errorsOut = string.Empty; //input and order erros that will display

            //call waiter and order
            newOrder = waiter.TakeOrder(servingTime, inputList.ToArray());

            //gather output to display from order's recipet
            foreach (string itemsOut in newOrder.GetReciept().OutputAsList())
            {
                output = output + itemsOut + ",";
            }
            //remove last comma
            output = output.TrimEnd(',');

            //display error collection
            foreach ( string error in newOrder.Errors)
            {
                errorsOut = errorsOut + error + "\r\n";
            }
            
            //Display 
            Console.WriteLine("\r\nOutput: " + output);
            Console.WriteLine("\r\n" + errorsOut + "\r\n");

        }
    }
}
