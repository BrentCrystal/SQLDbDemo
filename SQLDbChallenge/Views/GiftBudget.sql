CREATE VIEW [dbo].[GiftBudget]
	AS 
	Select c.[ContactId], c.FirstName, c.LastName, cb.BudgetAmount
	From dbo.Contact c
	Left Join dbo.ContactBudget cb on c.[ContactId] = cb.ContactId;
