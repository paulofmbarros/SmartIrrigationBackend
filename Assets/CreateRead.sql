/****** Object:  Table [dbo].[Read]    Script Date: 13/11/2020 10:42:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Read](
	[Id_Read] [int] NOT NULL,
	[DateReading] [datetime] NULL,
	[Temperature] [float] NULL,
	[Dwpt] [float] NULL,
	[Rhum] [int] NULL,
	[Prcp] [float] NULL,
	[Snow] [int] NULL,
	[Wdir] [int] NULL,
	[Wspd] [float] NULL,
	[Wpgt] [float] NULL,
	[Pres] [float] NULL,
	[Tsun] [int] NULL,
	[Coco] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Read] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Read] ADD  DEFAULT (getdate()) FOR [DateReading]
GO


