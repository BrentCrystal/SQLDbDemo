using SQLDbDemoLibrary.Models;

namespace DbProjectLibrary.Models
{
    public class ContactModel : IBudget, IContactModel
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal BudgetAmount { get; set; }
    }
}
