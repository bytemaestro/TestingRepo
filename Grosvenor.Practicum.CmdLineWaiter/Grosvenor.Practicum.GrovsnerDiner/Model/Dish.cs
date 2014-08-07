using System;
using System.Collections.Generic;
using System.Linq;

namespace Grosvenor.Practicum.GrovsnerDiner
{
    #region Public Enums

    /// <summary>
    /// ServingTimes enum are all the possible times a dish can be served.
    /// </summary>
    public enum ServingTime
    {
        MORNING = 1,
        NIGHT = 3
    }

    /// <summary>
    /// What is the order the dish will be served. Even if not ordered so.
    /// </summary>
    public enum ServingPosition
    {
        Unknown = 0,
        First = 1,
        Second =2,
        Third = 3,
        Fourth = 4, 
        Last = 5
    }

    #endregion

     /// <summary>
     /// Base class for all dishes that can be created and served from a diner.
     /// </summary>
    public abstract class Dish
    {

        private IList<ServingTime> servingTimes = null;

        #region Public Properties

        /// <summary>
        /// Diner name for the dish.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// What is the max serverings someone can have per order? 0 = no limit.
        /// </summary>
        public int MaxServingsPerOrder { get; set; }

        /// <summary>
        /// Actual Serving Order the dish will be serverd at.
        /// </summary>
        public ServingPosition PositionToServe { get; set; }

        /// <summary>
        /// Serving times are the times an dish can be served. current requirements only require one serving time per dish
        /// but this is a list incase the head chef wants to add more serving times for a dish (i.e. eggs at NIGHT and the MORNING)
        /// </summary>
        public IList<ServingTime> ServingTimes
        {
            get { return servingTimes; }
            set { servingTimes = value; }

        }

        public override string ToString()
        {
            return DishType + " : " + this.Name;
        }

        #endregion 

        #region Abstract Members

        /// <summary>
        /// DishType returns the type of dish.
        /// </summary>
        public abstract string DishType { get; }

        /// <summary>
        /// Default position to serve the dish.
        /// </summary>
        /// <remarks>
        /// Making this member abstract forces derived classes to use this.
        /// </remarks>
        public abstract ServingPosition DefaultPositionToServe { get; }

        #endregion

        public Dish() 
        {
            servingTimes = new List<ServingTime>();
        }
    }
}
