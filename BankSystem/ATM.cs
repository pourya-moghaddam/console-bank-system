using System;
using System.Security.Principal;

namespace BankSystem
{
    public class ATM
    {
        private Bank _bank;

        public ATM(Bank bank)
        {
            _bank = bank;
        }

        public void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            if ((accountNumber.Length != 16) || (!accountNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid account number. Try again.");
                return;
            }
            
            Console.Write("Enter account PIN: ");
            string accountPIN = Console.ReadLine();

            try
            {
                if (_bank.IsPINValid(accountNumber, accountPIN))
                {
                    Customer customer = _bank.GetCustomerByAccountNumber(accountNumber);

                    if (customer != null)
                    {
                        Account account = _bank.GetAccountByAccountNumber(accountNumber);

                        Console.Write("Enter deposit amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        account.Deposit(amount);
                        Console.WriteLine("Deposit successful. New balance: {0:c}\n",
                            account.Balance);
                    }
                    else
                    {
                        Console.WriteLine("Customer not found\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN.\n");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Account doesn't exist.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
        public void Withdraw()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            if ((accountNumber.Length != 16) || (!accountNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid account number. Try again.");
                return;
            }
            Console.Write("Enter account PIN: ");
            string accountPIN = Console.ReadLine();

            try
            {
                if (_bank.IsPINValid(accountNumber, accountPIN))
                {
                    Customer customer = _bank.GetCustomerByAccountNumber(accountNumber);

                    if (customer != null)
                    {
                        Account account = _bank.GetAccountByAccountNumber(accountNumber);

                        Console.Write("Enter withdrawal amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (account.Withdraw(amount))
                        {
                            Console.WriteLine("Deposit successful. New balance: {0:c}\n",
                                account.Balance);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Customer not found.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN.\n");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Account doesn't exist.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
        public void Transfer()
        {
            Console.Write("Enter source account number: ");
            string srcAccountNumber = Console.ReadLine();
            if ((srcAccountNumber.Length != 16)
                || (!srcAccountNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid account number. Try again.");
                return;
            }
            Console.Write("Enter destination account number: ");
            string dstAccountNumber = Console.ReadLine();
            if ((dstAccountNumber.Length != 16)
                || (!dstAccountNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid account number. Try again.");
                return;
            }

            Console.Write("Enter source account PIN: ");
            string srcAccountPIN = Console.ReadLine();

            try
            {
                if (_bank.IsPINValid(srcAccountNumber, srcAccountPIN))
                {
                    Customer srcCustomer = _bank.GetCustomerByAccountNumber(
                        srcAccountNumber);
                    Customer dstCustomer = _bank.GetCustomerByAccountNumber(
                        dstAccountNumber);

                    if ((srcCustomer != null) && (dstCustomer != null))
                    {
                        Account srcAccount = _bank.GetAccountByAccountNumber(
                            srcAccountNumber);
                        Account dstAccount = _bank.GetAccountByAccountNumber(
                            dstAccountNumber);

                        Console.Write("Enter transfer amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        if (srcAccount.Transfer(dstAccount, amount))
                        {
                            Console.WriteLine(
                                "Transfer successful. New balance in source account: {0:c}\n",
                                srcAccount.Balance);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Source or destination account not found.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN.\n");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Account doesn't exist.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
        public void CheckBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();
            if ((accountNumber.Length != 16) || (!accountNumber.All(char.IsDigit)))
            {
                Console.WriteLine("Invalid account number. Try again.");
                return;
            }
            Console.Write("Enter account PIN: ");
            string accountPIN = Console.ReadLine();

            try
            {
                if (_bank.IsPINValid(accountNumber, accountPIN))
                {
                    Customer customer = _bank.GetCustomerByAccountNumber(accountNumber);

                    if (customer != null)
                    {
                        Account account = _bank.GetAccountByAccountNumber(accountNumber);
                        Console.WriteLine("Current balance: {0:c}", account.Balance);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Account not found.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid PIN.\n");
                }
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Account doesn't exist.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Try again.\n");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
    }
}
