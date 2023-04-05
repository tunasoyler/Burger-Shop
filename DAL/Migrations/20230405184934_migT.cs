using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class migT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "Menus");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(731),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(715));

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(6212),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 440, DateTimeKind.Local).AddTicks(443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(6001),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 440, DateTimeKind.Local).AddTicks(221));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(3869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(3665),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(4224));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(715),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 440, DateTimeKind.Local).AddTicks(443),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(6212));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 440, DateTimeKind.Local).AddTicks(221),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(6001));

            migrationBuilder.AddColumn<int>(
                name: "Size",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(5445),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(3869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 5, 20, 56, 29, 439, DateTimeKind.Local).AddTicks(4224),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 5, 21, 49, 34, 367, DateTimeKind.Local).AddTicks(3665));
        }
    }
}
