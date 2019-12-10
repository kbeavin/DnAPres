using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnAPresa.Common.Models
{
    public class DTO<T>
    {
        public DTO()
        {
            Data = new List<T>();
        }

        public int Code { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<T> Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
