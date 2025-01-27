using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal abstract class BaseMenu
    {
        protected int choice = 0;
        ConsoleKey key;
        protected abstract string[] MenuItems { get; }
        protected abstract void HandleChoice(int choice);

        public void Run()
        {
            key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                ShowMenu();

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, MenuItems.Length))
                {
                    HandleChoice(choice);
                }
            } while (key != ConsoleKey.Escape);
        }

        protected bool ChoiceHandle(ConsoleKey key, int length)
        {
            if (key == ConsoleKey.UpArrow)
            {
                choice = Math.Max(1, choice - 1);
            }
            if (key == ConsoleKey.DownArrow)
            {
                choice = Math.Min(length - 1, choice + 1);
            }
            if (key == ConsoleKey.Enter)
            {
                return true;
            }
            return false;
        }
        private void ShowMenu()
        {
            Console.WriteLine(MenuItems[choice]);
        }
    }
}
