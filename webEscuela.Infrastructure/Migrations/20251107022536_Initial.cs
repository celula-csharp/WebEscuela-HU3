// using System;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// #nullable disable
//
// namespace webEscuela.Infrastructure.Migrations
// {
//     /// <inheritdoc />
//     public partial class Initial : Migration
//     {
//         /// <inheritdoc />
//         protected override void Up(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.AlterDatabase()
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "admins",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//                     Email = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Password = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4")
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_admins", x => x.Id);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "users",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//                     Name = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     LastName = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     DocNumber = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Email = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Phone = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     UserName = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Password = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Role = table.Column<int>(type: "int", nullable: false),
//                     Code = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4")
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_users", x => x.Id);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "students",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false),
//                     StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
//                     Career = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_students", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_students_users_Id",
//                         column: x => x.Id,
//                         principalTable: "users",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "teachers",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false),
//                     Specialization = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4")
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_teachers", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_teachers_users_Id",
//                         column: x => x.Id,
//                         principalTable: "users",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "Courses",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//                     CourseName = table.Column<string>(type: "longtext", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     Code = table.Column<string>(type: "varchar(255)", nullable: false)
//                         .Annotation("MySql:CharSet", "utf8mb4"),
//                     TeacherId = table.Column<int>(type: "int", nullable: false),
//                     StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
//                     EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Courses", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_Courses_teachers_TeacherId",
//                         column: x => x.TeacherId,
//                         principalTable: "teachers",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateTable(
//                 name: "Enrollments",
//                 columns: table => new
//                 {
//                     Id = table.Column<int>(type: "int", nullable: false)
//                         .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
//                     StudentId = table.Column<int>(type: "int", nullable: false),
//                     CourseId = table.Column<int>(type: "int", nullable: false),
//                     Grade = table.Column<double>(type: "double", nullable: false),
//                     EnrollmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
//                 },
//                 constraints: table =>
//                 {
//                     table.PrimaryKey("PK_Enrollments", x => x.Id);
//                     table.ForeignKey(
//                         name: "FK_Enrollments_Courses_CourseId",
//                         column: x => x.CourseId,
//                         principalTable: "Courses",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                     table.ForeignKey(
//                         name: "FK_Enrollments_students_StudentId",
//                         column: x => x.StudentId,
//                         principalTable: "students",
//                         principalColumn: "Id",
//                         onDelete: ReferentialAction.Cascade);
//                 })
//                 .Annotation("MySql:CharSet", "utf8mb4");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_admins_Email",
//                 table: "admins",
//                 column: "Email",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_admins_Id",
//                 table: "admins",
//                 column: "Id",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Courses_Code",
//                 table: "Courses",
//                 column: "Code",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Courses_TeacherId",
//                 table: "Courses",
//                 column: "TeacherId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Enrollments_CourseId",
//                 table: "Enrollments",
//                 column: "CourseId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_Enrollments_StudentId",
//                 table: "Enrollments",
//                 column: "StudentId");
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_users_Code",
//                 table: "users",
//                 column: "Code",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_users_DocNumber",
//                 table: "users",
//                 column: "DocNumber",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_users_Email",
//                 table: "users",
//                 column: "Email",
//                 unique: true);
//
//             migrationBuilder.CreateIndex(
//                 name: "IX_users_UserName",
//                 table: "users",
//                 column: "UserName",
//                 unique: true);
//         }
//
//         /// <inheritdoc />
//         protected override void Down(MigrationBuilder migrationBuilder)
//         {
//             migrationBuilder.DropTable(
//                 name: "admins");
//
//             migrationBuilder.DropTable(
//                 name: "Enrollments");
//
//             migrationBuilder.DropTable(
//                 name: "Courses");
//
//             migrationBuilder.DropTable(
//                 name: "students");
//
//             migrationBuilder.DropTable(
//                 name: "teachers");
//
//             migrationBuilder.DropTable(
//                 name: "users");
//         }
//     }
// }
