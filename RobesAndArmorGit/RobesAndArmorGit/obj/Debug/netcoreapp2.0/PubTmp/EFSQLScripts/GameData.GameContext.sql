IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [battles] (
        [Id] int NOT NULL IDENTITY,
        [characterID] int NOT NULL,
        [enemyHealth] int NOT NULL,
        [enemyId] int NOT NULL,
        CONSTRAINT [PK_battles] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Classes] (
        [Id] int NOT NULL IDENTITY,
        [Agility] int NOT NULL,
        [Int] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Str] int NOT NULL,
        [imageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Classes] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Enemies] (
        [Id] int NOT NULL IDENTITY,
        [Atk] int NOT NULL,
        [Def] int NOT NULL,
        [Health] int NOT NULL,
        [Level] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [imageUrl] nvarchar(max) NULL,
        CONSTRAINT [PK_Enemies] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Inventories] (
        [Id] int NOT NULL IDENTITY,
        [Size] int NOT NULL,
        CONSTRAINT [PK_Inventories] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [itemArchives] (
        [Id] int NOT NULL IDENTITY,
        [Atk] int NOT NULL,
        [Def] int NOT NULL,
        [Description] nvarchar(max) NULL,
        [Health] int NOT NULL,
        [Level] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Rarity] nvarchar(max) NULL,
        [imgeUrl] nvarchar(max) NULL,
        [price] int NOT NULL,
        CONSTRAINT [PK_itemArchives] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [theNews] (
        [Id] int NOT NULL IDENTITY,
        [Body] nvarchar(max) NULL,
        [Title] nvarchar(max) NULL,
        [postDate] datetime2 NOT NULL,
        CONSTRAINT [PK_theNews] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Types] (
        [Id] int NOT NULL IDENTITY,
        [Description] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        CONSTRAINT [PK_Types] PRIMARY KEY ([Id])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Items] (
        [Id] int NOT NULL IDENTITY,
        [Atk] int NOT NULL,
        [Def] int NOT NULL,
        [Description] nvarchar(max) NULL,
        [Health] int NOT NULL,
        [Level] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [Rarity] nvarchar(max) NULL,
        [imgeUrl] nvarchar(max) NULL,
        [price] int NOT NULL,
        [typeId] int NOT NULL,
        CONSTRAINT [PK_Items] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Items_Types_typeId] FOREIGN KEY ([typeId]) REFERENCES [Types] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Enemy_has_Item] (
        [EnemyId] int NOT NULL,
        [ItemId] int NOT NULL,
        [Id] int NOT NULL,
        CONSTRAINT [PK_Enemy_has_Item] PRIMARY KEY ([EnemyId], [ItemId]),
        CONSTRAINT [AK_Enemy_has_Item_Id] UNIQUE ([Id]),
        CONSTRAINT [FK_Enemy_has_Item_Enemies_EnemyId] FOREIGN KEY ([EnemyId]) REFERENCES [Enemies] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Enemy_has_Item_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Equipment] (
        [Id] int NOT NULL IDENTITY,
        [bodyId] int NOT NULL,
        [bodyItemId] int NULL,
        [feetId] int NOT NULL,
        [feetItemId] int NULL,
        [gloveId] int NOT NULL,
        [gloveItemId] int NULL,
        [headId] int NOT NULL,
        [headItemId] int NULL,
        [legsId] int NOT NULL,
        [legsItemId] int NULL,
        [shieldId] int NOT NULL,
        [shieldItemId] int NULL,
        [weaponId] int NOT NULL,
        [weaponItemId] int NULL,
        CONSTRAINT [PK_Equipment] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Equipment_Items_bodyItemId] FOREIGN KEY ([bodyItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_feetItemId] FOREIGN KEY ([feetItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_gloveItemId] FOREIGN KEY ([gloveItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_headItemId] FOREIGN KEY ([headItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_legsItemId] FOREIGN KEY ([legsItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_shieldItemId] FOREIGN KEY ([shieldItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION,
        CONSTRAINT [FK_Equipment_Items_weaponItemId] FOREIGN KEY ([weaponItemId]) REFERENCES [Items] ([Id]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Inventory_has_Item] (
        [InventoryId] int NOT NULL,
        [ItemId] int NOT NULL,
        [Count] int NOT NULL,
        CONSTRAINT [PK_Inventory_has_Item] PRIMARY KEY ([InventoryId], [ItemId]),
        CONSTRAINT [FK_Inventory_has_Item_Inventories_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [Inventories] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Inventory_has_Item_Items_ItemId] FOREIGN KEY ([ItemId]) REFERENCES [Items] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE TABLE [Characters] (
        [Id] int NOT NULL IDENTITY,
        [Agility] int NOT NULL,
        [ClassId] int NOT NULL,
        [EquipmentId] int NOT NULL,
        [Exp] int NOT NULL,
        [Health] int NOT NULL,
        [INT] int NOT NULL,
        [InventoryId] int NOT NULL,
        [Level] int NOT NULL,
        [Name] nvarchar(max) NULL,
        [UserID] nvarchar(max) NULL,
        [gold] int NOT NULL,
        [imageUrl] nvarchar(max) NULL,
        [str] int NOT NULL,
        CONSTRAINT [PK_Characters] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Characters_Classes_ClassId] FOREIGN KEY ([ClassId]) REFERENCES [Classes] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Characters_Equipment_EquipmentId] FOREIGN KEY ([EquipmentId]) REFERENCES [Equipment] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Characters_Inventories_InventoryId] FOREIGN KEY ([InventoryId]) REFERENCES [Inventories] ([Id]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Characters_ClassId] ON [Characters] ([ClassId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Characters_EquipmentId] ON [Characters] ([EquipmentId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Characters_InventoryId] ON [Characters] ([InventoryId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Enemy_has_Item_ItemId] ON [Enemy_has_Item] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_bodyItemId] ON [Equipment] ([bodyItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_feetItemId] ON [Equipment] ([feetItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_gloveItemId] ON [Equipment] ([gloveItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_headItemId] ON [Equipment] ([headItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_legsItemId] ON [Equipment] ([legsItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_shieldItemId] ON [Equipment] ([shieldItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Equipment_weaponItemId] ON [Equipment] ([weaponItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Inventory_has_Item_ItemId] ON [Inventory_has_Item] ([ItemId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    CREATE INDEX [IX_Items_typeId] ON [Items] ([typeId]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20180605135841_intialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20180605135841_intialCreate', N'2.0.3-rtm-10026');
END;

GO

