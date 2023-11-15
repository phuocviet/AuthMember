using AuthMember.Controllers;
using AuthMember.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthMember.Data
{
    public class MemberContext : DbContext
    {
        public DbSet<Member> members { get; set; }
        public DbSet<UserCredential> credential { get; set; } 
        
        public MemberContext(DbContextOptions<MemberContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserCredential>()
                .HasOne(m => m.Member)
                .WithOne(u => u.UserCredential)
                .HasForeignKey<Member>(m => m.Id);
        }
    }
}
