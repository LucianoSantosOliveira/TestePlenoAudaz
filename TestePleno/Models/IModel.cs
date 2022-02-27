using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestePleno.Models
{
    public interface IModel
    {
        string Id { get; set; }
        String Code { get; set; }
        DateTime data { get; set; }
    }
}
