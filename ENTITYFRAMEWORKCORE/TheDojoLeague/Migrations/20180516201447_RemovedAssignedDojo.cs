using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TheDojoLeague.Migrations
{
    public partial class RemovedAssignedDojo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedDojo",
                table: "Ninjas");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedDojo",
                table: "Ninjas",
                nullable: false,
                defaultValue: "");
        }
    }
}
