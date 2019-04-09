/****** Object:  Index [IX_PickupLocationId_DropOffLocationId]    Script Date: 4/9/2019 3:04:01 AM ******/
DROP INDEX [IX_PickupLocationId_DropOffLocationId] ON [dbo].[GreenTripData]
GO

/****** Object:  Index [IX_PickupLocationId_DropOffLocationId]    Script Date: 4/9/2019 3:04:01 AM ******/
CREATE NONCLUSTERED INDEX [IX_PickupLocationId_DropOffLocationId] ON [dbo].[GreenTripData]
(
	[PickupLocationId] ASC,
	[DropOffLocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO


