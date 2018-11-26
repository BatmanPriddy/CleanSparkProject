using static VendingMachine.Enums.CoffeeSizes;

namespace VendingMachine.Models
{
    /// <summary>
    /// Model to be used for storing coffee related information for the UI
    /// </summary>
    public sealed class CoffeeModel
    {
        #region properties

        public Size Size { get; set; }

        public string DisplaySize { get; set; }

        public double Cost { get; set; }

        public int Sugars { get; set; }

        public int Creamers { get; set; }

        #endregion
    }
}