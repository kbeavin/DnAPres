using DnAPresa.UI.Models;
using DnAScreener;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DnAPresa.UI.Controllers
{
    public class HomeController : Controller
    {
        LoginModels loginModel = new LoginModels();

        #region Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(LoginModels mData)
        {
            JsonResult json = new JsonResult { Data = mData, };

            try
            {
                loginModel.Username = mData.Username;
                loginModel.Password = mData.Password;

                json.Data = mData;
            }
            catch (Exception ex)
            {
                return new JsonResult { Data = "fail" };
            }

            return json;
        }

        #endregion

        #region Driver

        public ActionResult Driver(TabModels model)
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getDrivers();

                viewModel.TotalActiveDrivers = myData.Rows.Count;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_DriverReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };
            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getDrivers();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region ExpressOffice

        public ActionResult ExpressOffice()
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getCEXPOffice();
                EmployeeList myEmpList = new EmployeeList(myData);
                PrintPreviewModels drugScreens = new PrintPreviewModels();
                foreach (Employee emp in myEmpList)
                {
                    drugScreens.DrugPool.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                viewModel.TotalActiveDrivers = myData.Rows.Count;
                viewModel.empList = drugScreens;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_OfficeReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };

            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getCEXPOffice();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region ExpressWarehouse

        public ActionResult ExpressWarehouse()
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getCEXPWarehouse();

                viewModel.TotalActiveDrivers = myData.Rows.Count;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_WarehouseReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };

            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getCEXPWarehouse();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region Logistics

        public ActionResult Logistics()
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getCLL();

                viewModel.TotalActiveDrivers = myData.Rows.Count;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_LogisticsReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };

            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getCLL();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region Duke

        public ActionResult Duke()
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getDukel();

                viewModel.TotalActiveDrivers = myData.Rows.Count;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_DukeReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };

            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getDukel();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region Canton

        public ActionResult Canton()
        {
            TabModels viewModel = new TabModels();

            try
            {
                DataMgr myDataMgr = new DataMgr("hi", "hi");

                var myData = myDataMgr.getCantons();

                viewModel.TotalActiveDrivers = myData.Rows.Count;
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }

            return View(viewModel);
        }

        public ActionResult Get_CantonReport(TabModels model)
        {
            JsonResult json = new JsonResult { Data = null };

            try
            {
                DataMgr myDataMgr = new DataMgr
                {
                    uname = model.Username,
                    password = model.Password,
                    TotalActiveDrivers = model.TotalActiveDrivers,
                    DriverPoolPercentage = model.DriverPoolPercentage,
                    AlchoholPercentage = model.AlchoholPercentage,
                    PrintActiveDriverList = model.PrintActiveDriverList
                };
                List<DrugScreen> drugScreens = new List<DrugScreen>();
                DriverTab button = new DriverTab(myDataMgr);
                var myData = myDataMgr.getCantons();
                EmployeeList myEmpList = new EmployeeList(myData);
                myDataMgr.empList = myData;
                myEmpList = button.button1_Click(myDataMgr, System.EventArgs.Empty);

                foreach (Employee emp in myEmpList)
                {
                    drugScreens.Add(new DrugScreen
                    {
                        ID = emp.EmpID,
                        FName = emp.FName,
                        LName = emp.LName,
                        MI = emp.MI,
                        Drug = emp.Drug,
                        Alcohol = emp.Alcohol,
                        Substitute = emp.Substitute
                    });
                }
                string viewContent = ConvertViewToString("PrintPreview", drugScreens);
                return Json(new { PartialView = viewContent });
            }
            catch (Exception ex)
            {

            }

            return json;
        }

        #endregion

        #region Helpers

        public void SetUserCredentials(string UName, string pwd)
        {
            try
            {
                loginModel.Username = UName;
                loginModel.Password = pwd;
            }
            catch (Exception ex)
            {

            }
        }

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