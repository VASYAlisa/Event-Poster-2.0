using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvent_Events_EventId",
                table: "ParticipationEvent");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvent_Participations_ParticipationId",
                table: "ParticipationEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipationEvent",
                table: "ParticipationEvent");

            migrationBuilder.RenameTable(
                name: "ParticipationEvent",
                newName: "ParticipationEvents");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipationEvent_ParticipationId",
                table: "ParticipationEvents",
                newName: "IX_ParticipationEvents_ParticipationId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipationEvent_EventId",
                table: "ParticipationEvents",
                newName: "IX_ParticipationEvents_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipationEvents",
                table: "ParticipationEvents",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvents_Events_EventId",
                table: "ParticipationEvents",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvents_Events_EventId",
                table: "ParticipationEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ParticipationEvents",
                table: "ParticipationEvents");

            migrationBuilder.RenameTable(
                name: "ParticipationEvents",
                newName: "ParticipationEvent");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipationEvents_ParticipationId",
                table: "ParticipationEvent",
                newName: "IX_ParticipationEvent_ParticipationId");

            migrationBuilder.RenameIndex(
                name: "IX_ParticipationEvents_EventId",
                table: "ParticipationEvent",
                newName: "IX_ParticipationEvent_EventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ParticipationEvent",
                table: "ParticipationEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvent_Events_EventId",
                table: "ParticipationEvent",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvent_Participations_ParticipationId",
                table: "ParticipationEvent",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
