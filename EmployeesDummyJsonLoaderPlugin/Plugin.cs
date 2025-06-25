using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PhoneApp.Domain.Attributes;
using PhoneApp.Domain.DTO;
using PhoneApp.Domain.Interfaces;
using static System.Net.WebRequestMethods;

namespace EmployeesLoaderPlugin
{

    [Author(Name = "Melnikow Denis")]
    public class Plugin : IPluggable
    {
        private static readonly NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private static readonly string URL = @"https://dummyjson.com/users";
        public IEnumerable<DataTransferObject> Run(IEnumerable<DataTransferObject> args)
        {
            logger.Info("Loading employees from {URl}", URL);

            var employees = args.OfType<EmployeesDTO>().ToList();
            
            var startCount = employees.Count();

            using (var httpClient = new HttpClient())
            {
                var jsonString = Task.Run(() => httpClient.GetStringAsync(URL)).Result;
                var response = JsonConvert.DeserializeObject<DummyResponse>(jsonString);

                foreach (var dummyEmployee in response.Users)
                {
                    var employee = new EmployeesDTO()
                    {
                        Name = $"{dummyEmployee.FirstName} {dummyEmployee.LastName} {dummyEmployee.MaidenName}",
                    };

                    employee.AddPhone(dummyEmployee.Phone);

                    employees.Add(employee);
                }
                logger.Info($"Loaded {employees.Count - startCount} employees");
                return employees;
            }
        }
    }
}
