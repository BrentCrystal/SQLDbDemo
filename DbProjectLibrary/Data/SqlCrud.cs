using Dapper;
using DbProjectLibrary.Db;
using DbProjectLibrary.Models;
using SQLDbDemoLibrary.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DbProjectLibrary.Data
{
    public class SqlCrud : ISqlCrud
    {
        private readonly ISqlDataAccess _dataAccess;
        private readonly IConnectionStringData _connectionString;

        public SqlCrud(ISqlDataAccess dataAccess, IConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public Task<List<ContactModel>> GetAllContacts()
        {
            return _dataAccess.LoadDataAsync<ContactModel, dynamic>("dbo.spContact_All",
                                                              new { },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<GiftModel>> GetAllGiftsEntered()
        {
            return _dataAccess.LoadDataAsync<GiftModel, dynamic>("dbo.spGift_All",
                                                              new { },
                                                              _connectionString.SqlConnectionName);
        }

        public Task<List<GiftRegisterModel>> GetAllBudgetActuals()
        {
            return _dataAccess.LoadDataAsync<GiftRegisterModel, dynamic>("dbo.spRegister_GetBudgetActual",
                                                                         new { },
                                                                         _connectionString.SqlConnectionName);
        }

        public async Task<int> CreateGiftEntry(GiftModel gift)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("GiftName", gift.GiftName);
            p.Add("GiftCost", gift.GiftCost);
            p.Add("ContactId", gift.ContactId);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveDataAsync("dbo.spGift_insert", p, _connectionString.SqlConnectionName);

            return p.Get<int>("Id");
        }

        public async Task InsertContact(ContactModel contact)
        {
            DynamicParameters p = new DynamicParameters();

            p.Add("FirstName", contact.FirstName);
            p.Add("LastName", contact.LastName);
            p.Add("Id", DbType.Int32, direction: ParameterDirection.Output);
            
            await _dataAccess.SaveDataAsync("dbo.spContact_Insert", p, _connectionString.SqlConnectionName);

            int contactId = p.Get<int>("Id");
            
            await _dataAccess.SaveDataAsync("spContactBudget_insertById", new { contact.BudgetAmount, contactId }, _connectionString.SqlConnectionName);
        }

        public async Task UpdateContactBudget(ContactModel contact)
        {
            await _dataAccess.SaveDataAsync("dbo.spContact_UpdateBudget", new {contact.BudgetAmount,contact.ContactId }, _connectionString.SqlConnectionName);
        }

        public async Task DeleteGiftFromContact(int giftId, int contactId)
        {
            await _dataAccess.SaveDataAsync("dbo.spGift_Delete", new { contactId, giftId }, _connectionString.SqlConnectionName);
        }
    }
}
