using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace new_atm_system
{
    internal class Withdraw
    {
        public int WithdrawValue { get; set; }
        int[] AvailableBankNotes = new int[] { 200, 100, 50, 20, 10, 5, 2 };//Array of available bank notes.
        Notas testNewStruct = new Notas();
        eNotas DescriptionNote;
        int Quantidade { get; set; }
        public enum eNotas//Enum to identify the output of the program. When we ask for the withdrawal amount,
                          //the computer doesn't know which ballot it is, just numbers. Enum sorts what the output is. 
        {
            eNota2 = 2,
            eNota5 = 5,
            eNota10 = 10,
            eNota20 = 20,
            eNota50 = 50,
            eNota100 = 100,
            eNota200 = 200,
        }
        public struct Notas//Will create a struct to be added on list of withdraw
        {
            public eNotas Nota { get; set; }// To identify the value type of banknotes
            public int Quantidade { get; set; }//To identify a quantity of banknotes to be withdrawn
        }
        public List<Notas> BanknotesSelection(int WithdrawValue)//Method to create list of results by withdraw
        {
            List<Notas> result = new List<Notas>();//Creating List of banknotes available.
            for (int i = 0; i < AvailableBankNotes.Length; i++)
            {
                if (WithdrawValue >= AvailableBankNotes[i])
                {
                    if (WithdrawValue % 5 == 1 || WithdrawValue % 5 == 3)
                    {
                        WithdrawValue -= 6;
                        DescriptionNote = eNotas.eNota2;
                        testNewStruct.Nota = DescriptionNote;
                        testNewStruct.Quantidade = 3;
                        result.Add(testNewStruct);

                    }
                    int quantityBankNotes = WithdrawValue / AvailableBankNotes[i];
                    WithdrawValue -= (quantityBankNotes * AvailableBankNotes[i]);

                    DescriptionNote = (eNotas)AvailableBankNotes[i];
                    testNewStruct.Nota = DescriptionNote;
                    testNewStruct.Quantidade = quantityBankNotes;

                    if (testNewStruct.Quantidade != 0)
                    {
                        result.Add(testNewStruct);
                    }
                    if (WithdrawValue == 0)//check if withdrawal amount is greater than zero to break the loop
                    {
                        break;
                    }
                }
            }
            return result;
        }
        public void PrintResult(List<Notas> result)
        {
            foreach (var item in result)
            {
                Console.WriteLine($"Saque: {item.Nota} | Quantidade = {item.Quantidade}");

            }
        }
    }
}
