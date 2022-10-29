using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BussinessObject.Migrations
{
    public partial class Phobo_huutinh_firstInitiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Concept",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Concept", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Photographer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photographer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photographer_User_Id",
                        column: x => x.Id,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PhotographerId = table.Column<int>(type: "int", nullable: false),
                    ConceptId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingRate = table.Column<float>(type: "real", nullable: false),
                    Duration = table.Column<float>(type: "real", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Concept_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Photographer_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingConceptConfig",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhotographerId = table.Column<int>(type: "int", nullable: false),
                    ConceptId = table.Column<int>(type: "int", nullable: false),
                    DurationConfig = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingConceptConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingConceptConfig_Concept_ConceptId",
                        column: x => x.ConceptId,
                        principalTable: "Concept",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingConceptConfig_Photographer_PhotographerId",
                        column: x => x.PhotographerId,
                        principalTable: "Photographer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingConceptImage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingConceptImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingConceptImage_BookingConceptConfig_ConfigId",
                        column: x => x.ConfigId,
                        principalTable: "BookingConceptConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Concept",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, false, "Marriage" },
                    { 2, false, "Graduation" },
                    { 3, false, "Anniversary" },
                    { 4, false, "Birthday" },
                    { 5, false, "Travel" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AvatarUrl", "DateOfBirth", "Email", "Gender", "IsDeleted", "Name", "Password", "Role" },
                values: new object[,]
                {
                    { 4, "Resource/Images/uyentrang.jpg", new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "uyentrang@phobo.com", 0, false, "Trương Thị Uyên Trang", "123123", 1 },
                    { 5, "Resource/Images/quockhanh.jpg", new DateTime(2001, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "quockhanh@phobo.com", 0, false, "Trần Quốc Khánh", "123123", 1 },
                    { 2, "Resource/Images/huutinh.jpg", new DateTime(2001, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "huutinh@phobo.com", 0, false, "Hồ Hữu Tình", "123123", 2 },
                    { 3, "Resource/Images/tanhoang.jpg", new DateTime(1999, 5, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tanhoang@phobo.com", 0, false, "Phạm Tấn Hoàng", "123123", 2 },
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@phobo.com", 0, false, "Admin", "admin@@", 0 }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                column: "Id",
                values: new object[]
                {
                    4,
                    5
                });

            migrationBuilder.InsertData(
                table: "Photographer",
                columns: new[] { "Id", "Rate" },
                values: new object[,]
                {
                    { 2, 0f },
                    { 3, 0f }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ConceptId",
                table: "Booking",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CustomerId",
                table: "Booking",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_PhotographerId",
                table: "Booking",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConceptConfig_ConceptId",
                table: "BookingConceptConfig",
                column: "ConceptId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConceptConfig_PhotographerId",
                table: "BookingConceptConfig",
                column: "PhotographerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConceptImage_ConfigId",
                table: "BookingConceptImage",
                column: "ConfigId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "BookingConceptImage");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "BookingConceptConfig");

            migrationBuilder.DropTable(
                name: "Concept");

            migrationBuilder.DropTable(
                name: "Photographer");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
