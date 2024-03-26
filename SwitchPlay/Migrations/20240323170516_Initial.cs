using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlay.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "269c51a9-77d4-4ad6-9e4b-45dd8dec0681", "AQAAAAIAAYagAAAAEBMChX9FLGHAvYfcxHuh8kqCKVdbfEP9emOsCpOblgngVpJI6t2YSOBo2A5TDIOnzA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd734717-fb35-4ec9-9fa2-492c2782c84d", "AQAAAAIAAYagAAAAEC9h4EgIL/xm6fBSFaLUzwR52alyi+Twrzn8Ohrmhb/LEmI2QXiFXt9gQkKRTBJ0Fw==" });
        }
    }
}
