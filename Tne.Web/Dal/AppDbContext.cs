using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Tne.Web.Dal;

namespace Tne.Web
{
    public class AppDbContext :DbContext
    {
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<ChidOrganization> ChidOrganizations { get; set; }
        public DbSet<ObjectOfConsumption> ObjectOfConsumption { get; set; }
        public DbSet<PointOfMeasure> PointsOfMeasure { get; set; }
        public DbSet<PointOfInstallation> PointOfInstallation { get; set; }
        public DbSet<MeteringDevice> MeteringDevices { get; set; }


        public DbSet<Counter> Counters { get; set; }
        public DbSet<CurrentTransformator> CurrentTransformators { get; set; }
        public DbSet<VoltageTransformator> VoltageTransformators { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

       
        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<AbstractCounter>()
     .HasDiscriminator<int>("ItemType")
     .HasValue<Counter>(1)
     .HasValue<CurrentTransformator>(2)
     .HasValue<VoltageTransformator>(3);

            builder.Entity<MeteringDevice>(

            ).HasKey(c => new { c.StartDate, c.PointOfMeasureId, c.PointOfInstallationId });

            builder.Entity<MeteringDevice>().HasOne(pom => pom.PointOfMeasure).WithMany(b => b.Records).HasForeignKey(pom => pom.PointOfMeasureId).
                OnDelete(DeleteBehavior.Restrict);
            builder.Entity<MeteringDevice>().HasOne(pom => pom.PointOfInstallation).WithMany(b => b.Records).HasForeignKey(pom => pom.PointOfInstallationId).
                OnDelete(DeleteBehavior.Restrict);




            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
   

            builder.Entity<Organization>().HasData(
        new Organization
        {
            Id = 1,
            Name = "First",
            Address = "Volokolamskiy 111",

        });


            builder.Entity<ChidOrganization>().HasData(
        new ChidOrganization {Id=1, OrganizationId = 1, Name="Child1", Address= "first" },
        new ChidOrganization { Id = 2, OrganizationId = 1, Name = "Child2", Address = "second" },
        new ChidOrganization { Id = 3, OrganizationId = 1, Name = "Child3", Address = "third" }    );


            builder.Entity<ObjectOfConsumption>().HasData(
        new ObjectOfConsumption { Id = 1, ChidOrganizationId=1,Name="1/1 object" },
        new ObjectOfConsumption { Id = 2, ChidOrganizationId = 1, Name = "2/1 object" },
        new ObjectOfConsumption { Id = 3, ChidOrganizationId = 1, Name = "1/1 object" });


            builder.Entity<PointOfMeasure>().HasData(
      new PointOfMeasure { Id = 1, Name = "1 point of m", ObjectOfConsumptionId = 1 },
      new PointOfMeasure { Id = 2, Name = "2 point of m", ObjectOfConsumptionId = 1 },
      new PointOfMeasure { Id = 3, Name = "3 point of m", ObjectOfConsumptionId = 2 },
      new PointOfMeasure { Id = 4, Name = "4 point of m", ObjectOfConsumptionId = 2 },
      new PointOfMeasure { Id = 5, Name = "5 point of m", ObjectOfConsumptionId = 3 },
      new PointOfMeasure { Id = 6, Name = "6 point of m", ObjectOfConsumptionId = 3 },
      new PointOfMeasure { Id = 7, Name = "7 point of m", ObjectOfConsumptionId = 3 });


            builder.Entity<PointOfInstallation>().HasData(
      new PointOfInstallation { Id = 1, Name = "1 point of i", ObjectOfConsumptionId = 1 , MaxVolume=100},
      new PointOfInstallation { Id = 2, Name = "2 point of i", ObjectOfConsumptionId = 2, MaxVolume = 200 },
      new PointOfInstallation { Id = 3, Name = "3 point of i", ObjectOfConsumptionId = 3, MaxVolume = 500 });


            builder.Entity<Counter>().HasData(
      new Counter { Id = 1, CounterType = CounterType.First, CheckDate = new System.DateTime(2018, 01, 01), PointOfMeasureId = 1 }, // 1 объект - просрочен
      new Counter { Id = 2, CounterType = CounterType.Second, CheckDate = new System.DateTime(2019, 01, 01), PointOfMeasureId = 2 }, // 1 объект - НЕ просрочен
      new Counter { Id = 3, CounterType = CounterType.Third, CheckDate = new System.DateTime(2017, 01, 01), PointOfMeasureId = 3 }); // 2 объект - просрочен


            builder.Entity<CurrentTransformator>().HasData(
      new CurrentTransformator { Id = 4, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2018, 01, 01), PointOfMeasureId = 1 }, // 1 объект - просрочен
      new CurrentTransformator { Id = 5, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2019, 01, 01), PointOfMeasureId = 2 }, // 1 объект - НЕ просрочен
      new CurrentTransformator { Id = 6, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2017, 01, 01), PointOfMeasureId = 3 }); // 2 объект -  просрочен


            builder.Entity<VoltageTransformator>().HasData(
      new VoltageTransformator { Id = 7, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2018, 01, 01), PointOfMeasureId = 1 },
      new VoltageTransformator { Id = 8, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2019, 01, 01), PointOfMeasureId = 2 },
      new VoltageTransformator { Id = 9, CurrentTransformatorType = TransformatorType.First2, CheckDate = new System.DateTime(2017, 01, 01), PointOfMeasureId = 3 });


            builder.Entity<MeteringDevice>().HasData(
     new MeteringDevice {StartDate= new DateTime(2017, 01, 01) ,EndDate= new DateTime(2018, 01, 01),PointOfInstallationId=1,PointOfMeasureId=1 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02),  PointOfInstallationId = 1, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2017, 01, 01), EndDate = new DateTime(2018, 01, 01), PointOfInstallationId = 2, PointOfMeasureId = 1 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02), PointOfInstallationId = 2, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2017, 01, 01), EndDate = new DateTime(2018, 01, 01), PointOfInstallationId = 3, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02), PointOfInstallationId = 3, PointOfMeasureId = 3 }
     );


        }
    }
}