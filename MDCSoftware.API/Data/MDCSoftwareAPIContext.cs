using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MDCSoftware.API.Modelo;

namespace MDCSoftware.API.Models
{
    public class MDCSoftwareAPIContext : DbContext
    {
        public MDCSoftwareAPIContext (DbContextOptions<MDCSoftwareAPIContext> options)
            : base(options)
        {
        }

        public DbSet<MDCSoftware.API.Modelo.Pessoa> Pessoa { get; set; }
    }
}
