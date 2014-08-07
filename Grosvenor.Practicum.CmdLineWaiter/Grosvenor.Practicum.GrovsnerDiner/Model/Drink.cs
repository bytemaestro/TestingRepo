using System;
using System.Collections.Generic;
using System.Linq;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    /// <summary>
    /// Drink dish type.
    /// </summary>
    public class Drink : Dish
    {
        public Drink()
            : base()
        {

        }
        public override string DishType
        {
            get
            {
                return this.GetType().ToString();
            }
        }

        /// <summary>
        /// Dish has a default position to serve, if diner/repository doesnt assign one.
        /// </summary>
        public override ServingPosition DefaultPositionToServe
        {
            get
            {
                //set up default serving position
                return ServingPosition.Third;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
