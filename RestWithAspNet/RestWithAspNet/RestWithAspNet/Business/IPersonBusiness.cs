using RestWithAspNet.Model;
using System.Collections.Generic;

namespace RestWithAspNet.Business
{
    public interface IPersonBusiness
    {
        Person Create(Person person);

        Person Update(Person person);

        Person FindById(long id);

        void Delete(long id);

        List<Person> FindAll();
    }
}
