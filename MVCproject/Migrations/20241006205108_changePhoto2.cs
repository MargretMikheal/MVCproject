using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MVCproject.Migrations
{
    /// <inheritdoc />
    public partial class changePhoto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<byte[]>(
                name: "Photo",
                table: "Products",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "489dcc60-2452-4d69-98a0-13658c8dfd97", null, "Admin", "ADMIN" },
                    { "c42d53d5-513e-41f9-8c78-2d83eeb7daa5", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcfdd0a9-05e4-41ba-875a-2096b42d7b86", 0, "cario", "3b956b6d-018c-4a41-b56f-d5e1b35d51e8", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEJVehfp3WkxFKOI5H7DGxjYuuNH/PIWe2xWcCUMkhXLhE56KLdYda35g2lBwykbiSw==", null, false, null, "", false, "admin@example.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "489dcc60-2452-4d69-98a0-13658c8dfd97", "bcfdd0a9-05e4-41ba-875a-2096b42d7b86" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c42d53d5-513e-41f9-8c78-2d83eeb7daa5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "489dcc60-2452-4d69-98a0-13658c8dfd97", "bcfdd0a9-05e4-41ba-875a-2096b42d7b86" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "489dcc60-2452-4d69-98a0-13658c8dfd97");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcfdd0a9-05e4-41ba-875a-2096b42d7b86");

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
    }
}
