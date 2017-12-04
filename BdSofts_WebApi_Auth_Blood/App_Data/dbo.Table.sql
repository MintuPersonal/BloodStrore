CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NCHAR(50) NULL, 
    [Pass] NCHAR(200) NULL, 
    [Url] NCHAR(500) NULL, 
    [DateAdded] DATETIME NULL, 
    [AddedBy] NCHAR(10) NULL, 
    [DateUpdated] DATETIME NULL, 
    [UpdatedBy] NCHAR(10) NULL
)
