using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Services;
using static VendingMachine.Enums.CoffeeSizes;

namespace VendingMachine.Tests
{
    /// <summary>
    /// Test Class for all vending machine service methods, usually would use moq,
    /// but to keep it simple, just going to instantiate the service classes directly.
    /// This is sort of an integration test as well, because we're not "mocking" the
    /// data store, so this would potentially be connected to a real data store.
    /// </summary>
    [TestClass]
    public sealed class VendingMachineServiceUnitTests
    {
        #region field(s)

        private VendingMachineService _vmSvc;

        private VendingMachineViewModel _viewModel;

        private CoffeeInputModel _inputModel;

        #endregion

        #region initializer(s)

        /// <summary>
        /// Initializer method for all tests in this test class
        /// Instantiates the in memory data store, main service and model data
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            var dataSvc = new InMemoryDataStoreService();

            _vmSvc = new VendingMachineService(dataSvc);

            _viewModel = _vmSvc.SetViewModel();

            _inputModel = new CoffeeInputModel
            {
                Cost = 2.00,
                Size = Size.Medium,
                Sugars = 2,
                Creamers = 3,
            };
        }

        #endregion

        #region test method(s)

        [TestMethod]
        public void TestSettingViewModel_Expect_ViewModelPopulated()
        {
            Assert.AreEqual(_viewModel.Coffees.Count, 3);

            Assert.AreEqual(_viewModel.Increments.Length, 8);
        }

        [TestMethod]
        public void TestAddingMoney_Expect_MoneyAddedCorrectly()
        {
            var coffeeInput = new CoffeeInputModel {Increment = 0.25};

            var amount = _vmSvc.AddMoney(coffeeInput);

            Assert.AreEqual(amount, 0.25);
        }

        [TestMethod]
        public void TestDispensingCoffee_Expect_CoffeeDispensedIncorrectly()
        {
            AddCoffee();

            var viewModel = _vmSvc.DispenseCoffee();

            Assert.AreEqual(viewModel.HasError, true);
        }

        [TestMethod]
        public void TestDispensingCoffee_Expect_CoffeeDispensedCorrectly()
        {
            AddCoffee();

            var coffeeInput = new CoffeeInputModel {Increment = 4.00};

            var initialAmount = _vmSvc.AddMoney(coffeeInput);

            Assert.AreEqual(initialAmount, 4.00);

            var viewModel = _vmSvc.DispenseCoffee();

            Assert.AreEqual(viewModel.HasError, false);
        }

        [TestMethod]
        public void TestAddingCoffee_Expect_CoffeeAddedCorrectly() => AddCoffee();

        [TestMethod]
        public void TestDispensingChange_Expect_AmountDispensedCorrectly()
        {
            var coffeeInput = new CoffeeInputModel {Increment = 10.00};

            var initialAmount = _vmSvc.AddMoney(coffeeInput);

            Assert.AreEqual(initialAmount, 10.00);

            var remainingAmount = _vmSvc.DispenseChange();

            Assert.AreEqual(remainingAmount, 10.00);
        }

        #endregion
        
        #region method(s)

        /// <summary>
        /// Convenience method for adding coffee with the various test methods, as
        /// well as asserting the appropriate data
        /// </summary>
        private void AddCoffee()
        {
            var items = _vmSvc.AddCoffee(_inputModel);

            Assert.AreEqual(items.First().Cost, 4.00);
        }

        #endregion
    }
}