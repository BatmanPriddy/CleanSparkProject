using System.Collections.Generic;
using VendingMachine.Models;
using VendingMachine.Services.Interfaces;
using static VendingMachine.Enums.CoffeeSizes;

namespace VendingMachine.Services
{
    /// <inheritdoc />
    /// <summary>
    /// Concrete implementation of the IDataStoreService interface
    /// </summary>
    public sealed class InMemoryDataStoreService : IDataStoreService<CoffeeModel>
    {
        #region interface method(s)

            /// <inheritdoc />
            /// <summary>
            /// Method used to obtain a list of coffee models, in this case,
            /// simply hard coded values
            /// </summary>
            /// <returns>List of coffee models from the "data store"</returns>
            public IList<CoffeeModel> GetData()
            {
                return new List<CoffeeModel>
                {
                    new CoffeeModel { Size = Size.Small, Cost = 1.75 },
                    new CoffeeModel { Size = Size.Medium, Cost = 2.00 },
                    new CoffeeModel { Size = Size.Large, Cost = 2.25 },
                };
            }

            /// <inheritdoc />
            /// <summary>
            /// Method used to obtain an array of monetary increments, in this case,
            /// simply hard coded values
            /// </summary>
            /// <returns>Array of doubles from the "data store"</returns>
            public double[] GetMonetaryIncrementData()
            {
                return new[] { 0.05, 0.10, 0.25, 0.50, 1.00, 5.00, 10.00, 20.00 };
            }

        #endregion
    }
}