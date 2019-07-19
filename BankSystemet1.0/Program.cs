using System;
using System.Collections.Generic;

namespace BankSystemet1._0
{

    class Transaction
    {
        string m_fromName;
        string m_toName;
        int m_amount;

        DateTime m_date = DateTime.Now;



        public static List<Transaction> transactionList = new List<Transaction>();


        public Transaction(Account accFrom, Account accTo, int amount)
        {
            this.m_fromName = accFrom.GetName();
            this.m_toName = accTo.GetName();
            this.m_amount = amount;
            this.m_date.ToString("d");

            transactionList.Add(this);


        }
        public static void GetTransactions()
        {
            if (transactionList.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("Nothing to report");
                Console.ReadKey();
                Console.Clear();
                MainSystem.Menu();
            }
            else
            {
                Console.Clear();

                for(int i = 0; i < transactionList.Count; i++)
                {
                    Console.WriteLine($"{i}\t{transactionList[i].m_fromName} -> {transactionList[i].m_toName}\t\t{transactionList[i].m_amount} Currency\n{transactionList[i].m_date}\n\n-------------------------------------------------");
                }
            }
               
        }

    }
    class Account
    {
        string m_name;
        int m_amount;
        int m_lopnummer;
        

       public static List<Account> accountList = new List<Account>();

        public Account(string name, int amount, int lopnummer)
        {
            this.m_name = name;
            this.m_lopnummer = lopnummer;
            this.m_amount = amount;

            accountList.Add(this);

        }
        public static void Transfer(Account accFrom, Account accTo, int amount)
        {

            
            if (accFrom.m_amount > amount)
            {
                accFrom.m_amount = accFrom.m_amount - amount;
                accTo.m_amount = accTo.m_amount + amount;
                Transaction one = new Transaction(accFrom, accTo, amount);
                Console.WriteLine($"Transfer Successful, from account {accFrom.m_name} to {accTo.m_name} amount {amount}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Cannot Transfer more money than you have");
                Console.ReadKey();
                Console.Clear();
                MainSystem.Menu();

            }
        }
        public static void GetAccounts()
        {
            Console.Clear();
            Console.WriteLine("Accounts on record: \n");
            for (int i = 0; i < accountList.Count; i++)
            {
                
                Console.WriteLine($"{i}\t\t{accountList[i].m_name}\t\t{accountList[i].m_amount} Currency");
            }
            Console.ReadKey();
            Console.Clear();

            MainSystem.Menu();
        }
        public string GetName()
        {
            return this.m_name;
        }
        public int GetLopNumber()
        {
            return this.m_lopnummer;
        }

    }
    class  MainSystem
    {
        
        public static int AssertNumber(string input)
        {
            if(int.TryParse(input,out int answer))
            {
                return answer;
            }
            return 0000;
        }

        public static void Menu()
        {
            Console.WriteLine($"Welcome to Bankmanager 1.0\n\nSpecify choice according to number:\n\n1:\tList Accounts\n2:\tMake Withdrawal\n3:\tList Transactions\n4:\tExit\n\n9:\tClear Screen");

            int input = AssertNumber(Console.ReadLine());

            switch (input)
            {
                case 1:
                    Account.GetAccounts();
                    break;
                case 2:
                    makeTransfer();
                    break;
                case 3:
                    Transaction.GetTransactions();
                    break;
                case 4:
                    Environment.Exit(-1);
                    break;
                case 9:
                    Console.Clear();
                    break;
                case 0000:
                    Console.Clear();
                    Console.WriteLine("Specify a number please");
                    break;

            }

        }
        public static void makeTransfer()
        {
            Console.Clear();
           
            Console.WriteLine("Specify FromAccount number:");
            int inputFrom = MainSystem.AssertNumber(Console.ReadLine());
            if (inputFrom > Account.accountList.Count)
            {
                Console.Clear();
                Console.WriteLine($"Your number {inputFrom} is bigger than the number of active accounts.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            Console.Clear();
            Console.WriteLine("Specify ToAccount number:");
            int inputTo = MainSystem.AssertNumber(Console.ReadLine());
            if (inputTo > Account.accountList.Count)
            {
                Console.Clear();
                Console.WriteLine($"Your number {inputFrom} is bigger than the number of active accounts.");
                Console.ReadKey();
                Console.Clear();
                return;
            }
            
            Console.Clear();
            Console.WriteLine("Specify Amount of currency:");
            int inputAmount = MainSystem.AssertNumber(Console.ReadLine());

            Console.Clear();

            Account.Transfer(Account.accountList[inputFrom], Account.accountList[inputTo], inputAmount);
            Console.ReadKey();

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Account Johnny = new Account("Johnny", 10000, 0);
            Account Mary = new Account("Mary", 10000, 1);
            Account Patek = new Account("Patek", 10000, 2);
            Account Johanna = new Account("Johanna", 10000, 3);
            Account Per = new Account("Per", 10000, 4);

            while (true)
            {
                MainSystem.Menu();

            }
        }
    }
}
