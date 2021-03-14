using Harissa.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Harissa.Data
{
    public class HarissaContext : DbContext
    {
        public HarissaContext(DbContextOptions<HarissaContext> options) : base(options)
        {
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Bio> Bio { get; set; }
        public DbSet<IndexPage> IndexPages { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Concert> Concerts { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<PageSettings> PageSettings { get; set; }
        public DbSet<MediaPatronage> MediaPatronages { get; set; }
        public DbSet<PrivacyPolicy> PrivacyPolicies { get; set; }

    }
}
