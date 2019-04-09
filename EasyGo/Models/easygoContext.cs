using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EasyGo.Models
{
    public partial class easygoContext : DbContext
    {
        public easygoContext()
        {
        }

        public easygoContext(DbContextOptions<easygoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FhvTripData> FhvTripData { get; set; }
        public virtual DbSet<GreenTripData> GreenTripData { get; set; }
        public virtual DbSet<TaxiZones> TaxiZones { get; set; }
        public virtual DbSet<YellowTripData> YellowTripData { get; set; }

        public TripStatistics GetFhvTripStatistics(int fromLocationId, int toLocationId, DateTime? date)
        {
            var results = new List<TripStatistics>();

            using (var connection = this.Database.GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Connection = connection;

                cmd.CommandText = "dbo.getFhvStatistics";

                cmd.Parameters.Add(new SqlParameter("@fromLocationId", fromLocationId));
                cmd.Parameters.Add(new SqlParameter("@toLocationId", toLocationId));

                if (date.HasValue)
                    cmd.Parameters.Add(new SqlParameter("@date", date.Value));

                connection.Open();

                var reader = cmd.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new TripStatistics
                        {
                            AfternoonTripsCount = Convert.ToInt32(reader["AfternoonTripsCount"].ToString()),
                            AverageCost = Convert.ToDecimal(reader["AverageCost"].ToString()),
                            AverageDistance = Convert.ToDecimal(reader["AverageDistance"].ToString()),
                            AveragePassangerCount = Convert.ToInt32(reader["AveragePassangerCount"].ToString()),
                            AverageTime = Convert.ToDecimal(reader["AverageTime"].ToString()),
                            AverageTip = Convert.ToDecimal(reader["AverageTip"].ToString()),
                            AverageTollAmount = Convert.ToDecimal(reader["AverageTollAmount"].ToString()),
                            EveningTripsCount = Convert.ToInt32(reader["EveningTripsCount"].ToString()),
                            FridayTripsCount = Convert.ToInt32(reader["FridayTripsCount"].ToString()),
                            MondayTripsCount = Convert.ToInt32(reader["MondayTripsCount"].ToString()),
                            TuesdayTripsCount = Convert.ToInt32(reader["TuesdayTripsCount"].ToString()),
                            MorningTripsCount = Convert.ToInt32(reader["MorningTripsCount"].ToString()),
                            SaturdayTripsCount = Convert.ToInt32(reader["SaturdayTripsCount"].ToString()),
                            SundayTripsCount = Convert.ToInt32(reader["SundayTripsCount"].ToString()),
                            ThursdayTripsCount = Convert.ToInt32(reader["ThursdayTripsCount"].ToString()),
                            WednesdayTripsCount = Convert.ToInt32(reader["WednesdayTripsCount"].ToString()),
                            From = reader["From"].ToString(),
                            To = reader["To"].ToString()
                        });
                    }
                }

                reader.Close();
                connection.Close();
            }

            return results[0];
        }

        public TripStatistics GetGreenCabTripStatistics(int fromLocationId, int toLocationId, DateTime? date)
        {
            var results = new List<TripStatistics>();

            using (var connection = this.Database.GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Connection = connection;

                cmd.CommandText = "dbo.getGreenCabStatistics";

                cmd.Parameters.Add(new SqlParameter("@fromLocationId", fromLocationId));
                cmd.Parameters.Add(new SqlParameter("@toLocationId", toLocationId));

                if (date.HasValue)
                    cmd.Parameters.Add(new SqlParameter("@date", date.Value));

                connection.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new TripStatistics
                        {
                            AfternoonTripsCount = Convert.ToInt32(reader["AfternoonTripsCount"].ToString()),
                            AverageCost = Convert.ToDecimal(reader["AverageCost"].ToString()),
                            AverageDistance = Convert.ToDecimal(reader["AverageDistance"].ToString()),
                            AveragePassangerCount = Convert.ToInt32(reader["AveragePassangerCount"].ToString()),
                            AverageTime = Convert.ToDecimal(reader["AverageTime"].ToString()),
                            AverageTip = Convert.ToDecimal(reader["AverageTip"].ToString()),
                            AverageTollAmount = Convert.ToDecimal(reader["AverageTollAmount"].ToString()),
                            EveningTripsCount = Convert.ToInt32(reader["EveningTripsCount"].ToString()),
                            FridayTripsCount = Convert.ToInt32(reader["FridayTripsCount"].ToString()),
                            MondayTripsCount = Convert.ToInt32(reader["MondayTripsCount"].ToString()),
                            TuesdayTripsCount = Convert.ToInt32(reader["TuesdayTripsCount"].ToString()),
                            MorningTripsCount = Convert.ToInt32(reader["MorningTripsCount"].ToString()),
                            SaturdayTripsCount = Convert.ToInt32(reader["SaturdayTripsCount"].ToString()),
                            SundayTripsCount = Convert.ToInt32(reader["SundayTripsCount"].ToString()),
                            ThursdayTripsCount = Convert.ToInt32(reader["ThursdayTripsCount"].ToString()),
                            WednesdayTripsCount = Convert.ToInt32(reader["WednesdayTripsCount"].ToString()),
                            From = reader["From"].ToString(),
                            To = reader["To"].ToString()
                        });
                    }
                }

                reader.Close();
                connection.Close();
            }

            return results[0];
        }

        public TripStatistics GetYellowCabTripStatistics(int fromLocationId, int toLocationId, DateTime? date)
        {
            var results = new List<TripStatistics>();

            using (var connection = this.Database.GetDbConnection())
            {
                var cmd = connection.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Connection = connection;

                cmd.CommandText = "dbo.getYellowCabStatistics";

                cmd.Parameters.Add(new SqlParameter("@fromLocationId", fromLocationId));
                cmd.Parameters.Add(new SqlParameter("@toLocationId", toLocationId));

                if (date.HasValue)
                    cmd.Parameters.Add(new SqlParameter("@date", date.Value));

                connection.Open();

                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        results.Add(new TripStatistics
                        {
                            AfternoonTripsCount = Convert.ToInt32(reader["AfternoonTripsCount"].ToString()),
                            AverageCost = Convert.ToDecimal(reader["AverageCost"].ToString()),
                            AverageDistance = Convert.ToDecimal(reader["AverageDistance"].ToString()),
                            AveragePassangerCount = Convert.ToInt32(reader["AveragePassangerCount"].ToString()),
                            AverageTime = Convert.ToDecimal(reader["AverageTime"].ToString()),
                            AverageTip = Convert.ToDecimal(reader["AverageTip"].ToString()),
                            AverageTollAmount = Convert.ToDecimal(reader["AverageTollAmount"].ToString()),
                            EveningTripsCount = Convert.ToInt32(reader["EveningTripsCount"].ToString()),
                            FridayTripsCount = Convert.ToInt32(reader["FridayTripsCount"].ToString()),
                            MondayTripsCount = Convert.ToInt32(reader["MondayTripsCount"].ToString()),
                            TuesdayTripsCount = Convert.ToInt32(reader["TuesdayTripsCount"].ToString()),
                            MorningTripsCount = Convert.ToInt32(reader["MorningTripsCount"].ToString()),
                            SaturdayTripsCount = Convert.ToInt32(reader["SaturdayTripsCount"].ToString()),
                            SundayTripsCount = Convert.ToInt32(reader["SundayTripsCount"].ToString()),
                            ThursdayTripsCount = Convert.ToInt32(reader["ThursdayTripsCount"].ToString()),
                            WednesdayTripsCount = Convert.ToInt32(reader["WednesdayTripsCount"].ToString()),
                            From = reader["From"].ToString(),
                            To = reader["To"].ToString()
                        });
                    }
                }

                reader.Close();
                connection.Close();
            }

            return results[0];
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FhvTripData>(entity =>
            {
                entity.Property(e => e.DispatchBaseNum)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DispatchingBaseNum)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DropDateTime).HasColumnType("datetime");

                entity.Property(e => e.DropOffDateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DropOffLocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickupDateTime)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PickupLocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PkpDateTime).HasColumnType("datetime");

                entity.Property(e => e.SrFlag)
                    .HasColumnName("SR_Flag")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Srflag1).HasColumnName("SRFlag");
            });

            modelBuilder.Entity<GreenTripData>(entity =>
            {
                entity.Property(e => e.DropOffDateTime).HasColumnType("datetime");

                entity.Property(e => e.EhailFee)
                    .HasColumnName("EHailFee")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Extra)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FareAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ImprovementSurcharge)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MtaTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PickupDateTime).HasColumnType("datetime");

                entity.Property(e => e.StoreAndForwardFlag)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TollsAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TripDistance)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TripType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TaxiZones>(entity =>
            {
                entity.Property(e => e.Borough)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId)
                    .IsRequired()
                    .HasColumnName("LocationID")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceZone)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.TaxiZone)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<YellowTripData>(entity =>
            {
                entity.Property(e => e.DropOffDateTime).HasColumnType("datetime");

                entity.Property(e => e.Extra)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FareAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ImprovementSurcharge)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MtaTax)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PickupDateTime).HasColumnType("datetime");

                entity.Property(e => e.StoreAndForwardFlag)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TollsAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TripDistance)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.VendorId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}
