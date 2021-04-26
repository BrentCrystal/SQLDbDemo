CREATE PROCEDURE [dbo].[spRegister_GetBudgetActual]
	
AS
Begin
	set nocount on;

	select GB.FirstName, GB.LastName, GB.BudgetAmount,
		COALESCE(sum(GP.GiftCost),0) as TotalCost, (GB.BudgetAmount - COALESCE(sum(GP.GiftCost),0)) as BudgetBalance
	From GiftBudget GB, GiftPurchases GP
	Where GB.ContactId = GP.ContactId
	Group By GB.FirstName, GB.LastName, GB.BudgetAmount

end