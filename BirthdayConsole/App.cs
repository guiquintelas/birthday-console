using System;
using System.Runtime.CompilerServices;
using AniversarioConsole.Services;
using BLL.Repositories;

namespace AniversarioConsole
{
    internal class App
    {
        public static readonly MenuService MenuService = new MenuService();
        public static readonly PersonRepository PersonRepository = new PersonRepository();

        public static void Main(string[] args)
        {
            Console.Write("Bem Vindo - Gerenciador de Aniversários");
            MenuService.ShowMenu();
        }
    }
}