using DbProjectLibrary.Models;

namespace SQLDbDemoLibrary.Models
{
    public class GiftModel : IContactModel
    {
        public string GiftName { get; set; }
        public decimal GiftCost { get; set; }
        public int ContactId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
