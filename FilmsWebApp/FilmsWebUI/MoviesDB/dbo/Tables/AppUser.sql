CREATE TABLE [dbo].[AppUser]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [username] NCHAR(25) NOT NULL, 
    [password] NCHAR(50) NOT NULL
)
