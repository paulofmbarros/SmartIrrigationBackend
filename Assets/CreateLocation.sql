/****** Object:  Table [dbo].[Location]    Script Date: 13/11/2020 10:41:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Location](
	[Id_Location] [int] NOT NULL,
	[Latitude] [nvarchar](255) NULL,
	[Longitude] [nvarchar](255) NULL,
	[Altitude] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[District] [int] NULL,
	[Countie] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Location] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


