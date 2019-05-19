CREATE TABLE [dbo].[Review] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [MovieId]      INT            NOT NULL,
    [UserId]       NVARCHAR (450) NOT NULL,
    [Review]       NVARCHAR (MAX) NOT NULL,
    [Rating]       FLOAT (53)     NOT NULL,
    [CreatedDate]  DATE           NOT NULL,
    [ModifiedDate] DATE           NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Review_AspNetUsers] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]),
    CONSTRAINT [FK_Review_Movie] FOREIGN KEY ([MovieId]) REFERENCES [dbo].[Movie] ([Id])
);

