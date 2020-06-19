using System;
using System.CodeDom;
using System.Linq;

namespace BLL.Models
{
    public class Person
    {
        public Person()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Id = new string(
                Enumerable.Repeat(chars, 10)
                    .Select(s => s[random.Next(s.Length)])
                    .ToArray());
        }

        private string Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        
        public void ConsoleWrite() 
        {
            Console.WriteLine($"ID: {this.Id}");
            Console.WriteLine($"Nome: {this.FirstName}");
            Console.WriteLine($"Sobrenome: {this.LastName}");
            Console.WriteLine($"Data de Nascimento: {this.BirthDate}");
            Console.WriteLine($"Dias para o próximo aniversário: {this.DaysToBirthday()}");
        }

        private double DaysToBirthday()
        {
            var nextBirthday = new DateTime(DateTime.Today.Year, this.BirthDate.Month, this.BirthDate.Day);

            return nextBirthday > DateTime.Today ? 
                (nextBirthday - DateTime.Today).TotalDays : 
                (nextBirthday.AddYears(1) - DateTime.Today).TotalDays;
        }
    }
}