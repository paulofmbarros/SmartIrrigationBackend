/****** Object:  Table [dbo].[Node]    Script Date: 13/11/2020 10:42:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Node](
	[Id_Node] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Id_Location] [int] NULL,
	[Id_NearStationOrSensor] [int] NULL,
	[Is_Enable] [bit] NULL,
	[is_RealSensor] [bit] NULL,
	[is_Sprinkler] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Node] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Node]  WITH CHECK ADD FOREIGN KEY([Id_Location])
REFERENCES [dbo].[Location] ([Id_Location])
GO

ALTER TABLE [dbo].[Node]  WITH CHECK ADD FOREIGN KEY([Id_NearStationOrSensor])
REFERENCES [dbo].[Station] ([Id_Station])
GO


