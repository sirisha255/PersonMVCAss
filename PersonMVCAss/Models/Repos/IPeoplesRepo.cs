namespace PersonMVCAss.Models.Repos
{
    public interface IPeoplesRepo
    {
        //crud
        //c
        Person Create(Person person);

        //Read
        List<Person> GetAll();
        List<Person> GetByCity(string City);

        Person GetById(int id);


        //U
        void Update(Person person);

        //Delete
        void Delete(Person person);
        //People LastAdded();
    }
}
