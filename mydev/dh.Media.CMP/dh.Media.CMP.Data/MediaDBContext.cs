using dh.Media.CMP.Data.Configuration;
using dh.Media.CMP.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace dh.Media.CMP.Data
{
    public class MediaDBContext:DbContext
    {
        public MediaDBContext(DbContextOptions<MediaDBContext> options): base(options) { }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new ClientConfiguration());
            builder.ApplyConfiguration(new ClientTypeConfiguration());
            builder.ApplyConfiguration(new RetailClientEntityTypeConfiguration());
        }
        //public DbSet<AudienceQuery> Audiences { get; set; }
        //public DbSet<AudienceQueryProductGroup> AudienceProductGroups { get; set; }
        //public DbSet<AudienceCriterion> AudienceCriterions { get; set; }
        //public DbSet<AudienceCriterionDateRange> AudienceCriterionDateRanges { get; set; }
        //public DbSet<AudienceCriterionReferenceType> AudienceCriterionReferenceTypes { get; set; }
        //public DbSet<AudienceCriterionReferenceTypeSelection> AudienceCriterionReferenceTypeSelections { get; set; }
        //public DbSet<AudienceCriterionType> AudienceCriterionTypes { get; set; }
        //public DbSet<AudienceCriterionTypeMarket> AudienceCriterionTypeMarkets { get; set; }
        //public DbSet<AudienceCriterionValueRange> AudienceCriterionValueRanges { get; set; }
        //public DbSet<AudienceObjective> AudienceObjectives { get; set; }
        //public DbSet<AudienceObjectiveType> AudienceObjectiveTypes { get; set; }
        //public DbSet<AudienceQueryProductGroup> AudienceQueryProductGroups { get; set; }
        //public DbSet<TargetingWeek> TargetingWeeks { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientType> ClientTypes { get; set; }
        public DbSet<RetailClient> RetailClients { get; set; }

        //public DbSet<UserProductGroup> UserProductGroups { get; set; }
        //public DbSet<UserProductGroupMember> UserProductGroupMembers { get; set; }
    }
}
