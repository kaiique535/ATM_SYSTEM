//Focus on the development solution, where the user just enters a value
//and the application returns the arrangement of the notes. 
//The system must: Validate the input, return best arrangement notes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewAtmSystem

{
    class Program
    {

        static void Main(string[] args)
        {
            Withdraw withdraw = new Withdraw();
            System.Console.WriteLine("Enter withdraw value:");
            withdraw._WithdrawValue = int.Parse(Console.ReadLine());
            var withdraBanknotesList = withdraw.BanknotesSelection(withdraw._WithdrawValue);
            withdraw.PrintResult(withdraBanknotesList);
        }

    }

}

//Comentarios ronny : Fazer a tabela verdade das entradas e saidas para saber definir a logica.
//Tudo que eu acesso frequentemente deve ficar modular com chamada para onde for usar.
//Sempre conhecer as entradas e saidas antes de começar a resolver o problema.


