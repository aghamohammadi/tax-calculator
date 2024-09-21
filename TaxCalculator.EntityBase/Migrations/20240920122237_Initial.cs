using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaxCalculator.EntityBase.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CityTaxRule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    HasSingleChargeRule = table.Column<bool>(type: "bit", nullable: false),
                    SingleChargeWindowInMinutes = table.Column<int>(type: "int", nullable: false),
                    MaxAmountPerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityTaxRule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityTaxRule_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Holiday",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    ExemptDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsExemptBeforeHoliday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holiday", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holiday_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MonthTaxExemption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthTaxExemption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthTaxExemption_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxAmount",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAmount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxAmount_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleExemption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleExemption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleExemption_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeekendDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekendDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeekendDay_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "Country", "Name" },
                values: new object[] { 1, "Sweden", "Gothenburg" });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "LicensePlate", "VehicleType" },
                values: new object[,]
                {
                    { 1, "EMG-001", "Emergency" },
                    { 2, "EMG-002", "Emergency" },
                    { 3, "BUS-001", "Busses" },
                    { 4, "BUS-002", "Busses" },
                    { 5, "DPL-001", "Diplomat" },
                    { 6, "DPL-002", "Diplomat" },
                    { 7, "MTR-001", "Motorcycles" },
                    { 8, "MTR-002", "Motorcycles" },
                    { 9, "MLT-001", "Military" },
                    { 10, "MLT-002", "Military" },
                    { 11, "FRG-001", "Foreign" },
                    { 12, "FRG-002", "Foreign" },
                    { 13, "FRG-003", "Foreign" },
                    { 14, "FRG-004", "Foreign" },
                    { 15, "FRG-005", "Foreign" },
                    { 16, "PRV-001", "Cars" },
                    { 17, "PRV-002", "Cars" },
                    { 18, "PRV-003", "Cars" },
                    { 19, "PKP-001", "Trucks" },
                    { 20, "PKP-002", "Trucks" },
                    { 21, "VAN-001", "Vans" },
                    { 22, "VAN-002", "Vans" },
                    { 23, "TRK-001", "Trucks" },
                    { 24, "TRK-002", "Trucks" },
                    { 25, "LUX-001", "Cars" }
                });

            migrationBuilder.InsertData(
                table: "CityTaxRule",
                columns: new[] { "Id", "CityId", "HasSingleChargeRule", "MaxAmountPerDay", "SingleChargeWindowInMinutes", "Year" },
                values: new object[] { 1, 1, true, 60m, 60, 2013 });

            migrationBuilder.InsertData(
                table: "Holiday",
                columns: new[] { "Id", "CityId", "ExemptDate", "IsExemptBeforeHoliday" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2013, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 2, 1, new DateTime(2013, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 3, 1, new DateTime(2013, 2, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 4, 1, new DateTime(2013, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 5, 1, new DateTime(2013, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), true },
                    { 6, 1, new DateTime(2013, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), true }
                });

            migrationBuilder.InsertData(
                table: "MonthTaxExemption",
                columns: new[] { "Id", "CityId", "Month", "Year" },
                values: new object[] { 1, 1, 7, 2013 });

            migrationBuilder.InsertData(
                table: "TaxAmount",
                columns: new[] { "Id", "Amount", "CityId", "EndTime", "StartTime", "Year" },
                values: new object[,]
                {
                    { 1, 8m, 1, new TimeOnly(6, 29, 0), new TimeOnly(6, 0, 0), 2013 },
                    { 2, 13m, 1, new TimeOnly(6, 59, 0), new TimeOnly(6, 30, 0), 2013 },
                    { 3, 18m, 1, new TimeOnly(7, 59, 0), new TimeOnly(7, 0, 0), 2013 },
                    { 4, 13m, 1, new TimeOnly(8, 29, 0), new TimeOnly(8, 0, 0), 2013 },
                    { 5, 8m, 1, new TimeOnly(14, 59, 0), new TimeOnly(8, 30, 0), 2013 },
                    { 6, 13m, 1, new TimeOnly(15, 29, 0), new TimeOnly(15, 0, 0), 2013 },
                    { 7, 18m, 1, new TimeOnly(16, 59, 0), new TimeOnly(15, 30, 0), 2013 },
                    { 8, 13m, 1, new TimeOnly(17, 59, 0), new TimeOnly(17, 0, 0), 2013 },
                    { 9, 8m, 1, new TimeOnly(18, 29, 0), new TimeOnly(18, 0, 0), 2013 },
                    { 10, 0m, 1, new TimeOnly(5, 59, 0), new TimeOnly(18, 30, 0), 2013 }
                });

            migrationBuilder.InsertData(
                table: "VehicleExemption",
                columns: new[] { "Id", "CityId", "VehicleType" },
                values: new object[,]
                {
                    { 1, 1, "Emergency" },
                    { 2, 1, "Busses" },
                    { 3, 1, "Diplomat" },
                    { 4, 1, "Motorcycles" },
                    { 5, 1, "Military" },
                    { 6, 1, "Foreign" }
                });

            migrationBuilder.InsertData(
                table: "WeekendDay",
                columns: new[] { "Id", "CityId", "DayOfWeek" },
                values: new object[,]
                {
                    { 1, 1, 6 },
                    { 2, 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityTaxRule_CityId",
                table: "CityTaxRule",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Holiday_CityId",
                table: "Holiday",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthTaxExemption_CityId",
                table: "MonthTaxExemption",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxAmount_CityId",
                table: "TaxAmount",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleExemption_CityId",
                table: "VehicleExemption",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekendDay_CityId",
                table: "WeekendDay",
                column: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CityTaxRule");

            migrationBuilder.DropTable(
                name: "Holiday");

            migrationBuilder.DropTable(
                name: "MonthTaxExemption");

            migrationBuilder.DropTable(
                name: "TaxAmount");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleExemption");

            migrationBuilder.DropTable(
                name: "WeekendDay");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
