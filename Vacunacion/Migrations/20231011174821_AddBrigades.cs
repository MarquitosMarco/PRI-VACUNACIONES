using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vacunacion.Migrations
{
    /// <inheritdoc />
    public partial class AddBrigades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brigade_Campaign_CampaignId",
                table: "Brigade");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Person",
                newName: "PersonID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Campaign",
                newName: "CampaignId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Brigade",
                newName: "BrigadeId");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Brigade",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Brigade_Campaign_CampaignId",
                table: "Brigade",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brigade_Campaign_CampaignId",
                table: "Brigade");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "PersonID",
                table: "Person",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                table: "Campaign",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BrigadeId",
                table: "Brigade",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CampaignId",
                table: "Brigade",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Brigade_Campaign_CampaignId",
                table: "Brigade",
                column: "CampaignId",
                principalTable: "Campaign",
                principalColumn: "Id");
        }
    }
}
