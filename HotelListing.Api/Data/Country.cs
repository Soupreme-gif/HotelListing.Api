namespace HotelListing.Api.Data;

public class Country
{
    // These three fields below are used to associate with the columns in the tables in the database.
    public int CountryId { get; set; }
    public String Name { get; set; }
    public String ShortName { get; set; }
    // This Hotels variable is called a navigation property that is used for relational operartions
    // it is a Ilist variable because a country can have multiple hotels.
    // The "= []" is to avoid null exceptions
    public IList<Hotel> Hotels { get; set; } = [];
}
