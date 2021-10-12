using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question1
{
    class Program
    {
        public static List<Person> listOfPersons = new List<Person>();
        static void Main(string[] args)
        {
            bool b = true;
            while (b)
            {
                Console.WriteLine("1) Open Account 2) Deposit Money 3) Withdraw Money 4) Loan Application");
                int res = Int32.Parse(Console.ReadLine());
                if (res == 1)
                {
                    Console.WriteLine("-------------Open an account-------------");
                    Console.WriteLine("enter ID");
                    int tempId = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("enter NAME");
                    string tempName = Console.ReadLine();

                    Console.WriteLine("enter AGE");
                    int tempAge = Int32.Parse(Console.ReadLine());

                    Console.WriteLine("Do you currectly have an account with our bank? Y/N");
                    string tempResp = Console.ReadLine();
                    bool tempOpenA = false;
                    if (tempResp == "Y")
                    {
                        tempOpenA = true;
                    }
                    if (tempResp == "N")
                    {
                        tempOpenA = false;
                    }

                    OpenAccount(tempId, tempName, tempAge, tempOpenA);
                }
                if (res == 2)
                {
                    Console.WriteLine("-------------Deposit Money-------------");
                    Console.WriteLine("enter ID");
                    int tempId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("How do you want to deposit? 1) Cash 2) Cheque");
                    int tempRes = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("enter amount to deposit");
                    double tempAmount = Convert.ToDouble(Console.ReadLine());
                    if (tempRes == 1)
                    {
                        Deposit(tempId, tempAmount);
                    }
                    if (tempRes == 2)
                    {
                        Deposit2(tempId, tempAmount);
                    }

                }
                if (res == 3)
                {
                    Console.WriteLine("-------------Withdraw Money-------------");
                    Console.WriteLine("enter ID");
                    int tempId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("How do you want to withdraw? 1) Cash 2) Cheque");
                    int tempRes = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("enter amount to withdraw");
                    double tempAmount = Convert.ToDouble(Console.ReadLine());
                    if (tempRes == 1)
                    {
                        Withdraw(tempId, tempAmount);
                    }
                    if (tempRes == 2)
                    {
                        //withdraw cheque
                        Withdraw2(tempId, tempAmount);
                    }

                }
                if (res == 4)
                {
                    Console.WriteLine("-------------Loan Application-------------");
                    Console.WriteLine("enter ID");
                    int tempId = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("enter AMOUNT to loan");
                    double tempAmount = Convert.ToDouble(Console.ReadLine());

                    LoanApplication(tempId, tempAmount);
                }

                Console.ReadLine();
                
            }
            
        }

        public static bool OpenAccount(int id, string name, int age, bool openAccnt)
        {
            Random rand = new Random();
            Person person = new Person
            {
                Id = id,
                Name = name,
                Age = age,
                HasAccount = openAccnt,
                MoneyInBank = 0,
                ChequeBookNum = rand.Next(1000, 9999)
            };

            foreach (Person item in listOfPersons)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("Curently have an open account. You cannot open another.");
                    return false;
                }
            }
            if (person.HasAccount)
            {
                Console.WriteLine("Curently have an open account. You cannot open another.");
                return false;
            }
            if (person.Age < 12)
            {
                Console.WriteLine("Younger than 12. You cannot open an account.");
                return false;
            }
            if (person.Age < 12)
            {
                Console.WriteLine("Younger than 12. You cannot open an account.");
                return false;
            }

            listOfPersons.Add(person);

            //file handling
            StreamWriter sw = new StreamWriter(); //input in file name
            sw.WriteLine(person);
            sw.Flush();
            sw.Close();

            //Console.WriteLine("Total number of open Accounts:" + listOfPersons.Count());

            Console.WriteLine("SUCCESSFUL!");
            Console.WriteLine("Please note your bank details below...");
            Console.WriteLine("ID = " + person.Id);
            Console.WriteLine("NAME = " + person.Name);
            Console.WriteLine("AGE = " + person.Age);
            Console.WriteLine("BANK BALANCE = " + person.MoneyInBank);
            Console.WriteLine("CHEQUE BOOK NUMBER = " + person.ChequeBookNum);

            return true;

        }

        public static bool Deposit(int id, double amount)
        {
            if(amount >= 5000)
            {
                Console.WriteLine("deposit only accepted in CHEQUE");
                Deposit2(id, amount);
            }
            foreach (Person item in listOfPersons)
            {
                if (item.Id == id)
                {
                    Console.WriteLine("you are a registered customer");
                    item.MoneyInBank += amount;

                    Console.WriteLine("SUCCESSFUL!");
                    Console.WriteLine("Please note your bank details below...");
                    Console.WriteLine("ID = " + item.Id);
                    Console.WriteLine("NAME = " + item.Name);
                    Console.WriteLine("AGE = " + item.Age);
                    Console.WriteLine("BANK BALANCE = " + item.MoneyInBank);
                    Console.WriteLine("CHEQUE BOOK NUMBER = " + item.ChequeBookNum);

                    return true;
                }
                
            }
            Console.WriteLine("no such customer exist. please open an account first");
            return false;
        }

        public static bool Deposit2(int id, double amount)  //cheque deposit
        {
            Console.WriteLine("input Cheque number: ");
            int tempChequeNum = Int32.Parse(Console.ReadLine());

            foreach (Person item in listOfPersons)
            {
                if (item.Id == id && item.ChequeBookNum == tempChequeNum)
                {
                    Console.WriteLine("you are a registered customer");
                    Console.WriteLine("correct cheque number");

                    item.MoneyInBank += amount;

                    Console.WriteLine("SUCCESSFUL!");
                    Console.WriteLine("Please note your bank details below...");
                    Console.WriteLine("ID = " + item.Id);
                    Console.WriteLine("NAME = " + item.Name);
                    Console.WriteLine("AGE = " + item.Age);
                    Console.WriteLine("BANK BALANCE = " + item.MoneyInBank);
                    Console.WriteLine("CHEQUE BOOK NUMBER = " + item.ChequeBookNum);

                    return true;
                }

            }
            Console.WriteLine("ERROR. please check ID and Cheque number");
            return false;
        }
           

        public static bool Withdraw(int id, double amount)
        {
            if (amount >= 5000)
            {
                Console.WriteLine("withdraw only accepted in CHEQUE");
                Withdraw2(id, amount);
            }
            foreach (Person item in listOfPersons)
            {
                if (item.Id == id && item.MoneyInBank>=amount)
                {
                    Console.WriteLine("you are a registered customer");
                    Console.WriteLine("you have sufficient balance");

                    item.MoneyInBank -= amount;

                    Console.WriteLine("SUCCESSFUL!");
                    Console.WriteLine("Please note your bank details below...");
                    Console.WriteLine("ID = " + item.Id);
                    Console.WriteLine("NAME = " + item.Name);
                    Console.WriteLine("AGE = " + item.Age);
                    Console.WriteLine("BANK BALANCE = " + item.MoneyInBank);
                    Console.WriteLine("CHEQUE BOOK NUMBER = " + item.ChequeBookNum);

                    return true;
                }

            }
            Console.WriteLine("ERROR! please check ID and account balance");
            return false;
        }

        public static bool Withdraw2(int id, double amount)
        {
            Console.WriteLine("input Cheque number: ");
            int tempChequeNum = Int32.Parse(Console.ReadLine());

            foreach (Person item in listOfPersons)
            {
                if (item.Id == id && item.ChequeBookNum == tempChequeNum && item.MoneyInBank >= amount)
                {
                    Console.WriteLine("you are a registered customer");
                    Console.WriteLine("correct cheque number");

                    item.MoneyInBank -= amount;

                    Console.WriteLine("SUCCESSFUL!");
                    Console.WriteLine("Please note your bank details below...");
                    Console.WriteLine("ID = " + item.Id);
                    Console.WriteLine("NAME = " + item.Name);
                    Console.WriteLine("AGE = " + item.Age);
                    Console.WriteLine("BANK BALANCE = " + item.MoneyInBank);
                    Console.WriteLine("CHEQUE BOOK NUMBER = " + item.ChequeBookNum);

                    return true;
                }

            }
            Console.WriteLine("ERROR. please check ID and Cheque number");
            return false;
        }

        public static void DisplayIndividualCustomerDetails()
        {
            //future updates to do
        }

        public static void LoanApplication(int id, double ampunt)
        {
            foreach (Person item in listOfPersons)
            {
                if (item.Id == id && item.MoneyInBank >= 1000 && item.MoneyInBank >= ampunt)
                {
                    Console.WriteLine("interest rates are based on loan period");
                    Console.WriteLine("input in months duration of loan");
                    int tempMonths = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("interest rate is: 10%");

                    Console.WriteLine("Application will be processed");
                    DateTime dt = DateTime.Now.AddDays(3);
                    Console.WriteLine("Outcome will be emailed by: " + dt);
                }
            }
        }

    }

}
