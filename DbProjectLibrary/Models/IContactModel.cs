namespace DbProjectLibrary.Models
{
    public interface IContactModel
    {
        int ContactId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}