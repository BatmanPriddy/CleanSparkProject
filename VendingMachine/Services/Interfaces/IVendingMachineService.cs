using System.Collections.Generic;
using VendingMachine.Models;

namespace VendingMachine.Services.Interfaces
{
    /// <summary>
    /// Interface class for supporting any implementation of a vending machine service
    /// </summary>
    public interface IVendingMachineService
    {
        #region method(s)

            /// <summary>
            /// Set the View Model for the UI elements of the main View
            /// </summary>
            /// <returns>ViewModel with appropriate UI elements set</returns>
            VendingMachineViewModel SetViewModel();

            /// <summary>
            /// Used to Add Money to the remaining balance and return that new value
            /// </summary>
            /// <param name="inputModel">contains all necessary values for the method</param>
            /// <returns>new remaining balance amount</returns>
            double AddMoney(CoffeeInputModel inputModel);

            /// <summary>
            /// Used to Add Coffee to a list of coffee items, and returns that list
            /// </summary>
            /// <param name="inputModel">contains all necessary values for the method</param>
            /// <returns>list of one or more coffee items</returns>
            IList<CoffeeModel> AddCoffee(CoffeeInputModel inputModel);

            /// <summary>
            /// Used to Dispense Coffee and return a new view model with the results
            /// </summary>
            /// <returns>new view model with all necessary UI information</returns>
            VendingMachineViewModel DispenseCoffee();

            /// <summary>
            /// Used to Dispense Change back to the user once their transaction is complete
            /// </summary>
            /// <returns>amount left to dispense to user</returns>
            double DispenseChange();

        #endregion
    }
}