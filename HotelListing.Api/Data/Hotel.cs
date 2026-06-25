using System.Diagnostics.Metrics;

namespace HotelListing.Api.Data;

public class Hotel
{
    // These four fields below are used to associate with the columns in the tables in the database.
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public double Rating { get; set; }
    // The CountryId variable is called a Foreign Key
    // This country variable is called a navigation property that is used for relational operartions.
    // it is two variables because there is only one country a hotel can be in.
    public int CountryId { get; set; }
    public Country? Country { get; set; }

}
