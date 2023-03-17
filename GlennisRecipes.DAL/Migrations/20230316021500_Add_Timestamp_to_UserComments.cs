using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlennisRecipes.DAL.Migrations
{
    public partial class Add_Timestamp_to_UserComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "TimeStamp",
                table: "UserComments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe86bb9-bf7e-46ec-a5b9-b29d38929611",
                column: "ConcurrencyStamp",
                value: "20d55b1a-65d1-4df0-8959-7c9945d1a00e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa50541c-0c35-40f5-a071-0f0aed68403c", "AQAAAAEAACcQAAAAEJijkdeRNILZvZb4xczYaKvV3Q5iTTjhMmGx0a7bKaPRXGzMlaG9Iz/u4VbPe4449Q==", "311f0867-8bbc-4ee8-9db6-544fce84078b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81139b48-6c24-4fc8-ad72-6c1423608d83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4833c39-62b7-49f8-9114-fbdf5cb65edd", "AQAAAAEAACcQAAAAEB99+y9twnlkSTl1RWosjdjZfbtbEIvOiq0vN0723vJL1iDFuy8JJED8RdFPPsMV5g==", "ab6b60e2-4ca5-4ad1-a8cf-d69913e9d5fc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b93270-4150-4411-a54b-6521de4a49aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "372cc357-10ac-4c55-a554-f342b78d641d", "AQAAAAEAACcQAAAAEEreG0o+fVHKiL00lv+sqIi2+jG5P0cu23ctPGCkG0bJyPbtHV2HJ8JF4uk+vOF8aA==", "187dfc08-b970-4741-9c3c-25f05dd4d9c7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fc9b9eb9-b3c9-41d7-94f7-38459cb017c2", "AQAAAAEAACcQAAAAELuQW0nINHyz72HAHe0erjiAF3u8UfsYEmWqrF8ZXgEuLe0cyOdyGXNMDEfRTMWhlg==", "58ad7aea-5014-4298-9f04-0cc4786e439d" });

            migrationBuilder.UpdateData(
                table: "UserComments",
                keyColumn: "Id",
                keyValue: "6d721ff4-8c3e-4d01-9ae9-a80310ecd988",
                column: "TimeStamp",
                value: new DateTime(2023, 3, 15, 22, 37, 50, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "UserComments");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe86bb9-bf7e-46ec-a5b9-b29d38929611",
                column: "ConcurrencyStamp",
                value: "968d9eb4-b2e3-49d7-87bf-ffa3fe3264c9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0c13a7c-7ee3-44be-8480-812407c86ace", "AQAAAAEAACcQAAAAEBXjZGn1q2pxtESReNiNgliUSfKsTFzN0ItgeHbHhWFNdVswgBBe0iXTSnzckfG5hA==", "f7e1adb6-969a-4dc2-8d5c-33c59d53238e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81139b48-6c24-4fc8-ad72-6c1423608d83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3360c207-67a1-47c9-834f-d116a57a7b44", "AQAAAAEAACcQAAAAEB0mPll/84h3Z1EAZeD14OjzUVtI0Mx+EUx35Yz3UYdTJer2a1z2xK5uoou/QptNPw==", "9d8f4d73-705f-496d-a804-2c0334fd15f9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b93270-4150-4411-a54b-6521de4a49aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f00decd4-c379-45b4-b767-a8684baa22fa", "AQAAAAEAACcQAAAAENQcSjJm5l8f5fyDPqk579BTmHHuOpPTwwmeEjfwRLyns6gshONfnF4R2YjMDCcV/Q==", "ddd6afd7-8eab-4cd2-87c9-2020586a3753" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "006d3d4d-425c-4aa7-80fe-044cbc1ccd47", "AQAAAAEAACcQAAAAEMZFovJ8EqI6EOcRZ6JEC/8IZTj0mM36euclwuTw2VNxLZUUgwFpldL2nUuH539dRw==", "12bf7e55-f527-4c05-9c92-7c2e8dbbd98a" });
        }
    }
}
