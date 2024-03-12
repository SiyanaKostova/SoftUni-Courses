using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskBoard.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Boards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Board identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, comment: "Board name")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false, comment: "Task identifier")
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: false, comment: "Task title"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Task description"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true, comment: "Date of creation"),
                    BoardId = table.Column<int>(type: "int", nullable: true, comment: "Board identifier"),
                    OwnerId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Application user identifier")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Boards_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Boards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2d51160e-3cb5-428d-9582-8484b972bcc8", 0, "2450d5ed-e7fe-49b4-bc66-68684e310418", null, false, false, null, null, "TEST@SOFTUNI.BG", "AQAAAAEAACcQAAAAEAKNLHBuq5VB/oBGj5fqQlXXlRE+AF0pm+mcFlxuucRiJtZ2LiADNBiG7LVwwyxj3Q==", null, false, "64b1821c-a7d9-4f46-9766-71bcfb52062a", false, "test@softuni.bg" });

            migrationBuilder.InsertData(
                table: "Boards",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Open" },
                    { 2, "In Progress" },
                    { 3, "Done" }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "BoardId", "CreatedOn", "Description", "OwnerId", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 7, 23, 19, 8, 26, 905, DateTimeKind.Local).AddTicks(3675), "Implement better styling for all public pages", "2d51160e-3cb5-428d-9582-8484b972bcc8", "Improve CSS styles" },
                    { 2, 1, new DateTime(2023, 9, 8, 19, 8, 26, 905, DateTimeKind.Local).AddTicks(3711), "Create Android client app for the TaskBoard RESTful API", "2d51160e-3cb5-428d-9582-8484b972bcc8", "Android Client App" },
                    { 3, 2, new DateTime(2024, 1, 8, 19, 8, 26, 905, DateTimeKind.Local).AddTicks(3715), "Create Windows Forms desktop app client for the TaskBoard RESTful API", "2d51160e-3cb5-428d-9582-8484b972bcc8", "Desktop Client App" },
                    { 4, 3, new DateTime(2023, 2, 8, 19, 8, 26, 905, DateTimeKind.Local).AddTicks(3717), "Implement [Create Task] page for adding new tasks", "2d51160e-3cb5-428d-9582-8484b972bcc8", "Create Tasks" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardId",
                table: "Tasks",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Boards");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2d51160e-3cb5-428d-9582-8484b972bcc8");
        }
    }
}
