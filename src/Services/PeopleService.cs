using Data.Repositories;
using Entities;
using Entities.Exceptions;
namespace Services;

public class PeopleService
{
    private readonly PeopleRepository _peopleRepository;

    public PeopleService(PeopleRepository peopleRepository)
    {
        _peopleRepository = peopleRepository;
    }

    public string SavePerson(Person person)
    {
        try
        {
            _peopleRepository.Save(person);
            return "Registro guardado con exito";
        }
        catch (Exception e)
        {
            throw new PersonException($"Ha ocurrido un error al registrar {e.Message}");
        }
    }

    public Person? SearchPerson(string identification)
    {
        return _peopleRepository.Find(person =>
            person.Identification == identification);
    }

    public List<Person> GetAllPeople()
    {
        return _peopleRepository.GetAll();
    }

    public List<Person> FilterPeopleName(string name)
    {
        return _peopleRepository.Filter(person => person.Name == name);
    }

    public string DeletePeople(string identification)
    {
        try
        {
            Person? foundPerson = SearchPerson(identification);
            if (foundPerson == null)
                throw new PersonException("Persona no encontrada");
            _peopleRepository.Delete(foundPerson);
            return "Registro eliminado";
        }
        catch (Exception e)
        {
            throw new  PersonException($"Ha ocurrido un error al eliminar {e.Message}");
        }
    }

}
