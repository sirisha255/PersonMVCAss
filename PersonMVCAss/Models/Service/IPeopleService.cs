using PersonMVCAss.Models.VIewModels;

namespace PersonMVCAss.Models.Service
{
    public interface IPeopleService
    {
        Person Create(CreatePersonViewModel createPerson);
        List<Person> GetAll();
        Person FindById(int id);
        void Edit(int id, CreatePersonViewModel editPerson);
        void Remove(int id);
        Person LastAdded();
    }
}
