CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Posts] (
    [Id] uniqueidentifier NOT NULL,
    [Title] nvarchar(50) NULL,
    [Content] nvarchar(1000) NULL,
    [CategoryId] uniqueidentifier NULL,
    CONSTRAINT [PK_Posts] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Posts_Categories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Categories] ([Id])
);
GO


CREATE INDEX [IX_Posts_CategoryId] ON [Posts] ([CategoryId]);
GO


