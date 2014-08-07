using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
 
    /// <summary>
    /// IFoodServer interface is the abstract FoodServer. (i.e. is a waiter or waitress)
    /// </summary>
    public interface IFoodServer
    {
        /// <summary>
        /// TakeOrder takes the order in the form of strings and generates an order object. 
        /// </summary>
        /// <param name="orderTime"></param>
        /// <param name="menuItems"></param>
        /// <returns></returns>
        Order TakeOrder(string orderTime, string[] menuItems);

        IDinerService TheDinerService { get; set; }


    }
}
