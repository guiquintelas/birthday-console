using System;
using System.Globalization;
using BLL.Models;

namespace AniversarioConsole.MenuActions
{
    public class InsertPersonAction : MenuAction
    {
        public InsertPersonAction() : base("Adicionar nova pessoa")
        {
        }

        public override void Action()
        {
            var newPerson = new Person();
            
            Console.WriteLine("Nome:");
            newPerson.FirstName = Console.ReadLine();
            
            Console.WriteLine("Sobrenome:");
            newPerson.LastName = Console.ReadLine();

            while(true)
            {
                try
                {
                    Console.WriteLine("Data de Nascimento (dd/MM/yyyy):");
                    newPerson.BirthDate = DateTime.ParseExact(
                        Console.ReadLine(), 
                        "dd/MM/yyyy", 
                        CultureInfo.InvariantCulture);
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Data Inválida!");
                }
            }

            App.PersonRepository.Add(newPerson);
            
            Console.WriteLine();
            Console.WriteLine($"A Pessoa {newPerson.FirstName} {newPerson.LastName} foi adicionada com sucesso!");
            newPerson.ConsoleWrite();
            Console.WriteLine();
        }
    }
}