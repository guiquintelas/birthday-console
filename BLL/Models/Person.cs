using System;
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
    }
}