CREATE PROCEDURE [dbo].[spContact_Insert]
	@firstname varchar(50),
	@lastName varchar(50),
	@Id int output
AS
begin
	set nocount on;

	if not exists (select 1 from dbo.Contact where FirstName = @firstName and LastName = @lastName)
		begin
			insert into dbo.Contact (FirstName, LastName)
			values (@firstName, @lastName)

			set @Id = SCOPE_IDENTITY();
		end
		
	--select top 1 [ContactId], [FirstName], [LastName]
	--from dbo.Contact
	--where FirstName = @firstName and LastName = @lastName;
end


