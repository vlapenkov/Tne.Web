using System;
using Tne.Web;
using Tne.Web.Dal;

namespace Web.Api.IntegrationTests
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            dbContext.MeteringDevices.AddRange(new[] {
                new MeteringDevice { StartDate = new DateTime(2017, 01, 01), EndDate = new DateTime(2018, 01, 01), PointOfInstallationId = 1, PointOfMeasureId = 1 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02), PointOfInstallationId = 1, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2017, 01, 01), EndDate = new DateTime(2018, 01, 01), PointOfInstallationId = 2, PointOfMeasureId = 1 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02), PointOfInstallationId = 2, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2017, 01, 01), EndDate = new DateTime(2018, 01, 01), PointOfInstallationId = 3, PointOfMeasureId = 2 },
     new MeteringDevice { StartDate = new DateTime(2018, 01, 02), PointOfInstallationId = 3, PointOfMeasureId = 3 } }
                );
            dbContext.SaveChanges();
        }
    }
}