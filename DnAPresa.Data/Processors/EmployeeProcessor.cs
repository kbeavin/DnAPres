using System;
using System.Collections.Generic;
using System.Linq;
using static DnAPresa.Common.Enumerations.Enumerations;
using DnAPresa.Common.Models;
using System.Data;
using System.Data.SqlClient;

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
        public static DTO Get_FilteredEmployees(Employee model)
        {
            DTO dto = new DTO();

            try
            {
                // Convert to Enums
                var eClass = Common.Utilities.Utilities.GetValueFromDescription<EmpClass>(model.Tier3).ToString();
                var eTerm = model.Terminal == "-- Select --" ? string.Empty : Common.Utilities.Utilities.GetValueFromDescription<EmpTerminal>(model.Terminal).ToString();

                // Go Get Filtered Lists
                var employees = Get_Employees(eClass);
                var drivers = Get_Drivers(eTerm);

                // Combine Lists to one
                dto.Data.AddRange(employees.Data);
                dto.Data.AddRange(drivers.Data);

                // Set the properties for Random Employees
                if (dto.Data != null && dto.Data.Count != 0)
                {
                    dto.Data = Common.Utilities.Utilities.Set_Randoms(dto.Data, model);
                }
            }
            catch (Exception ex)
            {
                dto.Message = ex.Message;
            }

            return dto;
        }

        /// <summary>
        /// Gets all employees from tbl_DNA_CurrentEmployees Table
        /// </summary>
        /// <param name="empClass">Filters by Tier3 column</param>
        /// <returns>a List of Employee objects</returns>
        private static DTO Get_Employees(string empClass = null)
        {
            DTO dto = new DTO();
            if (empClass == "Drivers") { return dto; }

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
                            dto.Data.Add(new Employee
                            {
                                EmployeeNumber = emp.EmployeeNumber,
                                EmployeeFullName = emp.EmployeeFullName,
                                Tier3 = emp.Tier3,
                                Terminal = "AND"
                            });
                        }
                    }
                }

                dto.Success = true;
            }
            catch (Exception ex)
            {
                dto.Message = ex.Message;
            }

            return dto;
        }

        /// <summary>
        /// Gets all drivers from manpowerprofile Table
        /// </summary>
        /// <param name="empTerminal">Filters by mpp_terminal column</param>
        /// <returns>a List of Employee objects</returns>
        private static DTO Get_Drivers(string empTerminal = null)
        {
            DTO dto = new DTO();
            if (empTerminal == string.Empty) { return dto; }

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
                            dto.Data.Add(new Employee
                            {
                                EmployeeNumber = emp.mpp_id,
                                EmployeeFullName = emp.mpp_firstname + " " + emp.mpp_lastname,
                                Tier3 = "Drivers",
                                Terminal = emp.mpp_terminal
                            });
                        }
                    }
                }

                dto.Success = true;
            }
            catch (Exception ex)
            {
                dto.Message = ex.Message;
            }

            return dto;
        }

        #endregion

        #region Post Methods

        /// <summary>
        /// Inserts the List of Employees into the carter_dnaHistory table 
        /// </summary>
        /// <param name="model">List of Employees</param>
        /// <returns>an DTO with success bool</returns>
        public static DTO Insert_DnAHistory(EmployeeList model)
        {
            DTO dto = new DTO();

            try
            {
                // Open connection to DB         // had to do it this way because table does not have PK
                using (SqlConnection conn = new SqlConnection("data source=NAUS03TMW1;initial catalog=TMW_Live;integrated security=True;multipleactiveresultsets=True"))
                {
                    // Get SPROC
                    SqlCommand cmd = new SqlCommand("up_Insert_carter_dnaHistory", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Loop over list and add to DB
                    foreach (var emp in model.Employees)
                    {
                        cmd.Parameters.Add(new SqlParameter("@EmployID", emp.EmployID));
                        cmd.Parameters.Add(new SqlParameter("@lastname", emp.lastname));
                        cmd.Parameters.Add(new SqlParameter("@firstname", emp.frstname));
                        cmd.Parameters.Add(new SqlParameter("@midlname", string.Empty));
                        cmd.Parameters.Add(new SqlParameter("@emplclas", emp.emplclas));
                        cmd.Parameters.Add(new SqlParameter("@db", "CEXPL"));
                        cmd.Parameters.Add(new SqlParameter("@testsel", emp.testsel));

                        using (SqlDataReader rdr = cmd.ExecuteReader()) { }

                        cmd.Parameters.Clear();
                    }
                }

                // Set Data Transfer Object Success property to true
                dto.Success = true;
            }
            catch (Exception ex)
            {
                dto.Message = "Failed to save pull. Error: " + ex.Message;
            }

            return dto;
        }

        #endregion
    }
}
