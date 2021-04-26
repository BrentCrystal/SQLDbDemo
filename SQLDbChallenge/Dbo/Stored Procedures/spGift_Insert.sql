CREATE PROCEDURE [dbo].[spGift_Insert]
	@GiftName varchar(50),
	@GiftCost money,
	@ContactId int,
	@Id int output
	
AS
begin
	set nocount on;

	insert into dbo.[Gift](GiftName, GiftCost, ContactId)
	values (@GiftName, @GiftCost, @ContactId);
	
	set @Id = SCOPE_IDENTITY();

end