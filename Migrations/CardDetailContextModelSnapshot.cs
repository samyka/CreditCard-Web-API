// <auto-generated />
using CreditCard.Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CreditCard.Migrations
{
    [DbContext(typeof(CardDetailContext))]
    partial class CardDetailContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CreditCard.Backend.Models.CardDetail", b =>
                {
                    b.Property<string>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("ExpirationDate")
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("NameOnCard")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("SecurityCode")
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("PaymentId");

                    b.ToTable("CardDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
