using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grosvenor.Practicum.GrovsnerDiner
{

    /// <summary>
    /// Entree dish type.
    /// </summary>
    public class Entree : Dish
    {
        public Entree()
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
                return ServingPosition.First;
            }
        }
        public override string ToString()
        {
            return base.ToString();
        }

    }
}
