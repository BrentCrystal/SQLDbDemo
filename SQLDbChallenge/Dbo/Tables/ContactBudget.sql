CREATE TABLE [dbo].[ContactBudget]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [BudgetAmount] MONEY NOT NULL,
    [ContactId] INT NOT NULL,
)
