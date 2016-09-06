using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Metadata;

namespace TrainingProject.Migrations
{
    public partial class addedCountryModelInApplicationDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.CreateTable(
                name: "Country",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });
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
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_City_Country_CountryId", schema: "dbo", table: "City");
            migrationBuilder.DropForeignKey(name: "FK_City_State_StateId", schema: "dbo", table: "City");
            migrationBuilder.DropColumn(name: "CountryId", schema: "dbo", table: "City");
            migrationBuilder.DropTable(name: "Country", schema: "dbo");
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
