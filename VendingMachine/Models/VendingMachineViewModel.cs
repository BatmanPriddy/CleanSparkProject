using System.Collections.Generic;

namespace VendingMachine.Models
{
    /// <summary>
    /// View Model to be used for displaying information to the user.
    /// In this case the coffee(s) they have ordered and their remaining balance,
    /// a message if adequate payment has not been provided, or that the coffee
    /// has been dispensed, and lastly if the message was an error.
    /// </summary>
    public sealed class VendingMachineViewModel
    {
        #region properties

        public IList<CoffeeModel> Coffees { get; set; }

        public double[] Increments { get; set; }

        public double RemainingAmount { get; set; }

        public string Message { get; set; }

        public bool HasError { get; set; }

        #endregion
    }
}