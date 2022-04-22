using MortgageBLL.IServices;
using MortgageCalculator.Dto;
using MortgageCalculator.Models;
using MortgageLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MortgageCalculator.Controllers
{
   
    public class MartgageController : Controller
    {
        private readonly IMortgageService _mortgageService;
        private readonly IMortgateLoanCalulator _mortgateLoanCalulator;

        public MartgageController(IMortgageService mortgageService, IMortgateLoanCalulator mortgateLoanCalulator)
        {
            _mortgageService = mortgageService;
            _mortgateLoanCalulator = mortgateLoanCalulator;
        }

        // GET: Martgage
        [HttpGet]
        public ActionResult Martgage()
        {
            SingletonLogger.Instance.Debug("Martgage method is started");

            var mortgageResult = _mortgageService.GetAllMortgages();

            SingletonLogger.Instance.Debug("Martgage method is Ended");

            return View(mortgageResult.ToList());
        }

        [HttpPost]
        public JsonResult MartgageTypes(string prefix)
        {
            List<MortgageType> mortgageTypes = Enum.GetValues(typeof(MortgageType))
                                       .Cast<MortgageType>()
                                       .ToList();

            var mortgageType = (from mt in mortgageTypes
                                where mt.ToString().StartsWith(prefix == null ? "" : prefix)
                                select mt);

            return Json(mortgageTypes);
        }

        [HttpPost]
        public JsonResult CalculateMonthlyPaymentLoan(MortgageLoan mortgageLoan)
        {
            var monthyLoanPayment = _mortgateLoanCalulator.CalculateMonthlyPaymentForLoan(Convert.ToDouble(mortgageLoan.Amount), mortgageLoan.Duration, out double totalInterestAmount, out double totalAmountAmount, Convert.ToDouble(mortgageLoan.Rate));
           
            mortgageLoan.Amount = Convert.ToString(monthyLoanPayment);
            mortgageLoan.Rate = Convert.ToString(totalInterestAmount);
            mortgageLoan.Duration = Convert.ToDouble(totalAmountAmount);

            return Json(mortgageLoan, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AutoComplete(string prefix)
        {
            var mortgageTypesDtos = new List<MortgageTypesDto>();

            mortgageTypesDtos.Add(new MortgageTypesDto { FixedType = "Fixed", VariableType = "Variable" });

            var mortgage = (from mr in mortgageTypesDtos
                             where mr.VariableType.StartsWith(prefix) || mr.FixedType.StartsWith(prefix)
                             select new
                             {
                                 label = mr.FixedType,
                                 val = mr.VariableType
                             }).ToList();

            return Json(mortgage);
        }
    }
}