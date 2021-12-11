using System.ComponentModel.DataAnnotations;

namespace SalesPOC.Shared
{
    public class People
    {
        public int personID { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required]
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }

        public string State { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string CellNumber { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string HomeNumber { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string PreferredContactMethod { get; set; }
    }

    public static class States
    {
        public static List<State> los = new List<State> {
      //us
      new State("AL", "Alabama"),
      new State("AK", "Alaska"),
      new State("AZ", "Arizona"),
      new State("AR", "Arkansas"),
      new State("CA", "California"),
      new State("CO", "Colorado"),
      new State("CT", "Connecticut"),
      new State("DE", "Delaware"),
      new State("DC", "District Of Columbia"),
      new State("FL", "Florida"),
      new State("GA", "Georgia"),
      new State("HI", "Hawaii"),
      new State("ID", "Idaho"),
      new State("IL", "Illinois"),
      new State("IN", "Indiana"),
      new State("IA", "Iowa"),
      new State("KS", "Kansas"),
      new State("KY", "Kentucky"),
      new State("LA", "Louisiana"),
      new State("ME", "Maine"),
      new State("MD", "Maryland"),
      new State("MA", "Massachusetts"),
      new State("MI", "Michigan"),
      new State("MN", "Minnesota"),
      new State("MS", "Mississippi"),
      new State("MO", "Missouri"),
      new State("MT", "Montana"),
      new State("NE", "Nebraska"),
      new State("NV", "Nevada"),
      new State("NH", "New Hampshire"),
      new State("NJ", "New Jersey"),
      new State("NM", "New Mexico"),
      new State("NY", "New York"),
      new State("NC", "North Carolina"),
      new State("ND", "North Dakota"),
      new State("OH", "Ohio"),
      new State("OK", "Oklahoma"),
      new State("OR", "Oregon"),
      new State("PA", "Pennsylvania"),
      new State("RI", "Rhode Island"),
      new State("SC", "South Carolina"),
      new State("SD", "South Dakota"),
      new State("TN", "Tennessee"),
      new State("TX", "Texas"),
      new State("UT", "Utah"),
      new State("VT", "Vermont"),
      new State("VA", "Virginia"),
      new State("WA", "Washington"),
      new State("WV", "West Virginia"),
      new State("WI", "Wisconsin"),
      new State("WY", "Wyoming"),
      //canada
      new State("AB", "Alberta"),
      new State("BC", "British Columbia"),
      new State("MB", "Manitoba"),
      new State("NB", "New Brunswick"),
      new State("NL", "Newfoundland and Labrador"),
      new State("NS", "Nova Scotia"),
      new State("NT", "Northwest Territories"),
      new State("NU", "Nunavut"),
      new State("ON", "Ontario"),
      new State("PE", "Prince Edward Island"),
      new State("QC", "Quebec"),
      new State("SK", "Saskatchewan"),
      new State("YT", "Yukon"),
      };

        public static List<string> Abbreviations()
        {
            return los.Select(s => s.Abbreviation).ToList();
        }

        public static List<string> Names()
        {
            return los.Select(s => s.Name).ToList();
        }

        public static string GetName(string abbreviation)
        {
            return los.Where(s => s.Abbreviation.Equals(abbreviation, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Name).FirstOrDefault();
        }

        public static string GetAbbreviation(string name)
        {
            return los.Where(s => s.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)).Select(s => s.Abbreviation).FirstOrDefault();
        }

        public static List<State> ToList()
        {
            return los;
        }
    }

    public class State
    {
        public State(string ab, string name)
        {
            Name = name;
            Abbreviation = ab;
        }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", Abbreviation, Name);
        }
    }
}