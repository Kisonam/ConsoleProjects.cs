using Bank;
using static System.Console;
//   Variables
Dictionary<int,string> Users = new Dictionary<int,string>();
Dictionary<int,float> UserCabinet = new Dictionary<int,float>();
Dictionary<int,string> UserPassword = new Dictionary<int,string>();

BankLogic Bank_User = new BankLogic();
Instrumental Instrumental = new Instrumental();
Random Random = new Random();

bool Secsess = false;

// Greetings
Write("Welcome in the ");
ForegroundColor = ConsoleColor.Green;
Write("PrivatBank \n");
ResetColor();

//Logic
while (true)
{
    WriteLine("Please, choose funktion:");
    WriteLine("| Create new account -- 1");
    WriteLine("| Sing in account -- 2");
    WriteLine("| Database -- 3");

    var Answer = ReadLine();

    if (Answer == "1")
    {
        WriteLine("Write your name:");
        var Name = ReadLine();
        var ID = Bank_User.SetId;
        Bank_User.Userame = Name;

        WriteLine("Write password:");
        Bank_User.SetPassword = ReadLine();
        UserPassword.Add(ID,Bank_User.SetPassword);

        ForegroundColor = ConsoleColor.Green;
        WriteLine("Complete!");
        ResetColor();

        Users.Add(ID, Name);
        UserCabinet.Add(ID, 0);

        WriteLine($"Your id: {ID}");
        WriteLine($"Your name: {Name}");
    }
    else if (Answer == "2")
    {
        WriteLine("Write your ID:");
        int _id = Convert.ToInt32(ReadLine());

        WriteLine("Write your password:");
        string password = ReadLine();
        var keys = Users.Keys;
        foreach (var i in keys)
        {
            if (i == _id)
            {
                // Find password
                var pass = UserPassword.Keys;
                foreach (var item in pass)
                {
                    if (UserPassword[item] == password)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("Complete!");
                        ResetColor();
                        Secsess = true;
                    }
                }
            }
        }
        if (!Secsess)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Somesing wrong!");
            ResetColor();
        }

        //Cabinet logic
        if (Secsess)
        { 
            while (Secsess)
            {
                //Drow menu
                {
                    Console.Clear();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("P r i v a t B a n k |");
                    WriteLine("___________________ |");
                    ResetColor();

                    Write("Your name: ");
                    ForegroundColor = ConsoleColor.Yellow;
                    Write($"{Users[_id]}\n");
                    ResetColor();

                    Write("Balance: ");
                    ForegroundColor = ConsoleColor.Red;
                    Write($"{UserCabinet[_id]} $\n");
                    ResetColor();

                    Write("ID: ");
                    ForegroundColor = ConsoleColor.Blue;
                    Write($"{_id}\n");
                    ResetColor();
                }
                //

                //Function Panel
                { 
                    WriteLine();
                    WriteLine();
                    WriteLine("___________________");
                    WriteLine("Choose funktion:");

                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine("Top up balance -- 1");
                    ResetColor();

                    ForegroundColor = ConsoleColor.DarkCyan;
                    WriteLine("Withdraw money -- 2");
                    ResetColor();

                    ForegroundColor = ConsoleColor.DarkCyan;
                    WriteLine("Notifications -- 3");
                    ResetColor();

                    ForegroundColor = ConsoleColor.DarkCyan;
                    WriteLine("Sent money-- 4");
                    ResetColor();

                    ForegroundColor = ConsoleColor.DarkRed;
                    WriteLine("Exit -- 0");
                    ResetColor();
                }

                var answer = Convert.ToInt32(ReadLine());

                if (answer == 1)
                {
                    float PlusBalance = float.Parse(ReadLine());
                    UserCabinet[_id] += PlusBalance;
                    continue;
                }
                else if (answer == 2)
                {
                    float MinusBalance = float.Parse(ReadLine());
                    if (MinusBalance > UserCabinet[_id])
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("Not Enough");
                        ResetColor();
                        Thread.Sleep(500);
                        continue;
                    }
                    else
                    {
                        UserCabinet[_id] -= MinusBalance;
                        continue;
                    }
                }
                else if (answer == 3)
                {
                    var money = Instrumental.CashPlus();
                    var credit = Instrumental.CashMinus();
                    var text = Instrumental.SetNotificatons(Users[_id], money, credit);

                    if (text == Instrumental.Notifications[1])
                        UserCabinet[_id] += money;
                    else if (text == Instrumental.Notifications[5])
                    {
                        if (UserCabinet[_id] < credit)
                        {
                            ForegroundColor = ConsoleColor.Red;
                            WriteLine("NOT ENOUGH");
                            ResetColor();
                            UserCabinet[_id] = 0;
                        }
                        else
                            UserCabinet[_id] -= credit;

                    }


                    WriteLine($"{text}");
                    Thread.Sleep(3000);
                    continue;
                }
                else if (answer == 4)
                {
                    WriteLine("How many do u want sent?");
                    int money = int.Parse(ReadLine());
                    WriteLine("User id?");
                    int id_user = int.Parse(ReadLine());
                    var bal = UserCabinet.Keys;

                    foreach (var user in bal)
                    {
                        if (id_user == user)
                        {
                            if (UserCabinet[_id] >= money)
                            {
                                WriteLine("Complete!");
                                UserCabinet[id_user] += money;
                                UserCabinet[_id] -= money;
                                continue;
                            }
                            else
                            {
                                ForegroundColor = ConsoleColor.Red;
                                WriteLine("NOT ENOUGH");
                                ResetColor();
                                continue;
                            }
                        }
                        else
                            continue;
                    }
                }
                else if (answer == 0)
                {
                    break;
                }
                
                ReadLine();
            }
        }
    }
    else if (Answer == "3")
    {
        foreach (var user in Users)
        {
            WriteLine(user);
        }

        while (true)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Exit -- 0");
            ResetColor();

            var answer = Convert.ToInt32(ReadLine());
            if (answer == 0)
            {
                break;
            }
            else
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine("Repeat");
                ResetColor();
                Thread.Sleep(300);
            }       
        }
    }
}
ReadLine();