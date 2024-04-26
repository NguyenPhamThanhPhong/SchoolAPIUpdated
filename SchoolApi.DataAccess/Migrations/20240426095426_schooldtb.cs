using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApi.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class schooldtb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "faculties",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_faculties", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileUrlsString = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "schoolmemberLogs",
                columns: table => new
                {
                    schoolMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    schoolClassId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolmemberLogs", x => new { x.schoolClassId, x.schoolMemberId });
                });

            migrationBuilder.CreateTable(
                name: "semesters",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_semesters", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    createdAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subjects",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    facultyid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_subjects_faculties_facultyid",
                        column: x => x.facultyid,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacultyPost",
                columns: table => new
                {
                    facultiesid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    postsid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyPost", x => new { x.facultiesid, x.postsid });
                    table.ForeignKey(
                        name: "FK_FacultyPost_faculties_facultiesid",
                        column: x => x.facultiesid,
                        principalTable: "faculties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacultyPost_posts_postsid",
                        column: x => x.postsid,
                        principalTable: "posts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schoolClassRegistrations",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    semesterid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolClassRegistrations", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolClassRegistrations_semesters_semesterid",
                        column: x => x.semesterid,
                        principalTable: "semesters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "scheduleTables",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    semesterid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Userid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduleTables", x => x.id);
                    table.ForeignKey(
                        name: "FK_scheduleTables_semesters_semesterid",
                        column: x => x.semesterid,
                        principalTable: "semesters",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_scheduleTables_users_Userid",
                        column: x => x.Userid,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "userProfiles",
                columns: table => new
                {
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    avatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    joinYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    program = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userProfiles", x => x.userId);
                    table.ForeignKey(
                        name: "FK_userProfiles_users_userId",
                        column: x => x.userId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubjectSubject",
                columns: table => new
                {
                    prequisiteSubjectsid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    previousSubjectsid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectSubject", x => new { x.prequisiteSubjectsid, x.previousSubjectsid });
                    table.ForeignKey(
                        name: "FK_SubjectSubject_subjects_prequisiteSubjectsid",
                        column: x => x.prequisiteSubjectsid,
                        principalTable: "subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectSubject_subjects_previousSubjectsid",
                        column: x => x.previousSubjectsid,
                        principalTable: "subjects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schoolClasses",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    roomName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    program = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    classType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    semesterid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    subjectid = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SchoolClassRegistrationid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolClasses", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolClasses_schoolClassRegistrations_SchoolClassRegistrationid",
                        column: x => x.SchoolClassRegistrationid,
                        principalTable: "schoolClassRegistrations",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_schoolClasses_semesters_semesterid",
                        column: x => x.semesterid,
                        principalTable: "semesters",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_schoolClasses_subjects_subjectid",
                        column: x => x.subjectid,
                        principalTable: "subjects",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "creditLogs",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    studentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    progress = table.Column<float>(type: "real", nullable: false),
                    midterm = table.Column<float>(type: "real", nullable: false),
                    practice = table.Column<float>(type: "real", nullable: false),
                    final = table.Column<float>(type: "real", nullable: false),
                    average = table.Column<float>(type: "real", nullable: false),
                    schoolClassid = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditLogs", x => x.id);
                    table.ForeignKey(
                        name: "FK_creditLogs_schoolClasses_schoolClassid",
                        column: x => x.schoolClassid,
                        principalTable: "schoolClasses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_creditLogs_users_studentId",
                        column: x => x.studentId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exams",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    schoolClassid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exams", x => x.id);
                    table.ForeignKey(
                        name: "FK_exams_schoolClasses_schoolClassid",
                        column: x => x.schoolClassid,
                        principalTable: "schoolClasses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "LecturerLogs",
                columns: table => new
                {
                    schoolMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    schoolClassId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LecturerLogs", x => new { x.schoolClassId, x.schoolMemberId });
                    table.ForeignKey(
                        name: "FK_LecturerLogs_schoolClasses_schoolClassId",
                        column: x => x.schoolClassId,
                        principalTable: "schoolClasses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LecturerLogs_schoolmemberLogs_schoolClassId_schoolMemberId",
                        columns: x => new { x.schoolClassId, x.schoolMemberId },
                        principalTable: "schoolmemberLogs",
                        principalColumns: new[] { "schoolClassId", "schoolMemberId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LecturerLogs_users_schoolMemberId",
                        column: x => x.schoolMemberId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schedules",
                columns: table => new
                {
                    schoolClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    room = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dayOfWeek = table.Column<int>(type: "int", nullable: false),
                    start = table.Column<TimeSpan>(type: "time", nullable: false),
                    end = table.Column<TimeSpan>(type: "time", nullable: false),
                    scheduleTableid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schedules", x => x.schoolClassId);
                    table.ForeignKey(
                        name: "FK_schedules_scheduleTables_scheduleTableid",
                        column: x => x.scheduleTableid,
                        principalTable: "scheduleTables",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_schedules_schoolClasses_schoolClassId",
                        column: x => x.schoolClassId,
                        principalTable: "schoolClasses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "schoolClassSections",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    offset = table.Column<float>(type: "real", nullable: false),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileUrlsString = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchoolClassid = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolClassSections", x => x.id);
                    table.ForeignKey(
                        name: "FK_schoolClassSections_schoolClasses_SchoolClassid",
                        column: x => x.SchoolClassid,
                        principalTable: "schoolClasses",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StudentLogs",
                columns: table => new
                {
                    schoolMemberId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    schoolClassId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    progress = table.Column<int>(type: "int", nullable: false),
                    midterm = table.Column<int>(type: "int", nullable: false),
                    practice = table.Column<int>(type: "int", nullable: false),
                    final = table.Column<int>(type: "int", nullable: false),
                    average = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentLogs", x => new { x.schoolClassId, x.schoolMemberId });
                    table.ForeignKey(
                        name: "FK_StudentLogs_schoolClasses_schoolClassId",
                        column: x => x.schoolClassId,
                        principalTable: "schoolClasses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLogs_schoolmemberLogs_schoolClassId_schoolMemberId",
                        columns: x => new { x.schoolClassId, x.schoolMemberId },
                        principalTable: "schoolmemberLogs",
                        principalColumns: new[] { "schoolClassId", "schoolMemberId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentLogs_users_schoolMemberId",
                        column: x => x.schoolMemberId,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_creditLogs_schoolClassid",
                table: "creditLogs",
                column: "schoolClassid");

            migrationBuilder.CreateIndex(
                name: "IX_creditLogs_studentId",
                table: "creditLogs",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_exams_schoolClassid",
                table: "exams",
                column: "schoolClassid");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyPost_postsid",
                table: "FacultyPost",
                column: "postsid");

            migrationBuilder.CreateIndex(
                name: "IX_LecturerLogs_schoolClassId",
                table: "LecturerLogs",
                column: "schoolClassId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LecturerLogs_schoolMemberId",
                table: "LecturerLogs",
                column: "schoolMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_schedules_scheduleTableid",
                table: "schedules",
                column: "scheduleTableid");

            migrationBuilder.CreateIndex(
                name: "IX_scheduleTables_semesterid",
                table: "scheduleTables",
                column: "semesterid");

            migrationBuilder.CreateIndex(
                name: "IX_scheduleTables_Userid",
                table: "scheduleTables",
                column: "Userid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClasses_SchoolClassRegistrationid",
                table: "schoolClasses",
                column: "SchoolClassRegistrationid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClasses_semesterid",
                table: "schoolClasses",
                column: "semesterid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClasses_subjectid",
                table: "schoolClasses",
                column: "subjectid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClassRegistrations_semesterid",
                table: "schoolClassRegistrations",
                column: "semesterid");

            migrationBuilder.CreateIndex(
                name: "IX_schoolClassSections_SchoolClassid",
                table: "schoolClassSections",
                column: "SchoolClassid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentLogs_schoolMemberId",
                table: "StudentLogs",
                column: "schoolMemberId");

            migrationBuilder.CreateIndex(
                name: "IX_subjects_facultyid",
                table: "subjects",
                column: "facultyid");

            migrationBuilder.CreateIndex(
                name: "IX_SubjectSubject_previousSubjectsid",
                table: "SubjectSubject",
                column: "previousSubjectsid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "creditLogs");

            migrationBuilder.DropTable(
                name: "exams");

            migrationBuilder.DropTable(
                name: "FacultyPost");

            migrationBuilder.DropTable(
                name: "LecturerLogs");

            migrationBuilder.DropTable(
                name: "schedules");

            migrationBuilder.DropTable(
                name: "schoolClassSections");

            migrationBuilder.DropTable(
                name: "StudentLogs");

            migrationBuilder.DropTable(
                name: "SubjectSubject");

            migrationBuilder.DropTable(
                name: "userProfiles");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "scheduleTables");

            migrationBuilder.DropTable(
                name: "schoolClasses");

            migrationBuilder.DropTable(
                name: "schoolmemberLogs");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "schoolClassRegistrations");

            migrationBuilder.DropTable(
                name: "subjects");

            migrationBuilder.DropTable(
                name: "semesters");

            migrationBuilder.DropTable(
                name: "faculties");
        }
    }
}
