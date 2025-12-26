using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class EditedFeatureTableAndDeletedFeature2Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features2");

            migrationBuilder.RenameColumn(
                name: "Post1Image",
                table: "Features",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "Post1Description",
                table: "Features",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Features",
                newName: "Post1Image");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Features",
                newName: "Post1Description");

            migrationBuilder.CreateTable(
                name: "Features2",
                columns: table => new
                {
                    FeatureID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Image = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features2", x => x.FeatureID);
                });
        }
    }
}
