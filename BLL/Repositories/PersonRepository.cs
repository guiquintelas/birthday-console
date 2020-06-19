using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BLL.Models;

namespace BLL.Repositories
{
    public class PersonRepository
    {
        private static readonly string FilePath = Path.Combine(Environment.CurrentDirectory, "../../Res/db.csv");
        private static List<Person> _allPersons = new List<Person>();
        
        public PersonRepository()
        {
            this.LoadFromFile();
        }

        public void Dispose()
        {
            this.WriteToFile();
        }


        public List<Person> FilterByBirthDay()
        {
            return _allPersons.FindAll(p => p.DaysToBirthday() >= 365);
        }
        
        public Person FindById(string id)
        {
            return _allPersons.Find(
                p => string.Equals(p.Id, id, StringComparison.CurrentCultureIgnoreCase)
            );
        }
        
        public List<Person> FilterByName(string name)
        {
            return _allPersons.FindAll(p => 
                p.FirstName.ToLower().Contains(name.ToLower()) || 
                p.LastName.ToLower().Contains(name.ToLower())
            );
        }
        
        public void Add(Person person)
        {
            _allPersons.Add(person);
        }
        
        public bool RemoveById(string id)
        {
            var countBefore = _allPersons.Count;

            _allPersons = _allPersons.FindAll(
                person => !string.Equals(person.Id, id, StringComparison.CurrentCultureIgnoreCase)
            );

            return countBefore != _allPersons.Count;
        }
        
        public bool Update(Person person)
        {
            int personIndex;
            
            try
            {
                personIndex = _allPersons.FindIndex(
                    p => string.Equals(p.Id, person.Id, StringComparison.CurrentCultureIgnoreCase)
                );
            }
            catch (Exception e)
            {
                return false;
            }

            _allPersons[personIndex] = person;
            return true;
        }

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