using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    /// <summary>
    /// Reciept is the return output from a FoodServer's (waiter or waitress) TakeOrder method
    /// </summary>
    public class Reciept
    {
        private List<string> outputList;

       /// <summary>
       /// TimeServed - Serving Time the Order was taken.
       /// </summary>
        public ServingTime TimeServed { get; set; }

        public List<string> Output
        {
            get
            {
                return outputList;
            }
            set
            {
                outputList = value;
            }
        }
        public Order TheOrder { get; set;}

        public Reciept(Order order)
        {
            this.TheOrder = order;
            outputList = new List<string>();

        }

        /// <summary>
        /// OutputAsList is returns a list of strings for the output of the order (or the reciept , and what and how it should displayed)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public List<string> OutputAsList()
        {
            List<string> finalList = new List<string>();

            var output = from x in TheOrder.Dishes
                         group x by x.Name into dishGrp
                         let count = dishGrp.Count()
                         select new { Count = count, DishName = dishGrp.Key};

            var finalOutput =  (from y in TheOrder.Dishes 
                              join o in output on y.Name equals o.DishName
                              orderby y.PositionToServe
                              select new {DisplayName = o.Count > 1 ? o.DishName + "(x" + o.Count.ToString() + ")" : o.DishName, Count = o.Count}).Distinct();

            //format like the requirements state OrderTimeOfDay, Dish serving order (i.e. "MORNING","eggs","toast","coffee(3x)")
           // finalList.Add(TheOrder.TimeOfDay.ToString());
            for (int i = 0; i < TheOrder.OutputOrderResults.Count(); i++)
            {
                if (TheOrder.OutputOrderResults[TheOrder.OutputOrderResults.Keys.ToList()[i]].ToString().ToLower() != "error")
                {
                    if (finalOutput.Count() > i) //outputOrderResults may contain an error object, which the final dishes would not
                    {
                        finalList.Add(finalOutput.ToList()[i].DisplayName);
                    }
                }
                else
                {
                    finalList.Add("Error");
                    break;
                }
            }

            this.outputList = finalList;
            return finalList;
        }
    }
}
