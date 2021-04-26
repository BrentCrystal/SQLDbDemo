CREATE TABLE [dbo].[Gift]
(
	[GiftId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [GiftName] VARCHAR(50) NOT NULL, 
    [GiftCost] MONEY NOT NULL, 
    [ContactId] INT NOT NULL
 )
