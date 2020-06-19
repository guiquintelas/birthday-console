using System;
using System.Net.Mime;
using System.Threading;

namespace AniversarioConsole.MenuActions
{
    public class ExitAction : MenuAction
    {
        public ExitAction() : base("Salvar e Sair") {}

        public override void Action()
        {            
            Environment.Exit(1);
        }
    }
}