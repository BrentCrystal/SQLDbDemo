CREATE PROCEDURE [dbo].[spContact_UpdateBudget]
	@BudgetAmount money,
	@ContactId int
AS
Begin
	set nocount on;

	update dbo.ContactBudget
	set BudgetAmount = @BudgetAmount
	where ContactId = @ContactId;

end

