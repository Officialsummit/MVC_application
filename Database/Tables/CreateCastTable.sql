CREATE TABLE [dbo].[Cast] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [MovieID]  INT           NOT NULL,
    [CastName] NVARCHAR (50) NOT NULL,
    [Role]     NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_Cast] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Cast_Movie] FOREIGN KEY ([MovieID]) REFERENCES [dbo].[Movie] ([Id])
);

