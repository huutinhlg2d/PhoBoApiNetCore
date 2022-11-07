using Microsoft.EntityFrameworkCore.Migrations;

namespace BussinessObject.Migrations
{
    public partial class Phobo_v2_Add_BCC_AlternateKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookingConceptConfig_ConceptId",
                table: "BookingConceptConfig");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_BookingConceptConfig_ConceptId_PhotographerId",
                table: "BookingConceptConfig",
                columns: new[] { "ConceptId", "PhotographerId" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "AvatarUrl",
                value: "Resources\\Images\\uyentrang.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "AvatarUrl",
                value: "Resources\\Images\\quockhanh.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarUrl",
                value: "Resources\\Images\\huutinh.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "AvatarUrl",
                value: "Resources\\Images\\tanhoang.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_BookingConceptConfig_ConceptId_PhotographerId",
                table: "BookingConceptConfig");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                column: "AvatarUrl",
                value: "Resource/Images/uyentrang.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                column: "AvatarUrl",
                value: "Resource/Images/quockhanh.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                column: "AvatarUrl",
                value: "Resource/Images/huutinh.jpg");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                column: "AvatarUrl",
                value: "Resource/Images/tanhoang.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_BookingConceptConfig_ConceptId",
                table: "BookingConceptConfig",
                column: "ConceptId");
        }
    }
}
