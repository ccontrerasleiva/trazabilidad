
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/10/2018 09:49:50
-- Generated from EDMX file: C:\Sistemas\Desarrollo_Trazabilidad\WCF\WcfArmado\WS\WcfArmado\ModeloArmado.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [TrazabilidadDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_IG_Mov_Armado_IG_Armado]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[IG_Mov_Armado] DROP CONSTRAINT [FK_IG_Mov_Armado_IG_Armado];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[IG_Armado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IG_Armado];
GO
IF OBJECT_ID(N'[dbo].[IG_Mov_Armado]', 'U') IS NOT NULL
    DROP TABLE [dbo].[IG_Mov_Armado];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'IG_Armado'
CREATE TABLE [dbo].[IG_Armado] (
    [IdIGArmado] int IDENTITY(1,1) NOT NULL,
    [stop_time] varchar(50)  NULL,
    [stop_event] varchar(50)  NULL,
    [start_time] varchar(50)  NULL,
    [start_event] varchar(100)  NULL,
    [condition] varchar(50)  NULL,
    [locationId] varchar(10)  NULL,
    [tag_count] varchar(10)  NULL,
    [type] varchar(100)  NULL,
    [UUID] varchar(200)  NULL,
    [objectId] varchar(100)  NULL,
    [drivers] varchar(100)  NULL,
    [status] varchar(100)  NULL,
    [timestamp] varchar(50)  NULL
);
GO

-- Creating table 'IG_Mov_Armado'
CREATE TABLE [dbo].[IG_Mov_Armado] (
    [IdIG_Mov_Armado] int IDENTITY(1,1) NOT NULL,
    [IdIGArmado] int  NOT NULL,
    [last_read] varchar(50)  NULL,
    [observationUUID] varchar(200)  NULL,
    [locationId] varchar(50)  NULL,
    [reads] varchar(50)  NULL,
    [companyPrefix] varchar(50)  NULL,
    [itemReference] varchar(50)  NULL,
    [filterValue] varchar(50)  NULL,
    [serialNumber] varchar(50)  NULL,
    [first_read] varchar(50)  NULL,
    [type] varchar(100)  NULL,
    [UUID] varchar(200)  NULL,
    [objectId] varchar(200)  NULL,
    [timestamp] varchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdIGArmado] in table 'IG_Armado'
ALTER TABLE [dbo].[IG_Armado]
ADD CONSTRAINT [PK_IG_Armado]
    PRIMARY KEY CLUSTERED ([IdIGArmado] ASC);
GO

-- Creating primary key on [IdIG_Mov_Armado] in table 'IG_Mov_Armado'
ALTER TABLE [dbo].[IG_Mov_Armado]
ADD CONSTRAINT [PK_IG_Mov_Armado]
    PRIMARY KEY CLUSTERED ([IdIG_Mov_Armado] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdIGArmado] in table 'IG_Mov_Armado'
ALTER TABLE [dbo].[IG_Mov_Armado]
ADD CONSTRAINT [FK_IG_Mov_Armado_IG_Armado]
    FOREIGN KEY ([IdIGArmado])
    REFERENCES [dbo].[IG_Armado]
        ([IdIGArmado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_IG_Mov_Armado_IG_Armado'
CREATE INDEX [IX_FK_IG_Mov_Armado_IG_Armado]
ON [dbo].[IG_Mov_Armado]
    ([IdIGArmado]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------