using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheDojoLeague.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dojos",
                columns: table => new
                {
                    DojoId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdditionalDojoInformation = table.Column<string>(nullable: false),
                    DojoLocation = table.Column<string>(nullable: false),
                    DojoName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dojos", x => x.DojoId);
                });

            migrationBuilder.CreateTable(
                name: "Ninjas",
                columns: table => new
                {
                    NinjaId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AssignedDojo = table.Column<string>(nullable: false),
                    DojoId = table.Column<int>(nullable: false),
                    NinjaName = table.Column<string>(nullable: false),
                    NinjaingLevel = table.Column<int>(nullable: false),
                    OptionalDescription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ninjas", x => x.NinjaId);
                    table.ForeignKey(
                        name: "FK_Ninjas_Dojos_DojoId",
                        column: x => x.DojoId,
                        principalTable: "Dojos",
                        principalColumn: "DojoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ninjas_DojoId",
                table: "Ninjas",
                column: "DojoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ninjas");

            migrationBuilder.DropTable(
                name: "Dojos");
        }
    }
}
