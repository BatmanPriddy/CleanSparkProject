using System.Collections.Generic;
using System.Linq;
using VendingMachine.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Concrete implementation of the IVendingMachineService interface
    /// </summary>
    public sealed class VendingMachineService : IVendingMachineService
    {
        #region field(s)

        private readonly IDataStoreService<CoffeeModel> _dataSvc;

        //created the following two variables as static to "persist" their
        //state throughout the service calls for the various transactions
        private static VendingMachineViewModel _model;

        private static IList<CoffeeModel> _coffeeList;

        #endregion

        #region constructor(s)

        /// <summary>
        /// constructor injection of the date store service was used here,
        /// to make the service available to all controller requests
        /// </summary>
        /// <param name="dataSvc">data store service instance</param>
        public VendingMachineService(IDataStoreService<CoffeeModel> dataSvc)
        {
            _dataSvc = dataSvc;
        }

        #endregion

        #region interface method(s)

            /// <inheritdoc />
            /// <summary>
            /// method will nullify the coffee list (in the case that someone
            /// reloaded the page, coffee list is a static variable), and then
            /// wire up the model with necessary UI data.
            /// </summary>
            /// <returns>view model with all the necessary UI elements</returns>
            public VendingMachineViewModel SetViewModel()
            {
                _coffeeList = null;

                _model = new VendingMachineViewModel
                {
                    Coffees = _dataSvc.GetData(),

                    Increments = _dataSvc.GetMonetaryIncrementData()
                };

                return _model;
            }

            /// <inheritdoc />
            /// <summary>
            /// method simply takes the increment value, and adds it to the remaining balance
            /// </summary>
            /// <param name="inputModel">contains the necessary "increment" value</param>
            /// <returns>the new remaining balance amount</returns>
            public double AddMoney(CoffeeInputModel inputModel)
            {
                _model.RemainingAmount += inputModel.Increment;

                return _model.RemainingAmount;
            }

            /// <inheritdoc />
            /// <summary>
            /// method for dispensing coffee by performing the following steps:
            /// 1) sum up the total cost of all coffee items in the list
            /// 2) if the sum is greater than the balance, set the message for the user
            /// containing how much is missing, and that this is an error message
            /// 3) otherwise missing the remaining amount from the sum, and that the coffee
            /// was dispensed
            /// 4) return the model with all of this information to the UI
            /// </summary>
            /// <returns>view model with all necessary UI information for the user</returns>
            public VendingMachineViewModel DispenseCoffee()
            {
                var coffeeSum = _coffeeList.Select(c => c.Cost).Sum();

                var remainingBalance = _model.RemainingAmount;

                if (coffeeSum > remainingBalance)
                {
                    _model.HasError = true;

                    var missingAmount = coffeeSum - remainingBalance;

                    _model.Message = $"You still need ${missingAmount:n2}. Please add more money.";
                }
                else
                {
                    _model.HasError = false;

                    _model.RemainingAmount -= coffeeSum;

                    _coffeeList = null;

                    _model.Message = "Your coffee has been dispensed! Enjoy!";
                }
                
                return _model;
            }

            /// <inheritdoc />
            /// <summary>
            /// method to add coffee by performing the following steps:
            /// 1) add the cost for the number of sugars chosen by the user
            /// 2) add the cost for the number of creamers chose by the user
            /// 3) create the coffee item and set all the necessary values
            /// 4) if the static variable for coffee list doesn't exist yet, create it
            /// 5) add the new coffee item to the list
            /// 6) return the coffee item list
            /// </summary>
            /// <param name="inputModel">contains all the necessary user information to 
            /// create a coffee item</param>
            /// <returns></returns>
            public IList<CoffeeModel> AddCoffee(CoffeeInputModel inputModel)
            {
                inputModel.Cost += inputModel.Sugars * 0.25;

                inputModel.Cost += inputModel.Creamers * 0.50;

                var coffee = new CoffeeModel
                {
                    Cost = inputModel.Cost,
                    Size = inputModel.Size,
                    DisplaySize = inputModel.Size.ToString(),
                    Sugars = inputModel.Sugars,
                    Creamers = inputModel.Creamers
                };

                if (_coffeeList == null)
                {
                    _coffeeList = new List<CoffeeModel>();
                }

                _coffeeList.Add(coffee);

                return _coffeeList;
            }

            /// <inheritdoc />
            /// <summary>
            /// method to dispense change by performing three simple steps:
            /// 1) save the amount into a var and reset the original value
            /// 2) if there were any items in the coffee item list, remove them all
            /// 3) return the remaining amount to the user
            /// </summary>
            /// <returns>the remaining amount for the user that was "dispensed"</returns>
            public double DispenseChange()
            {
                var remainingAmount = _model.RemainingAmount;

                _model.RemainingAmount = 0;

                _coffeeList = null;

                return remainingAmount;
            }
            
        #endregion
    }
}