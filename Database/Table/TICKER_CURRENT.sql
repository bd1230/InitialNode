USE [SimTickerData]
GO

/****** Object:  Table [dbo].[TICKER_CURRENT]    Script Date: 6/9/2024 10:57:05 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TICKER_CURRENT]') AND type in (N'U'))
DROP TABLE [dbo].[TICKER_CURRENT]
GO

/****** Object:  Table [dbo].[TICKER_CURRENT]    Script Date: 6/9/2024 10:57:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TICKER_CURRENT](
	[TICKER_ID] [uniqueidentifier] NOT NULL,
	[TICKER_COMPANY_NAME] [nvarchar](200) NULL,
	[TICKER_SYMBOL] [nchar](10) NOT NULL,
	[TICKER_OPEN_VALUE] [money] NULL,
	[TICKER_HIGH_VALUE] [money] NULL,
	[TICKER_CLOSE_VALUE] [money] NULL,
	[TICKER_VALUE_AT_TIME] [datetime] NULL,
	[TICKER_VOLUME] [bigint] NULL
) ON [PRIMARY]
GO


