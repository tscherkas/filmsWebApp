CREATE TABLE [dbo].[Posters] (
    [MovieId]  UNIQUEIDENTIFIER NOT NULL,
    [PosterId] BIGINT           NOT NULL,
    CONSTRAINT [PK_Posters] PRIMARY KEY CLUSTERED ([MovieId] ASC, [PosterId] ASC),
    CONSTRAINT [FK_Posters_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([MovieId])
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'PosterURL = http://tr-by.kinopoisk.ru/images/poster/{PosterId}.jpg', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Posters', @level2type = N'COLUMN', @level2name = N'PosterId';

