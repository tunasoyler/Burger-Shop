using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(1400),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(4763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 22, DateTimeKind.Local).AddTicks(8869),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(9534));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 22, DateTimeKind.Local).AddTicks(8459),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(9329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(9969),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(9256),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(6982));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(4763),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(1400));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(9534),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 22, DateTimeKind.Local).AddTicks(8869));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(9329),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 22, DateTimeKind.Local).AddTicks(8459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(7182),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(9969));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 4, 23, 45, 26, 502, DateTimeKind.Local).AddTicks(6982),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 4, 23, 53, 3, 21, DateTimeKind.Local).AddTicks(9256));
        }
    }
}
