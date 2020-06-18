using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Repositories
{
    public class PersonRepository
    {
        private static readonly List<Person> AllPersons = new List<Person>()
        {
            new Person()
            {
                FirstName = "Teste",
                LastName = "Opa",
                BirthDate = DateTime.Parse("1996-10-07")
            },
            new Person()
            {
                FirstName = "Teste 2",
                LastName = "Opa",
                BirthDate = DateTime.Parse("1996-05-07")
            },
        };

        public List<Person> All()
        {
            return AllPersons;
        }
        
        public List<Person> FilterByName(string name)
        {
            return AllPersons.FindAll(p => p.FirstName.ToLower().Contains(name.ToLower()));
        }
        
        public void Add(Person person)
        {
            AllPersons.Add(person);
        }
    }
}