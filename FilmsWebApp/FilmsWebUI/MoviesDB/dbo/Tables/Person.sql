CREATE TABLE [dbo].[Person] (
    [PersonId]    UNIQUEIDENTIFIER CONSTRAINT [DF_Person_PersonId] DEFAULT (newid()) NOT NULL,
    [KinopoiskId] BIGINT           NOT NULL,
    [EnglishName] NVARCHAR (MAX)   NULL,
    [RussianName] NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([PersonId] ASC)
);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Person', @level2type = N'COLUMN', @level2name = N'PersonId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'PhotoURL = "http://tr-by.kinopoisk.ru/images/actor/{KinopoiskId}.jpg"', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Person', @level2type = N'COLUMN', @level2name = N'KinopoiskId';

