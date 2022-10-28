USE [cryptodb]
GO

/****** Object: Table [dbo].[Cryptos] Script Date: 10/3/2022 2:55:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Cryptos];
DROP TABLE [dbo].[Users];
DROP TABLE [dbo].[WatchList];

GO
CREATE TABLE [Cryptos] (
    [Id] nvarchar(450) NOT NULL,
    [Last_update] datetime2 NULL,
    [Name] nvarchar(max) NULL,
    [Symbol] nvarchar(max) NULL,
    [Image] nvarchar(max) NULL,
    [Current_price] float NULL,
    [High_24h] float NULL,
    [Low_24h] float NULL,
    [Total_volume] float NULL,
    [market_cap] float NULL,
    [market_cap_rank] float NULL,
    [fully_diluted_valuation] float NULL,
    [price_change_24h] float NULL,
    [price_change_percentage_24h] float NULL,
    [market_cap_change_24h] float NULL,
    [market_cap_change_percentage_24h] float NULL,
    [total_supply] float NULL,
    [max_supply] float NULL,
    [ath] float NULL,
    [ath_change_percentage] float NULL,
    [ath_date] datetime2 NULL,
    CONSTRAINT [PK_Cryptos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Users] (
    [Id] nvarchar(450) NOT NULL,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Email] nvarchar(max) NOT NULL,
    [UserName] nvarchar(max) NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [WatchList] (
    [Id] nvarchar(450) NOT NULL,
    [WatchId] nvarchar(max) NOT NULL,
    [Coin] nvarchar(20) null
    CONSTRAINT [PK_WatchList] PRIMARY KEY ([Id])
);
GO