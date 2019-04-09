/****** Object:  Table [dbo].[TaxiZones]    Script Date: 4/9/2019 3:00:29 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaxiZones](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[LocationID] [varchar](50) NOT NULL,
	[Borough] [varchar](250) NULL,
	[TaxiZone] [varchar](250) NULL,
	[ServiceZone] [varchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


