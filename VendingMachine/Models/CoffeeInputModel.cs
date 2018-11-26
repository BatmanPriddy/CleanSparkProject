using static VendingMachine.Enums.CoffeeSizes;

namespace VendingMachine.Models
{
    /// <summary>
    /// Model to be used to collect information from the user, which
    /// will be used in the service class(es)
    /// </summary>
    public sealed class CoffeeInputModel
    {
        #region properties

        public double Cost { get; set; }

        public Size Size { get; set; }

        public int Sugars { get; set; }

        public int Creamers { get; set; }

        public double Increment { get; set; }

        #endregion
    }
}