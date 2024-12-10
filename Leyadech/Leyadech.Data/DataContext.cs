using Leyadech.Core.Entities;
using Leyadech.Data.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Formats.Asn1;
using System.Globalization;
using System.Text.Json;

namespace Leyadech.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Mother> MotherData { get; set; }
        public DbSet<Volunteer> VolunteerData { get; set; }
        public DbSet<Request> RequestData { get; set; }
        public DbSet<Suggest> SuggestData { get; set; }
        public DbSet<Volunteering> VolunteeringData { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(mesege => Console.WriteLine(":::"+mesege));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(m => m.JoinDate)
                     .HasConversion<DateOnlyConverter, DateOnlyComparer>();
                entity.HasDiscriminator<string>("UserType")    
                     .HasValue<User>("User")              
                     .HasValue<Mother>("Mother")             
                     .HasValue<Volunteer>("Volunteer");
               
            });

            modelBuilder.Entity<Mother>(entity =>
            {
                entity.Property(m => m.BirthDate)
                      .HasConversion<DateOnlyConverter, DateOnlyComparer>();

                entity.Property(m => m.SpecialRequests)
                      .HasConversion(
                          v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                          v => JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions()))
                      .Metadata.SetValueComparer(
                          new ValueComparer<List<string>>(
                          (c1, c2) => c1.SequenceEqual(c2), // Compare two lists
                          c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Generate hash code
                          c => c.ToList())); // Create a deep copy

            });
            modelBuilder.Entity<Application>(entity =>
            {
                entity.HasDiscriminator<string>("ApplicationType")
                    .HasValue<Application>("Application")
                    .HasValue<Request>("Request")
                    .HasValue<Suggest>("Suggest");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(r => r.Preferences)
                    .HasConversion(
                         v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                         v => JsonSerializer.Deserialize<List<string>>(v, new JsonSerializerOptions()))
                    .Metadata.SetValueComparer(
                       new ValueComparer<List<string>>(
                       (c1, c2) => c1.SequenceEqual(c2), // Compare two lists
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Generate hash code
                       c => c.ToList())); // Create a deep copy
            });


            modelBuilder.Entity<Suggest>(entity =>
            {
                entity.Property(s => s.RelevantDays)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, new JsonSerializerOptions()),
                        v => JsonSerializer.Deserialize<List<DayOfWeek>>(v, new JsonSerializerOptions()))
                    .Metadata.SetValueComparer(
                       new ValueComparer<List<DayOfWeek>>(
                       (c1, c2) => c1.SequenceEqual(c2), // Compare two lists
                       c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Generate hash code
                       c => c.ToList())); // Create a deep copy
            });


            modelBuilder.Entity<Volunteering>(entity =>
            {
                entity.Property(v => v.DateStart)
                      .HasConversion<DateOnlyConverter, DateOnlyComparer>();

                entity.Property(v => v.DateEnd)
                      .HasConversion<DateOnlyConverter, DateOnlyComparer>();

                entity.Property(v => v.TimeStart)
                      .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();

                entity.Property(v => v.TimeEnd)
                      .HasConversion<TimeOnlyConverter, TimeOnlyComparer>();
            });
        }

    }
}
