namespace PersonMVCAss.Models.Repos
{
    public class InMemoryPeopleRepo : IPeoplesRepo
    {


        static int idCounter = 0;
        static List<Person> personsList = new List<Person>();
        public Person Create(Person person)
        {
            person.Id = ++idCounter;
            personsList.Add(person);
            return person;
        }

        public List<Person> GetAll()
        {
            return personsList;
        }

        public List<Person> GetByCity(string city)
        {
            List<Person> personCity = new List<Person>();
            foreach (Person pPerson in personsList)
            {
                if (pPerson.City == city)
                {
                    personCity.Add(pPerson);
                }

            }
            return personCity;

        }

        public Person GetById(int id)
        {
            Person person = null;
            foreach (Person person1 in personsList)
            {
                if (person1.Id == id)
                {
                    person = person1;
                    break;
                }
            }
            return person;
        }

        public void Update(Person person)
        {
            Person originalPerson = GetById(person.Id);
            if (originalPerson != null)
            {
                originalPerson.Name = person.Name;
                originalPerson.City = person.City;
                originalPerson.PhoneNumber = person.PhoneNumber;
            }
        }
        public void Delete(Person person)
        {
            if (person != null)
            {
                personsList.Remove(person);
            }
        }
    }
}
