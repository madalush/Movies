using Microsoft.EntityFrameworkCore.Migrations;

namespace Seminar2.Migrations
{
    public partial class addedWatched : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "watched",
                table: "Movies",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "watched",
                table: "Movies");
        }
    }
}
