using Microsoft.EntityFrameworkCore.Migrations;

namespace CreditCard.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CardDetails",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NameOnCard = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CardNumber = table.Column<string>(type: "nvarchar(16)", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(5)", nullable: true),
                    SecurityCode = table.Column<string>(type: "nvarchar(3)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardDetails", x => x.PaymentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardDetails");
        }
    }
}
