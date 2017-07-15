
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 07/15/2017 09:02:27
-- Generated from EDMX file: E:\Git\2017\MyPower\MyPowerMS\src\MyPowerMS.Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [MyPowerDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[T_Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_Permissions];
GO
IF OBJECT_ID(N'[dbo].[T_RoleInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_RoleInfo];
GO
IF OBJECT_ID(N'[dbo].[T_RoleToPermissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_RoleToPermissions];
GO
IF OBJECT_ID(N'[dbo].[T_UserInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_UserInfo];
GO
IF OBJECT_ID(N'[dbo].[T_UserToRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[T_UserToRole];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'T_Permissions'
CREATE TABLE [dbo].[T_Permissions] (
    [id] char(32)  NOT NULL,
    [Title] nvarchar(50)  NULL,
    [Url] nvarchar(200)  NULL,
    [Status] int  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'T_RoleInfo'
CREATE TABLE [dbo].[T_RoleInfo] (
    [id] char(32)  NOT NULL,
    [RoleName] nvarchar(50)  NULL,
    [RoleDesc] nvarchar(500)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'T_RoleToPermissions'
CREATE TABLE [dbo].[T_RoleToPermissions] (
    [id] char(32)  NOT NULL,
    [RoleId] char(32)  NOT NULL,
    [Permissions] char(32)  NOT NULL
);
GO

-- Creating table 'T_UserInfo'
CREATE TABLE [dbo].[T_UserInfo] (
    [id] char(32)  NOT NULL,
    [UserName] nvarchar(50)  NULL,
    [TrueName] nvarchar(50)  NULL,
    [PassWord] nvarchar(200)  NULL,
    [Role] char(32)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'T_UserToRole'
CREATE TABLE [dbo].[T_UserToRole] (
    [id] char(32)  NOT NULL,
    [UserId] char(32)  NOT NULL,
    [RoleId] char(32)  NOT NULL,
    [CreateDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'T_Permissions'
ALTER TABLE [dbo].[T_Permissions]
ADD CONSTRAINT [PK_T_Permissions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'T_RoleInfo'
ALTER TABLE [dbo].[T_RoleInfo]
ADD CONSTRAINT [PK_T_RoleInfo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'T_RoleToPermissions'
ALTER TABLE [dbo].[T_RoleToPermissions]
ADD CONSTRAINT [PK_T_RoleToPermissions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'T_UserInfo'
ALTER TABLE [dbo].[T_UserInfo]
ADD CONSTRAINT [PK_T_UserInfo]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'T_UserToRole'
ALTER TABLE [dbo].[T_UserToRole]
ADD CONSTRAINT [PK_T_UserToRole]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------