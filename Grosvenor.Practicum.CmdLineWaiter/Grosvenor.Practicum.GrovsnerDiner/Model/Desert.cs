using System;
using System.Collections.Generic;
using System.Linq;

namespace Grosvenor.Practicum.GrovsnerDiner
{

    /// <summary>
    /// Desert dish type.
    /// </summary>
    public class Desert : Dish
    {
        public Desert()
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
                return ServingPosition.Fourth;
            }
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
