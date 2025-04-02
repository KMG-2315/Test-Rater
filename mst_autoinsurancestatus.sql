USE [TestRater]
GO

/****** Object:  Table [dbo].[mst_autoinsurancestatus]    Script Date: 4/2/2025 2:43:12 PM ****/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_autoinsurancestatus](
	[insurance_id] [int] IDENTITY(1,1) NOT NULL,
	[has_insurance] [bit] NOT NULL,
	[provider_name] [varchar](100) NULL,
	[policy_number] [varchar](50) NULL,
	[coverage_type] [varchar](50) NULL,
	[policy_start_date] [date] NULL,
	[policy_end_date] [date] NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[insurance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


