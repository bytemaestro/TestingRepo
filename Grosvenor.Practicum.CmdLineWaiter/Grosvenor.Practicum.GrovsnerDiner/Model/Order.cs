using System;
using System.Collections.Generic;
using System.Linq;


namespace Grosvenor.Practicum.GrovsnerDiner
{
    public class Order
    {
        private IList<Dish> dishes;
        private List<string> orderingErrors;
        private Dictionary<int,string> outputOrderResults; //persists what position has an dish or an error

        public ServingTime TimeOfDay { get; set;} 

        public IList<Dish> Dishes
        {
            get
            {
                return dishes;
            }

            set
            {
                dishes = value;
            }
        }

        public List<string> Errors
        {
            get
            {
                return orderingErrors;
            }

            set
            {
                orderingErrors = value;
            }
        }

        public Dictionary<int, string> OutputOrderResults
        {
            get
            {
                return outputOrderResults;
            }

            set
            {
                outputOrderResults = value;
            }
        }


        /// <summary>
        /// Order Constructor
        /// </summary>

        public Order() 
        {
            dishes = new List<Dish>();
            orderingErrors = new List<string>();
            outputOrderResults = new Dictionary<int, string>(); //persists what position has an dish or an error
        }

        public Reciept GetReciept()
        {
            Reciept reciept = new Reciept(this);
            return reciept;
        }

    }
}
