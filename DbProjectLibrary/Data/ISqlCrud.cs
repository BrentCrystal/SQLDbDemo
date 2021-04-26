using DbProjectLibrary.Models;
using SQLDbDemoLibrary.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbProjectLibrary.Data
{
    public interface ISqlCrud
    {
        Task<List<ContactModel>> GetAllContacts();
        Task<List<GiftModel>> GetAllGiftsEntered();
        Task<List<GiftRegisterModel>> GetAllBudgetActuals();
        Task<int> CreateGiftEntry(GiftModel gift);
        Task InsertContact(ContactModel contact);
        Task UpdateContactBudget(ContactModel contact);
        Task DeleteGiftFromContact(int contactId, int giftId);
    }
}