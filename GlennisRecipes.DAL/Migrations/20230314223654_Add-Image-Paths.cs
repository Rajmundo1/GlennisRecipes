using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GlennisRecipes.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePaths : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "0fccd974-5b7e-4157-887d-87ce146756e1",
                column: "ImagePath",
                value: "ChocolateCake202303142235021967.png");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "20bf6a09-4f7f-45c0-80df-defdfb494656",
                column: "ImagePath",
                value: "RedVelvetCake202303142234211747.png");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "604f5685-08d4-40a0-94a1-63f309bb07e7",
                column: "ImagePath",
                value: "LemonSpongeCake202303142234497511.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4fe86bb9-bf7e-46ec-a5b9-b29d38929611",
                column: "ConcurrencyStamp",
                value: "2fd44e77-ece5-4253-8620-3daf7ee6dfd6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7a0f0fc8-de75-4231-bca4-f02595b8fc22",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b3de81c8-4c77-4f5a-9bc9-529183ef2e34", "AQAAAAEAACcQAAAAEOR5ijcLEUUQDcVq5cX6cEOugcVoMtFZpKU7BcPIluN3dG9mazOUAUkYYB301/wrdA==", "22f06de7-a46a-4571-914b-bd218e4daf0b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "81139b48-6c24-4fc8-ad72-6c1423608d83",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9136f156-a628-4333-a4a7-6ae34d1f08d9", "AQAAAAEAACcQAAAAEN39HbGb2pg9QmF4kPKWxddr6SltiIdEVlCjEU6sR37/lfThibWsIRAlxSTcL5Xidw==", "39fa66b6-8b18-4486-8c9c-2fd273eddf93" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a8b93270-4150-4411-a54b-6521de4a49aa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7799d6ca-db6f-4a2d-86b1-4975830ca48d", "AQAAAAEAACcQAAAAEN9kFnNLrqg5xJAUogi8t2/DrUDTSvBGRoK3BYc/ug47X+CRLJZ3a0YqmaxAFd0BNQ==", "0628a652-2a60-4edc-9967-b464336d2c1f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b295bea7-efc3-42a7-8e26-ea3fd5c99ec6",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "03c23694-5ed3-4eb2-ae34-330278160b9f", "AQAAAAEAACcQAAAAEL6vR/x3q5tItCYZqY7uDszxtgsnbsBDLvItgMVrf21qorJjgS1F8iOBy3LZM+PmDQ==", "2e846cb8-40b1-4f89-b004-3b1d205027b1" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "0fccd974-5b7e-4157-887d-87ce146756e1",
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "20bf6a09-4f7f-45c0-80df-defdfb494656",
                column: "ImagePath",
                value: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: "604f5685-08d4-40a0-94a1-63f309bb07e7",
                column: "ImagePath",
                value: "");
        }
    }
}
