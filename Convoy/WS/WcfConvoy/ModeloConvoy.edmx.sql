
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/31/2018 10:50:03
-- Generated from EDMX file: C:\Sistemas\Desarrollo_Trazabilidad\WCF\WcfConvoy\WcfConvoy\ModeloConvoy.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ET_Comboy_Detalle_ET_Comboy_Cabecera]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ET_Convoy_Detalle] DROP CONSTRAINT [FK_ET_Comboy_Detalle_ET_Comboy_Cabecera];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ET_Convoy_Cabecera]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ET_Convoy_Cabecera];
GO
IF OBJECT_ID(N'[dbo].[ET_Convoy_Detalle]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ET_Convoy_Detalle];
GO
IF OBJECT_ID(N'[TrazabilidadModelStoreContainer].[ET_Convoy_Log_Service]', 'U') IS NOT NULL
    DROP TABLE [TrazabilidadModelStoreContainer].[ET_Convoy_Log_Service];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ET_Convoy_Cabecera'
CREATE TABLE [dbo].[ET_Convoy_Cabecera] (
    [IdEtConvoyCabecera] int IDENTITY(1,1) NOT NULL,
    [CnvBseCod] int  NULL,
    [CnvBasCod] int  NULL,
    [CnvID] varchar(60)  NULL,
    [CnvObs] varchar(255)  NULL,
    [CnvCicPesCod] int  NULL,
    [CnvChoid] int  NULL,
    [CnvChoDid] varchar(1)  NULL,
    [CnvChoNom] varchar(60)  NULL,
    [Procesado] bit  NULL
);
GO

-- Creating table 'ET_Convoy_Detalle'
CREATE TABLE [dbo].[ET_Convoy_Detalle] (
    [IdEtConvoyDetalle] int IDENTITY(1,1) NOT NULL,
    [IdEtConvoyCabecera] int  NOT NULL,
    [PesCarIde] varchar(10)  NULL,
    [PesCarDes] varchar(30)  NULL,
    [PesConId] int  NULL,
    [PesConDes] varchar(30)  NULL,
    [PesConSelPor] varchar(12)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdEtConvoyCabecera] in table 'ET_Convoy_Cabecera'
ALTER TABLE [dbo].[ET_Convoy_Cabecera]
ADD CONSTRAINT [PK_ET_Convoy_Cabecera]
    PRIMARY KEY CLUSTERED ([IdEtConvoyCabecera] ASC);
GO

-- Creating primary key on [IdEtConvoyDetalle] in table 'ET_Convoy_Detalle'
ALTER TABLE [dbo].[ET_Convoy_Detalle]
ADD CONSTRAINT [PK_ET_Convoy_Detalle]
    PRIMARY KEY CLUSTERED ([IdEtConvoyDetalle] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdEtConvoyCabecera] in table 'ET_Convoy_Detalle'
ALTER TABLE [dbo].[ET_Convoy_Detalle]
ADD CONSTRAINT [FK_ET_Comboy_Detalle_ET_Comboy_Cabecera]
    FOREIGN KEY ([IdEtConvoyCabecera])
    REFERENCES [dbo].[ET_Convoy_Cabecera]
        ([IdEtConvoyCabecera])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ET_Comboy_Detalle_ET_Comboy_Cabecera'
CREATE INDEX [IX_FK_ET_Comboy_Detalle_ET_Comboy_Cabecera]
ON [dbo].[ET_Convoy_Detalle]
    ([IdEtConvoyCabecera]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------