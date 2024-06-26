using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APBD_Projekt.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_ID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Client_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tel_Num = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Client_ID);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    Discount_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date_From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_To = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.Discount_ID);
                });

            migrationBuilder.CreateTable(
                name: "Workers",
                columns: table => new
                {
                    Worker_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Hashed_Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Refresh_Token = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Refresh_Token_Exp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workers", x => x.Worker_ID);
                });

            migrationBuilder.CreateTable(
                name: "Software_Systems",
                columns: table => new
                {
                    Soft_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_Systems", x => x.Soft_ID);
                    table.ForeignKey(
                        name: "FK_Software_Systems_Categories_Category_ID",
                        column: x => x.Category_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Firms",
                columns: table => new
                {
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    KRS = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firms", x => x.Client_ID);
                    table.ForeignKey(
                        name: "FK_Firms_Clients_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "Clients",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Private_Clients",
                columns: table => new
                {
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Is_Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Private_Clients", x => x.Client_ID);
                    table.ForeignKey(
                        name: "FK_Private_Clients_Clients_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "Clients",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Software_Discounts",
                columns: table => new
                {
                    Software_ID = table.Column<int>(type: "int", nullable: false),
                    Discount_ID = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_Discounts", x => new { x.Software_ID, x.Discount_ID });
                    table.ForeignKey(
                        name: "FK_Software_Discounts_Discounts_Discount_ID",
                        column: x => x.Discount_ID,
                        principalTable: "Discounts",
                        principalColumn: "Discount_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Software_Discounts_Software_Systems_Software_ID",
                        column: x => x.Software_ID,
                        principalTable: "Software_Systems",
                        principalColumn: "Soft_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Software_Versions",
                columns: table => new
                {
                    Version_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Software_ID = table.Column<int>(type: "int", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Version_Info = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Software_Versions", x => x.Version_ID);
                    table.ForeignKey(
                        name: "FK_Software_Versions_Software_Systems_Software_ID",
                        column: x => x.Software_ID,
                        principalTable: "Software_Systems",
                        principalColumn: "Soft_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Contract_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Date_From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date_To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Actualisation = table.Column<int>(type: "int", nullable: true),
                    Version_ID = table.Column<int>(type: "int", nullable: false),
                    Is_Signed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Contract_ID);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "Clients",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Software_Versions_Version_ID",
                        column: x => x.Version_ID,
                        principalTable: "Software_Versions",
                        principalColumn: "Version_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Payment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Client_ID = table.Column<int>(type: "int", nullable: false),
                    Contract_ID = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Payment_ID);
                    table.ForeignKey(
                        name: "FK_Payments_Clients_Client_ID",
                        column: x => x.Client_ID,
                        principalTable: "Clients",
                        principalColumn: "Client_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Contracts_Contract_ID",
                        column: x => x.Contract_ID,
                        principalTable: "Contracts",
                        principalColumn: "Contract_ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Client_ID",
                table: "Contracts",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Version_ID",
                table: "Contracts",
                column: "Version_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Client_ID",
                table: "Payments",
                column: "Client_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_Contract_ID",
                table: "Payments",
                column: "Contract_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Software_Discounts_Discount_ID",
                table: "Software_Discounts",
                column: "Discount_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Software_Systems_Category_ID",
                table: "Software_Systems",
                column: "Category_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Software_Versions_Software_ID",
                table: "Software_Versions",
                column: "Software_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Firms");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Private_Clients");

            migrationBuilder.DropTable(
                name: "Software_Discounts");

            migrationBuilder.DropTable(
                name: "Workers");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Software_Versions");

            migrationBuilder.DropTable(
                name: "Software_Systems");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
