using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventParticipation");

            migrationBuilder.CreateTable(
                name: "ParticipationEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParticipationId = table.Column<int>(type: "int", nullable: false),
                    ParticipatinId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParticipationEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParticipationEvent_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParticipationEvent_Participations_ParticipationId",
                        column: x => x.ParticipationId,
                        principalTable: "Participations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationEvent_EventId",
                table: "ParticipationEvent",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_ParticipationEvent_ParticipationId",
                table: "ParticipationEvent",
                column: "ParticipationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParticipationEvent");

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
    }
}
