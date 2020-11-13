/****** Object:  Table [dbo].[District]    Script Date: 13/11/2020 10:39:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[District](
	[Id_District] [int] NOT NULL,
	[DistrictName] [nvarchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_District] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


