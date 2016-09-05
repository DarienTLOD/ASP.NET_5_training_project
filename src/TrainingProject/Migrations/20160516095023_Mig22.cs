using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TrainingProject.Migrations
{
    public partial class Mig22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", table: "City");
            migrationBuilder.EnsureSchema("dbo");
            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                schema: "dbo",
                table: "City",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameTable(
                name: "State",
                newSchema: "dbo");
            migrationBuilder.RenameTable(
                name: "City",
                newSchema: "dbo");
            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                newSchema: "dbo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                table: "City",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameTable(
                name: "State",
                schema: "dbo");
            migrationBuilder.RenameTable(
                name: "City",
                schema: "dbo");
            migrationBuilder.RenameTable(
                name: "ApplicationUser",
                schema: "dbo");
        }
    }
}
