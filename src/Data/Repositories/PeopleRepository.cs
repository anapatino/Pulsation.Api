using Data.Repositories.Shared;
using Entities;

namespace Data.Repositories;

public class PeopleRepository: Repository<Person>
{
    public PeopleRepository(PulsationsDbContext context) : base(context)
    {
    }
}
