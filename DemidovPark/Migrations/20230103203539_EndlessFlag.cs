using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemidovPark.Migrations
{
    public partial class EndlessFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Endless",
                schema: "u1790493_1",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endless",
                schema: "u1790493_1",
                table: "Contracts");
        }
    }
}
