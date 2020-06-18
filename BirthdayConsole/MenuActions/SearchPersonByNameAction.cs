using System;

namespace AniversarioConsole.MenuActions
{
    public class SearchPersonByNameAction : MenuAction
    {
        public SearchPersonByNameAction() : base("Pesquisar Pessoas")
        {
        }

        public override void Action()
        {
            Console.WriteLine("Escreva o nome ou parte do nome:");
            var searchTerm = Console.ReadLine();

            var foundPersons = App.PersonRepository.FilterByName(searchTerm);

            if (foundPersons.Count <= 0)
            {
                Console.WriteLine("Nenhuma pessoa encontrada :/");
                return;
            }
            
            
            Console.WriteLine();
            Console.WriteLine($"{foundPersons.Count} pessoas encontradas! \n");
            
            foreach (var person in foundPersons)
            {
                person.ConsoleWrite();
                Console.WriteLine();
            }
        }
    }
}