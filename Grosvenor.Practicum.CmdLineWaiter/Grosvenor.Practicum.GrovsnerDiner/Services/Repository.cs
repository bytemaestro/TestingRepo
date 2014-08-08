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

                //---Morning Dishes---
                //1. entree / eggs
                dish = new Entree() { Name = "Eggs", PositionToServe = ServingPosition.First, MaxPortionsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.Morning);
                dishes.Add(dish);

                //2. side / toast
                dish = new Side() { Name = "Toast", PositionToServe = ServingPosition.Second, MaxPortionsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.Morning);
                dishes.Add(dish);

                //3. drink / coffee
                dish = new Drink() { Name = "Coffee", PositionToServe = ServingPosition.Third, MaxPortionsPerOrder = 0 };
                dish.ServingTimes.Add(ServingTime.Morning);
                dishes.Add(dish);

                //---Night Dishes----
                //1. entree / steak
                dish = new Entree() { Name = "Steak", PositionToServe = ServingPosition.First, MaxPortionsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.Night);
                dishes.Add(dish);

                //2. side / potatos
                dish = new Side() { Name = "Potatos", PositionToServe = ServingPosition.Second, MaxPortionsPerOrder = 0 };
                dish.ServingTimes.Add(ServingTime.Night);
                dishes.Add(dish);

                //3. drink / wine
                dish = new Drink() { Name = "Wine", PositionToServe = ServingPosition.Third, MaxPortionsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.Night);
                dishes.Add(dish);

                //4. desert / cake
                dish = new Desert() { Name = "Cake", PositionToServe = ServingPosition.Fourth, MaxPortionsPerOrder = 1 };
                dish.ServingTimes.Add(ServingTime.Night);
                dishes.Add(dish);

                returnList = (List<T>)dishes.Cast<Dish>().ToList().AsEnumerable();

            }

            return returnList;

        }
    }
}
