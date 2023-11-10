CREATE TABLE [Posts] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(50) NULL,
    [Content] nvarchar(1000) NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id])
);
GO


