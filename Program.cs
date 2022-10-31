using System;

class Program
{
    static void BankNoteSelection(int withdrawValue)
    {
        var availableBankNotes = new int[] { 200, 100, 50, 20, 10 };

        if (withdrawValue == 0 || withdrawValue < 0)
        {
            Console.WriteLine("Please, entry with a value more than zero");
            //Verifica se o numero é par valido para saque
        }
        else if (withdrawValue == 0)
            Console.WriteLine(" successfull withdraw! ");
        else if (withdrawValue % 2 == 0)
        {
            int[] bankNotes = new int[availableBankNotes.Length];

            for (var item = 0; item < availableBankNotes.Length; item++)
            {
                bankNotes[item] = (int)(
                    Math.Floor((decimal)withdrawValue / availableBankNotes[item])
                );
                withdrawValue -= (bankNotes[item] * availableBankNotes[item]);
            }
            for (int item = 0; item < bankNotes.Length; item++)
                Console.WriteLine($"Cedula de {availableBankNotes[item]}: {bankNotes[item]}");
        }

        return;
    }

    public static void Main(string[] args)
    {
        int balanceAmount = 5000;
        int withdrawValue = 0;
        bool openApp = true;
        int deposit;

        bool isValidNumber;
        int operation;

        while (openApp)
        {
            Console.WriteLine("");
            Console.WriteLine("Welcome to the electronic cashout system!");
            Console.WriteLine("Select the desired operation below:");
            Console.WriteLine("1 - WITHDRAW");
            Console.WriteLine("2 - DEPOSIT");
            Console.WriteLine("3 - BALANCE");
            Console.WriteLine("4 - LOGOUT");

            string operationEntry = Console.ReadLine();

            isValidNumber = int.TryParse(operationEntry, out operation);

            if ((isValidNumber == false) || (operation <= 0) || (operation > 4))
            {
                Console.WriteLine("Plese entry with a valid operation number");
            }

            switch (operation)
            {
                case 1:
                    string bankNotes;
                    Console.WriteLine("Enter with withdraw value:");

                    string withdrawValueEntry = Console.ReadLine();
                    isValidNumber = int.TryParse(withdrawValueEntry, out withdrawValue);

                    if (withdrawValue % 2 != 0)
                    {
                        Console.WriteLine("Please entry with a valid value");
                    }
                    if (withdrawValue > balanceAmount)
                    {
                        Console.WriteLine("Insufficient balance for withdrawal");
                    }
                    if (
                        (isValidNumber == true)
                        && (withdrawValue > 0)
                        && (withdrawValue <= balanceAmount)
                    )
                    {
                        balanceAmount = balanceAmount - withdrawValue;
                        //bankNotes = bankNoteSelection(withdrawValue);
                        Program notes = Program();
                        notes.BankNoteSelection();
                        Console.WriteLine("Your withdrawal is complete!");
                        Console.WriteLine($"Your current balance is: {balanceAmount}");
                    }
                    break;
                case 2:
                    Console.WriteLine("Whats the deposit value");
                    deposit = int.Parse(Console.ReadLine());

                    balanceAmount = balanceAmount + deposit;

                    Console.WriteLine($"Your current balance is: R${balanceAmount}");

                    break;
                case 3:
                    Console.WriteLine($"Your balance is: R${balanceAmount}");
                    break;
                case 4:
                    openApp = false;
                    break;
            }
        }
    }
}
