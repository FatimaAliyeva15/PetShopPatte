using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetShopPatte_Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPetPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Pets",
                type: "decimal(18,2)",
                maxLength: 18,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Pets");
        }
    }
}
