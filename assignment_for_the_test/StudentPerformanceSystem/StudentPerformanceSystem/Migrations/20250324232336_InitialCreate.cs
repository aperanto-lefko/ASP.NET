using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentPerformanceSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Group = table.Column<string>(type: "TEXT", nullable: false),
                    TaskPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    TestPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    ExamPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "EnrollmentDate", "ExamPoints", "FirstName", "Group", "LastName", "TaskPoints", "TestPoints" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 25, 2, 23, 35, 224, DateTimeKind.Local).AddTicks(1948), 80, "Иван", "ИТ-101", "Иванов", 85, 90 },
                    { 2, new DateTime(2025, 3, 25, 2, 23, 35, 226, DateTimeKind.Local).AddTicks(4984), 70, "Петр", "ИТ-101", "Петров", 75, 80 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
