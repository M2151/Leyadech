using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leyadech.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JoinDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FamilySize = table.Column<int>(type: "int", nullable: true),
                    ChildrenBelow7 = table.Column<int>(type: "int", nullable: true),
                    HelpKindNeeded = table.Column<int>(type: "int", nullable: true),
                    SpecialRequests = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsStandingOrder = table.Column<bool>(type: "bit", nullable: true),
                    Volunteer_Status = table.Column<int>(type: "int", nullable: true),
                    HelpKindSuggested = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aplication",
                columns: table => new
                {
                    ApplicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    HelpKind = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsRelevant = table.Column<bool>(type: "bit", nullable: false),
                    ApplicationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Frequency = table.Column<int>(type: "int", nullable: true),
                    UrgencyLevel = table.Column<int>(type: "int", nullable: true),
                    Preferences = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFlexible = table.Column<bool>(type: "bit", nullable: true),
                    Suggest_Frequency = table.Column<int>(type: "int", nullable: true),
                    RelevantDays = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aplication", x => x.ApplicationId);
                    table.ForeignKey(
                        name: "FK_Aplication_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteering",
                columns: table => new
                {
                    VolunteeringId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    SuggestId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HelpKind = table.Column<int>(type: "int", nullable: true),
                    HelpFrequency = table.Column<int>(type: "int", nullable: true),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TimeStart = table.Column<TimeSpan>(type: "time", nullable: true),
                    TimeEnd = table.Column<TimeSpan>(type: "time", nullable: true),
                    Feedback = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteering", x => x.VolunteeringId);
                    table.ForeignKey(
                        name: "FK_Volunteering_Aplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Aplication",
                        principalColumn: "ApplicationId");
                    table.ForeignKey(
                        name: "FK_Volunteering_Aplication_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Aplication",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Volunteering_Aplication_SuggestId",
                        column: x => x.SuggestId,
                        principalTable: "Aplication",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aplication_UserId",
                table: "Aplication",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteering_ApplicationId",
                table: "Volunteering",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteering_RequestId",
                table: "Volunteering",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteering_SuggestId",
                table: "Volunteering",
                column: "SuggestId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteering");

            migrationBuilder.DropTable(
                name: "Aplication");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
