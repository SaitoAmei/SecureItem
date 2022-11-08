using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureItem.Migrations
{
    public partial class Creating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegritySecureData",
                columns: table => new
                {
                    dangerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameOfAsset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssetCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Danger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerAncor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DangerAction = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegritySecureData", x => x.dangerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passwors = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegritySecureData");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
