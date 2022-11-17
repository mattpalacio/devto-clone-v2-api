using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DevtoCloneV2.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JoinedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "JoinedDate", "Username" },
                values: new object[,]
                {
                    { 1, "matt@email.com", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9757), "matt" },
                    { 2, "patrick@email.com", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9759), "patrick" },
                    { 3, "anne@email.com", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9759), "anne" }
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "Content", "CreatedDate", "Title", "UserId" },
                values: new object[,]
                {
                    { 1, "This is the first blog post.", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9813), "Blog Post #1", 1 },
                    { 2, "This is the second blog post.", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9814), "Blog Post #2", 1 },
                    { 3, "This is the third blog post.", new DateTime(2022, 11, 17, 20, 30, 47, 838, DateTimeKind.Utc).AddTicks(9815), "Blog Post #3", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_UserId",
                table: "Blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
