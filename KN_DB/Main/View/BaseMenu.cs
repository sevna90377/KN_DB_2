using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
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
        protected int bottom_choice = 0;
        protected ConsoleKey key;
        protected Presenter _presenter;

        protected BaseMenu(Presenter presenter) { _presenter = presenter; }
        
        protected abstract string[] MenuItems { get; }
        protected abstract string[] MenuParts { get; }

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
                if (ChoiceHandle(key))
                {
                    HandleChoice(choice);
                }
            } while (key != ConsoleKey.Escape);
        }

        protected bool ChoiceHandle(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow)
            {
                choice = Math.Max(1, choice - 1);
            }
            else
            if (key == ConsoleKey.DownArrow)
            {
                choice = Math.Min(MenuItems.Length - 1, choice + 1);
            }
            else
            if (key == ConsoleKey.LeftArrow)
            {
                bottom_choice = Math.Max(1, bottom_choice - 1);
            }else
            if (key == ConsoleKey.RightArrow)
            {
                bottom_choice = Math.Min(MenuParts.Length - 1, bottom_choice + 1);
            }
            else
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
