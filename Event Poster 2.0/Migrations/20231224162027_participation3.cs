using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "EventParticipation",
                columns: table => new
                {
                    EventsId = table.Column<int>(type: "int", nullable: false),
                    ParticipationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipation", x => new { x.EventsId, x.ParticipationsId });
                    table.ForeignKey(
                        name: "FK_EventParticipation_Events_EventsId",
                        column: x => x.EventsId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventParticipation_Participations_ParticipationsId",
                        column: x => x.ParticipationsId,
                        principalTable: "Participations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipation_ParticipationsId",
                table: "EventParticipation",
                column: "ParticipationsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipation");

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
    }
}
