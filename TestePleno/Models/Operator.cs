using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public class Operator : IModel
    {


        public string Id { get; set; }
        public string Code { get; set; }
        public DateTime data { get; set; }

        public Operator(string Id, string code, DateTime data)
        {
            this.Id = Id;
            this.Code = code;
            this.data = data;
        }
    }
}
