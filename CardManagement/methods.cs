﻿using CardManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CardManagment.Model.Data;


namespace CardManagement
{
    public class methods
    {
        public void displayCustomer(string id, string choice)
        {
            using (CardManagmentContext context = new CardManagmentContext())
            {
                Customer customer = context.Customers.Include(x => x.Accounts).FirstOrDefault(c => c.id == id);
                if (choice == "n" && customer != null)
                {
                    Console.WriteLine($"Customer ID: {customer.id}\nCustomer Name: {customer.CustomerName}\nCustomer Email: {customer.Email}");
                }

                else if (choice == "y" && customer != null)
                {
                    Console.WriteLine($"Customer ID: {customer.id}\nCustomer Name: {customer.CustomerName}\nCustomer Email: {customer.Email}");
                    Console.WriteLine();
                    Console.WriteLine($"account id : {customer.Accounts.id}\naccount number : {customer.Accounts.AccountNumber}\naccount type : {customer.Accounts.AccountType} \nbalance : {customer.Accounts.Balance}");

                }
                else
                {
                    Console.WriteLine("Customer not found.");
                }


            }
        }



        public void AmountChange(Account acc, List<Transaction> transaction)
        {
            using (CardManagmentContext context = new CardManagmentContext())
            {
                foreach (var t in transaction)
                {
                    if (t.transactionType == Transaction.TransactionType.Deposit)
                    {
                        acc.Balance = acc.Balance + t.Amount;

                    }
                    else
                    {
                        acc.Balance = acc.Balance - t.Amount;

                    }

                }
                context.Accounts.Update(acc);
                context.SaveChanges();
            }

        }
    }
}

