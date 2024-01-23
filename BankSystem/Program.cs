using System;
using System.Text;

namespace BankSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            ATM atm = new ATM(bank);

            try
            {
                do
                {
                    Console.WriteLine("====== Bank System ======");
                    Console.WriteLine("[1] ATM services");
                    Console.WriteLine("[2] Bank services");
                    Console.WriteLine("[0] Exit");

                    Console.Write("Enter your choice: ");
                    int mainChoice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (mainChoice)
                    {
                        case 1:
                            DoATMServices(atm);
                            break;
                        case 2:
                            DoBankServices(bank);
                            break;
                        case 0:
                            Console.WriteLine("Exiting the program... Goodbye!");
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong. Exiting the program...");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }

        }
        static void DoATMServices(ATM atm)
        {
            try
            {
                do
                {
                    Console.WriteLine("====== ATM Services ======");
                    Console.WriteLine("[1] Deposit");
                    Console.WriteLine("[2] Withdraw");
                    Console.WriteLine("[3] Transfer");
                    Console.WriteLine("[4] Check Balance");
                    Console.WriteLine("[0] Back to Main Menu");

                    Console.Write("Enter your choice: ");
                    int atmChoice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (atmChoice)
                    {
                        case 1:
                            atm.Deposit();
                            break;
                        case 2:
                            atm.Withdraw();
                            break;
                        case 3:
                            atm.Transfer();
                            break;
                        case 4:
                            atm.CheckBalance();
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Try again.");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
        static void DoBankServices(Bank bank)
        {
            Console.Write("Enter your name: ");
            string customerName = Console.ReadLine();
            if ((customerName.Length == 0) || (customerName.Any(char.IsDigit)))
            {
                Console.WriteLine("Invalid name. Try again.");
                return;
            }
            Console.Clear();

            Customer customer;
            if (!bank.DoesCustomerExist(customerName))
            {
                customer = new Customer(customerName);
                bank.AddCustomer(customer);
                Console.WriteLine("Welcome, {0}!\n", customerName);
            }
            else
            {
                customer = bank.GetCustomerByName(customerName);
                Console.WriteLine("Welcome back, {0}!\n", customerName);
            }

            try
            {
                do
                {
                    Console.WriteLine("====== Bank Services ======");
                    Console.WriteLine("[1] Open Account");
                    Console.WriteLine("[2] Close Account");
                    Console.WriteLine("[3] View All Accounts");
                    Console.WriteLine("[0] Back to Main Menu");

                    Console.Write("Enter your choice: ");
                    int bankChoice = Convert.ToInt32(Console.ReadLine());

                    Console.Clear();

                    switch (bankChoice)
                    {
                        case 1:
                            bank.OpenAccount(customer);
                            break;
                        case 2:
                            bank.CloseAccount(customer);
                            break;
                        case 3:
                            customer.DisplayAllAccounts();
                            break;
                        case 0:
                            return; // Return to the main menu
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }

                } while (true);
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Something went wrong. Try again.");
                Console.WriteLine("{0}: {1}", ex.GetType().Name, ex.Message);
            }
        }
    }
}
