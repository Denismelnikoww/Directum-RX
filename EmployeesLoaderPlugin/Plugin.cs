using System;
using System.Collections.Generic;
using System.Linq;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;

namespace EmployeesLoaderPlugin
{

    [Author(Name = "Ivan Petrov")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {

            logger.Info("Loading employees");

            var employees = args.OfType<EmployeesDTO>().ToList();
            
            var employeesList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<EmployeesDTO>>(EmployeesLoaderPlugin.Properties.Resources.EmployeesJson);

            logger.Info($"Loaded {employeesList.Count()} employees");

            employees.AddRange(employeesList);

            return employees;
        }
    }
}
