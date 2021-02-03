using Microsoft.EntityFrameworkCore.Migrations;

namespace MiBahia_Estate.Data.Migrations
{
    public partial class refacturingDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CoinType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoinType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyType",
                columns: table => new
                {
                    id = table.Column<bool>(type: "bit", nullable: false),
                    type = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Property",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    PropertyTypeID = table.Column<bool>(type: "bit", nullable: false),
                    title = table.Column<string>(type: "varchar(80)", unicode: false, maxLength: 80, nullable: false),
                    description = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    area = table.Column<decimal>(type: "decimal(13,2)", nullable: false),
                    outstanding = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Property", x => x.id);
                    table.ForeignKey(
                        name: "Inmueble_TipoInmueble_fk",
                        column: x => x.PropertyTypeID,
                        principalTable: "PropertyType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BuildingSite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    pricePerMeter = table.Column<decimal>(type: "decimal(13,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingSite", x => x.id);
                    table.ForeignKey(
                        name: "Property_BuildingSite_fk",
                        column: x => x.id,
                        principalTable: "Property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    bathrooms = table.Column<int>(type: "int", nullable: false),
                    rooms = table.Column<int>(type: "int", nullable: false),
                    serviceRoom = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    Gym = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))"),
                    washingArea = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "((0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.id);
                    table.ForeignKey(
                        name: "Property_House_fk",
                        column: x => x.id,
                        principalTable: "Property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyAddress",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyid = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "varchar(120)", unicode: false, maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyAddress", x => x.id);
                    table.ForeignKey(
                        name: "PropertyAddress_fk",
                        column: x => x.propertyid,
                        principalTable: "Property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPhotos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    propertyid = table.Column<int>(type: "int", nullable: false),
                    photopath = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPhotos", x => x.id);
                    table.ForeignKey(
                        name: "PropertyPhotos_fk",
                        column: x => x.propertyid,
                        principalTable: "Property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropertyPrice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinId = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<int>(type: "int", nullable: false),
                    priceNotes = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyPrice", x => x.id);
                    table.ForeignKey(
                        name: "PropertyPrice_fk",
                        column: x => x.id,
                        principalTable: "Property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Property_PropertyTypeID",
                table: "Property",
                column: "PropertyTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyAddress_propertyid",
                table: "PropertyAddress",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyPhotos_propertyid",
                table: "PropertyPhotos",
                column: "propertyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingSite");

            migrationBuilder.DropTable(
                name: "CoinType");

            migrationBuilder.DropTable(
                name: "House");

            migrationBuilder.DropTable(
                name: "PropertyAddress");

            migrationBuilder.DropTable(
                name: "PropertyPhotos");

            migrationBuilder.DropTable(
                name: "PropertyPrice");

            migrationBuilder.DropTable(
                name: "Property");

            migrationBuilder.DropTable(
                name: "PropertyType");
        }
    }
}
