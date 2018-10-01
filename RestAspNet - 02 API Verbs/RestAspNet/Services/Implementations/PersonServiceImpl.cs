using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestAspNet.Controllers.Models;

namespace RestAspNet.Services.Implementations
{
    public class PersonServiceImpl : IPersonService

    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 10; i++)
            {
                Person person = MockPerson(i);
                persons.Add(person);
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Nelson",
                LastName = "Campos",
                Addres = "Mogi",
                Gender = "M"
            };
        }

        public Person Update(Person person)
        {
            return person;
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
