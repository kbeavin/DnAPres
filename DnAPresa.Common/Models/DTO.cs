using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnAPresa.Common.Models
{
    public class DTO
    {
        public DTO()
        {
            Data = new List<Employee>();
        }

        public int Code { get; set; }
        public string Message { get; set; }
        public List<Employee> Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
