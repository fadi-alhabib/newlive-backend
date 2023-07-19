using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace newLive.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "booktbl",
                columns: table => new
                {
                    bookname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    booksection = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    bookdoctor = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    bookdate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "dignoses",
                columns: table => new
                {
                    patientid = table.Column<int>(name: "patient id", type: "int", nullable: false),
                    patientname = table.Column<string>(name: "patient name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    doctorname = table.Column<string>(name: "doctor name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    digognses = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dignoses", x => x.patientid);
                });

            migrationBuilder.CreateTable(
                name: "doctorsinfos",
                columns: table => new
                {
                    Doctor_id = table.Column<int>(type: "int", nullable: false),
                    Doctor_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Doctor_age = table.Column<int>(type: "int", nullable: true),
                    Daddress = table.Column<string>(name: "D-address", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    D_phone = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    D_email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    D_gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    D_spcelization = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    hire_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_doctorsinfos", x => x.Doctor_id);
                });

            migrationBuilder.CreateTable(
                name: "login",
                columns: table => new
                {
                    username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    usertype = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "patientinfos",
                columns: table => new
                {
                    patientid = table.Column<int>(type: "int", nullable: false),
                    patientname = table.Column<string>(name: "patient-name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    gender = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    age = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    phonenumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(name: "E-mail", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_patientinfos", x => x.patientid);
                });

            migrationBuilder.CreateTable(
                name: "section",
                columns: table => new
                {
                    sectionID = table.Column<int>(type: "int", nullable: false),
                    sectionname = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__section__3F58FD32D65EAC72", x => x.sectionID);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    sectionsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sectionsname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sections__F7701F409D7F3BC6", x => x.sectionsID);
                });

            migrationBuilder.CreateTable(
                name: "surgerytblinfos",
                columns: table => new
                {
                    patientID = table.Column<int>(name: "patient ID", type: "int", nullable: false),
                    surgery_date = table.Column<DateTime>(type: "date", nullable: true),
                    surgery_room = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    surgery_time = table.Column<double>(type: "float", nullable: true),
                    surgery_type = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    doctorIDName = table.Column<string>(name: "doctor ID&Name", type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_surgerytblinfos", x => x.patientID);
                });

            migrationBuilder.CreateTable(
                name: "doctorsection",
                columns: table => new
                {
                    doctorID = table.Column<int>(type: "int", nullable: false),
                    doctorname = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true),
                    sectionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__doctorse__722485966DD144CD", x => x.doctorID);
                    table.ForeignKey(
                        name: "FK__doctorsec__secti__74AE54BC",
                        column: x => x.sectionID,
                        principalTable: "section",
                        principalColumn: "sectionID");
                });

            migrationBuilder.CreateTable(
                name: "Doctorssection",
                columns: table => new
                {
                    doctorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    doctorname = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    sectionsID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Doctorss__722485961B1324B0", x => x.doctorID);
                    table.ForeignKey(
                        name: "FK__Doctorsse__secti__0C85DE4D",
                        column: x => x.sectionsID,
                        principalTable: "sections",
                        principalColumn: "sectionsID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_doctorsection_sectionID",
                table: "doctorsection",
                column: "sectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Doctorssection_sectionsID",
                table: "Doctorssection",
                column: "sectionsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booktbl");

            migrationBuilder.DropTable(
                name: "dignoses");

            migrationBuilder.DropTable(
                name: "doctorsection");

            migrationBuilder.DropTable(
                name: "doctorsinfos");

            migrationBuilder.DropTable(
                name: "Doctorssection");

            migrationBuilder.DropTable(
                name: "login");

            migrationBuilder.DropTable(
                name: "patientinfos");

            migrationBuilder.DropTable(
                name: "surgerytblinfos");

            migrationBuilder.DropTable(
                name: "section");

            migrationBuilder.DropTable(
                name: "sections");
        }
    }
}
