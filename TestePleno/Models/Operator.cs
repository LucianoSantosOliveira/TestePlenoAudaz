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
        public DateTime data { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
