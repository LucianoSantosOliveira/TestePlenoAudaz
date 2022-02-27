using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno
{
    public class FareController
    {
        private OperatorService _operatorService;
        private FareService FareService = new FareService();


        //public void UpdateFareService(FareService fareService)
        //{
        //    this.FareService = fareService; 
        //}

        public void UpdateOperatorService(OperatorService operatorService)
        {
            this._operatorService = operatorService;
        }

        public FareController()
        {
            _operatorService = new OperatorService();
        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorCode = selectedOperator.Code;

            FareService.Create(fare);
        }
    }
}
