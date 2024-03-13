namespace SuggestionSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class StoreDb : DbContext
    {
        public StoreDb()
            : base("name=StoreDb")
        {
        }

      
        public virtual DbSet<Degree> Degrees { get; set; }
        public virtual DbSet<DomainOfUsage> DomainOfUsages { get; set; }
        public virtual DbSet<Invitatin> Invitatins { get; set; }

        public virtual DbSet<FileUpload> FileUploads { get; set; }
        public virtual DbSet<MemberType> MemberTypes { get; set; }
        public virtual DbSet<ParticipatingUnit> ParticipatingUnits { get; set; }
        public virtual DbSet<ParticipatingUnits_Suggest_Interface> ParticipatingUnits_Suggest_Interface { get; set; }
        public virtual DbSet<PartType> PartTypes { get; set; }
        public virtual DbSet<PeopleType> PeopleTypes { get; set; }
        public virtual DbSet<PersonProfile> PersonProfiles { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<SuggestProfil> SuggestProfils { get; set; }
        public virtual DbSet<SuggestType> SuggestTypes { get; set; }
        public virtual DbSet<SuggProfile_SuggType_Interface> SuggProfile_SuggType_Interface { get; set; }
        public virtual DbSet<TitlList> TitlLists { get; set; }
        public virtual DbSet<UnitType_Suggest_Interface> UnitType_Suggest_Interface { get; set; }
        public virtual DbSet<UnitType> UnitTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            modelBuilder.Entity<DomainOfUsage>()
                .HasMany(e => e.SuggestProfils)
                .WithOptional(e => e.DomainOfUsage)
                .HasForeignKey(e => e.ID_DomainOfUsage);

            modelBuilder.Entity<Invitatin>()
                .HasMany(e => e.SuggestProfils)
                .WithOptional(e => e.Invitatin)
                .HasForeignKey(e => e.ID_Invitation);

            modelBuilder.Entity<MemberType>()
                .HasMany(e => e.PersonProfiles)
                .WithOptional(e => e.MemberType)
                .HasForeignKey(e => e.ID_MemType);

            modelBuilder.Entity<ParticipatingUnit>()
                .HasMany(e => e.ParticipatingUnits_Suggest_Interface)
                .WithOptional(e => e.ParticipatingUnit)
                .HasForeignKey(e => e.ID_PartiCipatingU);

            modelBuilder.Entity<PartType>()
                .HasMany(e => e.SuggProfile_SuggType_Interface)
                .WithOptional(e => e.PartType)
                .HasForeignKey(e => e.ID_Part);

            modelBuilder.Entity<PeopleType>()
                .HasMany(e => e.SuggestProfils)
                .WithOptional(e => e.PeopleType)
                .HasForeignKey(e => e.ID_PeopleType);

            modelBuilder.Entity<SuggestProfil>()
                .HasMany(e => e.SuggProfile_SuggType_Interface)
                .WithOptional(e => e.SuggestProfil)
                .HasForeignKey(e => e.ID_SuggProfile);

            modelBuilder.Entity<SuggestType>()
                .HasMany(e => e.SuggProfile_SuggType_Interface)
                .WithOptional(e => e.SuggestType)
                .HasForeignKey(e => e.ID_SuggType);

            modelBuilder.Entity<UnitType>()
                .HasMany(e => e.UnitType_Suggest_Interface)
                .WithOptional(e => e.UnitType)
                .HasForeignKey(e => e.ID_UnitType);
        }
    }
}
