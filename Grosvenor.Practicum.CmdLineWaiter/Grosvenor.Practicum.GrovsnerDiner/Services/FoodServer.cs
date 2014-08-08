using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;


namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class FoodServer : IFoodServer
    {
        [Inject]
        public IDinerService TheDinerService { get; set; }

        public FoodServer()
        {
          
        }
        /// <summary>
        /// TakeOrder is the main method that inputs the string Food order, and instances a new Order object
        /// </summary>
        /// <param name="servingTime">
        /// Time of day that certain dishes are categorized by. (Morning (Breakfast), Night (Dinner), etc.
        /// </param>
        /// <param name="dishes">
        /// A comma delimited string of numbers, that uniquely represent a dish. (i.e.Night,1,2,2,4 represents 1=Steak, 2=Potatos(x2 portions)(#2), 4=Cake)
        /// </param>
        /// <returns>Order</returns>
        public Order TakeOrder (string servingTime, string[] dishes)
        {
            Order order = new Order();

            try
            {
                ServingTime orderTime;

                //convert string input args for an order to instance a new Order
                if (Enum.TryParse<ServingTime>(servingTime, true, out  orderTime))
                {
                    order.TimeOfDay = orderTime;
                    /* Uncomment following line, to add the Serving Time to the output 
                       (i.e. Morning, Eggs, Toast. Currently just outputing Eggs, Toast ...etc...)
                    //order.OutputOrderResults.Add(0, order.TimeOfDay.ToString());
                    */
                }
                else
                {
                    string orderTimeError = "Error: Ordering Time Invalid! Possible times are: ";
                    foreach (string times in Enum.GetNames(typeof(ServingTime)))
                    {
                        orderTimeError += times + ", ";
                    }
                    //strip last comma
                    orderTimeError = orderTimeError.TrimEnd(',',' ');
                    order.Errors.Add(orderTimeError);
                }

                //add dishes to the order and setup position dictionary (order.OutputOrderResults)
                foreach (string posEntry in dishes)
                {
                    ServingPosition servingPos = (ServingPosition)Enum.Parse(typeof(ServingPosition),posEntry);
                    Dish dishToAdd;

                    dishToAdd = this.TheDinerService.GetDishByServingTimeAndPosition(order.TimeOfDay, servingPos);
                    if (dishToAdd != null)
                    {
                        //check how many times the dish can be ordered, by the MaxOrderProperty
                        var currentDishes = (from x in order.Dishes
                                             where x.ServingTimes.Contains(order.TimeOfDay)
                                                  && x.DefaultPositionToServe == servingPos
                                             
                                             select x).ToList();

                        if ( dishToAdd.MaxPortionsPerOrder == 0 || currentDishes.Count < dishToAdd.MaxPortionsPerOrder)
                        {
                            //unlimted so just add the dish to the order
                            order.Dishes.Add(dishToAdd);
                            if (!order.OutputOrderResults.ContainsKey((int)servingPos))
                            {
                                order.OutputOrderResults.Add((int)servingPos, "ok");
                            }                          
                        }
                        else
                        {
                            if (order.OutputOrderResults.ContainsKey((int)servingPos + 1))
                            {
                                order.OutputOrderResults.Remove((int)servingPos);
                            }
                            //this will be used to stop display at display position 
                            order.OutputOrderResults.Add((int)servingPos + 1, "error");
                            order.Errors.Add("Error: Dish '" + dishToAdd.Name
                                                + "' has reached its max order portion amount of '"
                                                + dishToAdd.MaxPortionsPerOrder + "'.");
                            break; //stop further processing/ordering 
                        }
                    }
                    else
                    {
                        //ordering error, no dish for the serving time and serving position
                        order.OutputOrderResults.Add((int)servingPos, "error"); //this will be used to stop display and processing
                        order.Errors.Add("Error: 'Dish Not Found' For given order parameters: " 
                                                + orderTime.ToString() 
                                                + " and dish#" + ((int)servingPos).ToString());
                        break; //stop further processing/ordering 
                    }

                    dishToAdd = null;
                }
            }
            catch (Exception ex)
            {
                order.Errors.Add("Error: " + ex.Message);
            }

            return order;
        }

       
    }
}
