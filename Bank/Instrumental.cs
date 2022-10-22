using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class Instrumental
    {
        Random random = new Random();
        public string[] Notifications = new string[6];
        public string SetNotificatons(string Name, int cash, int credit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Notifications[0] =  $"Your card will end {random.Next(1,28)}.{random.Next(1,12)}.20{random.Next(22,99)}";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Notifications[1] = $"Your cashback -- {cash}";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Notifications[2] = $"Dear {Name}, go to the bank";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Notifications[3] = $"On monday in the bank will be technical robots";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Green;
            Notifications[4] = $"Good day, {Name}!";
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Green;
            Notifications[5] = $"Credit! Minus {credit}";
            Console.ResetColor();

            return Notifications[random.Next(0, Notifications.Length)];
        }

        public int CashPlus()
        {
            int CashBack = random.Next(100, 400);
            return CashBack;
        }

        public int CashMinus()
        {
            int Credit = random.Next(50, 500);
            return Credit;
        }

    }
}
