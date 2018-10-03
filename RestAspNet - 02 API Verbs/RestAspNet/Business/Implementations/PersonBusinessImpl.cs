using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestAspNet.Controllers.Models;
using RestAspNet.Models.Context;
using RestAspNet.Repository;

namespace RestAspNet.Business
{
    public class PersonBusinessImpl : IPersonBusiness

    {

        private IPersonRepository _repository;

        public PersonBusinessImpl(IPersonRepository repository)
        {
            _repository = repository;
        }

        private volatile int count;

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
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

            return _repository.FindAll();
        }

        public Person FindById(long id)
        {
            return _repository.FindById(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
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
