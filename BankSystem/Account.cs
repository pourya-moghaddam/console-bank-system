using System;
using System.Text;

namespace BankSystem
{
    public class Account
    {
        private Random random = new Random();
        private string _accountNumber;
        private string _pin;
        private double _balance;

        public Account(string pin, double initialDeposit)
        {
            AccountNumber = GetRandomAccountNum();
            PIN = pin;
            Balance = initialDeposit;
        }

        public string AccountNumber
        {
            get { return _accountNumber; }
            set
            {
                if (!Bank.IsAccountNumDuplicate(value))
                {
                    _accountNumber = value;
                    Bank.AddAccountNum(value);
                }
            }
        }
        public double Balance
        {
            get { return _balance; }
            set
            {
                if (value >= 0)
                {
                    _balance = value;
                }
            }
        }
        public string PIN
        {
            get { return _pin; }
            set
            {
                if (value.All(char.IsDigit) && (value.Length == 4))
                {
                    _pin = value;
                }
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
        public bool Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public bool Transfer(Account destinationAccount, double amount)
        {
            if (amount <= Balance)
            {
                Withdraw(amount);
                destinationAccount.Deposit(amount);
                return true;
            }
            return false;
        }
        private string GetRandomAccountNum()
        {
            StringBuilder num = new StringBuilder();
            for (int i = 0; i < 16; i++)
            {
                num.Append(random.Next(10).ToString());
            }
            return num.ToString();
        }
    }
}
