using System;

namespace AniversarioConsole.MenuActions
{
    public class DeletePersonAction : MenuAction
    {
        public DeletePersonAction() : base("Deletar uma pessoa")
        {
        }

        public override void Action()
        {
            Console.WriteLine("Informe o Id da pessoa para deletar:");
            var id = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine(App.PersonRepository.RemoveById(id)
                ? "Pessoa deletada com sucesso!"
                : "Esse Id não existe! Nenhuma pessoa foi deletada ...");
            
            Console.WriteLine();
        }
    }
}