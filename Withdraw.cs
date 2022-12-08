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
        public int _WithdrawValue { get; set; }
        int[] _AvailableBankNotes = new int[] { 200, 100, 50, 20, 10, 5, 2 };
        BanknoteToBeWithdraw _structToBeAddOnWithdrawList = new BanknoteToBeWithdraw();

        //Will create a struct to be added on list of withdraw
        // -Identify the value type of banknotes
        // -Identify a quantity of banknotes to be withdrawn
        public struct BanknoteToBeWithdraw
        {
            public BanknotesDescription Notes { get; set; }
            public int Quantity { get; set; }
        }

        //List of banknotes to be withdraw
        private List<BanknoteToBeWithdraw> ListBanknoteToBeWithdraw = new List<BanknoteToBeWithdraw>();

        //Pitvate methods
        private bool IsValidWithdrawalAmount(int _WithdrawValue)
        {
            int constantMod = _WithdrawValue % 5;
            if (constantMod == 1 || constantMod == 3)
            {
                return true;
            }
            return false;
        }

        private int AddExtraNotesOnList(bool IsValidWithdraw, int _WithdrawValue)
        {
            if (IsValidWithdraw == true)
            {
                _WithdrawValue -= 4;
            }
            return _WithdrawValue;
        }            

        private void QuantityAndDescriptionBanknotes(int qtd, int num, int arrPosition)
        {
            _structToBeAddOnWithdrawList.Notes = (BanknotesDescription)_AvailableBankNotes[arrPosition];
            if (_structToBeAddOnWithdrawList.Notes == BanknotesDescription.Note2)
            {
                _structToBeAddOnWithdrawList.Quantity = qtd + num;
            }
            else
            {
                _structToBeAddOnWithdrawList.Quantity = qtd;
            }
        }

        private void AddNotesAndQuantityOnList(int quantity, int _WithdrawValue)
        {
            if (quantity != 0)
            {
                ListBanknoteToBeWithdraw.Add(_structToBeAddOnWithdrawList);
            }
        }

        //Method to create list of results by withdraw
        public List<BanknoteToBeWithdraw> BanknotesSelection(int _WithdrawValue)
        {
            int NumberOfNotes2ToBeAddOnlist = 0;

            //loop through array of notes valu
            for (int arrPosition = 0; arrPosition < _AvailableBankNotes.Length; arrPosition++)
            {
                if (_WithdrawValue >= _AvailableBankNotes[arrPosition])
                {
                    bool isValidValue = IsValidWithdrawalAmount(_WithdrawValue);
                    _WithdrawValue = AddExtraNotesOnList(isValidValue, _WithdrawValue);

                    if (isValidValue == true)
                    {
                        NumberOfNotes2ToBeAddOnlist = 2;
                    }

                    int quantity = _WithdrawValue / _AvailableBankNotes[arrPosition];
                    _WithdrawValue -= (quantity * _AvailableBankNotes[arrPosition]);

                    QuantityAndDescriptionBanknotes(quantity, NumberOfNotes2ToBeAddOnlist, arrPosition);
                    AddNotesAndQuantityOnList(quantity, _WithdrawValue);
                }
                else if (_WithdrawValue == 0)
                {
                    break;
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
