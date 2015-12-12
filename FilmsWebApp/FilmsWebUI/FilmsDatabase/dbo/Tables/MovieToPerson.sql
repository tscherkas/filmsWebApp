CREATE TABLE [dbo].[MovieToPerson] (
    [MovieId]      UNIQUEIDENTIFIER NOT NULL,
    [PersonId]     UNIQUEIDENTIFIER NOT NULL,
    [DepartmentId] TINYINT          NOT NULL,
    [Role]         NVARCHAR (512)   NULL,
    CONSTRAINT [PK_MovieToPerson] PRIMARY KEY CLUSTERED ([MovieId] ASC, [PersonId] ASC, [DepartmentId] ASC),
    CONSTRAINT [FK_MovieToPerson_Department] FOREIGN KEY ([DepartmentId]) REFERENCES [dbo].[Department] ([DepartmentId]),
    CONSTRAINT [FK_MovieToPerson_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId]),
    CONSTRAINT [FK_MovieToPerson_Person] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[Person] ([PersonId])
);

