using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DynamicFormBuilder.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFormFieldForLabelType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FieldType",
                table: "FormFields",
                newName: "SelectedLabelType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SelectedLabelType",
                table: "FormFields",
                newName: "FieldType");
        }
    }
}
