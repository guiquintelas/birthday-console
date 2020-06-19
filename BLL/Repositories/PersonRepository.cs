using System;
using System.Collections.Generic;
using BLL.Models;

namespace BLL.Repositories
{
    public class PersonRepository
    {
        private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "../../Res/db.csv");
        public PersonRepository()
        {
            this.LoadFromFile();
        }

        public void Dispose()
            {
            this.WriteToFile();
        }
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
            return AllPersons.FindAll(p => 
                p.FirstName.ToLower().Contains(name.ToLower()) || 
                p.LastName.ToLower().Contains(name.ToLower())
            );
        }
        
        public void Add(Person person)
        {
        private void LoadFromFile()
        {
            using (var stream = new StreamReader(FilePath, Encoding.Default))
            {
                while (!stream.EndOfStream)
                {
                    var row = stream.ReadLine()?.Split(';');
                    if (row != null)
                    {
                        _allPersons.Add(new Person()
                        {
                            Id = row[0],
                            FirstName = row[1],
                            LastName = row[2],
                            BirthDate = DateTime.Parse(row[3]),
                        });
                    }
                }
            }
        }
        
        private void WriteToFile()
        {
            Console.WriteLine("Salvando dados em disco ...");
            using (var stream = new StreamWriter(FilePath))
            {
                foreach (var person in _allPersons)
                {
                    stream.WriteLine($"{person.Id};{person.FirstName};{person.LastName};{person.BirthDate:yyyy-MM-dd}");
                }
            }
        }
    }
}