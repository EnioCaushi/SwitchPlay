using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SwitchPlay.Migrations
{
    /// <inheritdoc />
    public partial class roleChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "moderatorId", null, "moderator", "moderator" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "beba2c39-db8e-49d1-84f5-330347ba171e", "AQAAAAIAAYagAAAAENTTo7im8Id/hv+kSgvCweQanZi8kBfWfs4+WyJNNEfPp19zUh11uu8hr9pScFpFqw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "moderatorId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a18be9c0-aa65-4af8-bd17-00bd9344e575",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "269c51a9-77d4-4ad6-9e4b-45dd8dec0681", "AQAAAAIAAYagAAAAEBMChX9FLGHAvYfcxHuh8kqCKVdbfEP9emOsCpOblgngVpJI6t2YSOBo2A5TDIOnzA==" });
        }
    }
}
