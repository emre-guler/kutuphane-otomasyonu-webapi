using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryProjectBackend.Data.Migrations
{
    public partial class M1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    tcId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminAccounts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookName = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    bookPage = table.Column<string>(nullable: true),
                    lentState = table.Column<int>(nullable: false),
                    deleteState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BookUsers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookId = table.Column<int>(nullable: false),
                    customerId = table.Column<int>(nullable: false),
                    giveBook = table.Column<DateTime>(nullable: false),
                    receiveBook = table.Column<DateTime>(nullable: false),
                    state = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUsers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserAccounts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fullname = table.Column<string>(nullable: true),
                    tcId = table.Column<int>(nullable: false),
                    deleteState = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAccounts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminAccounts");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "BookUsers");

            migrationBuilder.DropTable(
                name: "UserAccounts");
        }
    }
}
