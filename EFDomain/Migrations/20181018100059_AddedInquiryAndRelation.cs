using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EFDomain.Migrations
{
    public partial class AddedInquiryAndRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InquiryId",
                table: "Entities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Inquiry",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InquiryString = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiry", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entities_InquiryId",
                table: "Entities",
                column: "InquiryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entities_Inquiry_InquiryId",
                table: "Entities",
                column: "InquiryId",
                principalTable: "Inquiry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entities_Inquiry_InquiryId",
                table: "Entities");

            migrationBuilder.DropTable(
                name: "Inquiry");

            migrationBuilder.DropIndex(
                name: "IX_Entities_InquiryId",
                table: "Entities");

            migrationBuilder.DropColumn(
                name: "InquiryId",
                table: "Entities");
        }
    }
}
