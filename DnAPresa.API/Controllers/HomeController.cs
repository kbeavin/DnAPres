using DnAPresa.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DnAPresa.API.Controllers
{
    public class HomeController : ApiController
    {
        public async Task<DTO<Employee>> Get_FilteredEmployees()
        {
            DTO<Employee> dto = new DTO<Employee>();

            try
            {
                HttpResponseMessage httpResponseMessage = await HttpClient.GetAsync("/api/Get_FilteredEmployees");
            }

            return dto;
        }
    }
}
