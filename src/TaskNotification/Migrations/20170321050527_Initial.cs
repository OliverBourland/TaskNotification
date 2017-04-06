using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TaskNotification.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true),
                    ContactName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    CustomerID = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskNotifies",
                columns: table => new
                {
                    TaskNotifyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(maxLength: 600, nullable: false),
                    CompletedByUserID = table.Column<int>(nullable: true),
                    CompletionDate = table.Column<DateTime>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    OrderID = table.Column<int>(nullable: true),
                    PostedByUserID = table.Column<int>(nullable: true),
                    TaskCompleted = table.Column<bool>(nullable: false),
                    TaskForUserID = table.Column<int>(nullable: true),
                    TaskViewed = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskNotifies", x => x.TaskNotifyID);
                    table.ForeignKey(
                        name: "FK_TaskNotifies_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    TaskNotifyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_TaskNotifies_TaskNotifyID",
                        column: x => x.TaskNotifyID,
                        principalTable: "TaskNotifies",
                        principalColumn: "TaskNotifyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerID",
                table: "Orders",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotifies_CompletedByUserID",
                table: "TaskNotifies",
                column: "CompletedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotifies_OrderID",
                table: "TaskNotifies",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotifies_PostedByUserID",
                table: "TaskNotifies",
                column: "PostedByUserID");

            migrationBuilder.CreateIndex(
                name: "IX_TaskNotifies_TaskForUserID",
                table: "TaskNotifies",
                column: "TaskForUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TaskNotifyID",
                table: "Users",
                column: "TaskNotifyID");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotifies_Users_CompletedByUserID",
                table: "TaskNotifies",
                column: "CompletedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotifies_Users_PostedByUserID",
                table: "TaskNotifies",
                column: "PostedByUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TaskNotifies_Users_TaskForUserID",
                table: "TaskNotifies",
                column: "TaskForUserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotifies_Users_CompletedByUserID",
                table: "TaskNotifies");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotifies_Users_PostedByUserID",
                table: "TaskNotifies");

            migrationBuilder.DropForeignKey(
                name: "FK_TaskNotifies_Users_TaskForUserID",
                table: "TaskNotifies");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TaskNotifies");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
