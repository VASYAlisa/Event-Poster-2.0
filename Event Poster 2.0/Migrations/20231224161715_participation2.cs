using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participations_Events_EventId",
                table: "Participations");

            migrationBuilder.DropIndex(
                name: "IX_Participations_EventId",
                table: "Participations");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "Participations");

            migrationBuilder.AddColumn<int>(
                name: "ParticipationId",
                table: "Events",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_ParticipationId",
                table: "Events",
                column: "ParticipationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Participations_ParticipationId",
                table: "Events",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Participations_ParticipationId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_ParticipationId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ParticipationId",
                table: "Events");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "Participations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participations_EventId",
                table: "Participations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participations_Events_EventId",
                table: "Participations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
