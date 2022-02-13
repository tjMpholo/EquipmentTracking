USE master;  
GO  
CREATE DATABASE [EquipmentTrackingContext];

USE [EquipmentTrackingContext]
GO

/****** Object: Table [dbo].[EquipmentClassification] Script Date: 2022/02/13 19:53:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EquipmentClassification] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NOT NULL
);

USE [EquipmentTrackingContext]
GO

/****** Object: Table [dbo].[Equipment] Script Date: 2022/02/13 19:53:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Equipment] (
    [EquipmentID]               INT           IDENTITY (1, 1) NOT NULL,
    [Code]                      NVARCHAR (15) NOT NULL,
    [Name]                      NVARCHAR (50) NOT NULL,
    [Description]               NVARCHAR (50) NULL,
    [Qty]                       INT           NOT NULL,
    [EquipmentClassificationID] INT           NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_EquipmentClassificationID]
    ON [dbo].[Equipment]([EquipmentClassificationID] ASC);


GO
ALTER TABLE [dbo].[Equipment]
    ADD CONSTRAINT [PK_dbo.Equipment] PRIMARY KEY CLUSTERED ([EquipmentID] ASC);


GO
ALTER TABLE [dbo].[Equipment]
    ADD CONSTRAINT [FK_dbo.Equipment_dbo.EquipmentClassification_EquipmentClassificationID] FOREIGN KEY ([EquipmentClassificationID]) REFERENCES [dbo].[EquipmentClassification] ([ID]) ON DELETE CASCADE;

USE [EquipmentTrackingContext]
GO

/****** Object: Table [dbo].[EquipmentMovementLog] Script Date: 2022/02/13 19:53:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EquipmentMovementLog] (
    [EquipmentMovementLogID] INT           IDENTITY (1, 1) NOT NULL,
    [EmployeeNo]             NVARCHAR (15) NOT NULL,
    [LogDate]                DATETIME      NOT NULL,
    [Qty]                    INT           NOT NULL,
    [Direction]              INT           NOT NULL,
    [EquipmentID]            INT           NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_EquipmentID]
    ON [dbo].[EquipmentMovementLog]([EquipmentID] ASC);


GO
ALTER TABLE [dbo].[EquipmentMovementLog]
    ADD CONSTRAINT [PK_dbo.EquipmentMovementLog] PRIMARY KEY CLUSTERED ([EquipmentMovementLogID] ASC);


GO
ALTER TABLE [dbo].[EquipmentMovementLog]
    ADD CONSTRAINT [FK_dbo.EquipmentMovementLog_dbo.Equipment_EquipmentID] FOREIGN KEY ([EquipmentID]) REFERENCES [dbo].[Equipment] ([EquipmentID]) ON DELETE CASCADE;




