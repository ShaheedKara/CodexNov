using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sprint1AppDev3A.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
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
            : base("OLLDB56", throwIfV1Schema: false)//DBContext5
        {
        } 

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<RFQ> rfq { get; set; }
        public DbSet<Quotes> quote { get; set; }

        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Vm> vms { get; set; }
        public DbSet<RateUs> RateUs { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Freequote> Freequotes {get; set;}
        public DbSet<CalAmt> CalAmts { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Vat> Vats { get; set; }
       public DbSet<prices> Prices { get; set; }
        public DbSet<maintain> Maintains { get; set; }
        public DbSet<Invoice> Invoies { get; set; }
        public DbSet<accountant> accountants { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<drivercheckinMk2> drivercheckinMk2 { get; set; }


        // public DbSet<Assign> Assigns { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.Assign> Assigns { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.AssignViewModel> AssignViewModels { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.DriverCheckIn> DriverCheckIns { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewTruck> NewTrucks { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewContainer> NewContainers { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewTrailer> NewTrailers { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewDriver> NewDrivers { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewAssign> NewAssigns { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewNEWAssign> NewNEWAssigns { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.DatesBookedDriver> DatesBookedDrivers { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.DatesBookedTrailer> DatesBookedTrailers { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.DatesBookedTrucks> DatesBookedTrucks { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.NewBooking> NewBookings { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.TrailerMk2> TrailerMk2 { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.AssignTrailerCont> AssignTrailerConts { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.PreSchedule> PreSchedules { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.Resource> Resources { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.ArchiveBooking> ArchiveBookings { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.AssignMk2> AssignMk2 { get; set; }
        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.Maintenance> Maintenances { get; set; }
        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.DeliveryNote> DeliveryNotes { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.checkIN> Checkin { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.CheckOut2> CheckOut2s { get; set; }

        public System.Data.Entity.DbSet<Sprint1AppDev3A.Models.ArchiveNewBooking> ArchiveNewBookings { get; set; }
    }
}