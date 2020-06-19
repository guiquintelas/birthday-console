using System;
using System.Globalization;
using BLL.Models;

namespace AniversarioConsole.MenuActions
{
    public class UpdatePersonAction : MenuAction
    {
        public UpdatePersonAction() : base("Atualizar uma pessoa")
        {
        }

        public override void Action()
        {
            Console.WriteLine("Informe o Id da pessoa para atualizar:");
            var id = Console.ReadLine();

            Person person;

            try
            {
                person = App.PersonRepository.FindById(id);
            }
            catch (Exception e)
            {
                Console.WriteLine("Id não encontrado!");
                return;
            }
            
            Console.WriteLine($"Novo nome: ({person.FirstName})");
            var newName = Console.ReadLine();
            if (newName != "")
                person.FirstName = newName;
            
            Console.WriteLine($"Novo sobrenome: ({person.LastName})");
            var newLastName = Console.ReadLine();
            if (newLastName != "")
                person.LastName = newLastName;
            
            Console.WriteLine($"Nova data de nascimento: ({person.BirthDate:dd/MM/yyyy})");
            var newBirthDate = Console.ReadLine();
            if (newBirthDate != "")
                person.BirthDate = DateTime.ParseExact(
                    newBirthDate, 
                    "dd/MM/yyyy", 
                    CultureInfo.InvariantCulture);

            App.PersonRepository.Update(person);
            
            person.ConsoleWrite();
            Console.WriteLine("\nPessoa atualizado com sucesso!\n");
        }
    }
}