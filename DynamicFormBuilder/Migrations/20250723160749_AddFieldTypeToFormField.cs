using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicFormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class AddFieldTypeToFormField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FieldType",
                table: "FormFields",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FieldType",
                table: "FormFields");
        }
    }
}
