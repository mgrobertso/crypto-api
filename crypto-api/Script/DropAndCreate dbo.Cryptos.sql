USE [cryptodb]
GO

/****** Object: Table [dbo].[Cryptos] Script Date: 10/3/2022 2:55:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Cryptos];
DROP TABLE [dbo].[User];
DROP TABLE [dbo].[WatchList];

GO
CREATE TABLE [dbo].[Cryptos] (
    [Id]            NVARCHAR (450) NOT NULL,
    [Last_update]   NVARCHAR (MAX) NOT NULL,
    [Name]          NVARCHAR (MAX) NOT NULL,
    [Symbol]        NVARCHAR (MAX) NOT NULL,
    [Image]         NVARCHAR (MAX) NOT NULL,
    [Current_price] FLOAT (53)     NOT NULL,
    [High_24h]      FLOAT (53)     NOT NULL,
    [Low_24h]       FLOAT (53)     NOT NULL,
    [Total_volume]  FLOAT (53)     NOT NULL,
    [market_cap] float             NOT NULL,
    [market_cap_rank] float        NOT NULL,
    [fully_diluted_valuation] float NOT NULL,
    [price_change_24h] float NOT NULL,
    [price_change_percentage_24h] float NOT NULL,
    [market_cap_change_24h] float NOT NULL,
    [market_cap_change_percentage_24h] float NOT NULL,
    [total_supply] float NOT NULL,
    [max_supply] float NOT NULL,
    [ath] float NOT NULL,
    [ath_change_percentage] float NOT NULL,
    [ath_date] datetime2 NOT NULL,
    [roi] float NOT NULL,
    CONSTRAINT [PK_Cryptos] PRIMARY KEY ([Id])
);

CREATE TABLE [dbo].[User] (
    [Id]            NVARCHAR (450) NOT NULL,
    [FirstName]     NVARCHAR (MAX),
    [UserName]      NVARCHAR (MAX) NOT NULL,
    [LastName]      NVARCHAR (MAX),
    [Email]         NVARCHAR (MAX),
    [WatchlistId]   NVARCHAR (450),
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])

);

CREATE TABLE [dbo].[WatchList] (
    [Id]       NVARCHAR (450) NOT NULL,
    [Coin]     NVARCHAR (MAX) NOT NULL
     CONSTRAINT [PK_WatchList] PRIMARY KEY ([Id])
);


