using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Data.EF.Migrations
{
    public partial class AddAuthorNameToBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "NameSuffixId",
                table: "Books",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_NameSuffixId",
                table: "Books",
                column: "NameSuffixId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Suffix_NameSuffixId",
                table: "Books",
                column: "NameSuffixId",
                principalTable: "Suffix",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Suffix_NameSuffixId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_NameSuffixId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "NameSuffixId",
                table: "Books");
        }
    }
}
