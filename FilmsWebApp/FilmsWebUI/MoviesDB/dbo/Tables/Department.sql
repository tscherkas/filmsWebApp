CREATE TABLE [dbo].[Department] (
    [DepartmentId] TINYINT       IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NULL,
    CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);

