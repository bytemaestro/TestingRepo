using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public interface IDinerService
    {
        Diner GetDiner();

        IList<Dish> GetCompleteMenu();

        IList<Dish> GetBreakfastMenu();

        IList<Dish> GetDinnerMenu();

        Dish GetDishByTimeAndPosition(ServingTime servingTime, ServingPosition servingPosition);

    };
}
