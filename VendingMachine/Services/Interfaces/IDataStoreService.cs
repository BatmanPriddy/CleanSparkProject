using System.Collections.Generic;

namespace VendingMachine.Services.Interfaces
{
    /// <summary>
    /// Interface class for an implementation of a Data Store Service
    /// </summary>
    public interface IDataStoreService<T> where T : new()
    {
        /// <summary>
        /// Method used to obtain a list of generic data based on the concretely
        /// implemented data store
        /// </summary>
        /// <returns>List of generic data from the data store</returns>
        IList<T> GetData();

        /// <summary>
        /// Method used to obtain an array monetary increments based on the concretely
        /// implemented data store
        /// </summary>
        /// <returns>Array of doubles from the data store</returns>
        double[] GetMonetaryIncrementData();
    }
}