using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable IDE0161 // Convert to file-scoped namespace
namespace Identity.Infrastracture.Migrations
#pragma warning restore IDE0161 // Convert to file-scoped namespace
{
    /// <inheritdoc />
    public partial class UPdatedConnectionString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0078F440-C7A4-4445-94C0-350F23700AA0",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a7984d8-c5bb-4e2a-8f6a-a9a61640f9da", "AQAAAAIAAYagAAAAEIqaKWji2QzUzXqm16VBiO3L2wZ9B/MK7+SLVjkt5I7m58jKlRFFF64utesPqWJXNQ==", "667ea889-6c11-439f-941e-65728145603a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40F21EAF-2807-4EF3-8506-84FAF53A2190",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b17dd54-2015-4b3a-8569-58d24bbb64a8", "AQAAAAIAAYagAAAAECIs68aO6P5K3mjiY732H7X3oyD9fNP8zKkOKOZHePaFbnWwJ3r1FhXE1gyJ/UkVuw==", "e1248bb0-0846-4214-936f-bac08c2f153d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b74ddd14-6340-4840-95c2-db12554843e5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f5e440ba-fa2b-4c12-9539-a8d8a13f376c", "AQAAAAIAAYagAAAAEC/ZLyQjfrXKoMGZNPzG4dsAAHb8yFR6gHxeUc1slxrjIMnln1ioN06OEFMy8WeYtw==", "2cba336e-7a6f-4d70-899a-7abcbf21bcd3" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
