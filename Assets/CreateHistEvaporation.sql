/****** Object:  Table [dbo].[Hist_Evaporation]    Script Date: 13/11/2020 10:41:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Hist_Evaporation](
	[Id_HistEvaporation] [int] IDENTITY(1,1) NOT NULL,
	[Reading_date] [datetime] NULL,
	[Minimum] [float] NULL,
	[Maxi] [float] NULL,
	[Range] [float] NULL,
	[Mean] [float] NULL,
	[Std] [float] NULL,
	[Id_County] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_HistEvaporation] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


