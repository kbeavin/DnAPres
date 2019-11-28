using DnAPresa.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using static DnAPresa.Common.Enumerations.Enumerations;

namespace DnAPresa.Common.Utilities
{
    public class Utilities
    {

        #region Enum Methods

        public static string Get_EnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static T GetValueFromDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            //throw new ArgumentException("Not found.", nameof(description));
            return default(T);
        }

        #endregion

        #region Drop Down Lists

        public static Dictionary<int, string> Get_EmpClassList()
        {
            Dictionary<int, string> empClassList = new Dictionary<int, string>();

            foreach (EmpClass empClass in EmpClass.GetValues(typeof(Enumerations.Enumerations.EmpClass))) 
            {
                empClassList.Add((int)empClass, Get_EnumDescription(empClass));
            }

            return empClassList;
        }

        public static Dictionary<int, string> Get_EmpTerminalList()
        {
            Dictionary<int, string> empTerminalList = new Dictionary<int, string>();

            foreach (EmpTerminal empTerminal in EmpTerminal.GetValues(typeof(Enumerations.Enumerations.EmpTerminal)))
            {
                empTerminalList.Add((int)empTerminal, Get_EnumDescription(empTerminal));
            }

            return empTerminalList;
        }

        #endregion

        #region Set Randoms

        public static List<Employee> Set_Randoms(List<Employee> filteredEmployees, Employee model)
        {
            List<Employee> clonedList = new List<Employee>(filteredEmployees);

            // Assign Employees properties and modify list accordingly
            filteredEmployees = Set_RandomDrug(filteredEmployees, model);
            filteredEmployees = Set_RandomAlc(filteredEmployees, model);
            filteredEmployees = Set_RandomSub(filteredEmployees, clonedList);

            return filteredEmployees;
        }

        public static List<Employee> Set_RandomDrug(List<Employee> filteredEmployees, Employee model)
        {
            List<Employee> drugPoolList = new List<Employee>();
            Random myRand = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);

            // Build up list of randoms
            for (int i = 0; i < (model.DrugPool * filteredEmployees.Count) / 100; i++)
            {
                int t = myRand.Next(filteredEmployees.Count);

                // Handle Duplicates not best way but better than nothing
                if (drugPoolList.Contains(filteredEmployees[t]))
                {
                    drugPoolList.Add(filteredEmployees[t + 1]);
                }
                else
                {
                    drugPoolList.Add(filteredEmployees[t]);
                }
            }

            // For Convention I always work with filteredEmployees List
            filteredEmployees = drugPoolList;

            // Assign properties
            foreach (Employee Emp in filteredEmployees)
            {
                Emp.Drug = true;
            }

            return filteredEmployees;
        }

        public static List<Employee> Set_RandomAlc(List<Employee> filteredEmployees, Employee model)
        {
            //Assign random employees to take alchohol tests
            Random myRand = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);
            for (int i = 0; i < (model.AlcPool * filteredEmployees.Count) / 100; i++)
            {
                int t = myRand.Next(filteredEmployees.Count);
                if (filteredEmployees[t].Alcohol)
                    i--;
                else filteredEmployees[t].Alcohol = true;
            }

            return filteredEmployees;
        }

        public static List<Employee> Set_RandomSub(List<Employee> filteredEmployees, List<Employee> subList)
        {
            // Remove employees already selected
            foreach (Employee Emp in filteredEmployees)
            {
                subList.Remove(Emp);
            }

            // Add 15 substitutes to list
            Random myRand = new Random(DateTime.Now.Second * DateTime.Now.Millisecond);
            for (int i = 0; i < 15; i++)
            {
                int t = myRand.Next(subList.Count);
                subList[t].Substitute = true;
                filteredEmployees.Add(subList[t]);
            }

            return filteredEmployees;
        }

        #endregion

    }
}
