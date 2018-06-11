
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/21/2018 01:55:48
-- Generated from EDMX file: E:\Projekt-PUM\Development\QuickTrade\QuickTrade\Models\QuickTradeModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [QuickTradeDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AdvertImages]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ImagesSet] DROP CONSTRAINT [FK_AdvertImages];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAdvert]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AdvertSet] DROP CONSTRAINT [FK_AccountAdvert];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccountSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSet];
GO
IF OBJECT_ID(N'[dbo].[AdvertSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvertSet];
GO
IF OBJECT_ID(N'[dbo].[ImagesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ImagesSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccountSet'
CREATE TABLE [dbo].[AccountSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Login] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'AdvertSet'
CREATE TABLE [dbo].[AdvertSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Body] nvarchar(max)  NOT NULL,
    [DateAdded] datetime  NOT NULL,
    [DateModified] datetime  NOT NULL,
    [PhoneNumber] nvarchar(max)  NOT NULL,
    [EMail] nvarchar(max)  NOT NULL,
    [AccountId] int  NOT NULL
);
GO

-- Creating table 'ImagesSet'
CREATE TABLE [dbo].[ImagesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Image] varbinary(max)  NOT NULL,
    [AdvertId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AccountSet'
ALTER TABLE [dbo].[AccountSet]
ADD CONSTRAINT [PK_AccountSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AdvertSet'
ALTER TABLE [dbo].[AdvertSet]
ADD CONSTRAINT [PK_AdvertSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ImagesSet'
ALTER TABLE [dbo].[ImagesSet]
ADD CONSTRAINT [PK_ImagesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AdvertId] in table 'ImagesSet'
ALTER TABLE [dbo].[ImagesSet]
ADD CONSTRAINT [FK_AdvertImages]
    FOREIGN KEY ([AdvertId])
    REFERENCES [dbo].[AdvertSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AdvertImages'
CREATE INDEX [IX_FK_AdvertImages]
ON [dbo].[ImagesSet]
    ([AdvertId]);
GO

-- Creating foreign key on [AccountId] in table 'AdvertSet'
ALTER TABLE [dbo].[AdvertSet]
ADD CONSTRAINT [FK_AccountAdvert]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[AccountSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAdvert'
CREATE INDEX [IX_FK_AccountAdvert]
ON [dbo].[AdvertSet]
    ([AccountId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------