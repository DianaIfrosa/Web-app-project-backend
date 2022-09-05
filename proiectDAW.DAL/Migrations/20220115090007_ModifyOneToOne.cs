using Microsoft.EntityFrameworkCore.Migrations;

namespace proiectDAW.DAL.Migrations
{
    public partial class ModifyOneToOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentationVideos_DIYIdeas_DIYIdeaId",
                table: "PresentationVideos");

            migrationBuilder.DropIndex(
                name: "IX_PresentationVideos_DIYIdeaId",
                table: "PresentationVideos");

            migrationBuilder.DropColumn(
                name: "DIYIdeaId",
                table: "PresentationVideos");

            migrationBuilder.CreateIndex(
                name: "IX_DIYIdeas_PresentationVideoId",
                table: "DIYIdeas",
                column: "PresentationVideoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DIYIdeas_PresentationVideos_PresentationVideoId",
                table: "DIYIdeas",
                column: "PresentationVideoId",
                principalTable: "PresentationVideos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DIYIdeas_PresentationVideos_PresentationVideoId",
                table: "DIYIdeas");

            migrationBuilder.DropIndex(
                name: "IX_DIYIdeas_PresentationVideoId",
                table: "DIYIdeas");

            migrationBuilder.AddColumn<int>(
                name: "DIYIdeaId",
                table: "PresentationVideos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PresentationVideos_DIYIdeaId",
                table: "PresentationVideos",
                column: "DIYIdeaId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationVideos_DIYIdeas_DIYIdeaId",
                table: "PresentationVideos",
                column: "DIYIdeaId",
                principalTable: "DIYIdeas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
