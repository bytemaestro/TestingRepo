using System;
using System.Collections;
using System.Collections.Generic;
using Ninject;
using Ninject.MockingKernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grosvenor.Practicum.GrovsnerDiner;

namespace CmdLineWaiterTests
{
    /// <summary>
    /// DinerServiceTester is unit test coverage for the Grosvenor.Practicum.GrovsnerDiner.DinerService class
    /// Note: I am using a Mocking Kernal, really is overkill, but just using it for example purposes.
    /// </summary>
    [TestClass]
    public class DinerServiceTester
    {
        const string DINER_NAME = "THE GROVSNER DINER";

        /// <summary>
        /// Test Diner Service basic setup is correct. One diner should be instanced, with 7 dishes on the menu
        /// </summary>
        [TestMethod]
        public void TestDinerServiceSetup()
        {
            var kernel = new Ninject.MockingKernel.Moq.MoqMockingKernel();
            kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Bind<DinerService>().ToMock();
            var mock = kernel.GetMock<DinerService>();
          
            //check for Diner instance is "The Grovsner Diner"
            Assert.IsTrue(mock.Object.GetDiner().Name.ToUpper() == DINER_NAME);

            //check all 7 dishes had been added
            Assert.IsTrue(mock.Object.GetCompleteMenu().Count == 7);

        }

        /// <summary>
        /// Test Getting MORNING Dishes test getting the only known possible MORNING dishes
        /// </summary>
        [TestMethod]
        public void TestGettingBreakfastDishes()
        {
            var kernel = new Ninject.MockingKernel.Moq.MoqMockingKernel();
            kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Bind<DinerService>().ToMock();
            var mock = kernel.GetMock<DinerService>();

            Assert.IsTrue(mock.Object.GetBreakfastMenu().Count == 3);

        }

        /// <summary>
        /// Test Getting D Dishes test getting the only known possible MORNING dishes
        /// </summary>
        [TestMethod]
        public void TestGettingDinnerDishes()
        {
            var kernel = new Ninject.MockingKernel.Moq.MoqMockingKernel();
            kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Bind<DinerService>().ToMock();
            var mock = kernel.GetMock<DinerService>();

            Assert.IsTrue(mock.Object.GetDinnerMenu().Count == 4);

        }

        /// <summary>
        /// Test that for each Serving Time (MORNING, NIGHT). There is only one dish in the collection
        /// that is unique in Serving Time and Position
        /// </summary>
        [TestMethod]
        public void TestDishesServingTimeAndPositionAreUnique()
        {
            var kernel = new Ninject.MockingKernel.Moq.MoqMockingKernel();
            //kernel.Bind<IRepository<Dish>>().To<Repository<Dish>>();
            kernel.Bind<DinerService>().ToMock();
            var mock = kernel.GetMock<DinerService>();

            bool IsDupeError = false; // No Duplicate Key Error
            Dictionary<ServingPosition, Dish> MORNINGDict = new Dictionary<ServingPosition, Dish>();
            Dictionary<ServingPosition, Dish> nightDict = new Dictionary<ServingPosition, Dish>(); 

            try
            {
                //try MORNING dishes 
                foreach (Dish dish in mock.Object.GetBreakfastMenu())
                {
                    //add to dictionary, if key violat
                    MORNINGDict.Add(dish.DefaultPositionToServe, dish);
                }

                //try NIGHT dishes
                foreach (Dish dish in mock.Object.GetDinnerMenu())
                {
                    //add to dictionary, if key violat
                    nightDict.Add(dish.DefaultPositionToServe, dish);
                }
            }
            catch (ArgumentException)
            {
                IsDupeError = true;
            }

            Assert.IsFalse(IsDupeError);
                      
        }
   }
}
