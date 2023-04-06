using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(205),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(3435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5755),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5569),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(9461));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3560),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(7439));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3344),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(7222));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraCategories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(343),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(120),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "ExtraCategories",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[] { 1, null, "Beverage", false });

            migrationBuilder.InsertData(
                table: "ExtraCategories",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[] { 2, null, "Snack", false });

            migrationBuilder.InsertData(
                table: "ExtraCategories",
                columns: new[] { "Id", "Description", "Name", "State" },
                values: new object[] { 3, null, "Sauce", false });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExtraCategories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExtraCategories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExtraCategories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "MemberSince",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(3435),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(205));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(9646),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Menus",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(9461),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(5569));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(7439),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "Extras",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 4, 6, 15, 52, 21, 392, DateTimeKind.Local).AddTicks(7222),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 447, DateTimeKind.Local).AddTicks(3344));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "ExtraCategories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModifiedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(343));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedTime",
                table: "ExtraCategories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 4, 6, 15, 56, 22, 448, DateTimeKind.Local).AddTicks(120));
        }
    }
}
