
/****** Object:  Table [dbo].[mst_annualmileagefrequency]    Script Date: 4/2/2025 3:06:52 PM ******/
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
/****** Object:  Table [dbo].[mst_autoinsurancestatus]    Script Date: 4/2/2025 3:06:53 PM ******/
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
/****** Object:  Table [dbo].[mst_BILiability]    Script Date: 4/2/2025 3:06:53 PM ******/
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
/****** Object:  Table [dbo].[mst_businessstructure]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_businessstructure](
	[business_id] [int] IDENTITY(1,1) NOT NULL,
	[business_type] [varchar](50) NOT NULL,
	[industry] [varchar](50) NULL,
	[business_size] [varchar](50) NULL,
	[location] [varchar](100) NULL,
	[annual_revenue] [decimal](18, 2) NULL,
	[number_of_employees] [int] NULL,
	[contact_person] [varchar](100) NULL,
	[contact_email] [varchar](100) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[business_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_businessvehicles]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_businessvehicles](
	[vehicle_id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_type] [varchar](50) NOT NULL,
	[vehicle_usage] [varchar](50) NULL,
	[capacity] [int] NULL,
	[fuel_type] [varchar](50) NULL,
	[registration_number] [varchar](100) NULL,
	[add_vehicle_by] [varchar](100) NULL,
	[make] [varchar](50) NULL,
	[model] [varchar](50) NULL,
	[year] [int] NULL,
	[vin] [varchar](100) NULL,
	[purchase_date] [date] NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[vehicle_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_collisioncoverage]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_collisioncoverage](
	[coll_id] [int] IDENTITY(1,1) NOT NULL,
	[deductible_amount] [decimal](18, 2) NOT NULL,
	[coverage_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[coll_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_comprehensivecoverage]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_comprehensivecoverage](
	[comp_id] [int] IDENTITY(1,1) NOT NULL,
	[deductible_amount] [decimal](18, 2) NOT NULL,
	[coverage_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[comp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_datefirstlicensed]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_datefirstlicensed](
	[license_id] [int] IDENTITY(1,1) NOT NULL,
	[month_year] [varchar](20) NOT NULL,
	[license_type] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[license_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_educationlevel]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_educationlevel](
	[education_id] [int] IDENTITY(1,1) NOT NULL,
	[education_level] [varchar](50) NOT NULL,
	[category] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[education_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_employmentstatus]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_employmentstatus](
	[status_id] [int] IDENTITY(1,1) NOT NULL,
	[employment_status] [varchar](50) NOT NULL,
	[status_type] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_genderidentity]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_genderidentity](
	[gender_id] [int] IDENTITY(1,1) NOT NULL,
	[gender] [varchar](20) NOT NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[gender_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_licensestatus]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_licensestatus](
	[licensestatus_id] [int] IDENTITY(1,1) NOT NULL,
	[license_status] [varchar](50) NOT NULL,
	[status_type] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[licensestatus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_maritalstatus]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_maritalstatus](
	[marital_id] [int] IDENTITY(1,1) NOT NULL,
	[is_married] [bit] NOT NULL,
	[status_type] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[marital_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_medpayments]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_medpayments](
	[med_id] [int] IDENTITY(1,1) NOT NULL,
	[med_limit] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[date_from] [date] NOT NULL,
	[date_to] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[med_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_noinsurancereason]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_noinsurancereason](
	[reason_id] [int] IDENTITY(1,1) NOT NULL,
	[reason_description] [varchar](255) NOT NULL,
	[category] [varchar](50) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reason_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_pdliability]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_pdliability](
	[pd_id] [int] IDENTITY(1,1) NOT NULL,
	[pd_limit] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[pd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_rentalreimbursement]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_rentalreimbursement](
	[rr_id] [int] IDENTITY(1,1) NOT NULL,
	[daily_limit] [decimal](18, 2) NOT NULL,
	[max_claim_limit] [decimal](18, 2) NOT NULL,
	[coverage_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[rr_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_residencestatus]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_residencestatus](
	[residence_id] [int] IDENTITY(1,1) NOT NULL,
	[residence_type] [varchar](50) NOT NULL,
	[ownership_status] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[residence_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_uimpdliability]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_uimpdliability](
	[uimpd_id] [int] IDENTITY(1,1) NOT NULL,
	[uimpd_limit] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[date_from] [date] NOT NULL,
	[date_to] [date] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[uimpd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_umbiliability]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_umbiliability](
	[umbi_id] [int] IDENTITY(1,1) NOT NULL,
	[umbi_limit] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[date_from] [date] NOT NULL,
	[date_to] [date] NOT NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[umbi_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_umpdliability]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_umpdliability](
	[umpd_id] [int] IDENTITY(1,1) NOT NULL,
	[umpd_limit] [decimal](18, 2) NOT NULL,
	[deductible_amount] [decimal](18, 2) NOT NULL,
	[limit_type] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[umpd_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_vehicledistance]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_vehicledistance](
	[distance_id] [int] IDENTITY(1,1) NOT NULL,
	[distance_limit] [decimal](18, 2) NOT NULL,
	[unit] [varchar](50) NOT NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[distance_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_vehiclemake]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_vehiclemake](
	[make_id] [int] IDENTITY(1,1) NOT NULL,
	[make_name] [varchar](50) NOT NULL,
	[country_of_origin] [varchar](50) NULL,
	[founded_year] [int] NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[make_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[mst_vehicletype]    Script Date: 4/2/2025 3:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mst_vehicletype](
	[vehicletype_id] [int] IDENTITY(1,1) NOT NULL,
	[vehicle_type] [varchar](50) NOT NULL,
	[category] [varchar](50) NULL,
	[description] [varchar](255) NULL,
	[created_date] [date] NOT NULL,
	[updated_date] [date] NULL,
	[is_active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[vehicletype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
