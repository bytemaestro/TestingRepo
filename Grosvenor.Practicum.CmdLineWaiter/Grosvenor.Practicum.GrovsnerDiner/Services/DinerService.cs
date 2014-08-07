using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class DinerService : IDinerService
    {
        private List<Dish> dishes;
        private Diner theDiner;

        [Inject]
        public IRepository<Dish> DishRepository { get; set; }

        /// <summary>
        /// Creates a new instance of a DinerService object.
        /// </summary>

        public DinerService()
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Inject(this);
            openDinerForBusiness(); //prepare the diner
        }
        /// <summary>
        /// Returns the instance to the Diner object.
        /// </summary>
        public Diner GetDiner()
        {
            return this.theDiner;
        }

        /// <summary>
        /// GetMenu returns a list of dishes that are available for order today.
        /// </summary>
        /// <returns></returns>
        public IList<Dish> GetCompleteMenu()
        {
            return dishes; 
        }

        /// <summary>
        /// Get Break Fast Menu returns a list of dishes that are available to order in the MORNING.
        /// </summary>
        /// <returns></returns>
        public IList<Dish> GetBreakfastMenu()
        {
            var MORNINGDishes = from x in dishes where x.ServingTimes.Contains(ServingTime.MORNING) select x;
            return MORNINGDishes.ToList<Dish>();
        }

        /// <summary>
        /// Get Dinner Menu returns a list of dishes that are available to order in the evening.
        /// </summary>
        /// <returns></returns>
        public IList<Dish> GetDinnerMenu()
        {
            var MORNINGDishes = from x in dishes where x.ServingTimes.Contains(ServingTime.NIGHT) select x;
            return MORNINGDishes.ToList<Dish>();
        }

        /// <summary>
        /// Gets a single dish instance from given parameters (ServingTime and ServingPosition)... thats the Unique-Key
        /// </summary>
        /// <param name="servingTime">TimeofDay the order is placed, and the dishes are served at</param>
        /// <param name="servingPosition">Position the dish will be served</param>
        /// <returns></returns>
        public Dish GetDishByTimeAndPosition(ServingTime servingTime, ServingPosition servingPosition)
        {
           //dish's unique key should be the ServingTime and ServingPosition, that test needs to always pass
            return  (from x in dishes
                    where x.ServingTimes.Contains(servingTime)
                            && x.DefaultPositionToServe == servingPosition
                    select x).AsEnumerable().FirstOrDefault();

        }


        private void openDinerForBusiness()
        {
            theDiner = new Diner() { Name = "The Grovsner Diner" };

            //eager load all of today's dishes
            dishes = this.DishRepository.GetAll().Cast<Dish>().ToList();

            //Note: can only be one ServingPosition to one ServingTime! 
            //TODO: AddCheck or another Test...
        }



    }
}
