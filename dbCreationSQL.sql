Build started...
Build succeeded.
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

CREATE TABLE [Roles] (
    [Id] INTEGER NOT NULL,
    [Nombre] TEXT NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Usuarios] (
    [Id] INTEGER NOT NULL,
    [Nombre] TEXT NOT NULL,
    [RolId] INTEGER NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Usuarios_Roles_RolId] FOREIGN KEY ([RolId]) REFERENCES [Roles] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Domicilios] (
    [Id] INTEGER NOT NULL,
    [Calle] TEXT NOT NULL,
    [Numero] INTEGER NOT NULL,
    [UsuarioId] INTEGER NULL,
    CONSTRAINT [PK_Domicilios] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Domicilios_Usuarios_UsuarioId] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuarios] ([Id])
);
GO

CREATE INDEX [IX_Domicilios_UsuarioId] ON [Domicilios] ([UsuarioId]);
GO

CREATE INDEX [IX_Usuarios_RolId] ON [Usuarios] ([RolId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221013213113_InitialMigration', N'6.0.10');
GO

COMMIT;
GO


