using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCproject.Migrations
{
    /// <inheritdoc />
    public partial class changePhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "77bc2b5e-3e46-469a-bc63-deb23cbc1b6c");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ab9dff5b-7920-4ed7-8f05-9607b46748e9", "da3946e5-0043-4eef-b6cc-7551a5f2395a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ab9dff5b-7920-4ed7-8f05-9607b46748e9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "da3946e5-0043-4eef-b6cc-7551a5f2395a");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0384ff9a-19fa-4c5c-892a-fdc8c8e6c5b4", null, "User", "USER" },
                    { "835fc8f9-b044-44cc-a7b3-e6e1590c7d08", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d924a152-4abb-41d1-a600-8562e1f356a5", 0, "cario", "46c19eb3-0c6d-4a18-acab-5f9fa48b66a8", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEO82MvktOapXhy6Db+zNBxSGR/h6Z1gyDI5wfvtDf+WafGs+D8TXmsQ0SA3YVCy1vA==", null, false, null, "", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "835fc8f9-b044-44cc-a7b3-e6e1590c7d08", "d924a152-4abb-41d1-a600-8562e1f356a5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0384ff9a-19fa-4c5c-892a-fdc8c8e6c5b4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "835fc8f9-b044-44cc-a7b3-e6e1590c7d08", "d924a152-4abb-41d1-a600-8562e1f356a5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "835fc8f9-b044-44cc-a7b3-e6e1590c7d08");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d924a152-4abb-41d1-a600-8562e1f356a5");

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "77bc2b5e-3e46-469a-bc63-deb23cbc1b6c", null, "User", "USER" },
                    { "ab9dff5b-7920-4ed7-8f05-9607b46748e9", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "da3946e5-0043-4eef-b6cc-7551a5f2395a", 0, "cario", "1118c515-3940-46c3-bfa1-c493882e560a", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJdjGwV730K19pLg+OkQmlmGfSPxOd51H3K84BQ5m6pSmDwcb4Lp44wq3DaWKhUH1Q==", null, false, null, "", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ab9dff5b-7920-4ed7-8f05-9607b46748e9", "da3946e5-0043-4eef-b6cc-7551a5f2395a" });
        }
    }
}
