using DbProjectLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQLDbDemoLibrary.Models
{
    public class GiftRegisterModel : IContactModel, IBudget
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal TotalCost { get; set; }
        public decimal BudgetBalance { get; set; }
    }
}
