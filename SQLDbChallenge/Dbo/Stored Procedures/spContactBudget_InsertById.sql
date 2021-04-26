CREATE PROCEDURE [dbo].[spContactBudget_InsertById]
	@budgetAmount money,
	@contactId int
	--@Id int output
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.ContactBudget where ContactId = @contactId)
		begin
			insert into dbo.ContactBudget(BudgetAmount, ContactId)
			values (@budgetAmount, @contactId)
		end
			--set @Id = SCOPE_IDENTITY();
end