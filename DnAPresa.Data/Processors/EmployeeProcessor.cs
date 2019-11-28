using System;
using System.Collections.Generic;
using System.Linq;
using static DnAPresa.Common.Enumerations.Enumerations;
using DnAPresa.Common.Models;

namespace DnAPresa.Data.Processors
{
    public class EmployeeProcessor
    {
        #region Get Methods

        /// <summary>
        /// Gets all filtered employees & drivers
        /// </summary>
        /// <param name="empClass">Filters by Tier3 column</param>
        /// <param name="empTerminal">Filters by mpp_terminal column</param>
        /// <returns>a List of Employee objects</returns>
        public static List<Employee> Get_FilteredEmployees(Employee model)
        {
            List<Employee> filteredEmployees = new List<Employee>();

            try
            {
                // Convert to Enums
                var eClass = Common.Utilities.Utilities.GetValueFromDescription<EmpClass>(model.Tier3).ToString();
                var eTerm = model.Terminal == "-- Select --" ? string.Empty : Common.Utilities.Utilities.GetValueFromDescription<EmpTerminal>(model.Terminal).ToString();

                // Go Get Filtered Lists
                var employees = Get_Employees(eClass);
                var drivers = Get_Drivers(eTerm);

                // Combine Lists to one
                filteredEmployees.AddRange(employees);
                filteredEmployees.AddRange(drivers);

                // Set the properties for Random Employees
                if (filteredEmployees != null && filteredEmployees.Count != 0)
                {
                    filteredEmployees = Common.Utilities.Utilities.Set_Randoms(filteredEmployees, model);
                }
            }
            catch (Exception ex)
            {
                // TODO: return processor response/error handling
                Console.WriteLine(ex);
            }

            return filteredEmployees;
        }

        /// <summary>
        /// Gets all employees from tbl_DNA_CurrentEmployees Table
        /// </summary>
        /// <param name="empClass">Filters by Tier3 column</param>
        /// <returns>a List of Employee objects</returns>
        private static List<Employee> Get_Employees(string empClass = null)
        {
            List<Employee> employees = new List<Employee>();
            if (empClass == "Drivers") { return employees; }

            try
            {
                using (CarterProdEntities CarterProd = new CarterProdEntities())
                {
                    // Query DB
                    var query = from ce in CarterProd.tbl_DNA_CurrentEmployees
                                select new
                                {
                                    ce.EmployeeNumber,
                                    ce.EmployeeFullName,
                                    ce.Tier3
                                };

                    // Filter Query by empClass parameter
                    query = string.IsNullOrEmpty(empClass) ? query : query.Where(p => p.Tier3 == empClass);

                    // Create List of Employee's
                    foreach (var emp in query)
                    {
                        if (!string.IsNullOrEmpty(emp.EmployeeNumber))
                        {
                            employees.Add(new Employee
                            {
                                EmployeeNumber = emp.EmployeeNumber,
                                EmployeeFullName = emp.EmployeeFullName,
                                Tier3 = emp.Tier3,
                                Terminal = "AND"
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: return processor response/error handling
                Console.WriteLine(ex);
            }

            return employees;
        }

        /// <summary>
        /// Gets all drivers from manpowerprofile Table
        /// </summary>
        /// <param name="empTerminal">Filters by mpp_terminal column</param>
        /// <returns>a List of Employee objects</returns>
        private static List<Employee> Get_Drivers(string empTerminal = null)
        {
            List<Employee> employees = new List<Employee>();
            if (empTerminal == string.Empty) { return employees; }

            try
            {
                using (TMW_LiveEntities1 TMW = new TMW_LiveEntities1())
                {
                    // Query DB
                    var query = from cd in TMW.manpowerprofiles
                                join lf in TMW.labelfiles on cd.mpp_terminal equals lf.abbr
                                where cd.mpp_terminationdt > DateTime.Now && lf.labeldefinition == "terminal"
                                select new
                                {
                                    cd.mpp_id,
                                    cd.mpp_firstname,
                                    cd.mpp_lastname,
                                    cd.mpp_terminal
                                };

                    // Filter Query by empClass parameter
                    query = string.IsNullOrEmpty(empTerminal) ? query : query.Where(p => p.mpp_terminal == empTerminal);

                    // Create List of Employee's
                    foreach (var emp in query)
                    {
                        if (!string.IsNullOrEmpty(emp.mpp_id))
                        {
                            employees.Add(new Employee
                            {
                                EmployeeNumber = emp.mpp_id,
                                EmployeeFullName = emp.mpp_firstname + " " + emp.mpp_lastname,
                                Tier3 = "Drivers",
                                Terminal = emp.mpp_terminal
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // TODO: return processor response/error handling
                Console.WriteLine(ex);
            }

            return employees;
        }

        #endregion
    }
}
