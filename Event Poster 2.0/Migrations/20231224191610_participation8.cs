using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Event_Poster_2._0.Migrations
{
    public partial class participation8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipationId",
                table: "ParticipationEvents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipationId",
                table: "ParticipationEvents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ParticipationEvents_Participations_ParticipationId",
                table: "ParticipationEvents",
                column: "ParticipationId",
                principalTable: "Participations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
