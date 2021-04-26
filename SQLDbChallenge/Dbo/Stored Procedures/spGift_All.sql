CREATE PROCEDURE [dbo].[spGift_All]
AS
Begin
	set nocount on;

	select [ContactId], [FirstName], [LastName], [GiftName], [GiftCost]
	from dbo.GiftPurchases
	
End
