/****** Object:  Table [dbo].[YellowTripData]    Script Date: 4/9/2019 3:00:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[YellowTripData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VendorId] [varchar](50) NOT NULL,
	[PickupDateTime] [datetime] NULL,
	[DropOffDateTime] [datetime] NULL,
	[PassangerCount] [int] NULL,
	[TripDistance] [varchar](10) NULL,
	[RateCodeId] [int] NULL,
	[StoreAndForwardFlag] [varchar](10) NULL,
	[PickupLocationId] [int] NULL,
	[DropOffLocationId] [int] NULL,
	[PaymentType] [int] NULL,
	[FareAmount] [varchar](10) NULL,
	[Extra] [varchar](10) NULL,
	[MtaTax] [varchar](10) NULL,
	[TipAmount] [varchar](10) NULL,
	[TollsAmount] [varchar](10) NULL,
	[ImprovementSurcharge] [varchar](10) NULL,
	[TotalAmount] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


