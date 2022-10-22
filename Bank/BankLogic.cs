using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    internal class BankLogic
    {
        Random random = new Random();
        public string Userame;
        public string passwprd;
        
        private float _balance;
        private int _id;
        private string _password;

        public float CheckBalace
        {
            get { return _balance = 0; }
        }
        public float BalancePlus
        {
            get { return _balance; }

            set { _balance += value; }
        }
        public float BalanceMinus
        {
            get { return _balance; }

            set { _balance -= value; }
        }

        public int SetId
        {
            get { return _id = random.Next(1, 100); }
            set { _id = random.Next(1, 100); }
        }
        public string SetPassword
        {
            get { return passwprd = _password; }
            set { _password = value; }
        }

        public BankLogic(string userame = "", float balance = 0)
        {
            Userame = userame;
        }
    }
}
