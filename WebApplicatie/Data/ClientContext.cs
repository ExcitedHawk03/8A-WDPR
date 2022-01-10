using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

    public class ClientContext : IdentityDbContext
    {
        public ClientContext (DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; }
        public DbSet<hulpverlener> hulpverlener { get; set; }
        public DbSet<client> cliënt { get; set; }
        public DbSet<ouder> ouder { get; set; }
        public DbSet<moderator> moderator { get; set; }
    }
