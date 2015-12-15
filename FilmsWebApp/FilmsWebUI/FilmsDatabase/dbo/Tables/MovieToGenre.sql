CREATE TABLE [dbo].[MovieToGenre] (
    [MovieId] UNIQUEIDENTIFIER NOT NULL,
    [GenreId] INT              NOT NULL,
    CONSTRAINT [PK_MovieToGenre] PRIMARY KEY CLUSTERED ([MovieId] ASC, [GenreId] ASC),
    CONSTRAINT [FK_MovieToGenre_Genre] FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genre] ([GenreId]),
    CONSTRAINT [FK_MovieToGenre_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId])
);

