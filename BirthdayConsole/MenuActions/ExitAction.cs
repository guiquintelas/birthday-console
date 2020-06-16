using System;
using System.Net.Mime;
using System.Threading;

namespace AniversarioConsole.MenuActions
{
    public class ExitAction : MenuAction
    {
        public ExitAction() : base("Sair") {}

        public override void Action()
        {            
            Console.WriteLine("Tchau tchau!");
            Environment.Exit(1);
        }
    }
}