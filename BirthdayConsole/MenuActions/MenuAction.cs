using System.Collections.Generic;

namespace AniversarioConsole.MenuActions
{
    public abstract class MenuAction
    {
        protected MenuAction(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public abstract void Action();
    }
}