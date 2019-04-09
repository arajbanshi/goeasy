/****** Object:  Table [dbo].[FhvTripData]    Script Date: 4/9/2019 2:53:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[FhvTripData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[DispatchingBaseNum] [varchar](50) NOT NULL,
	[PickupDateTime] [varchar](50) NULL,
	[DropOffDateTime] [varchar](50) NULL,
	[PickupLocationId] [varchar](50) NULL,
	[DropOffLocationId] [varchar](50) NULL,
	[SR_Flag] [varchar](50) NULL,
	[DispatchBaseNum] [varchar](50) NULL,
	[PkpDateTime] [datetime] NULL,
	[DropDateTime] [datetime] NULL,
	[PkpLocationId] [int] NULL,
	[DropLocationId] [int] NULL,
	[SRFlag] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


