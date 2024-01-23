using System;
using System.Text.RegularExpressions;

namespace BankSystem
{
    public class Bank
    {
        private List<Customer> _customers;
        private static List<string> _allAccountNums = new List<string>();

        public Bank()
        {
            _customers = new List<Customer>();
        }
        
        public void OpenAccount(Customer customer)
        {
            Console.Write("Enter initial deposit amount: ");
            Double initialDeposit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter a 4 digit PIN for your account: ");
            string pin = Console.ReadLine();

            if ((pin.All(char.IsDigit)) && (pin.Length == 4))
            {
                if (initialDeposit > 0)
                {
                    Account account = new Account(pin, initialDeposit);
                    customer.AddAccount(account);

                    Console.WriteLine("Account created successfully. Account number: {0}\n",
                        Regex.Replace(account.AccountNumber, ".{4}", "$0 "));
                }
                else
                {
                    Console.WriteLine("Initial deposit has to be a positive value.\n");
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN. Try again.\n");
                return;
            }
        }
        public void CloseAccount(Customer customer)
        {
            Console.Write("Enter account number to close: ");
            string accountNumber = Console.ReadLine();

            customer.RemoveAccount(accountNumber);
        }
        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
        public Customer GetCustomerByAccountNumber(string accountNumber)
        {
            return _customers.Find(c => c.HasAccount(accountNumber));
        }
        public Customer GetCustomerByName(string name)
        {
            return _customers.Find(c => c.Name == name);
        }
        public Account GetAccountByAccountNumber(string accountNumber)
        {
            Customer customer = GetCustomerByAccountNumber(accountNumber);
            return customer.Accounts.Find(
                account => account.AccountNumber == accountNumber);
        }
        public bool IsPINValid(string accountNumber, string pin)
        {
            Account account = GetAccountByAccountNumber(accountNumber);
            return account.PIN == pin;
        }
        public bool DoesCustomerExist(string name)
        {
            return _customers.Any(c => c.Name == name);
        }
        public static void AddAccountNum(string accountNum)
        {
            _allAccountNums.Add(accountNum);
        }
        public static bool IsAccountNumDuplicate(string accountNum)
        {
            return _allAccountNums.Contains(accountNum);
        }
    }
}
