using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SuggestionSystem.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StoreDb", throwIfV1Schema: false)
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


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}