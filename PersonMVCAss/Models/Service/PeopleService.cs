using PersonMVCAss.Models.Repos;
using PersonMVCAss.Models.VIewModels;

namespace PersonMVCAss.Models.Service
{
    public class PeopleService : IPeopleService
    {
        IPeoplesRepo _peoplesRepo;
        public PeopleService(IPeoplesRepo peoplesRepo)
        {
            _peoplesRepo = peoplesRepo;
        }
        public Person Create(CreatePersonViewModel createPerson)
        {
            if (string.IsNullOrEmpty(createPerson.Name) || string.IsNullOrWhiteSpace(createPerson.City))//|| int.Parse(createPeople.PhoneNumber))
            {
                throw new ArgumentException("Name,PhoneNumber,CityName not allowed whitespace");
            }

            Person person = new Person()
            {
                Name = createPerson.Name,
                PhoneNumber = createPerson.PhoneNumber,
                City = createPerson.City

            };
            person = _peoplesRepo.Create(person);
            return person;

        }



        public Person FindById(int id)
        {
            return _peoplesRepo.GetById(id);
        }

        public List<Person> GetAll()
        {
            return _peoplesRepo.GetAll();
        }
        //public List<People> FindByCityName(string cityname) => _peopleRepo.GetByCityName(cityname);
        public void Edit(int id, CreatePersonViewModel editPerson)
        {
            throw new NotImplementedException();
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
        public Person? LastAdded()
        {
            List<Person> person = _peoplesRepo.GetAll();
            if (person.Count < 1)
            {
                return null;
            }

            return person.Last();
        }


    }
}

