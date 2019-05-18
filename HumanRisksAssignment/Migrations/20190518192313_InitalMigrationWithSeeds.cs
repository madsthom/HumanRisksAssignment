using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HumanRisksAssignment.Migrations
{
    public partial class InitalMigrationWithSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RiskAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Latitude = table.Column<double>(nullable: false),
                    Longitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RiskAssessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Threats",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    RiskAssessmentId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Threats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Threats_RiskAssessments_RiskAssessmentId",
                        column: x => x.RiskAssessmentId,
                        principalTable: "RiskAssessments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("8f2f4c20-a879-4928-b20f-5df458cd9537"), 0, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "Some threat" },
                    { new Guid("7ade31c9-f01d-4911-883b-b267bf28ad73"), 1, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "Some other threat" },
                    { new Guid("4659c06b-e658-49bf-888a-2c557ef90deb"), 2, new Guid("fddce38a-25cc-45d2-b4a0-1a9bae75fa7f"), "This is a threat" },
                    { new Guid("f30241a5-8891-470c-a18e-07bbb42af44d"), 0, new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"), "Some failure threat" },
                    { new Guid("ad359c38-932c-4564-993c-45b8b098cbe1"), 1, new Guid("32ca327a-8fee-44f4-9401-2304ca6b55ad"), "Some unknown threat" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Threats_RiskAssessmentId",
                table: "Threats",
                column: "RiskAssessmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Threats");

            migrationBuilder.DropTable(
                name: "RiskAssessments");
        }
    }
}
