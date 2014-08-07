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
        public Order TakeOrder (string servingTime, string[] dishes)
        {
            Order order = new Order();

            servingTime = servingTime.ToUpper();
            try
            {
                ServingTime orderTime;

                //convert string input args for an order to instance a new Order
                if (Enum.TryParse<ServingTime>(servingTime, out orderTime))
                {
                    order.TimeOfDay = orderTime;
                    //order.OutputOrderResults.Add(0, order.TimeOfDay.ToString()); //initialize the order results step comparer
                }
                else
                {
                    string orderTimeError = "Error: Ordering Time Invalid! Possible times are: ";
                    foreach (string times in Enum.GetNames(typeof(ServingTime)))
                    {
                        orderTimeError += times + ", ";
                    }
                    //strip last comma
                    orderTimeError.TrimEnd(',');
                    order.Errors.Add(orderTimeError);
                }

                //add dishes to the order and setup position dictionary (order.OutputOrderResults)
                foreach (string posEntry in dishes)
                {
                    ServingPosition servingPos = (ServingPosition)Enum.Parse(typeof(ServingPosition),posEntry);
                    Dish dishToAdd;

                    dishToAdd = this.TheDinerService.GetDishByTimeAndPosition(order.TimeOfDay, servingPos);
                    if (dishToAdd != null)
                    {
                        //check how many times the dish can be ordered, by the MaxOrderProperty
                        var currentDishes = (from x in order.Dishes
                                             where x.ServingTimes.Contains(order.TimeOfDay)
                                                  && x.DefaultPositionToServe == servingPos
                                             
                                             select x).ToList();

                        if (dishToAdd.MaxServingsPerOrder == 0 || currentDishes.Count < dishToAdd.MaxServingsPerOrder)
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
                            if (order.OutputOrderResults.ContainsKey((int)servingPos+1))
                            {
                                order.OutputOrderResults.Remove((int)servingPos);
                            }
                            //this will be used to stop display at display position
                            order.OutputOrderResults.Add((int)servingPos+1, "error"); 
                            break; //stop further processing/ordering if an error occurs
                        }
                    }
                    else
                    {
                        //no dish for the serving time and serving order
                        order.OutputOrderResults.Add((int)servingPos, "error"); //this will be used to stop display
                        break; //stop further processing/ordering if an error occurs
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
