CREATE PROCEDURE [dbo].[spContact_All]
	
AS
Begin
	set nocount on;

	Select [ContactId], [FirstName], [LastName], [BudgetAmount]
	From dbo.[GiftBudget]

End
