using HotelListing.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelListing.Api
{
    public class HotelListingDbContext : DbContext
    {
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options) : base(options)
        {
            
        }

        //DbSet data type represents a table inside our database
        //Ef Core will look and the field name and create table named accordingly 
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Country> Countries { get; set; }


    }
}
