using Microsoft.EntityFrameworkCore.Migrations;

namespace AlkatreszRaktar.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alkatresz",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Gyarto = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Tipus = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BeszerzesiAr = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alkatresz", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alkatresz");
        }
    }
}
