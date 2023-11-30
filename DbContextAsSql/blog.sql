CREATE TABLE [Categories] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
);
GO


CREATE TABLE [Tags] (
    [Id] uniqueidentifier NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Tags] PRIMARY KEY ([Id])
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


CREATE TABLE [PostTags] (
    [Id] uniqueidentifier NOT NULL,
    [PostId] uniqueidentifier NOT NULL,
    [TagId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_PostTags] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PostTags_Posts_PostId] FOREIGN KEY ([PostId]) REFERENCES [Posts] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_PostTags_Tags_TagId] FOREIGN KEY ([TagId]) REFERENCES [Tags] ([Id]) ON DELETE CASCADE
);
GO


CREATE INDEX [IX_Posts_CategoryId] ON [Posts] ([CategoryId]);
GO


CREATE INDEX [IX_PostTags_PostId_TagId] ON [PostTags] ([PostId], [TagId]);
GO


CREATE INDEX [IX_PostTags_TagId] ON [PostTags] ([TagId]);
GO


