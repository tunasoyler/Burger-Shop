using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class InitBeste060423 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(7385),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(7134),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(4770),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(4522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 446, DateTimeKind.Local).AddTicks(4618),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 446, DateTimeKind.Local).AddTicks(4396),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(120));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(376));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(7385));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5569),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(7134));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(4770));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 445, DateTimeKind.Local).AddTicks(4522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 446, DateTimeKind.Local).AddTicks(4618));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 22, 17, 59, 446, DateTimeKind.Local).AddTicks(4396));
        }
    }
}
