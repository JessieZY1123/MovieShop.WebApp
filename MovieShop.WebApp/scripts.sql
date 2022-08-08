IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Cast] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(128) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [TmdbUrl] nvarchar(max) NOT NULL,
    [ProfilePath] nvarchar(2084) NOT NULL,
    CONSTRAINT [PK_Cast] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Crew] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(128) NOT NULL,
    [Gender] nvarchar(max) NOT NULL,
    [TmdbUrl] nvarchar(max) NOT NULL,
    [ProfilePath] nvarchar(2084) NOT NULL,
    CONSTRAINT [PK_Crew] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Movie] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(256) NOT NULL,
    [Overview] nvarchar(max) NOT NULL,
    [Tagline] nvarchar(512) NOT NULL,
    [Budget] decimal(18,2) NOT NULL,
    [Revenue] decimal(18,2) NOT NULL,
    [ImdbUrl] nvarchar(2084) NOT NULL,
    [TmdbUrl] nvarchar(2084) NOT NULL,
    [PosterUrl] nvarchar(2084) NOT NULL,
    [BackdropUrl] nvarchar(2084) NOT NULL,
    [OriginalLanguage] nvarchar(64) NOT NULL,
    [ReleaseDate] datetime2 NOT NULL,
    [RunTime] int NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [CreatedDate] datetime2 NOT NULL,
    [UpdatedDate] datetime2 NOT NULL,
    [UpdatedBy] nvarchar(max) NOT NULL,
    [CreatedBy] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Movie] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [User] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(128) NOT NULL,
    [LastName] nvarchar(128) NOT NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Email] nvarchar(256) NOT NULL,
    [HashedPassword] nvarchar(1024) NOT NULL,
    [Salt] nvarchar(1024) NOT NULL,
    [PhoneNumber] nvarchar(16) NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEndDate] datetime2 NOT NULL,
    [LastLoginDateTime] datetime2 NOT NULL,
    [IsLocked] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [ProfilePictureUrl] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Genre] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(64) NOT NULL,
    [MovieId] int NULL,
    CONSTRAINT [PK_Genre] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Genre_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id])
);
GO

CREATE TABLE [MovieCast] (
    [MovieId] int NOT NULL IDENTITY,
    [CastId] int NOT NULL,
    [Character] nvarchar(450) NOT NULL,
    [MoviesId] int NOT NULL,
    [CrewId] int NULL,
    CONSTRAINT [PK_MovieCast] PRIMARY KEY ([MovieId]),
    CONSTRAINT [FK_MovieCast_Cast_CastId] FOREIGN KEY ([CastId]) REFERENCES [Cast] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCast_Crew_CrewId] FOREIGN KEY ([CrewId]) REFERENCES [Crew] ([Id]),
    CONSTRAINT [FK_MovieCast_Movie_MoviesId] FOREIGN KEY ([MoviesId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieCrew] (
    [MovieId] int NOT NULL IDENTITY,
    [CrewId] int NOT NULL,
    [Department] nvarchar(128) NOT NULL,
    [Job] nvarchar(128) NOT NULL,
    [MovieId1] int NOT NULL,
    CONSTRAINT [PK_MovieCrew] PRIMARY KEY ([MovieId]),
    CONSTRAINT [FK_MovieCrew_Crew_CrewId] FOREIGN KEY ([CrewId]) REFERENCES [Crew] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieCrew_Movie_MovieId1] FOREIGN KEY ([MovieId1]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Trailer] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [TrailerUrl] nvarchar(max) NOT NULL,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Trailer] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Trailer_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Favorite] (
    [Id] int NOT NULL IDENTITY,
    [MovieId] int NOT NULL,
    [UserId] int NOT NULL,
    CONSTRAINT [PK_Favorite] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Favorite_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Favorite_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Purchase] (
    [Id] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [PurchaseNumber] int NOT NULL,
    [TotalPrice] decimal(18,2) NOT NULL,
    [PurchaseDateTime] datetime2 NOT NULL,
    [MovieId] int NOT NULL,
    CONSTRAINT [PK_Purchase] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Purchase_Movie_MovieId] FOREIGN KEY ([MovieId]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Purchase_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Review] (
    [MovieId] int NOT NULL IDENTITY,
    [UserId] int NOT NULL,
    [Rating] decimal(3,2) NOT NULL,
    [ReviewText] nvarchar(max) NOT NULL,
    [MovieId1] int NOT NULL,
    CONSTRAINT [PK_Review] PRIMARY KEY ([MovieId]),
    CONSTRAINT [FK_Review_Movie_MovieId1] FOREIGN KEY ([MovieId1]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Review_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [MovieGenre] (
    [MovieId] int NOT NULL IDENTITY,
    [GenreId] int NOT NULL,
    [MovieId1] int NOT NULL,
    CONSTRAINT [PK_MovieGenre] PRIMARY KEY ([MovieId]),
    CONSTRAINT [FK_MovieGenre_Genre_GenreId] FOREIGN KEY ([GenreId]) REFERENCES [Genre] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_MovieGenre_Movie_MovieId1] FOREIGN KEY ([MovieId1]) REFERENCES [Movie] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Favorite_MovieId] ON [Favorite] ([MovieId]);
GO

CREATE INDEX [IX_Favorite_UserId] ON [Favorite] ([UserId]);
GO

CREATE INDEX [IX_Genre_MovieId] ON [Genre] ([MovieId]);
GO

CREATE INDEX [IX_MovieCast_CastId] ON [MovieCast] ([CastId]);
GO

CREATE INDEX [IX_MovieCast_CrewId] ON [MovieCast] ([CrewId]);
GO

CREATE INDEX [IX_MovieCast_MoviesId] ON [MovieCast] ([MoviesId]);
GO

CREATE INDEX [IX_MovieCrew_CrewId] ON [MovieCrew] ([CrewId]);
GO

CREATE INDEX [IX_MovieCrew_MovieId1] ON [MovieCrew] ([MovieId1]);
GO

CREATE INDEX [IX_MovieGenre_GenreId] ON [MovieGenre] ([GenreId]);
GO

CREATE INDEX [IX_MovieGenre_MovieId1] ON [MovieGenre] ([MovieId1]);
GO

CREATE INDEX [IX_Purchase_MovieId] ON [Purchase] ([MovieId]);
GO

CREATE INDEX [IX_Purchase_UserId] ON [Purchase] ([UserId]);
GO

CREATE INDEX [IX_Review_MovieId1] ON [Review] ([MovieId1]);
GO

CREATE INDEX [IX_Review_UserId] ON [Review] ([UserId]);
GO

CREATE INDEX [IX_Trailer_MovieId] ON [Trailer] ([MovieId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220730032244_removeUserRole', N'6.0.7');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'UpdatedDate');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Movie] ALTER COLUMN [UpdatedDate] datetime2 NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'UpdatedBy');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Movie] ALTER COLUMN [UpdatedBy] nvarchar(max) NULL;
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'Price');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Movie] ALTER COLUMN [Price] decimal(18,2) NULL;
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'CreatedDate');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Movie] ALTER COLUMN [CreatedDate] datetime2 NULL;
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Movie]') AND [c].[name] = N'CreatedBy');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Movie] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Movie] ALTER COLUMN [CreatedBy] nvarchar(max) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220730172833_changeProprety', N'6.0.7');
GO

COMMIT;
GO

