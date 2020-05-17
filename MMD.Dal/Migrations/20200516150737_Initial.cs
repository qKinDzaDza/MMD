using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MMD.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Consignments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consignments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plates",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warehouses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Warehouses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accelerometers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Ea1 = table.Column<double>(nullable: false),
                    Ea1_3v = table.Column<double>(nullable: false),
                    Ea2 = table.Column<double>(nullable: false),
                    Ea2_3v = table.Column<double>(nullable: false),
                    Ed1 = table.Column<double>(nullable: false),
                    Ed1_3v = table.Column<double>(nullable: false),
                    Ed2 = table.Column<double>(nullable: false),
                    Ed2_3v = table.Column<double>(nullable: false),
                    PlateId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accelerometers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accelerometers_Plates_PlateId1",
                        column: x => x.PlateId1,
                        principalTable: "Plates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gyroscopes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ParameterF2 = table.Column<double>(nullable: false),
                    ParameterF1 = table.Column<double>(nullable: false),
                    ParameterQ1 = table.Column<double>(nullable: false),
                    ParameterQ2 = table.Column<double>(nullable: false),
                    ParameterQ = table.Column<double>(nullable: false),
                    DifferentialF = table.Column<double>(nullable: false),
                    DifferentialFQ = table.Column<double>(nullable: false),
                    PlateId1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gyroscopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gyroscopes_Plates_PlateId1",
                        column: x => x.PlateId1,
                        principalTable: "Plates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AssemblyMms",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccelerometerId = table.Column<string>(nullable: true),
                    GyroscopeId = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    TypeOfIc = table.Column<string>(nullable: true),
                    StructureOfSensor = table.Column<string>(nullable: true),
                    Substrate = table.Column<int>(nullable: false),
                    ConsignmentId = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssemblyMms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssemblyMms_Accelerometers_AccelerometerId",
                        column: x => x.AccelerometerId,
                        principalTable: "Accelerometers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyMms_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyMms_Consignments_ConsignmentId",
                        column: x => x.ConsignmentId,
                        principalTable: "Consignments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AssemblyMms_Gyroscopes_GyroscopeId",
                        column: x => x.GyroscopeId,
                        principalTable: "Gyroscopes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguringMmses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ResultConfiguring = table.Column<bool>(nullable: false),
                    ReasonDefects = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    AssemblyMmsId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguringMmses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguringMmses_AssemblyMms_AssemblyMmsId",
                        column: x => x.AssemblyMmsId,
                        principalTable: "AssemblyMms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfiguringMmses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MakeProducts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AssemblyMmsId = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    WarehouseId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    NumberOfApplication = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MakeProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MakeProducts_AssemblyMms_AssemblyMmsId",
                        column: x => x.AssemblyMmsId,
                        principalTable: "AssemblyMms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MakeProducts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MakeProducts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MobileTestingMmses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    ConfiguringMmsId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Nonlinearity = table.Column<double>(nullable: false),
                    Inaccuracy = table.Column<double>(nullable: false),
                    СhangeShiftZero = table.Column<double>(nullable: false),
                    СhangeTransformation = table.Column<double>(nullable: false),
                    HysteresisShiftZero = table.Column<double>(nullable: false),
                    HysteresisTransformation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTestingMmses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileTestingMmses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MobileTestingMmses_ConfiguringMmses_ConfiguringMmsId",
                        column: x => x.ConfiguringMmsId,
                        principalTable: "ConfiguringMmses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConfiguringProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    ResultConfiguring = table.Column<bool>(nullable: false),
                    ReasonDefects = table.Column<string>(nullable: true),
                    AuthorId = table.Column<int>(nullable: true),
                    MakeProductId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguringProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguringProducts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConfiguringProducts_MakeProducts_MakeProductId",
                        column: x => x.MakeProductId,
                        principalTable: "MakeProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalibrationMmses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    MobileTestingMmsId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Nonlinearity = table.Column<double>(nullable: false),
                    Inaccuracy = table.Column<double>(nullable: false),
                    СhangeShiftZero = table.Column<double>(nullable: false),
                    СhangeTransformation = table.Column<double>(nullable: false),
                    HysteresisShiftZero = table.Column<double>(nullable: false),
                    HysteresisTransformation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationMmses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalibrationMmses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalibrationMmses_MobileTestingMmses_MobileTestingMmsId",
                        column: x => x.MobileTestingMmsId,
                        principalTable: "MobileTestingMmses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileTestingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    ConfiguringProductId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Nonlinearity = table.Column<double>(nullable: false),
                    Inaccuracy = table.Column<double>(nullable: false),
                    СhangeShiftZero = table.Column<double>(nullable: false),
                    СhangeTransformation = table.Column<double>(nullable: false),
                    HysteresisShiftZero = table.Column<double>(nullable: false),
                    HysteresisTransformation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileTestingProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileTestingProducts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MobileTestingProducts_ConfiguringProducts_ConfiguringProductId",
                        column: x => x.ConfiguringProductId,
                        principalTable: "ConfiguringProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationaryTestingMms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    CalibrationMmsId = table.Column<int>(nullable: false),
                    AlanInstability = table.Column<double>(nullable: false),
                    PowerDensity = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryTestingMms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationaryTestingMms_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationaryTestingMms_CalibrationMmses_CalibrationMmsId",
                        column: x => x.CalibrationMmsId,
                        principalTable: "CalibrationMmses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalibrationProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    MobileTestingProductId = table.Column<int>(nullable: false),
                    Place = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Nonlinearity = table.Column<double>(nullable: false),
                    Inaccuracy = table.Column<double>(nullable: false),
                    СhangeShiftZero = table.Column<double>(nullable: false),
                    СhangeTransformation = table.Column<double>(nullable: false),
                    HysteresisShiftZero = table.Column<double>(nullable: false),
                    HysteresisTransformation = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalibrationProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalibrationProducts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CalibrationProducts_MobileTestingProducts_MobileTestingProductId",
                        column: x => x.MobileTestingProductId,
                        principalTable: "MobileTestingProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StationaryTestingProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(nullable: true),
                    CalibrationProductId = table.Column<int>(nullable: false),
                    AlanInstability = table.Column<double>(nullable: false),
                    PowerDensity = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StationaryTestingProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StationaryTestingProducts_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StationaryTestingProducts_CalibrationProducts_CalibrationProductId",
                        column: x => x.CalibrationProductId,
                        principalTable: "CalibrationProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accelerometers_PlateId1",
                table: "Accelerometers",
                column: "PlateId1");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyMms_AccelerometerId",
                table: "AssemblyMms",
                column: "AccelerometerId",
                unique: true,
                filter: "[AccelerometerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyMms_AuthorId",
                table: "AssemblyMms",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyMms_ConsignmentId",
                table: "AssemblyMms",
                column: "ConsignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_AssemblyMms_GyroscopeId",
                table: "AssemblyMms",
                column: "GyroscopeId",
                unique: true,
                filter: "[GyroscopeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CalibrationMmses_AuthorId",
                table: "CalibrationMmses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalibrationMmses_MobileTestingMmsId",
                table: "CalibrationMmses",
                column: "MobileTestingMmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CalibrationProducts_AuthorId",
                table: "CalibrationProducts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CalibrationProducts_MobileTestingProductId",
                table: "CalibrationProducts",
                column: "MobileTestingProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguringMmses_AssemblyMmsId",
                table: "ConfiguringMmses",
                column: "AssemblyMmsId",
                unique: true,
                filter: "[AssemblyMmsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguringMmses_AuthorId",
                table: "ConfiguringMmses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguringProducts_AuthorId",
                table: "ConfiguringProducts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguringProducts_MakeProductId",
                table: "ConfiguringProducts",
                column: "MakeProductId",
                unique: true,
                filter: "[MakeProductId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Gyroscopes_PlateId1",
                table: "Gyroscopes",
                column: "PlateId1");

            migrationBuilder.CreateIndex(
                name: "IX_MakeProducts_AssemblyMmsId",
                table: "MakeProducts",
                column: "AssemblyMmsId",
                unique: true,
                filter: "[AssemblyMmsId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MakeProducts_AuthorId",
                table: "MakeProducts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MakeProducts_WarehouseId",
                table: "MakeProducts",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTestingMmses_AuthorId",
                table: "MobileTestingMmses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTestingMmses_ConfiguringMmsId",
                table: "MobileTestingMmses",
                column: "ConfiguringMmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MobileTestingProducts_AuthorId",
                table: "MobileTestingProducts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileTestingProducts_ConfiguringProductId",
                table: "MobileTestingProducts",
                column: "ConfiguringProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationaryTestingMms_AuthorId",
                table: "StationaryTestingMms",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryTestingMms_CalibrationMmsId",
                table: "StationaryTestingMms",
                column: "CalibrationMmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StationaryTestingProducts_AuthorId",
                table: "StationaryTestingProducts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_StationaryTestingProducts_CalibrationProductId",
                table: "StationaryTestingProducts",
                column: "CalibrationProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AuthorId",
                table: "Warehouses",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StationaryTestingMms");

            migrationBuilder.DropTable(
                name: "StationaryTestingProducts");

            migrationBuilder.DropTable(
                name: "CalibrationMmses");

            migrationBuilder.DropTable(
                name: "CalibrationProducts");

            migrationBuilder.DropTable(
                name: "MobileTestingMmses");

            migrationBuilder.DropTable(
                name: "MobileTestingProducts");

            migrationBuilder.DropTable(
                name: "ConfiguringMmses");

            migrationBuilder.DropTable(
                name: "ConfiguringProducts");

            migrationBuilder.DropTable(
                name: "MakeProducts");

            migrationBuilder.DropTable(
                name: "AssemblyMms");

            migrationBuilder.DropTable(
                name: "Warehouses");

            migrationBuilder.DropTable(
                name: "Accelerometers");

            migrationBuilder.DropTable(
                name: "Consignments");

            migrationBuilder.DropTable(
                name: "Gyroscopes");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Plates");
        }
    }
}
