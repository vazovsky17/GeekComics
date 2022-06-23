using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeekComics.EntityFramework.Migrations
{
    public partial class AddBH : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "BonusHistory",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BonusHistory_AccountId",
                table: "BonusHistory",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_BonusHistory_Accounts_AccountId",
                table: "BonusHistory",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BonusHistory_Accounts_AccountId",
                table: "BonusHistory");

            migrationBuilder.DropIndex(
                name: "IX_BonusHistory_AccountId",
                table: "BonusHistory");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "BonusHistory");
        }
    }
}
