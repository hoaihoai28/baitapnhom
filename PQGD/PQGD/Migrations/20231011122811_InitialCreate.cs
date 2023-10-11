using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PQGD.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoViens",
                columns: table => new
                {
                    id_giaovien = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hoten = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gioitinh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ngaysinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    sdt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    takhoan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matkhau = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiaoViens", x => x.id_giaovien);
                });

            migrationBuilder.CreateTable(
                name: "HocKys",
                columns: table => new
                {
                    Id_hocky = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenhocky = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    namhoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HocKys", x => x.Id_hocky);
                });

            migrationBuilder.CreateTable(
                name: "Lops",
                columns: table => new
                {
                    id_lop = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenlop = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lops", x => x.id_lop);
                });

            migrationBuilder.CreateTable(
                name: "MonHocs",
                columns: table => new
                {
                    id_monhoc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenmonhoc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonHocs", x => x.id_monhoc);
                });

            migrationBuilder.CreateTable(
                name: "PhanQuyens",
                columns: table => new
                {
                    id_phanquyen = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_giaovien = table.Column<int>(type: "int", nullable: false),
                    id_lop = table.Column<int>(type: "int", nullable: false),
                    id_monhoc = table.Column<int>(type: "int", nullable: false),
                    id_hocky = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhanQuyens", x => x.id_phanquyen);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_GiaoViens_id_giaovien",
                        column: x => x.id_giaovien,
                        principalTable: "GiaoViens",
                        principalColumn: "id_giaovien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_HocKys_id_hocky",
                        column: x => x.id_hocky,
                        principalTable: "HocKys",
                        principalColumn: "Id_hocky",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_Lops_id_lop",
                        column: x => x.id_lop,
                        principalTable: "Lops",
                        principalColumn: "id_lop",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhanQuyens_MonHocs_id_monhoc",
                        column: x => x.id_monhoc,
                        principalTable: "MonHocs",
                        principalColumn: "id_monhoc",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_giaovien",
                table: "PhanQuyens",
                column: "id_giaovien");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_hocky",
                table: "PhanQuyens",
                column: "id_hocky");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_lop",
                table: "PhanQuyens",
                column: "id_lop");

            migrationBuilder.CreateIndex(
                name: "IX_PhanQuyens_id_monhoc",
                table: "PhanQuyens",
                column: "id_monhoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhanQuyens");

            migrationBuilder.DropTable(
                name: "GiaoViens");

            migrationBuilder.DropTable(
                name: "HocKys");

            migrationBuilder.DropTable(
                name: "Lops");

            migrationBuilder.DropTable(
                name: "MonHocs");
        }
    }
}
