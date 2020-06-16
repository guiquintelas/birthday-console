using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Repositories
{
    public class PersonRepository
    {
        private readonly List<Person> TodasPessoas = new List<Person>()
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
                BirthDate = DateTime.Parse("1996-10-07")
            },
        };

        public List<Person> Index()
        {
            return TodasPessoas;
        }
        
        public List<Person> FilterByNome(string termo)
        {
            return TodasPessoas.FindAll(p => p.FirstName.ToLower().Contains(termo.ToLower()));
        }
        
        public void Add(Person person)
        {
            TodasPessoas.Add(person);
        }

        public Person GetByNome(string nome)
        {
            return TodasPessoas.Find(p => p.FirstName.Contains(nome));
        }

        public void DeleteByNome(string nome)
        {
            TodasPessoas.Remove(GetByNome(nome));
        }
        
        public void UpdateByNome(Person person)
        {
            TodasPessoas.Remove(GetByNome(person.FirstName));
            TodasPessoas.Add(person);
        }
    }
}