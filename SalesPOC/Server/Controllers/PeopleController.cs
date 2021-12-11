using Microsoft.AspNetCore.Mvc;
using SalesPOC.Shared;

namespace SalesPOC.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        public List<People> people = new List<People>();

        public PeopleController(ILogger<PeopleController> logger)
        {
            _logger = logger;
        }

        private void InitializePeople()
        {
            People person = new People();
            person.personID = 1;
            person.FirstName = "Ryan";
            person.LastName = "Black";
            person.Address1 = "1234 Test Address";
            person.Address2 = "";
            person.City = "Test City";
            person.PostalCode = "12345";
            person.State = "KY";
            person.PreferredContactMethod = "Email";
            person.CellNumber = "1234565";
            person.HomeNumber = "1234565";
            people.Add(person);

            person = new People();
            person.personID = 2;
            person.FirstName = "Mary";
            person.LastName = "Smith";
            person.Address1 = "9100 Testing Avenue";
            person.Address2 = "";
            person.City = "Test City";
            person.PostalCode = "12345";
            person.State = "KY";
            person.PreferredContactMethod = "Email";
            person.CellNumber = "1234565";
            person.HomeNumber = "1234565";
            people.Add(person);
        }

        [HttpGet]
        public IEnumerable<People> Get()
        {
            if (people.Count == 0)
                InitializePeople();

            return people;
        }

        [HttpGet("{PersonID}")]
        public People GetById(int PersonID)
        {
            IEnumerable<People> results = Get();
            return results.First(person => person.personID == PersonID);
        }

        [HttpPost]
        public Task Post([FromBody] People person)
        {
            if (people.Count == 0)
                InitializePeople();

            if (person.personID == -1)
                people.Add(person);
            else
            {
                var obj = people.FirstOrDefault(x => x.personID == person.personID);
                if (obj != null) 
                    obj.FirstName = person.FirstName;
                    obj.LastName = person.LastName;
                    obj.Address1 = person.Address1;
                    obj.Address2 = person.Address2;
                    obj.City = person.City;
                    obj.State = person.State;
                    obj.PostalCode = person.PostalCode;
                    obj.PreferredContactMethod = person.PreferredContactMethod;
                    obj.CellNumber = person.CellNumber;
                    obj.HomeNumber = person.HomeNumber;
            }

            return Task.CompletedTask;
        }

        [HttpDelete("{PersonID}")]
        public Task Delete(int personID)
        {
            if (people.Count == 0)
                InitializePeople();

            var itemToRemove = people.Single(r => r.personID == personID);
            people.Remove(itemToRemove);

            return Task.CompletedTask;
        }
    }
}