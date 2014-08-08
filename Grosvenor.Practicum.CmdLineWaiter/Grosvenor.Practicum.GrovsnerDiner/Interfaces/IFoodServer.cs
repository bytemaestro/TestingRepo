using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
 
    /// <summary>
    /// A Food Server handles, takes orders, and delivers food. Like an actual server or in other words, a waiter or waitress)
    /// </summary>
    public interface IFoodServer
    {
        /// <summary>
        /// TakeOrder takes the order in the form of strings and generates an order object. 
        /// </summary>
        /// <param name="orderTime">string for time when dishes are served. i.e. Morning dishes are (eggs, toast, etc.) 
        /// Night are steak, wine, cake, etc.
        /// </param>
        /// <param name="menuItems">the id (and serving position) of the dish you are ordering. i.e. Night 1,3 means:
        /// Steak(#1), and Wine(#3). Morning 1,3,3,3 means: Eggs(#1), and coffee(#2) x3 cups 
        /// </param>
        /// <returns></returns>
        Order TakeOrder(string orderTime, string[] menuItems);

        /// <summary>
        /// Diner service is the service object that maintains diner related functions.
        /// </summary>
        IDinerService TheDinerService { get; set; }


    }
}
