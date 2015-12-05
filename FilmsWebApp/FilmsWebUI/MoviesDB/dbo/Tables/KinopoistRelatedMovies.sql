CREATE TABLE [dbo].[KinopoistRelatedMovies] (
    [KinopoiskId]        BIGINT NOT NULL,
    [RelatedKinopoiskId] BIGINT NOT NULL,
    CONSTRAINT [PK_KinopoistRelatedMovies] PRIMARY KEY CLUSTERED ([KinopoiskId] ASC, [RelatedKinopoiskId] ASC)
);

