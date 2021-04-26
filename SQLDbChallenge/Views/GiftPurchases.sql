CREATE VIEW [dbo].[GiftPurchases]
	AS 
	select GB.[ContactId], GB.FirstName, GB.LastName, G.GiftName, G.GiftCost
	from dbo.GiftBudget GB
	Left Outer Join dbo.Gift G on GB.[ContactId] = G.ContactId;
	
