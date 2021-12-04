using CreditCard.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditCard.Backend.Data
{
    public class CardDetailContext : DbContext
    {
        public CardDetailContext(DbContextOptions<CardDetailContext> options): base(options)
        { }

        public DbSet<CardDetail> CardDetails { get; set; }
    }
}
