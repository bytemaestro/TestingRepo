using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    /// <summary>
    /// DinerService used to manage diner related services and attributes.
    /// </summary>
    public class DinerService : IDinerService
    {
        private List<Dish> dishes;
        private Diner theDiner;

        /// <summary>
        /// The DinerService's Dish Repository object that maintains dish data
        /// </summary>
        [Inject]
        public IRepository<Dish> DishRepository { get; set; }

        /// <summary>
        /// Creates a new instance of a DinerService object.
        /// </summary>
        public DinerService()
        {
            //prepare DI kernel
            IKernel kernel = new StandardKernel();
            kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Inject(this);
            //prepare the diner (dinerService)
            openDinerForBusiness();
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
        /// <returns>IList of Dishes</returns>
        public IList<Dish> GetAllDishes()
        {
            return dishes; 
        }

        /// <summary>
        /// Gets All Dishes for a given ServingTime. (i.e. GetDishesByServingTime(ServingTime.Morning)
        /// </summary>
        /// <param name="servingTime">ServingTime is the given time of day certain dishes can be ordered at.</param>
        /// <returns>List of Dishes servered at the given servingTime ></returns>
        public IList<Dish> GetDishesByServingTime(ServingTime servingTime)
        {
            //Get Dishes for given serving time, if ever another serving time were to be added, this method is already
            //ready for it.
            return (from x in dishes
                    where x.ServingTimes.Contains(servingTime)
                    select x).ToList<Dish>();
        }

        /// <summary>
        /// Get Break Fast Menu returns a list of dishes that are available to order in the Morning.
        /// </summary>
        /// <returns>List of Dishes</returns>
        public IList<Dish> GetBreakfastMenu()
        {
            var morningDishes = from x in dishes where x.ServingTimes.Contains(ServingTime.Morning) select x;
            return morningDishes.ToList<Dish>();
        }

        /// <summary>
        /// Get Dinner Menu returns a list of dishes that are available to order in the evening.
        /// </summary>
        /// <returns>List of Dishes</returns>
        public IList<Dish> GetDinnerMenu()
        {
            var dinnerDishes = from x in dishes where x.ServingTimes.Contains(ServingTime.Night) select x;
            return dinnerDishes.ToList<Dish>();
        }

        /// <summary>
        /// Gets a single dish instance from given parameters (ServingTime and ServingPosition)... thats the Unique-Key
        /// </summary>
        /// <param name="servingTime">TimeofDay the order is placed, and the dishes are served at</param>
        /// <param name="servingPosition">Position the dish will be served</param>
        /// <returns>Dish</returns>
        public Dish GetDishByServingTimeAndPosition(ServingTime servingTime, ServingPosition servingPosition)
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
