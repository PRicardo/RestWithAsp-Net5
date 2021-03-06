using RestWithAspNet.Model;
using RestWithAspNet.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNet.Repository.Implementations
{
    public class PersonRepositoryImplementation : IPersonRepository
    {

        private MySqlContext _context;

        public PersonRepositoryImplementation(MySqlContext context)
        {
            _context = context;
        }


        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }

            return person;
        }

        public void Delete(long id)
        {
            var result = FindById(id);

            try
            {
                _context.People.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Person> FindAll()
        {
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            Person person = _context.People.SingleOrDefault(p => p.Id == id);
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
                return new Person();

            var result = FindById(person.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return person;
        }

        public bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
