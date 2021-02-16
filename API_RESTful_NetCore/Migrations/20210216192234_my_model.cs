using Microsoft.EntityFrameworkCore.Migrations;

namespace API_RESTful_NetCore.Migrations
{
    public partial class my_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    pro_codigo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    pro_nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pro_descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pro_precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.pro_codigo);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
