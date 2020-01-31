using GolfHandicap.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GolfHandicap.Data
{
    public class RoundDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Round> Rounds { get; set; }
        public IEnumerable<object> ScoreDifferential { get; internal set; }

        public RoundDbContext(DbContextOptions<RoundDbContext> options) : base(options){}

    }
}
