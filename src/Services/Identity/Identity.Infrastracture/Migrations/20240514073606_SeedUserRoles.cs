using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

#pragma warning disable IDE0161 // Convert to file-scoped namespace
namespace Identity.Infrastracture.Migrations
#pragma warning restore IDE0161 // Convert to file-scoped namespace
{
    /// <inheritdoc />
    public partial class SeedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
#pragma warning disable SA1118 // Parameter should not span multiple lines
            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "c7b013f0-5201-4317-abd8-c211f91b7330", "0078F440-C7A4-4445-94C0-350F23700AA0" },
                    { "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", "40F21EAF-2807-4EF3-8506-84FAF53A2190" },
                    { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" },
                });
#pragma warning restore SA1118 // Parameter should not span multiple lines

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0078F440-C7A4-4445-94C0-350F23700AA0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dc106e91-1f18-4869-8479-e5fe8454056f", "AQAAAAIAAYagAAAAEIB3T/RuJB+Ek1mYT9upC1XQ8rWzVJl/M7L25q13sQ0+jLRiM34LOBNypo/UHh/HHg==", "2f9380cb-8c5f-4ae5-9f8e-7a08f9fb285b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40F21EAF-2807-4EF3-8506-84FAF53A2190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7ee23b93-b180-45f8-8f73-50459b5938c7", "AQAAAAIAAYagAAAAEGmYDNEGcDVMtrh+l66cQMDEtLUwbMzc/+s+N4ROUTARIMFIhpZ0Yfc8TIRlfHu/Yg==", "7a35116a-9128-4d01-919e-c1354f652dde" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7eb494d3-7a6b-4916-be8a-c5deec89e9f6", "AQAAAAIAAYagAAAAELmNIuyGUPA653GUDYtx4n1hdH+lbr5FHJGV/ypD/TeC7F5l7eH7EyKPyY7zpj3aIQ==", "f2d4a8b1-0a86-4d77-8531-682942e4c02c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7b013f0-5201-4317-abd8-c211f91b7330", "0078F440-C7A4-4445-94C0-350F23700AA0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "C262F33A-0F33-4B7B-9DB7-7581AEA78EAB", "40F21EAF-2807-4EF3-8506-84FAF53A2190" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fab4fac1-c546-41de-aebc-a14da6895711", "b74ddd14-6340-4840-95c2-db12554843e5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0078F440-C7A4-4445-94C0-350F23700AA0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43fffa33-f937-40d3-b89d-256c83a21b32", "AQAAAAIAAYagAAAAELewYGnLSv5GzI209vDzBayH+GrLCenKAgc12loaesUzicKj54Fh56nqxHGotFivSw==", "1e22cc16-ce28-4b88-9eae-606732014699" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40F21EAF-2807-4EF3-8506-84FAF53A2190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3e6f9eaa-193d-4724-8b0d-c476e7f47eef", "AQAAAAIAAYagAAAAEN1EJBW/YIeoZzhIFDFImger36YE3PekLXQstveBVpNMvan3z6WjwQi4AF3MWCbBMA==", "31e86946-0681-41fd-91d9-aad59f0687fb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4e873f95-7d22-44a8-baa5-69725a346e9f", "AQAAAAIAAYagAAAAEEPeyoIdmp6AZCjsj1WXlQzA2NSdFAEfbvtdhfnMpcQPjZNxZftijueTQglSGEI1Zw==", "fa4c10eb-ac26-429b-8d34-4a18eff8a017" });
        }
    }
}
