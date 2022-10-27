using System;

public class program
{
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

                    if ((withdrawValue == 1) || (withdrawValue == 3))
                    {
                        Console.WriteLine(
                            "It is not possible to withdraw 1R$ or 3R$, enter another valid amount:"
                        );
                    }
                    if ((isValidNumber == false) || (withdrawValue == null) || (withdrawValue <= 0))
                    {
                        Console.WriteLine("Plese entry with a valid number");
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
                        bankNotes = bankNoteSelection(withdrawValue);
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

    static string bankNoteSelection(int withdrawValue)
    {
        var availableBankNotes = new int[] { 200, 100, 50, 20, 10 };

        if (withdrawValue == 0 || withdrawValue < 0)
        {
            Console.WriteLine("Please, entry with a value more than zero");
            //Verifica se o numero é par valido para saque
        }
        else if (withdrawValue % 2 == 0) { 

         }
         else {
          Console.WriteLine( " " )
         }
    }

        /* int bn200 = 0, bn100 = 0, bn50 = 0, bn20 = 0, bn10 = 0, bn5 = 0, bn2 = 0;
    
    
        if (withdrawValue >= 200) {
          //Console.WriteLine($"test 200 {withdrawValue}");
          bn200 = withdrawValue / 200;
          withdrawValue = withdrawValue - (bn200 * 200);
        };
        if (withdrawValue >= 100) {
          //Console.WriteLine($"test 100 {withdrawValue}");
          bn100 = (withdrawValue / 2) / 100;
          withdrawValue = withdrawValue - (bn100 * 100);
        };
        if (withdrawValue >= 50) {
          //Console.WriteLine($"test 50 {withdrawValue}");
          bn50 = (withdrawValue / 2) / 50;
          withdrawValue = withdrawValue - (bn50 * 50);
        };
        if (withdrawValue >= 20) {
          //Console.WriteLine($"test 20 {withdrawValue}");
          bn20 = (withdrawValue / 2) / 20;
          withdrawValue = withdrawValue - (bn20 * 20);
    
        };
        if (withdrawValue >= 10) {
          //Console.WriteLine($"test 10 {withdrawValue}");
          bn10 = (withdrawValue / 2) / 10;
          withdrawValue = withdrawValue - (bn10 * 10);
    
        };
        if (withdrawValue >= 5) {
          //Console.WriteLine($"test 5 {withdrawValue}");
          bn5 = (withdrawValue / 2) / 5;
          withdrawValue = withdrawValue - (bn5 * 5);
    
        };
        if (withdrawValue >= 2) {
          //Console.WriteLine($"test 2 {withdrawValue}");
          bn2 = withdrawValue / 2;
          withdrawValue = withdrawValue - (bn2 * 2);
    
        };
    
        string bankNotes = ($"{bn200} - banknotes of 200 \n {bn100} - banknotes of 100 \n {bn50} - banknotes of 50 \n {bn20} - banknotes of 20 \n {bn10} - banknotes of 10 \n {bn5} - banknotes of 5 \n {bn2} - banknotes of 2 ");
    
        Console.WriteLine(bankNotes);
    
        return bankNotes; */
    }
}
