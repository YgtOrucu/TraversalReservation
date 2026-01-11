using Microsoft.EntityFrameworkCore;
using TraversalAPI.DAL.Entities;

namespace TraversalAPI.DAL.Context
{
    public class VisitorContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YIGITORUCU\\MY_YOUTUBE_KURSU;initial catalog=DB_TravelsalReservationApi;Integrated Security=True;TrustServerCertificate=True");
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
