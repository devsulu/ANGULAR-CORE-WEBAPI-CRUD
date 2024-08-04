using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace angularCRUDAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    employeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeGender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    employeeSkills = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.employeeId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
