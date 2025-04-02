USE [TestRater]
GO

/***** Object:  Table [dbo].[mst_BILiability]    Script Date: 4/2/2025 2:41:06 PM **/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[mst_BILiability](
	[BI_id] [int] IDENTITY(1,1) NOT NULL,
	[BI_limit] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[BI_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


