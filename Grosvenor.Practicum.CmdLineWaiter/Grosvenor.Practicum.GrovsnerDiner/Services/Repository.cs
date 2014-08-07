using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class Repository<T> : IRepository<T>
    {
        public IList<T> GetAll()
        {
            List<T> returnList = null;

            //for example purposes, this not going to the db, or and ef entity, so just using this for data access abstraction example
            Type repoType = typeof(T);

            if (repoType == typeof(Dish))
            {
                //load the Dishes (from db, or from here for now)
                List<Dish> dishes = new List<Dish>();
                Dish dish;

                //---MORNING Dishes---
                //1. entree / eggs
                dish = new Entree() { Name = "Eggs", PositionToServe = ServingPosition.First, MaxServingsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.MORNING);
                dishes.Add(dish);

                //2. side / toast
                dish = new Side() { Name = "Toast", PositionToServe = ServingPosition.Second, MaxServingsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.MORNING);
                dishes.Add(dish);

                //3. drink / coffee
                dish = new Drink() { Name = "Coffee", PositionToServe = ServingPosition.Third, MaxServingsPerOrder = 0 };
                dish.ServingTimes.Add(ServingTime.MORNING);
                dishes.Add(dish);

                //---NIGHT Dishes----
                //1. entree / steak
                dish = new Entree() { Name = "Steak", PositionToServe = ServingPosition.First, MaxServingsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.NIGHT);
                dishes.Add(dish);

                //2. side / potatos
                dish = new Side() { Name = "Potatos", PositionToServe = ServingPosition.Second, MaxServingsPerOrder = 0 };
                dish.ServingTimes.Add(ServingTime.NIGHT);
                dishes.Add(dish);

                //3. drink / wine
                dish = new Drink() { Name = "Wine", PositionToServe = ServingPosition.Third, MaxServingsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.NIGHT);
                dishes.Add(dish);

                //4. desert / cake
                dish = new Desert() { Name = "Cake", PositionToServe = ServingPosition.Fourth, MaxServingsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.NIGHT);
                dishes.Add(dish);

                returnList = (List<T>)dishes.Cast<Dish>().ToList().AsEnumerable();

            }

            return returnList;

        }
    }
}
