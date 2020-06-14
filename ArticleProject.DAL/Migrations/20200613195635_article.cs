using Microsoft.EntityFrameworkCore.Migrations;

namespace ArticleProject.DAL.Migrations
{
    public partial class article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_UserAccount_UserAccountId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_UserAccountId",
                table: "Article");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "Article");

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_UserAccount_AuthorId",
                table: "Article",
                column: "AuthorId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_UserAccount_AuthorId",
                table: "Article");

            migrationBuilder.DropIndex(
                name: "IX_Article_AuthorId",
                table: "Article");

            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "Article",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserAccountId",
                table: "Article",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_UserAccount_UserAccountId",
                table: "Article",
                column: "UserAccountId",
                principalTable: "UserAccount",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
