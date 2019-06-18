using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WebApplication1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "administration");

            migrationBuilder.EnsureSchema(
                name: "Market");

            migrationBuilder.CreateSequence(
                name: "pk1_Account",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pk1_Client",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pk1_ClientType",
                incrementBy: 10);


            migrationBuilder.CreateTable(
                name: "Account",
                schema: "administration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientType",
                schema: "administration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id);
                });


            migrationBuilder.CreateTable(
                name: "Client",
                schema: "administration",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ClientTypeId = table.Column<long>(nullable: false),
                    RetailClientId = table.Column<long>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByUserId = table.Column<long>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<long>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false),
                    Group = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalSchema: "administration",
                        principalTable: "ClientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Account_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "administration",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_RetailClient_RetailClientId",
                        column: x => x.RetailClientId,
                        principalSchema: "Market",
                        principalTable: "RetailClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Account_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalSchema: "administration",
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                schema: "Market",
                table: "RetailClient",
                columns: new[] { "Id", "Description", "MarketSiteCode", "Name" },
                values: new object[,]
                {
                    { 1L, "Tesco UK", "Tesco_UK", "TescoUK" },
                    { 2L, "Exito Colombia", "CCO", "ExitoCO" }
                });

            migrationBuilder.InsertData(
                schema: "administration",
                table: "Account",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 1L, "mayankgg@dunnhumby.com", "mayankgg" },
                    { 2L, "system@dunnhumby.com", "system" }
                });

            migrationBuilder.InsertData(
                schema: "administration",
                table: "ClientType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Retailer" },
                    { 2L, "Dunnhumby" },
                    { 3L, "Supplier" }
                });

            migrationBuilder.InsertData(
                schema: "administration",
                table: "Client",
                columns: new[] { "Id", "ClientTypeId", "CreatedByUserId", "CreatedDate", "Description", "Group", "IsArchived", "Name", "RetailClientId", "UpdatedByUserId", "UpdatedDate" },
                values: new object[,]
                {
                    { 1L, 1L, 1L, null, "Tesco UK", null, false, "Tesco UK", 1L, 1L, null },
                    { 2L, 2L, 1L, null, "Tesco UK", null, false, "Dunnhumby", 1L, 1L, null },
                    { 3L, 1L, 1L, null, "Exito CO", null, false, "Exio CO", 2L, 1L, null },
                    { 4L, 2L, 1L, null, "Exito CO", null, false, "Dunnhumby", 2L, 1L, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                schema: "administration",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Name",
                schema: "administration",
                table: "Account",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                schema: "administration",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreatedByUserId",
                schema: "administration",
                table: "Client",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RetailClientId",
                schema: "administration",
                table: "Client",
                column: "RetailClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UpdatedByUserId",
                schema: "administration",
                table: "Client",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "ClientType",
                schema: "administration");

            migrationBuilder.DropTable(
                name: "Account",
                schema: "administration");

            migrationBuilder.DropSequence(
                name: "pk1_Account");

            migrationBuilder.DropSequence(
                name: "pk1_Client");

            migrationBuilder.DropSequence(
                name: "pk1_ClientType");
        }
    }
}
