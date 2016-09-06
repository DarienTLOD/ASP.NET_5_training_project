using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace TrainingProject.Migrations
{
    public partial class addedCountryModelInApplicationDBContextRemoveMistake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_Country_CountryId", schema: "dbo", table: "City");
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.DropColumn(name: "CountryId", schema: "dbo", table: "City");
            migrationBuilder.AddColumn<int>(
                name: "CountryId1",
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
            migrationBuilder.AddForeignKey(
                name: "FK_State_Country_CountryId1",
                schema: "dbo",
                table: "State",
                column: "CountryId1",
                principalSchema: "dbo",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.DropForeignKey(name: "FK_State_Country_CountryId1", schema: "dbo", table: "State");
            migrationBuilder.DropColumn(name: "CountryId1", schema: "dbo", table: "State");
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                schema: "dbo",
                table: "City",
                nullable: true);
            migrationBuilder.AddForeignKey(
                name: "FK_City_Country_CountryId",
                schema: "dbo",
                table: "City",
                column: "CountryId",
                principalSchema: "dbo",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
