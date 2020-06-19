using System;
using AniversarioConsole.Services;
using BLL.Repositories;

namespace AniversarioConsole
{
    internal static class App
    {
        private static MenuService MenuService;
        public static PersonRepository PersonRepository;

        private static bool _isDisposing;

        public static void Main(string[] args)
        {
            AppDomain.CurrentDomain.ProcessExit += Dispose;
            Console.CancelKeyPress += Dispose;
            
            PersonRepository = new PersonRepository();
            MenuService = new MenuService();

            Console.Write("Bem Vindo - Gerenciador de Aniversários");
            MenuService.ShowMenu();
        }

        private static void Dispose(object sender, object e)
        {
            if (_isDisposing)
                return;

            _isDisposing = true;
            
            PersonRepository.Dispose();
            Console.WriteLine ("Tchau tchau!");
        }
    }
}