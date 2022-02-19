using Microsoft.EntityFrameworkCore.Migrations;

namespace dijak.Data.Migrations
{
    public partial class eso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NobelDij",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Evszam = table.Column<int>(type: "int", nullable: false),
                    Tipus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeresztNev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VezetekNev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NobelDij", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NobelDij");
        }
    }
}
