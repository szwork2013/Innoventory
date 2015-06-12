USE [inFlow]
GO

/****** Object:  Table [dbo].[BASE_Company]    Script Date: 06/06/2015 09:54:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BASE_Company](
	[CompanyId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Phone] [nvarchar](50) NOT NULL,
	[Fax] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Website] [nvarchar](200) NOT NULL,
	[Address1] [nvarchar](200) NOT NULL,
	[Address2] [nvarchar](200) NOT NULL,
	[City] [nvarchar](100) NOT NULL,
	[State] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](200) NOT NULL,
	[PostalCode] [nvarchar](50) NOT NULL,
	[Timestamp] [timestamp] NOT NULL,
	[TaxNumber] [nvarchar](100) NOT NULL,
	[PictureFileAttachmentId] [int] NULL,
 CONSTRAINT [PK_BASE_Company] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BASE_Company]  WITH CHECK ADD  CONSTRAINT [FK_BASE_Company_PictureFileAttachmentId] FOREIGN KEY([PictureFileAttachmentId])
REFERENCES [dbo].[BASE_FileAttachment] ([FileAttachmentId])
GO

ALTER TABLE [dbo].[BASE_Company] CHECK CONSTRAINT [FK_BASE_Company_PictureFileAttachmentId]
GO

ALTER TABLE [dbo].[BASE_Company] ADD  DEFAULT ('') FOR [TaxNumber]
GO


