USE [TestRater]
GO

/****** Object:  Table [dbo].[mst_annualmileagefrequency]    Script Date: 4/2/2025 2:51:21 PM *****/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_annualmileagefrequency](
	[mileage_id] [int] IDENTITY(1,1) NOT NULL,
	[frequency_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[average_mileage] [int] NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[mileage_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


