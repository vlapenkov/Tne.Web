using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tne.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChidOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Address = table.Column<string>(maxLength: 200, nullable: true),
                    OrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChidOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChidOrganizations_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObjectOfConsumption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ChidOrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObjectOfConsumption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObjectOfConsumption_ChidOrganizations_ChidOrganizationId",
                        column: x => x.ChidOrganizationId,
                        principalTable: "ChidOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointOfInstallation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    MaxVolume = table.Column<int>(nullable: false),
                    ObjectOfConsumptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointOfInstallation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointOfInstallation_ObjectOfConsumption_ObjectOfConsumptionId",
                        column: x => x.ObjectOfConsumptionId,
                        principalTable: "ObjectOfConsumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PointsOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    ObjectOfConsumptionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PointsOfMeasure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PointsOfMeasure_ObjectOfConsumption_ObjectOfConsumptionId",
                        column: x => x.ObjectOfConsumptionId,
                        principalTable: "ObjectOfConsumption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AbstractCounter",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CheckDate = table.Column<DateTime>(type: "date", nullable: false),
                    PointOfMeasureId = table.Column<int>(nullable: false),
                    ItemType = table.Column<int>(nullable: false),
                    CounterType = table.Column<int>(nullable: true),
                    CurrentTransformatorType = table.Column<int>(nullable: true),
                    Ktt = table.Column<int>(nullable: true),
                    VoltageTransformator_CurrentTransformatorType = table.Column<int>(nullable: true),
                    VoltageTransformator_Ktt = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbstractCounter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbstractCounter_PointsOfMeasure_PointOfMeasureId",
                        column: x => x.PointOfMeasureId,
                        principalTable: "PointsOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeteringDevices",
                columns: table => new
                {
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PointOfMeasureId = table.Column<int>(nullable: false),
                    PointOfInstallationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeteringDevices", x => new { x.StartDate, x.PointOfMeasureId, x.PointOfInstallationId });
                    table.UniqueConstraint("AK_MeteringDevices_PointOfInstallationId_PointOfMeasureId_StartDate", x => new { x.PointOfInstallationId, x.PointOfMeasureId, x.StartDate });
                    table.ForeignKey(
                        name: "FK_MeteringDevices_PointOfInstallation_PointOfInstallationId",
                        column: x => x.PointOfInstallationId,
                        principalTable: "PointOfInstallation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MeteringDevices_PointsOfMeasure_PointOfMeasureId",
                        column: x => x.PointOfMeasureId,
                        principalTable: "PointsOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "Volokolamskiy 111", "First" });

            migrationBuilder.InsertData(
                table: "ChidOrganizations",
                columns: new[] { "Id", "Address", "Name", "OrganizationId" },
                values: new object[] { 1, "first", "Child1", 1 });

            migrationBuilder.InsertData(
                table: "ChidOrganizations",
                columns: new[] { "Id", "Address", "Name", "OrganizationId" },
                values: new object[] { 2, "second", "Child2", 1 });

            migrationBuilder.InsertData(
                table: "ChidOrganizations",
                columns: new[] { "Id", "Address", "Name", "OrganizationId" },
                values: new object[] { 3, "third", "Child3", 1 });

            migrationBuilder.InsertData(
                table: "ObjectOfConsumption",
                columns: new[] { "Id", "ChidOrganizationId", "Name" },
                values: new object[] { 1, 1, "1/1 object" });

            migrationBuilder.InsertData(
                table: "ObjectOfConsumption",
                columns: new[] { "Id", "ChidOrganizationId", "Name" },
                values: new object[] { 2, 1, "2/1 object" });

            migrationBuilder.InsertData(
                table: "ObjectOfConsumption",
                columns: new[] { "Id", "ChidOrganizationId", "Name" },
                values: new object[] { 3, 1, "1/1 object" });

            migrationBuilder.InsertData(
                table: "PointOfInstallation",
                columns: new[] { "Id", "MaxVolume", "Name", "ObjectOfConsumptionId" },
                values: new object[,]
                {
                    { 1, 100, "1 point of i", 1 },
                    { 2, 200, "2 point of i", 2 },
                    { 3, 500, "3 point of i", 3 }
                });

            migrationBuilder.InsertData(
                table: "PointsOfMeasure",
                columns: new[] { "Id", "Name", "ObjectOfConsumptionId" },
                values: new object[,]
                {
                    { 1, "1 point of m", 1 },
                    { 2, "2 point of m", 1 },
                    { 3, "3 point of m", 2 },
                    { 4, "4 point of m", 2 },
                    { 5, "5 point of m", 3 },
                    { 6, "6 point of m", 3 },
                    { 7, "7 point of m", 3 }
                });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CounterType" },
                values: new object[] { 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CurrentTransformatorType", "Ktt" },
                values: new object[] { 4, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "VoltageTransformator_CurrentTransformatorType", "VoltageTransformator_Ktt" },
                values: new object[] { 7, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 0, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CounterType" },
                values: new object[] { 2, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, 1 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CurrentTransformatorType", "Ktt" },
                values: new object[] { 5, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 0, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "VoltageTransformator_CurrentTransformatorType", "VoltageTransformator_Ktt" },
                values: new object[] { 8, new DateTime(2019, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 0, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CounterType" },
                values: new object[] { 3, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 2 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "CurrentTransformatorType", "Ktt" },
                values: new object[] { 6, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, 0, 0 });

            migrationBuilder.InsertData(
                table: "AbstractCounter",
                columns: new[] { "Id", "CheckDate", "ItemType", "PointOfMeasureId", "VoltageTransformator_CurrentTransformatorType", "VoltageTransformator_Ktt" },
                values: new object[] { 9, new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, 0, 0 });

            migrationBuilder.InsertData(
                table: "MeteringDevices",
                columns: new[] { "StartDate", "PointOfMeasureId", "PointOfInstallationId", "EndDate" },
                values: new object[,]
                {
                    { new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 1, null },
                    { new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null },
                    { new DateTime(2017, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 3, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new DateTime(2018, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbstractCounter_PointOfMeasureId",
                table: "AbstractCounter",
                column: "PointOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ChidOrganizations_OrganizationId",
                table: "ChidOrganizations",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_MeteringDevices_PointOfMeasureId",
                table: "MeteringDevices",
                column: "PointOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_ObjectOfConsumption_ChidOrganizationId",
                table: "ObjectOfConsumption",
                column: "ChidOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_PointOfInstallation_ObjectOfConsumptionId",
                table: "PointOfInstallation",
                column: "ObjectOfConsumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PointsOfMeasure_ObjectOfConsumptionId",
                table: "PointsOfMeasure",
                column: "ObjectOfConsumptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbstractCounter");

            migrationBuilder.DropTable(
                name: "MeteringDevices");

            migrationBuilder.DropTable(
                name: "PointOfInstallation");

            migrationBuilder.DropTable(
                name: "PointsOfMeasure");

            migrationBuilder.DropTable(
                name: "ObjectOfConsumption");

            migrationBuilder.DropTable(
                name: "ChidOrganizations");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
