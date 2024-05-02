using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Infrastructure.Migrations
{
    public partial class MigrationCorrectionTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdLoan",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdLoan",
                table: "Books");
        }
    }
}