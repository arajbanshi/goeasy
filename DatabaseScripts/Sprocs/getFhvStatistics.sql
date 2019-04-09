/****** Object:  StoredProcedure [dbo].[getFhvStatistics]    Script Date: 4/9/2019 3:01:28 AM ******/
DROP PROCEDURE [dbo].[getFhvStatistics]
GO

/****** Object:  StoredProcedure [dbo].[getFhvStatistics]    Script Date: 4/9/2019 3:01:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[getFhvStatistics]
	@fromLocationId int,
	@toLocationId int,
	@date datetime=null
as
BEGIN
	declare @FhvStatisticsTable TABLE
	(
		PickupDateTime datetime,
		DropOffDateTime datetime,
		DayOfTheWeek varchar(50),
		PartOfTheDay varchar(50),
		PickUpHour int,
		TimeTaken decimal
	)

	insert into @FhvStatisticsTable
		select 
		PkpDateTime, 
		DropDateTime, 
		DATENAME(WEEKDAY, PkpDateTime) as DayOfTheWeek,
		 CASE   
			  WHEN DATEPART (HH, PkpDateTime)  between 00 and 12  THEN 'Morning'   
			  WHEN DATEPART (HH, PkpDateTime) between 12 and 18 THEN 'Afternoon'
			  Else 'Evening'   
		   END   as TimeOfDay,
		DATEPART (HH, PkpDateTime) as PickUpHour,
		DATEDIFF (mi,PkpDateTime,DropDateTime) as TimeTaken
		from [dbo].[FhvTripData] 
		where PkpLocationId = @fromLocationId  and DropLocationId = @toLocationId

		if @date is not null
		begin
			declare @FhvStatisticsTableByDate TABLE
			(
				PickupDateTime datetime,
				DropOffDateTime datetime,
				DayOfTheWeek varchar(50),
				PartOfTheDay varchar(50),
				PickUpHour int,
				TimeTaken decimal
			)

			insert into @FhvStatisticsTableByDate
			select * from @FhvStatisticsTable where DayOfTheWeek = DATENAME(WEEKDAY, @date)
			
			delete from @FhvStatisticsTable

			insert into @FhvStatisticsTable
			select * from @FhvStatisticsTableByDate
		end
		
	declare @rowCount int = (select count(*) from @FhvStatisticsTable)
	
	declare @totalTimeTaken decimal 
	select @totalTimeTaken = sum(TimeTaken) from @FhvStatisticsTable

	declare @from varchar(100) = (select (Borough + '(' + TaxiZone + ')') from [dbo].[TaxiZones] where Id = @fromLocationId)
	declare @to varchar(100) = (select (Borough + '(' + TaxiZone + ')') from [dbo].[TaxiZones] where Id = @toLocationId)
	declare @cost decimal = 0.0
	declare @timetaken decimal = @totalTimeTaken / @rowCount
	declare @distance decimal = 0.0
	declare @avgPassangerCount int = 0.0
	declare @avgTip decimal = 0.0
	declare @avgTollAmount decimal = 0.0

	declare @morningTrips int = (select count(*) from @FhvStatisticsTable where PartOfTheDay = 'Morning')
	declare @afternoonTrips int = (select count(*) from @FhvStatisticsTable where PartOfTheDay = 'Afternoon')
	declare @eveningTrips int = (select count(*) from @FhvStatisticsTable where PartOfTheDay = 'Evening')

	declare @mondayTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Monday')
	declare @tuesdayTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Tuesday')
	declare @wednesdatTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Wednesday')
	declare @thursdayTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Thursday')
	declare @fridayTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Friday')
	declare @saturdayTrips int = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Saturday')
	declare @sundayTrips int  = (select count(*) from @FhvStatisticsTable where DayOfTheWeek = 'Sunday')

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


