using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ShareTrip",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(nullable: true),
                    driver_id = table.Column<int>(nullable: true),
                    distance = table.Column<int>(nullable: true),
                    amount = table.Column<int>(nullable: true),
                    StartTo = table.Column<string>(nullable: true),
                    sub_amount = table.Column<int>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareTrip", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(nullable: true),
                    last_name = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    user_name = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    id_poof = table.Column<string>(nullable: true),
                    role = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Driver",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    type = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    id_proof = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    Id_Car = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Driver", x => x.id);
                    table.ForeignKey(
                        name: "FK__Driver__Id_Car__440B1D61",
                        column: x => x.Id_Car,
                        principalTable: "Car",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Feedback",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<int>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedback", x => x.id);
                    table.ForeignKey(
                        name: "FK__Feedback__descri__46E78A0C",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRun = table.Column<string>(nullable: true),
                    TimeRun = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    StartTo = table.Column<string>(nullable: true),
                    EndFrom = table.Column<string>(nullable: true),
                    id_user = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.id);
                    table.ForeignKey(
                        name: "FK__Notificat__id_us__49C3F6B7",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(nullable: true),
                    id_driver = table.Column<int>(nullable: true),
                    StartTo = table.Column<string>(nullable: true),
                    EndFrom = table.Column<string>(nullable: true),
                    date = table.Column<string>(nullable: true),
                    distance = table.Column<int>(nullable: true),
                    amount = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    status = table.Column<int>(nullable: true),
                    member = table.Column<int>(nullable: true),
                    isCancel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.id);
                    table.ForeignKey(
                        name: "FK__Booking__id_driv__4D94879B",
                        column: x => x.id_driver,
                        principalTable: "Driver",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Booking__member__4CA06362",
                        column: x => x.id_user,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShareBooking",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booking_id = table.Column<int>(nullable: true),
                    id_sharetrip = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareBooking", x => x.id);
                    table.ForeignKey(
                        name: "FK__ShareBook__booki__5165187F",
                        column: x => x.booking_id,
                        principalTable: "Booking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShareBooking_ShareTrip",
                        column: x => x.id_sharetrip,
                        principalTable: "ShareTrip",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Booking_id_driver",
                table: "Booking",
                column: "id_driver");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_id_user",
                table: "Booking",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Driver_Id_Car",
                table: "Driver",
                column: "Id_Car");

            migrationBuilder.CreateIndex(
                name: "IX_Feedback_user_id",
                table: "Feedback",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_id_user",
                table: "Notification",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_ShareBooking_booking_id",
                table: "ShareBooking",
                column: "booking_id");

            migrationBuilder.CreateIndex(
                name: "IX_ShareBooking_id_sharetrip",
                table: "ShareBooking",
                column: "id_sharetrip");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Feedback");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "ShareBooking");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropTable(
                name: "ShareTrip");

            migrationBuilder.DropTable(
                name: "Driver");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Car");
        }
    }
}
