using System;
using DbProjectLibrary.Data;
using DbProjectLibrary.Db;
using DbProjectLibrary.Models;
using SQLDbDemoLibrary.Models;

/*Design a database project in Visual Studio that holds information about people on your Christmas list. 
Store people and items you bought for them, and how much each item cost.
Include a budget amount for each person. 
Create a view that identifies who you have left to shop for and how much you have left to spend. Also, 
create stored procedures to capture purchases.*/

namespace DbProjectConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = Factory.GetConnectionString();

            ISqlDataAccess dataAccess = Factory.CreateSqlDataAccess(config);
            IConnectionStringData connectionStringName = Factory.CreateConnectionStringName();
            ISqlCrud sqlCrud = Factory.CreateSqlCrud(dataAccess, connectionStringName);

            try
            {
                //ReadAllContacts(sqlCrud);
                //ReadAllGiftsEntered(sqlCrud);
                //ReadAllBudgetActuals(sqlCrud);
                CreateNewGiftEntry(sqlCrud);
                //InsertNewContact(sqlCrud);
                //UpdateBudgetAmount(sqlCrud);
                //RemoveGiftFromContact(sqlCrud);
            }
            catch (Exception ex)
            {
                Console.WriteLine("We had an error");
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }

        private static void CreateNewGiftEntry(ISqlCrud sqlCrud)
        {
            GiftModel gift = new GiftModel
            {
                GiftName = "Barbie Doll",
                GiftCost = 15,
                ContactId = 4
            };

            sqlCrud.CreateGiftEntry(gift);

            Console.WriteLine($"Gift data entry conmplete.");
        }
        private static void ReadAllContacts(ISqlCrud sqlCrud)
        {
            var rows = sqlCrud.GetAllContacts().Result;

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.ContactId}: {row.FirstName} {row.LastName}"
                                  + Environment.NewLine
                                  + $"Budget:{string.Format("{0:C}", row.BudgetAmount)}");
                Console.WriteLine();
            }
        }
        private static void ReadAllGiftsEntered(ISqlCrud sqlCrud)
        {
            var rows = sqlCrud.GetAllGiftsEntered().Result;

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.FirstName} {row.LastName}"
                                  + Environment.NewLine
                                  + $"Gift: {row.GiftName}"
                                  + Environment.NewLine
                                  + $"Cost: {string.Format("{0:C}", row.GiftCost)}");
                Console.WriteLine();
            }
        }
        private static void ReadAllBudgetActuals(ISqlCrud sqlCrud)
        {
            var rows = sqlCrud.GetAllBudgetActuals().Result;

            foreach (var row in rows)
            {
                Console.WriteLine($"{row.FirstName} {row.LastName}"
                                  + Environment.NewLine
                                  + $"Budget:{string.Format("{0:C}", row.BudgetAmount)}"
                                  + Environment.NewLine
                                  + $"TotalCost: {string.Format("{0:C}", row.TotalCost)}"
                                  + Environment.NewLine
                                  + $"Balance: {string.Format("{0:C}", row.BudgetBalance)}");

                Console.WriteLine();
            }
        }

        private static void InsertNewContact(ISqlCrud sqlCrud)
        {
            ContactModel contact = new ContactModel
            {
                FirstName = "Brent",
                LastName = "Crystal",
                BudgetAmount = 20
            };

            sqlCrud.InsertContact(contact);
            Console.WriteLine($"{contact.FirstName} {contact.LastName} added to contact list.");
        }

        private static void UpdateBudgetAmount(ISqlCrud sqlCrud)
        {
            ContactModel contact = new ContactModel
            {
                ContactId = 11,
                FirstName = "Brent",
                LastName = "Crystal",
                BudgetAmount = 50
            };

            sqlCrud.UpdateContactBudget(contact);
            Console.WriteLine($"Budget for {contact.FirstName} {contact.LastName} is updated.");
        }

        private static void RemoveGiftFromContact(ISqlCrud sqlCrud)
        {
            int giftId = 1002;
            int contactId = 4;

            sqlCrud.DeleteGiftFromContact(giftId, contactId);
            Console.WriteLine($"Gift Id {giftId} is removed from contact Id {contactId}.");
        }
    }
}
