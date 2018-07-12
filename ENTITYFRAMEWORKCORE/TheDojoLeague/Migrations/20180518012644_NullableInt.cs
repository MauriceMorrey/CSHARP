using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheDojoLeague.Migrations
{
    public partial class NullableInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas");

            migrationBuilder.AlterColumn<int>(
                name: "DojoId",
                table: "Ninjas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas",
                column: "DojoId",
                principalTable: "Dojos",
                principalColumn: "DojoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas");

            migrationBuilder.AlterColumn<int>(
                name: "DojoId",
                table: "Ninjas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ninjas_Dojos_DojoId",
                table: "Ninjas",
                column: "DojoId",
                principalTable: "Dojos",
                principalColumn: "DojoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
