using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestePleno.Models;

namespace TestePleno
{
    class Program
    {
        static void Main(string[] args)
        {
            int continuar = 1;

            OperatorService OpService = new OperatorService();

            var op = new Operator();
            var fare = new Fare();

            int fareCode = 100;
            int opCode = 200;

            while (continuar == 1)
            {
                Console.Clear();

                Guid GenerateNewguidFare = Guid.NewGuid();
                Guid GenerateNewguidOp = Guid.NewGuid();
                fareCode += 1;
                opCode += 1;
                //fare.Id = GenerateNewguidFare;
                fare.Code = Convert.ToString(fareCode);
                fare.Data = DateTime.Now;

                op.Code = Convert.ToString(opCode);
                //op.Id = GenerateNewguidOp;

                Console.WriteLine("Informe o valor da tarifa a ser cadastrada:");
                var fareValueInput = Console.ReadLine();
                fare.Value = decimal.Parse(fareValueInput);
                fare.Status = 1;

                Console.WriteLine("Informe o código da operadora para a tarifa:");
                Console.WriteLine("Exemplos: OP01, OP02, OP03...");
                var operatorCodeInput = Console.ReadLine();
                op.Code = operatorCodeInput;
                
                OpService.Create(op);

                var fareController = new FareController();
                fareController.UpdateOperatorService(OpService);
                fareController.CreateFare(fare, operatorCodeInput);

                Console.WriteLine("Tarifa cadastrada com sucesso!");
                Console.WriteLine("Cadastrar nova tarifa ? S = 1 || N = 0 ");
                continuar = Convert.ToInt16(Console.ReadLine());
            }
        }
    }
}
