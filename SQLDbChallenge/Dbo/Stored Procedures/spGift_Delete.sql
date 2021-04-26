CREATE PROCEDURE [dbo].[spGift_Delete]
	@giftId int,
	@contactId int
	
AS
begin
	set nocount on;

	delete
	from dbo.[Gift]
	Where GiftId = @giftId and ContactId = @contactId;

end