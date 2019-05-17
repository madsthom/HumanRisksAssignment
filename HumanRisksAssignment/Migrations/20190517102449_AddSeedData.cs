using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanRisksAssignment.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), 57.054516999999997, 9.9093795999999994, "Risk Assessment 1" });

            migrationBuilder.InsertData(
                table: "RiskAssessments",
                columns: new[] { "Id", "Latitude", "Longitude", "Title" },
                values: new object[] { new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"), 57.035969700000003, 9.9329561999999996, "Risk Assessment 2" });

            migrationBuilder.InsertData(
                table: "Threats",
                columns: new[] { "Id", "Level", "RiskAssessmentId", "Title" },
                values: new object[,]
                {
                    { new Guid("f494a1b1-aac9-411a-8ba4-a673828854b0"), 0, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "Some threat" },
                    { new Guid("6213d44f-57b9-4e57-883e-c041b6cde84d"), 2, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "Some other threat" },
                    { new Guid("97f497eb-d909-42a2-b67c-8074c7f88491"), 2, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "This is a threat" },
                    { new Guid("f3a0920a-c5c6-4655-bc61-f25faaa5770f"), 1, new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"), "Some failure threat" },
                    { new Guid("390a5ad4-80ff-492f-9565-04883f9c80bc"), 1, new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"), "Some unknown threat" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: new Guid("390a5ad4-80ff-492f-9565-04883f9c80bc"));

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: new Guid("6213d44f-57b9-4e57-883e-c041b6cde84d"));

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: new Guid("97f497eb-d909-42a2-b67c-8074c7f88491"));

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: new Guid("f3a0920a-c5c6-4655-bc61-f25faaa5770f"));

            migrationBuilder.DeleteData(
                table: "Threats",
                keyColumn: "Id",
                keyValue: new Guid("f494a1b1-aac9-411a-8ba4-a673828854b0"));

            migrationBuilder.DeleteData(
                table: "RiskAssessments",
                keyColumn: "Id",
                keyValue: new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"));

            migrationBuilder.DeleteData(
                table: "RiskAssessments",
                keyColumn: "Id",
                keyValue: new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"));
        }
    }
}
