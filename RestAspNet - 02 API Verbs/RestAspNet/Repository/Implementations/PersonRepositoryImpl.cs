using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RestAspNet.Business;
using RestAspNet.Controllers.Models;
using RestAspNet.Models.Context;

namespace RestAspNet.Repository.Implementatios
{
    public class PersonRepositoryImpl : IPersonRepository

    {

        private MySQLContext _context;

        public PersonRepositoryImpl(MySQLContext context)
        {
            _context = context;
        }

        private volatile int count;

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;

        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));

            try
            {
                if (result != null) _context.Persons.Remove(result);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Person> FindAll()
        {
            /* List<Person> persons = new List<Person>();

             for (int i = 0; i < 10; i++)
             {
                 Person person = MockPerson(i);
                 persons.Add(person);
             }

             return persons;

             */

            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Update(Person person)
        {
            if (!Exist(person.Id)) return null;

            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));

            try
            {
                _context.Entry(result).CurrentValues.SetValues(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return person;
        }

        public bool Exist(long? id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }




        /* 
            Método de Mocks 
        */

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Nome" + i,
                LastName = "Sobrenome" + i,
                Addres = "Mogi",
                Gender = "M"
            };
        }


        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }


    }
}
