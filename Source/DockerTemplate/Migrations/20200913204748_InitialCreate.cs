#pragma warning disable IDE0058 // Expression value is never used
#pragma warning disable IDE0022 // Use expression body for methods
#pragma warning disable CA1062 // Validate arguments of public methods
#pragma warning disable SA1413 // Use trailing comma in multi-line initializers
#pragma warning disable IDE0053 // Use expression body for lambda expressions
namespace DockerTemplate.Migrations
{
    using System;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    CarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTimeOffset>(nullable: false),
                    Cylinders = table.Column<int>(nullable: false),
                    Make = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.CarId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}

#pragma warning restore CA1062 // Validate arguments of public methods
#pragma warning restore SA1413 // Use trailing comma in multi-line initializers
#pragma warning restore IDE0053 // Use expression body for lambda expressions
#pragma warning restore IDE0022 // Use expression body for methods
#pragma warning restore IDE0058 // Expression value is never used
