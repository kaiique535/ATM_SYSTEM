int withdrawValue=0;
int balanceAmount = 5000;
int deposit;
int banknotes;
int operation=0;
bool openApp=true;

int bn200=0, bn100=0, bn50=0, bn20=0, bn10=0, bn5=0, bn2=0, bn1=0;

while (openApp)
{
Console.WriteLine("Welcome to the electronic cashout system!");
Console.WriteLine("Select the desired operation below:");
Console.WriteLine("1 - WITHDRAW");
Console.WriteLine("2 - DEPOSIT");
Console.WriteLine("3 - BALANCE");
Console.WriteLine("4 - LOGOUT");

operation= int.Parse(Console.ReadLine());



switch (operation)
{
  
  case 1:
  Console.WriteLine("Enter with withdraw value:");
  withdrawValue = int.Parse(Console.ReadLine());
    balanceAmount = balanceAmount - withdrawValue;

    if (withdrawValue >0){
      bn200 = withdrawValue/200;
      withdrawValue = withdrawValue % 200;
    };
     if (withdrawValue >0){
      bn100 = withdrawValue/100;
      withdrawValue = withdrawValue % 100;
    };
     if (withdrawValue >0){
      bn50 = withdrawValue/50;
      withdrawValue = withdrawValue % 50;
    };
     if (withdrawValue >0){
      bn20 = withdrawValue/20;
      withdrawValue = withdrawValue % 20;
    };
     if (withdrawValue >0){
      bn10 = withdrawValue/10;
      withdrawValue = withdrawValue % 10;
    };
     if (withdrawValue >0){
      bn5 = withdrawValue/5;
      withdrawValue = withdrawValue % 5;
    };
     if (withdrawValue >0){
      bn2 = withdrawValue/2;
      withdrawValue = withdrawValue % 2;
    };
    if (withdrawValue >0){
      bn1 = withdrawValue/1;
      withdrawValue = withdrawValue % 1;
    };
     Console.WriteLine("Your withdrawal is complete!");
     Console.WriteLine($"{bn200} - banknotes of 200 ");
     Console.WriteLine($"{bn100} - banknotes of 100 ");
     Console.WriteLine($"{bn50} - banknotes of 50 ");
     Console.WriteLine($"{bn20} - banknotes of 20 ");
     Console.WriteLine($"{bn10} - banknotes of 10 ");
     Console.WriteLine($"{bn5} - banknotes of 5 ");
     Console.WriteLine($"{bn2} - banknotes of 2 ");
     Console.WriteLine($"{bn1} - banknotes of 1 ");


     Console.WriteLine($"Your current balance is: {balanceAmount}");
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
  openApp=false;
  break;
}
}