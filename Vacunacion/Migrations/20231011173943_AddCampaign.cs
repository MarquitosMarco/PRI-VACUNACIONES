using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacunacion.Migrations
{
    /// <inheritdoc />
    public partial class AddCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCampaign",
                table: "Brigade");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCampaign",
                table: "Brigade",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
