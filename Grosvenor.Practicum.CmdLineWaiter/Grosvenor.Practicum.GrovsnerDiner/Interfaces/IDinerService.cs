using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public interface IDinerService
    {
        /// <summary>
        /// The DinerService's Dish Repository object that maintains dish data
        /// </summary>
        IRepository<Dish> DishRepository { get; set; }

        /// <summary>
        /// Returns the instance to the Diner object.
        /// </summary>
        Diner GetDiner();

        /// <summary>
        /// Gets All Dishes for a given ServingTime. (i.e. GetDishesByServingTime(ServingTime.Morning)
        /// </summary>
        /// <param name="servingTime">ServingTime is the given time of day certain dishes can be ordered at.</param>
        /// <returns>List of Dishes servered at the given servingTime ></returns>
        IList<Dish> GetDishesByServingTime(ServingTime servingTime);

        /// <summary>
        /// GetMenu returns a list of dishes that are available for order today.
        /// </summary>
        /// <returns>IList of Dishes</returns>
        IList<Dish> GetAllDishes();

        /// <summary>
        /// Get Break Fast Menu returns a list of dishes that are available to order in the Morning.
        /// </summary>
        /// <returns>IList of Dishes</returns>
        IList<Dish> GetBreakfastMenu();

        /// <summary>
        /// Get Dinner Menu returns a list of dishes that are available to order in the evening.
        /// </summary>
        /// <returns>List of Dishes</returns>
        IList<Dish> GetDinnerMenu();

        /// <summary>
        /// Gets a single dish instance from given parameters (ServingTime and ServingPosition)... thats the Unique-Key
        /// </summary>
        /// <param name="servingTime">TimeofDay the order is placed, and the dishes are served at</param>
        /// <param name="servingPosition">Position the dish will be served</param>
        /// <returns>Dish</returns>
        Dish GetDishByServingTimeAndPosition(ServingTime servingTime, ServingPosition servingPosition);

    };
}
