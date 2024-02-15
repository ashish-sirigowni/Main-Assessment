using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Main_Assessment.Migrations
{
    public partial class MainAssessmentAshishagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conferences",
                columns: table => new
                {
                    ConferenceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserID = table.Column<string>(type: "char(5)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conferences", x => x.ConferenceID);
                    table.ForeignKey(
                        name: "FK_Conferences_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conferences_UserID",
                table: "Conferences",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conferences");
        }
    }
}
