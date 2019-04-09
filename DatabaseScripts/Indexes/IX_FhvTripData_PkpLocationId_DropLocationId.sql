/****** Object:  Index [IX_FhvTripData_PkpLocationId_DropLocationId]    Script Date: 4/9/2019 3:04:33 AM ******/
DROP INDEX [IX_FhvTripData_PkpLocationId_DropLocationId] ON [dbo].[FhvTripData]
GO

/****** Object:  Index [IX_FhvTripData_PkpLocationId_DropLocationId]    Script Date: 4/9/2019 3:04:33 AM ******/
CREATE NONCLUSTERED INDEX [IX_FhvTripData_PkpLocationId_DropLocationId] ON [dbo].[FhvTripData]
(
	[PkpLocationId] ASC,
	[DropLocationId] ASC
)WITH (STATISTICS_NORECOMPUTE = OFF, DROP_EXISTING = OFF, ONLINE = OFF) ON [PRIMARY]
GO


