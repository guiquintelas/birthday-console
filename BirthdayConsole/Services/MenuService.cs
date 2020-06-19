using System;
using System.Collections.Generic;
using AniversarioConsole.MenuActions;

namespace AniversarioConsole.Services
{
    public class MenuService
    {
        public static readonly List<MenuAction> Actions = new List<MenuAction>()
        {
            new SearchPersonByNameAction(),
            new InsertPersonAction(),
            new ExitAction(),
        }; 
        
        public void ShowMenu()
        {
            Console.WriteLine("Selecione uma das opções abaixo:");
            
            for (var index=0; index < Actions.Count; index++)
            {
                Console.WriteLine($"{index+1} - {Actions[index].Name}");
            }

            MenuAction selectedAction = null;
            
            try
            {
                var selectedIndex = Convert.ToInt32(char.GetNumericValue(Console.ReadKey().KeyChar)) - 1;
                selectedAction = Actions[selectedIndex];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("\n Opção inválida!");
                ShowMenu();
                return;
            }
            
            Console.WriteLine();
            
            selectedAction?.Action();
            ShowMenu();
        }
    }
}