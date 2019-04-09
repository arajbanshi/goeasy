/****** Object:  StoredProcedure [dbo].[getGreenCabStatistics]    Script Date: 4/9/2019 3:01:56 AM ******/
DROP PROCEDURE [dbo].[getGreenCabStatistics]
GO

/****** Object:  StoredProcedure [dbo].[getGreenCabStatistics]    Script Date: 4/9/2019 3:01:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getGreenCabStatistics]
	@fromLocationId int,
	@toLocationId int,
	@date datetime=null
as
BEGIN
	declare @GreenStatisticsTable TABLE
	(
		PickupDateTime datetime,
		DropOffDateTime datetime,
		DayOfTheWeek varchar(50),
		PartOfTheDay varchar(50),
		PickUpHour int,
		TimeTaken decimal,
		PassangerCount int,
		TripDistance decimal,
		TotalAmount decimal,
		TipAmount decimal,
		TollAmount decimal
	)

	insert into @GreenStatisticsTable
		select 
		PickupDateTime, 
		DropOffDateTime, 
		DATENAME(WEEKDAY, PickupDateTime) as DayOfTheWeek,
		 CASE   
			  WHEN DATEPART (HH, PickupDateTime)  between 00 and 12  THEN 'Morning'   
			  WHEN DATEPART (HH, PickupDateTime) between 12 and 18 THEN 'Afternoon'
			  Else 'Evening'   
		   END   as TimeOfDay,
		DATEPART (HH, PickupDateTime) as PickUpHour,
		DATEDIFF (mi,PickupDateTime,DropOffDateTime) as TimeTaken,
		PassangerCount,
		CAST(TripDistance as decimal),
		CAST(TotalAmount as decimal),
		CAST(TipAmount as decimal),
		CAST(TollsAmount as decimal)
		from [dbo].[GreenTripData] 
		where PickupLocationId = @fromLocationId  and DropOffLocationId = @toLocationId

		if @date is not null
		begin
			declare @GreenStatisticsTableByDate TABLE
			(
				PickupDateTime datetime,
				DropOffDateTime datetime,
				DayOfTheWeek varchar(50),
				PartOfTheDay varchar(50),
				PickUpHour int,
				TimeTaken decimal,
				PassangerCount int,
				TripDistance decimal,
				TotalAmount decimal,
				TipAmount decimal,
				TollAmount decimal
			)

			insert into @GreenStatisticsTableByDate
			select * from @GreenStatisticsTable where DayOfTheWeek = DATENAME(WEEKDAY, @date)
			
			delete from @GreenStatisticsTable

			insert into @GreenStatisticsTable
			select * from @GreenStatisticsTableByDate
		end
		
	declare @rowCount int = (select count(*) from @GreenStatisticsTable)
	
	declare @totalTimeTaken decimal
	declare @totalCost decimal
	declare @totalTip decimal
	declare @totalDistance decimal
	declare @totalTollAmount decimal
	declare @totalPassangerCount int

	select @totalTimeTaken = sum(TimeTaken) from @GreenStatisticsTable
	select @totalCost = sum(TotalAmount) from @GreenStatisticsTable
	select @totalTip = sum(TipAmount) from @GreenStatisticsTable
	select @totalDistance = sum(TripDistance) from @GreenStatisticsTable
	select @totalTollAmount = sum(TollAmount) from @GreenStatisticsTable
	select @totalPassangerCount = sum(PassangerCount) from @GreenStatisticsTable

	declare @from varchar(100) = (select (Borough + '(' + TaxiZone + ')') from [dbo].[TaxiZones] where Id = @fromLocationId)
	declare @to varchar(100) = (select (Borough + '(' + TaxiZone + ')') from [dbo].[TaxiZones] where Id = @toLocationId)
	declare @cost decimal = @totalCost / @rowCount
	declare @timetaken decimal = @totalTimeTaken / @rowCount
	declare @distance decimal = @totalDistance / @rowCount
	declare @avgPassangerCount int = @totalPassangerCount / @rowCount
	declare @avgTip decimal = @totalTip / @rowCount
	declare @avgTollAmount decimal = @totalTollAmount / @rowCount

	declare @morningTrips int = (select count(*) from @GreenStatisticsTable where PartOfTheDay = 'Morning')
	declare @afternoonTrips int = (select count(*) from @GreenStatisticsTable where PartOfTheDay = 'Afternoon')
	declare @eveningTrips int = (select count(*) from @GreenStatisticsTable where PartOfTheDay = 'Evening')

	declare @mondayTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Monday')
	declare @tuesdayTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Tuesday')
	declare @wednesdatTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Wednesday')
	declare @thursdayTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Thursday')
	declare @fridayTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Friday')
	declare @saturdayTrips int = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Saturday')
	declare @sundayTrips int  = (select count(*) from @GreenStatisticsTable where DayOfTheWeek = 'Sunday')

	select 
		@from as [From], 
		@to as [To], 
		isnull(@cost,0) as [AverageCost], 
		isnull(@timetaken,0) as [AverageTime], 
		isnull(@distance,0) as [AverageDistance],
		isnull(@avgPassangerCount,0) as [AveragePassangerCount],
		isnull(@avgTip,0) as [AverageTip],
		isnull(@avgTollAmount,0) as [AverageTollAmount],
		@morningTrips as [MorningTripsCount],
		@afternoonTrips as [AfternoonTripsCount],
		@eveningTrips as [EveningTripsCount],
		@mondayTrips as [MondayTripsCount],
		@tuesdayTrips as [TuesdayTripsCount],
		@wednesdatTrips as [WednesdayTripsCount],
		@thursdayTrips as [ThursdayTripsCount],
		@fridayTrips as [FridayTripsCount],
		@saturdayTrips as [SaturdayTripsCount],
		@sundayTrips as [SundayTripsCount]
END
GO


