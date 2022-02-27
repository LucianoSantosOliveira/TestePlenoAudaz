using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public class Fare : IModel
    {
        public string Id { get; set; }
        //public Guid OperatorId { get; set; }
        public string OperatorCode { get; set; }
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime data { get; set; }
        public string Code { get; set; }


        public Fare(string id, string OperatorCode, int status, decimal value, DateTime data, string code)
        {
            this.Status = status;
            this.data = data;
            this.Code = code;
            this.Id = id;
            this.OperatorCode = OperatorCode;
            this.Value = value;
        }
    }
}
