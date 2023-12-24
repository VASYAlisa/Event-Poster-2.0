using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Participations_ParticipationId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_ParticipationId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "ParticipationId",
                table: "Participations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipationId",
                table: "Participations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_ParticipationId",
                table: "Participations",
                column: "ParticipationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Participations_ParticipationId",
                table: "Participations",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id");
        }
    }
}
