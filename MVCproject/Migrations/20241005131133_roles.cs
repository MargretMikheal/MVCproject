using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCproject.Migrations
{
    /// <inheritdoc />
    public partial class roles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
