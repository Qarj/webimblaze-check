using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webimblaze_check.Migrations
{
    public partial class DelaySeconds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipe",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cuisine",
                table: "Recipe",
                maxLength: 24,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DelaySeconds",
                table: "Recipe",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DelaySeconds",
                table: "Recipe");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 60);

            migrationBuilder.AlterColumn<string>(
                name: "Cuisine",
                table: "Recipe",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 24);
        }
    }
}
