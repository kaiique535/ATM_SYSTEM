using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace NewAtmSystem
{
    //Enum to identify the output of the program. When we ask for the withdrawal amount,
    //the computer doesn't know which ballot it is, just numbers. Enum sorts what the output is. 
    public enum BanknotesDescription
    {
        Note2 = 2,
        Note5 = 5,
        Note10 = 10,
        Note20 = 20,
        Note50 = 50,
        Note100 = 100,
        Note200 = 200,
    }
    internal class Withdraw
    {
        public int WithdrawValue { get; set; }
        BanknoteToBeWithdraw structToBeAddOnWithdrawList = new BanknoteToBeWithdraw();
        BanknotesDescription DescriptionNote;


        public struct BanknoteToBeWithdraw//Will create a struct to be added on list of withdraw
        {
            public BanknotesDescription Notes { get; set; }// To identify the value type of banknotes
            public int Quantity { get; set; }//To identify a quantity of banknotes to be withdrawn
        }

        private List<BanknoteToBeWithdraw> ListBanknoteToBeWithdraw = new List<BanknoteToBeWithdraw>();

        private static bool LogicToValidateIfTheAmountCanBeWithdraw(int WithdrawValue)
        {
            int constantMod = WithdrawValue % 5;
            if (constantMod == 1 || constantMod == 3) 
            { 
                return true; 
            }
            return false;
        }

        private static int AddNotesOnList (bool A, int WithdrawValue )
        {
            if (A == true)
            {
             WithdrawValue -= 4;
            }
            return WithdrawValue;
        }
        private int QuantityBanknotes(int qtd, int num) 
        {
            if (structToBeAddOnWithdrawList.Notes == BanknotesDescription.Note2)
            {
                structToBeAddOnWithdrawList.Quantity = qtd + num;
            }
            else
            {
                structToBeAddOnWithdrawList.Quantity = qtd;
            }            
            return structToBeAddOnWithdrawList.Quantity;
        }

        //Method to create list of results by withdraw
        public List<BanknoteToBeWithdraw> BanknotesSelection(int WithdrawValue)
        {
            //Array of available bank notes.
            int[] AvailableBankNotes = new int[] { 200, 100, 50, 20, 10, 5, 2 };
            int NumberOfNotes2ToBeAddOnlist = 0;
            for (int i = 0; i < AvailableBankNotes.Length; i++)
            {
                if (WithdrawValue >= AvailableBankNotes[i])
                {
                    bool isValidValue = LogicToValidateIfTheAmountCanBeWithdraw(WithdrawValue);
                    WithdrawValue = AddNotesOnList(isValidValue, WithdrawValue);                 
                    if (isValidValue == true)
                    {
                        NumberOfNotes2ToBeAddOnlist = 2;
                    }
                    int quantityBankNotes = WithdrawValue / AvailableBankNotes[i];
                    WithdrawValue -= (quantityBankNotes * AvailableBankNotes[i]);
                    DescriptionNote = (BanknotesDescription)AvailableBankNotes[i];
                    structToBeAddOnWithdrawList.Notes = DescriptionNote;
                    QuantityBanknotes(quantityBankNotes, NumberOfNotes2ToBeAddOnlist);
                    if (structToBeAddOnWithdrawList.Quantity != 0)
                    {
                        ListBanknoteToBeWithdraw.Add(structToBeAddOnWithdrawList);
                    }
                    //check if withdrawal amount is greater than zero to break the loop
                    if (WithdrawValue == 0)
                    {
                        break;
                    }
                }
            }
            return ListBanknoteToBeWithdraw;
        }
        //Method responsible for showing the list of banknotes to be withdrawn.
        public void PrintResult(List<BanknoteToBeWithdraw> ListBanknotes)
        {
            foreach (var item in ListBanknotes)
            {
                Console.WriteLine($"Saque: {item.Notes} | Quantidade = {item.Quantity}");

            }
        }
    }
}
