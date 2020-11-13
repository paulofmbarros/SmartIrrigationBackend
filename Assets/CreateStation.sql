/****** Object:  Table [dbo].[Station]    Script Date: 13/11/2020 10:43:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Station](
	[Id_Station] [int] NOT NULL,
	[Name] [nvarchar](255) NULL,
	[Country] [nvarchar](255) NULL,
	[Regional] [varchar](50) NULL,
	[Nat] [nvarchar](255) NULL,
	[Wmo] [int] NULL,
	[Icao] [varchar](255) NULL,
	[Iata] [varchar](255) NULL,
	[Elevation] [int] NULL,
	[Timezone] [varchar](255) NULL,
	[Active] [bit] NULL,
	[Id_Location] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Station] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Station]  WITH CHECK ADD FOREIGN KEY([Id_Location])
REFERENCES [dbo].[Location] ([Id_Location])
GO


