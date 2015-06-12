USE [inFlow]
GO

/****** Object:  Table [dbo].[BASE_PricingScheme]    Script Date: 06/06/2015 10:34:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BASE_PricingScheme](
	[PricingSchemeId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastModUserId] [int] NOT NULL,
	[LastModDttm] [datetime] NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CurrencyId] [int] NOT NULL,
 CONSTRAINT [PK_BASE_PricingScheme] PRIMARY KEY CLUSTERED 
(
	[PricingSchemeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BASE_PricingScheme]  WITH CHECK ADD  CONSTRAINT [FK_BASE_PricingScheme_CurrencyId] FOREIGN KEY([CurrencyId])
REFERENCES [dbo].[GLOBAL_Currency] ([CurrencyId])
GO

ALTER TABLE [dbo].[BASE_PricingScheme] CHECK CONSTRAINT [FK_BASE_PricingScheme_CurrencyId]
GO

ALTER TABLE [dbo].[BASE_PricingScheme]  WITH CHECK ADD  CONSTRAINT [FK_BASE_PricingScheme_LastModUserId] FOREIGN KEY([LastModUserId])
REFERENCES [dbo].[BASE_User] ([UserId])
GO

ALTER TABLE [dbo].[BASE_PricingScheme] CHECK CONSTRAINT [FK_BASE_PricingScheme_LastModUserId]
GO

ALTER TABLE [dbo].[BASE_PricingScheme] ADD  CONSTRAINT [DF_BASE_PricingScheme_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO


