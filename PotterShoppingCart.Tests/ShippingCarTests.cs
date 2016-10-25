using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotterShoppingCart.Tests;

namespace PotterShoppingCart.Tests
{
    /// <summary>
    /// Summary description for ShippingCarTests
    /// </summary>
    [TestClass]
    public class ShippingCarTests
    {
        private ShoppingCart _target;
        private Dictionary<string, int> _books;
        private double discountAmount;
        private double newOrdAmount;

        [TestInitialize]
        public void TestInitialized()
        {
            this._target = new ShoppingCart();
            this._books = new Dictionary<string, int>();
            this.newOrdAmount = 0;
        }



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
            var expected = 100;
            this._books.Add("first", 1);
            this.newOrdAmount = this._target.CalculateFee(this._books);
            Assert.AreEqual(expected, this.newOrdAmount);
        }

        /// <summary>
        /// 第一集買了一本，第二集也買了一本，價格應為100*2*0.95=190
        /// </summary>
        [TestMethod]
        public void Test_第一集買了一本_第二集也買了一本_價格應為190()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 190;
            Assert.AreEqual(expected, this.newOrdAmount);
        }


        [TestMethod]
        public void Test_一二三集各買了一本_價格應為270()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 270;
            Assert.AreEqual(expected, this.newOrdAmount);
        }

        [TestMethod]
        public void Test_一二三四集各買了一本_價格應為320()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this._books.Add("fourth", 1);
            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 320;
            Assert.AreEqual(expected, this.newOrdAmount);
        }

        [TestMethod]
        public void Test_一次買了整套_一二三四五集各買了一本_價格應為375()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 1);
            this._books.Add("fourth", 1);
            this._books.Add("fifth", 1);
            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 375;
            Assert.AreEqual(expected, this.newOrdAmount);
        }

        [TestMethod]
        public void Test_一套加孤本_一二集各買了一本_第三集買了兩本_價格應為370()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 1);
            this._books.Add("third", 2);

            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 370;
            Assert.AreEqual(expected, this.newOrdAmount);
        }

        [TestMethod]
        public void Test_兩套加孤本_第一集買了一本_第二三集各買了兩本_價格應為460()
        {
            this._books.Add("first", 1);
            this._books.Add("second", 2);
            this._books.Add("third", 2);

            this.newOrdAmount = this._target.CalculateFee(this._books);
            var expected = 460;
            Assert.AreEqual(expected, this.newOrdAmount);
        }
    }
}
