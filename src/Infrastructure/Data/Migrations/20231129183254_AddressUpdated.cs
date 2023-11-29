using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddressUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress_State",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_District",
                table: "Orders",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShippingAddress_District",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "ShippingAddress_State",
                table: "Orders",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: true);
        }
    }
}
