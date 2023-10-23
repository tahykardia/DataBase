using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Database.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComputerInfo",
                columns: table => new
                {
                    ComputerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OSVersion = table.Column<string>(type: "text", nullable: true),
                    ComputerName = table.Column<string>(type: "text", nullable: true),
                    SystemFolder = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<string>(type: "text", nullable: true),
                    UpdateTime = table.Column<string>(type: "text", nullable: true),
                    OSName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerInfo", x => x.ComputerId);
                });

            migrationBuilder.CreateTable(
                name: "Gpu",
                columns: table => new
                {
                    GPUId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    VolumeMemory = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gpu", x => x.GPUId);
                });

            migrationBuilder.CreateTable(
                name: "Ram",
                columns: table => new
                {
                    RAMId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    Volume = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ram", x => x.RAMId);
                });

            migrationBuilder.CreateTable(
                name: "Ssd",
                columns: table => new
                {
                    SSDId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedWrite = table.Column<string>(type: "text", nullable: true),
                    MaxSpeedRead = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ssd", x => x.SSDId);
                });

            migrationBuilder.CreateTable(
                name: "CPU",
                columns: table => new
                {
                    CPUId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Frequency = table.Column<string>(type: "text", nullable: true),
                    Bitness = table.Column<string>(type: "text", nullable: true),
                    CacheMemory = table.Column<string>(type: "text", nullable: true),
                    NumberOfCores = table.Column<string>(type: "text", nullable: true),
                    ComputerInfoComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPU", x => x.CPUId);
                    table.ForeignKey(
                        name: "FK_CPU_ComputerInfo_ComputerInfoComputerId",
                        column: x => x.ComputerInfoComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToGPU",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GPUId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToGPU", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToGPU_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToGPU_Gpu_GPUId",
                        column: x => x.GPUId,
                        principalTable: "Gpu",
                        principalColumn: "GPUId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToRAM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RAMId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToRAM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToRAM_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToRAM_Ram_RAMId",
                        column: x => x.RAMId,
                        principalTable: "Ram",
                        principalColumn: "RAMId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ComputersToSSD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SSDId = table.Column<int>(type: "integer", nullable: true),
                    ComputerId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputersToSSD", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComputersToSSD_ComputerInfo_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "ComputerInfo",
                        principalColumn: "ComputerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComputersToSSD_Ssd_SSDId",
                        column: x => x.SSDId,
                        principalTable: "Ssd",
                        principalColumn: "SSDId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToGPU_ComputerId",
                table: "ComputersToGPU",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToGPU_GPUId",
                table: "ComputersToGPU",
                column: "GPUId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToRAM_ComputerId",
                table: "ComputersToRAM",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToRAM_RAMId",
                table: "ComputersToRAM",
                column: "RAMId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToSSD_ComputerId",
                table: "ComputersToSSD",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_ComputersToSSD_SSDId",
                table: "ComputersToSSD",
                column: "SSDId");

            migrationBuilder.CreateIndex(
                name: "IX_CPU_ComputerInfoComputerId",
                table: "CPU",
                column: "ComputerInfoComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComputersToGPU");

            migrationBuilder.DropTable(
                name: "ComputersToRAM");

            migrationBuilder.DropTable(
                name: "ComputersToSSD");

            migrationBuilder.DropTable(
                name: "CPU");

            migrationBuilder.DropTable(
                name: "Gpu");

            migrationBuilder.DropTable(
                name: "Ram");

            migrationBuilder.DropTable(
                name: "Ssd");

            migrationBuilder.DropTable(
                name: "ComputerInfo");
        }
    }
}
