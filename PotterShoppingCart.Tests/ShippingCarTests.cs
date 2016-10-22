using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// Summary description for ShippingCarTests
    /// </summary>
    [TestClass]
    public class ShippingCarTests
    {

        private int qty ;
        private double price ;
        private double OrdAmount ;
        private double discountAmount;
        private double newOrdAmount;


        public ShippingCarTests()
        {
            //
            // TODO: Add constructor logic here
            //


        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        /// <summary>
        /// 只買一本書,價格應為100元
        /// </summary>

        [TestMethod]
        public void TestMethod_oneProduct_oneQty()
        {
            qty = 1;
            price = 100;
            OrdAmount = qty * price ;
            discountAmount = this.CalculateDiscountAmount(qty, price);
            newOrdAmount = OrdAmount - discountAmount;
            Assert.AreEqual(OrdAmount, newOrdAmount);

        }

        private double CalculateDiscountAmount(int qty, double price)
        {
            if (qty == 1 )
            {
                discountAmount=0 ;
            }
            return discountAmount;
        }
    }
}
