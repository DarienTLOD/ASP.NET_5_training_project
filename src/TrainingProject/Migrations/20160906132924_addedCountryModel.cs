using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TrainingProject.Migrations
{
    public partial class addedCountryModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                schema: "dbo",
                table: "State",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                schema: "dbo",
                table: "City",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.DropColumn(name: "CountryId", schema: "dbo", table: "State");
            migrationBuilder.AddForeignKey(
                name: "FK_City_State_StateId",
                schema: "dbo",
                table: "City",
                column: "StateId",
                principalSchema: "dbo",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
