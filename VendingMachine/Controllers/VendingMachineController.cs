using System.Web.Mvc;
using VendingMachine.Models;
using VendingMachine.Services.Interfaces;

namespace VendingMachine.Controllers
{
    /// <inheritdoc />
    /// <summary>
    /// Controller class to facilitate user requests via service class(es)
    /// </summary>
    public sealed class VendingMachineController : Controller
    {
        #region field(s)

        private readonly IVendingMachineService _vmSvc;

        #endregion

        #region constructor(s)

        /// <inheritdoc />
        /// <summary>
        /// Constructor injection of the vending machine service was used here,
        /// to make the service available to all controller requests
        /// </summary>
        /// <param name="vmSvc">Vending machine service instance</param>
        public VendingMachineController(IVendingMachineService vmSvc)
        {
            _vmSvc = vmSvc;
        }

        #endregion

        #region controller method(s)

        /// <summary>
        /// On initial load of the view, we simply set the viewModel and return it to
        /// the view for the various UI elements, using the vending machine service
        /// </summary>
        /// <returns>Action result with the appropriate viewModel information</returns>
        public ActionResult Index()
        {
            var viewModel = _vmSvc.SetViewModel();

            return View(viewModel);
        }

        /// <summary>
        /// Uses vending machine service to set remaining balance and return that new value
        /// </summary>
        /// <param name="inputModel">contains the "increment" value so service will
        /// know how much to increment the remaining balance by</param>
        /// <returns>json object with the appropriate data set</returns>
        [HttpPost]
        public JsonResult AddMoney(CoffeeInputModel inputModel)
        {
            var data = _vmSvc.AddMoney(inputModel);

            return Json(data);
        }

        /// <summary>
        /// Uses vending machine service to add a return list of one or more coffees
        /// </summary>
        /// <param name="inputModel">contains all values necessary for the Add
        /// coffee service method</param>
        /// <returns>json object with the appropriate data set</returns>
        [HttpPost]
        public JsonResult AddCoffee(CoffeeInputModel inputModel)
        {
            var data = _vmSvc.AddCoffee(inputModel);

            return Json(data);
        }

        /// <summary>
        /// Uses vending machine service to dispense coffee and return a new view model 
        /// with the results
        /// </summary>
        /// <returns>json object with the appropriate data set</returns>
        [HttpPost]
        public JsonResult DispenseCoffee()
        {
            var data = _vmSvc.DispenseCoffee();

            return Json(data);
        }

        /// <summary>
        /// Uses vending machine service to dispense change back to the user once their 
        /// transaction is complete
        /// </summary>
        /// <returns>json object with the appropriate data set</returns>
        [HttpPost]
        public JsonResult DispenseChange()
        {
            var data = _vmSvc.DispenseChange();

            return Json(data);
        }

        #endregion
    }
}