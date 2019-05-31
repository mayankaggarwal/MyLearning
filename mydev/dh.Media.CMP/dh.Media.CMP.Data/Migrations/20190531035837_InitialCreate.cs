using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace dh.Media.CMP.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "pk1_Account",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pk1_Client",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pk1_ClientType",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "pk1_RetailClient",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetailClient",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    MarketSiteCode = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailClient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    ClientTypeId = table.Column<int>(nullable: false),
                    RetailClientId = table.Column<int>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: true),
                    CreatedByUserId = table.Column<int>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: true),
                    UpdatedByUserId = table.Column<int>(nullable: true),
                    IsArchived = table.Column<bool>(nullable: false),
                    Group = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Client_ClientType_ClientTypeId",
                        column: x => x.ClientTypeId,
                        principalTable: "ClientType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_Account_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Client_RetailClient_RetailClientId",
                        column: x => x.RetailClientId,
                        principalTable: "RetailClient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Account_UpdatedByUserId",
                        column: x => x.UpdatedByUserId,
                        principalTable: "Account",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (env!=null && env.Equals("Development"))
            {
                migrationBuilder.InsertData(
                    table: "Account",
                    columns: new[] { "Id", "Email", "Name" },
                    values: new object[,]
                    {
                    { 1, "mayankgg@dunnhumby.com", "mayankgg" },
                    { 2, "system@dunnhumby.com", "system" },
                    });
            }
            else
            {
                migrationBuilder.InsertData(
        table: "Account",
        columns: new[] { "Id", "Email", "Name" },
        values: new object[,]
        {
                    { 1, "mayankgg1@dunnhumby.com", "mayankgg1" },
                    { 2, "system1@dunnhumby.com", "system1" }
        });
            }

            migrationBuilder.InsertData(
                table: "ClientType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Retailer" },
                    { 2, "Dunnhumby" },
                    { 3, "Supplier" }
                });

            migrationBuilder.InsertData(
                table: "RetailClient",
                columns: new[] { "Id", "Description", "MarketSiteCode", "Name" },
                values: new object[,]
                {
                    { 1, "Tesco UK", "Tesco_UK", "TescoUK" },
                    { 2, "Exito Colombia", "CCO", "ExitoCO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_Email",
                table: "Account",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_Name",
                table: "Account",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientTypeId",
                table: "Client",
                column: "ClientTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_CreatedByUserId",
                table: "Client",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_RetailClientId",
                table: "Client",
                column: "RetailClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_UpdatedByUserId",
                table: "Client",
                column: "UpdatedByUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientType");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "RetailClient");

            migrationBuilder.DropSequence(
                name: "pk1_Account");

            migrationBuilder.DropSequence(
                name: "pk1_Client");

            migrationBuilder.DropSequence(
                name: "pk1_ClientType");

            migrationBuilder.DropSequence(
                name: "pk1_RetailClient");
        }
    }
}
