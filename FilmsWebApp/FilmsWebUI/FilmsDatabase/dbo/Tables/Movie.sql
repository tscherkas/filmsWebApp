CREATE TABLE [dbo].[Movie] (
    [MovieId]       UNIQUEIDENTIFIER CONSTRAINT [DF_Movie_MovieId] DEFAULT (newid()) NOT NULL,
    [OriginalTitle] NVARCHAR (MAX)   NULL,
    [RussianTitle]  NVARCHAR (MAX)   NULL,
    [KinopoiskId]   BIGINT           NULL,
    [Description]   NVARCHAR (MAX)   NULL,
    [ReleaseDate]   DATE             NULL,
    [AgeLimit]      TINYINT          NULL,
    [MPAA]          VARCHAR (5)      NULL,
    [Runtime]       INT              NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY CLUSTERED ([MovieId] ASC),
    CONSTRAINT [UX_Movie_KinopoiskId_1] UNIQUE NONCLUSTERED ([KinopoiskId] ASC)
);

