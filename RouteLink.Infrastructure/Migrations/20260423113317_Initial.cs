using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RouteLink.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "Transports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlateNumber = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Model = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    FuelConsumptionPer100Km = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Phone = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true),
                    PasswordHash = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    Role = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripNumber = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    DriverUserId = table.Column<int>(type: "integer", nullable: false),
                    TransportId = table.Column<int>(type: "integer", nullable: false),
                    StartPoint = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EndPoint = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    PlannedDistanceKm = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    ExecutionStatus = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trips_Users_DriverUserId",
                        column: x => x.DriverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FuelRefills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripId = table.Column<int>(type: "integer", nullable: true),
                    DriverUserId = table.Column<int>(type: "integer", nullable: false),
                    TransportId = table.Column<int>(type: "integer", nullable: false),
                    Liters = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Odometer = table.Column<decimal>(type: "numeric(12,2)", precision: 12, scale: 2, nullable: false),
                    Location = table.Column<Point>(type: "geometry(Point, 4326)", nullable: false),
                    ReceiptPath = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelRefills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FuelRefills_Transports_TransportId",
                        column: x => x.TransportId,
                        principalTable: "Transports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FuelRefills_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_FuelRefills_Users_DriverUserId",
                        column: x => x.DriverUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TripDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TripId = table.Column<int>(type: "integer", nullable: false),
                    DocumentType = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    FilePath = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripDocuments_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FuelRefillValidations",
                columns: table => new
                {
                    FuelRefillId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    IsConsumptionMismatch = table.Column<bool>(type: "boolean", nullable: false),
                    RejectionReasonCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    RejectionComment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelRefillValidations", x => x.FuelRefillId);
                    table.ForeignKey(
                        name: "FK_FuelRefillValidations_FuelRefills_FuelRefillId",
                        column: x => x.FuelRefillId,
                        principalTable: "FuelRefills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripDocumentValidations",
                columns: table => new
                {
                    TripDocumentId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    RejectionReasonCode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    RejectionComment = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripDocumentValidations", x => x.TripDocumentId);
                    table.ForeignKey(
                        name: "FK_TripDocumentValidations_TripDocuments_TripDocumentId",
                        column: x => x.TripDocumentId,
                        principalTable: "TripDocuments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FuelRefills_DriverUserId",
                table: "FuelRefills",
                column: "DriverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelRefills_TransportId",
                table: "FuelRefills",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_FuelRefills_TripId",
                table: "FuelRefills",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Transports_PlateNumber",
                table: "Transports",
                column: "PlateNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripDocuments_TripId",
                table: "TripDocuments",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_DriverUserId",
                table: "Trips",
                column: "DriverUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TransportId",
                table: "Trips",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TripNumber",
                table: "Trips",
                column: "TripNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FuelRefillValidations");

            migrationBuilder.DropTable(
                name: "TripDocumentValidations");

            migrationBuilder.DropTable(
                name: "FuelRefills");

            migrationBuilder.DropTable(
                name: "TripDocuments");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Transports");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
