﻿using Kino.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Kino.Api.DataLayer
{
    public class KinoDbContext: DbContext
    {
        public KinoDbContext( DbContextOptions<KinoDbContext> options)
            : base(options) {}


        public DbSet<Moveis> Moveiss { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
