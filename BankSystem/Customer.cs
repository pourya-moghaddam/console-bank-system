using System;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class Customer
    {
        public Customer(string name)
        {
            if (!name.Any(char.IsDigit))
            {
                Name = name;
            }
            Accounts = new List<Account>();
        }

        public bool HasAccount(string accountNumber)
        {
            return Accounts.Any(acc => acc.AccountNumber == accountNumber);
        }
        public void AddAccount(Account account)
        {
            Accounts.Add(account);
        }
        public void RemoveAccount(string accountNumber)
        {
            Account accountToRemove = Accounts.Find(
                acc => acc.AccountNumber == accountNumber);
            Accounts.Remove(accountToRemove);
            Console.WriteLine("Account closed successfully.\n");
        }
        public void DisplayAllAccounts()
        {
            if (Accounts.Count > 0)
            {
                Console.WriteLine("- Accounts owned by {0} -", Name);

                for (int i = 0; i < Accounts.Count; i++)
                {
                    Console.WriteLine("{0}. Account Number: {1}\tBalance: {2:c}",
                        i + 1,
                        Regex.Replace(Accounts[i].AccountNumber, ".{4}", "$0 "),
                        Accounts[i].Balance);
                }
            }
            else
            {
                Console.WriteLine("{0} has no accounts.", Name);
            }
            Console.WriteLine();
        }

        public string Name { get; }
        public List<Account> Accounts { get; }
    }
}
