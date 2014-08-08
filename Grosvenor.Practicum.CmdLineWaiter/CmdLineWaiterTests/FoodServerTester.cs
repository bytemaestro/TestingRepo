
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Ninject;
using Ninject.MockingKernel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Grosvenor.Practicum.GrovsnerDiner;

namespace CmdLineWaiterTests
{
    [TestClass]
    public class FoodServerTester
    {
        [TestMethod]
        public void TestCreatingAnOrder()
        {
            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();

            Order order = mock.TakeOrder(ServingTime.Morning.ToString(), new string[] { "1", "2", "3" });

            Assert.IsNotNull(order);

        }

        [TestMethod]
        public void TestCreatingFullBreakfastOrder()
        {

            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Morning.ToString(), new string[] { "1", "2", "3" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "eggs");
            Assert.IsTrue(results[1].ToString().ToLower() == "toast");
            Assert.IsTrue(results[2].ToString().ToLower() == "coffee");

        }

        [TestMethod]
        public void TestCreatingDoubleCoffeeOrder()
        {

            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Morning.ToString(), new string[] { "1", "2", "3","3" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "eggs");
            Assert.IsTrue(results[1].ToString().ToLower() == "toast");
            Assert.IsTrue(results[2].ToString().ToLower() == "coffee(x2)");

        }


        [TestMethod]
        public void TestDesertOrderForBreakfast()
        {

            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Morning.ToString(), new string[] { "1", "2", "3", "4" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "eggs");
            Assert.IsTrue(results[1].ToString().ToLower() == "toast");
            Assert.IsTrue(results[2].ToString().ToLower() == "coffee");
            Assert.IsTrue(results[3].ToString().ToLower() == "error");
           
        }

        [TestMethod]
        public void TestOrderServingPositions()
        {

            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Morning.ToString(), new string[] { "3", "3", "3", "1", "2" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "eggs");
            Assert.IsTrue(results[1].ToString().ToLower() == "toast");
            Assert.IsTrue(results[2].ToString().ToLower() == "coffee(x3)");
        }

        [TestMethod]
        public void TestFullDinnerOrder()
        {

            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Night.ToString(), new string[] { "1", "2", "3", "4" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "steak");
            Assert.IsTrue(results[1].ToString().ToLower() == "potatos");
            Assert.IsTrue(results[2].ToString().ToLower() == "wine");
            Assert.IsTrue(results[3].ToString().ToLower() == "cake");
        }

        [TestMethod]
        public void TestMultiPotatoDinnerOrder()
        {
            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Night.ToString(), new string[] { "1", "2", "3", "4","2","2","2","2" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "steak");
            Assert.IsTrue(results[1].ToString().ToLower() == "potatos(x5)");
            Assert.IsTrue(results[2].ToString().ToLower() == "wine");
            Assert.IsTrue(results[3].ToString().ToLower() == "cake");
        }

        [TestMethod]
        public void TestMultiPotatoDinnerCrazyOrder()
        {
            var kernel = new StandardKernel(new LibraryBindings());
            var mock = kernel.Get<FoodServer>();
            StringBuilder orderOutput = new StringBuilder();
            Order order = mock.TakeOrder(ServingTime.Night.ToString(), new string[] {  "2", "2", "2", "2","1", "2", "3", "4" });

            var results = order.GetReciept().OutputAsList();

            Assert.IsTrue(results[0].ToString().ToLower() == "steak");
            Assert.IsTrue(results[1].ToString().ToLower() == "potatos(x5)");
            Assert.IsTrue(results[2].ToString().ToLower() == "wine");
            Assert.IsTrue(results[3].ToString().ToLower() == "cake");
        }

    }
}
