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
        public FareService FareService = new FareService();


        public void UpdateFareService(FareService fareService)
        {
            this.FareService = fareService; 
        }

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
            var selectop = _operatorService.GetOperatorByCode(operatorCode);
            var allfares = FareService.GetFares();
            bool cadastrarFare = true;

            foreach(var fares in allfares)
            {
                if(fares.OperatorCode == selectedOperator.Code && fares.Value == fare.Value)
                {
                    cadastrarFare=false;
                    break;
                }
                else
                {
                    cadastrarFare = true;
                }
            }

            if(cadastrarFare == true)
            {
                FareService.Create(fare);
            }
            else
            {
                Console.WriteLine("Existe Tarifa ativa com mesmo valor e com menos de 6 meses para este operador");
                Console.ReadLine();
            }
            
        }
    }
}
