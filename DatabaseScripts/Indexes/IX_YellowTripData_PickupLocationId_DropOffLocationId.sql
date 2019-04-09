/****** Object:  Index [IX_YellowTripData_PickupLocationId_DropOffLocationId]    Script Date: 4/9/2019 3:03:03 AM ******/
DROP INDEX [IX_YellowTripData_PickupLocationId_DropOffLocationId] ON [dbo].[YellowTripData]
GO

/****** Object:  Index [IX_YellowTripData_PickupLocationId_DropOffLocationId]    Script Date: 4/9/2019 3:03:03 AM ******/
CREATE NONCLUSTERED INDEX [IX_YellowTripData_PickupLocationId_DropOffLocationId] ON [dbo].[YellowTripData]
(
	[PickupLocationId] ASC,
	[DropOffLocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO


