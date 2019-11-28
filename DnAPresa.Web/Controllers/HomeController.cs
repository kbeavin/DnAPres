using System;
using System.Web.Mvc;
using DnAPresa.Web.Models;
using DnAPresa.Common.Utilities;
using DnAPresa.Data.Processors;
using System.IO;

namespace DnAPresa.Web.Controllers
{
    public class HomeController : Controller
    {

        #region Get Methods

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _Filter()
        {
            EmployeeModel viewModel = new EmployeeModel();

            try
            {
                // Get Dictionaries for DropDownLists
                ViewBag.EmpClassList = Utilities.Get_EmpClassList();
                ViewBag.EmpTerminalList = Utilities.Get_EmpTerminalList();
            }
            catch (Exception ex)
            {
                // TODO: return processor response/error handling
                Console.WriteLine(ex);
            }

            // Convert partial view to return as Json
            string viewContent = ConvertViewToString("_Filter", viewModel);
            return Json(new { PartialView = viewContent });
        }

        public ActionResult Get_FilteredEmployees(EmployeeModel model)
        {
            EmployeeListModel viewModel = new EmployeeListModel();

            try
            {
                // Convert to Data Model
                Common.Models.Employee mData = new Common.Models.Employee
                {
                    Tier3 = model.Tier3,
                    Terminal = model.Terminal,
                    DrugPool = model.DrugPool,
                    AlcPool = model.AlcPool
                };

                // Go get our filtered list of employees
                var mResponse = EmployeeProcessor.Get_FilteredEmployees(mData);

                // Assignment to view model
                foreach (var emp in mResponse)
                {
                    viewModel.Employees.Add(new EmployeeModel
                    {
                        EmployeeNumber = emp.EmployeeNumber,
                        EmployeeFullName = emp.EmployeeFullName,
                        Tier3 = emp.Tier3,
                        Terminal = emp.Terminal,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }

                // Convert partial view to return as Json
                string viewContent = ConvertViewToString("_PrintPreview", viewModel);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {
                // TODO: return processor response/error handling
                Console.WriteLine(ex);
            }

            return View(viewModel);
        }

        #endregion

        #region Helpers

        private string ConvertViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (StringWriter writer = new StringWriter())
            {
                ViewEngineResult vResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext vContext = new ViewContext(this.ControllerContext, vResult.View, ViewData, new TempDataDictionary(), writer);
                vResult.View.Render(vContext, writer);
                return writer.ToString();
            }
        }

        #endregion
    }
}