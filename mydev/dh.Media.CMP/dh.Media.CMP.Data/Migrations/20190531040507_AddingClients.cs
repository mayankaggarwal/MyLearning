using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;

namespace dh.Media.CMP.Data.Migrations
{
    public partial class AddingClients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "Id", "ClientTypeId", "CreatedByUserId", "CreatedDate", "Description", "Group", "IsArchived", "Name", "RetailClientId", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, 1, 1, null, "Tesco UK", null, false, "Tesco UK", 1, null, null },
                    { 2, 2, 1, null, "Tesco UK", null, false, "Dunnhumby", 1, null, null },
                    { 3, 1, 1, null, "Exito CO", null, false, "Exio CO", 2, null, null },
                    { 4, 2, 1, null, "Exito CO", null, false, "Dunnhumby", 2, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Client",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
