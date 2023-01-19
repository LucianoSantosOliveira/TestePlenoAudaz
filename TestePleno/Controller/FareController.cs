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

        public bool CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            fare.OperatorCode = selectedOperator.Code;
            var selectop = _operatorService.GetOperatorByCode(operatorCode);
            var allfares = FareService.GetFares();
            bool cadastrarFare = true;

            var FaresForThisOperatorAndValue = from f in allfares
                                               where f.OperatorCode == selectedOperator.Code && f.Value == fare.Value
                                               select f;

            var FaresList = FaresForThisOperatorAndValue.ToList();

            TimeSpan differenceEmDias;

            if (FaresList.Count() > 0)
            {
                differenceEmDias = fare.data - FaresForThisOperatorAndValue.FirstOrDefault().data;
                if (FaresForThisOperatorAndValue.FirstOrDefault().OperatorCode == selectedOperator.Code && FaresForThisOperatorAndValue.FirstOrDefault().Value == fare.Value && differenceEmDias.TotalDays < 180)
                {
                    cadastrarFare = false;
                }
                else
                {
                    FaresForThisOperatorAndValue.FirstOrDefault().Status = 0;
                    cadastrarFare = true;
                }
            }
            else
                cadastrarFare = true;

            


            if(cadastrarFare == true)
            {
                FareService.Create(fare);
            }
            else
            {
                Console.WriteLine("Existe Tarifa ativa com mesmo valor e com menos de 6 meses para este operador");
                Console.ReadLine();
            }
            return cadastrarFare;
        }
    }
}
