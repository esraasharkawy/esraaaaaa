using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Advancedproject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Deptno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Dept_floor = table.Column<int>(nullable: false),
                    Dept_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Deptno);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    p_name = table.Column<string>(nullable: true),
                    p_gender = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.pid);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Did = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    D_name = table.Column<string>(nullable: true),
                    D_age = table.Column<int>(nullable: false),
                    D_address = table.Column<string>(nullable: true),
                    Dept_no = table.Column<int>(nullable: false),
                    departementDeptno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Did);
                    table.ForeignKey(
                        name: "FK_Doctors_Departments_departementDeptno",
                        column: x => x.departementDeptno,
                        principalTable: "Departments",
                        principalColumn: "Deptno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Rno = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    R_floor = table.Column<int>(nullable: false),
                    dept_no = table.Column<int>(nullable: false),
                    departmentDeptno = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Rno);
                    table.ForeignKey(
                        name: "FK_Rooms_Departments_departmentDeptno",
                        column: x => x.departmentDeptno,
                        principalTable: "Departments",
                        principalColumn: "Deptno",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Departments",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false),
                    deptno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Departments", x => new { x.pid, x.deptno });
                    table.ForeignKey(
                        name: "FK_Patient_Departments_Departments_deptno",
                        column: x => x.deptno,
                        principalTable: "Departments",
                        principalColumn: "Deptno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Departments_Patients_pid",
                        column: x => x.pid,
                        principalTable: "Patients",
                        principalColumn: "pid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Eid = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    E_salary = table.Column<decimal>(nullable: false),
                    E_phone = table.Column<int>(nullable: false),
                    E_gender = table.Column<string>(nullable: true),
                    D_id = table.Column<int>(nullable: false),
                    doctorDid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Eid);
                    table.ForeignKey(
                        name: "FK_Employees_Doctors_doctorDid",
                        column: x => x.doctorDid,
                        principalTable: "Doctors",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patient_Doctors",
                columns: table => new
                {
                    pid = table.Column<int>(nullable: false),
                    Did = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patient_Doctors", x => new { x.pid, x.Did });
                    table.ForeignKey(
                        name: "FK_Patient_Doctors_Doctors_Did",
                        column: x => x.Did,
                        principalTable: "Doctors",
                        principalColumn: "Did",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Patient_Doctors_Patients_pid",
                        column: x => x.pid,
                        principalTable: "Patients",
                        principalColumn: "pid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_departementDeptno",
                table: "Doctors",
                column: "departementDeptno");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_doctorDid",
                table: "Employees",
                column: "doctorDid");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Departments_deptno",
                table: "Patient_Departments",
                column: "deptno");

            migrationBuilder.CreateIndex(
                name: "IX_Patient_Doctors_Did",
                table: "Patient_Doctors",
                column: "Did");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_departmentDeptno",
                table: "Rooms",
                column: "departmentDeptno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Patient_Departments");

            migrationBuilder.DropTable(
                name: "Patient_Doctors");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
