using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal abstract class BaseMenu
    {
        protected int choice = 0;           // wybrana pozycja w menu
        protected int bottom_choice = 0;    // wybrana pozycja w menu "dolnego" dla wyświetlanej akurat tabeli
        protected ConsoleKey key;
        protected Presenter _presenter;
        protected int[] window_size_thin = { 20, 69 };
        protected int[] window_size_wide = { 40, 109 };

        protected BaseMenu(Presenter presenter) { _presenter = presenter; }

        protected abstract string[] MenuItems { get; }      // pre-wygenerowane ekrany z kolejnymi pozycjami menu
        protected abstract string[] MenuParts { get; }      // pozycje jakie powinny się znaleźć w dolnym menu
        protected abstract string MenuHeader { get; }       // ozdobny nagłówek menu

        protected abstract void HandleChoice(int choice);                           // obsługa wyboru z menu
        protected abstract void HandleBottomChoice(int choice, int bottom_choice);  // obsługa wyboru z menu dolnego

        public void Run()           // główna pętla menu
        {
            key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                ShowMenu();

                key = Console.ReadKey(intercept: true).Key;
                if (ChoiceHandle(key))
                {
                    HandleChoice(choice);
                }
            } while (key != ConsoleKey.Escape);
        }

        public void RunTable()      // pętla dolnego menu dla wyświetlanej tabeli
        {
            printBottomMenu();  // rysuje dolną część ramki
            key = ConsoleKey.S;
            bottom_choice = 0;
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            do
            {
                ShowBottomMenu();   // wypełnia dolne menu opcjami
                key = Console.ReadKey(intercept: true).Key;
                if (ChoiceHandle(key))
                {
                    HandleBottomChoice(choice, bottom_choice);
                }

                // wybór encji z listy
                if (key == ConsoleKey.UpArrow)
                {
                    y = Math.Max(5, y - 1);
                    Highlight();
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    y = Math.Min(Console.CursorTop - 2, y + 1);
                    Highlight();
                }

            } while (key != ConsoleKey.Escape && key != ConsoleKey.Spacebar);
        }

        protected int y = 5, prev_y = 5;
        private void Highlight()    // wizualne oznaczenie, która encja jest akurat wybrana do wykonania czynności z menu
        {
            int originalTop = Console.CursorTop;
            int originalLeft = Console.CursorLeft;

            Console.SetCursorPosition(1, prev_y);
            Console.Write("  ");
            Console.SetCursorPosition(1, y);
            Console.WriteLine(">>");

            prev_y = y; // zapamiętanie miejsca do zmazania następnym razem 

            Console.SetCursorPosition(originalLeft, originalTop);
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
                bottom_choice = Math.Max(0, bottom_choice - 1);
            }
            else
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
        private void ShowMenu() // wyświetlenie ekranu z odpowiednim wyborem
        {
            Console.WriteLine(MenuItems[choice]);
        }
        internal void ShowEntity(string? v)
        {
            if (string.IsNullOrEmpty(v)) return;
            Console.WriteLine(v);
        }

        internal void ShowEntities(string[] v)
        {
            if (v == null) return;
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }

        private void ShowBottomMenu()
        {
            // formatowanie pozycji dolnego menu - oklejenie spacjami w równych odstępach, i zaznaczenie obecnie wybranej pozycji
            string left = string.Join("   ", MenuParts.Where((part, index) => index == bottom_choice - 1)).PadLeft(8).PadRight(11);
            string chosen = ("< " + MenuParts[bottom_choice].PadRight(8).PadLeft(10) + " >   ");
            string right = string.Join("   ", MenuParts.Where((part, index) => index > bottom_choice));
            right = right.Length > 48 ? right.Substring(0, 48) : right;
            string line = left + chosen + right;
            line = line.Length > 56 ? line.Substring(0, 56) : line.PadRight(56);

            Console.SetCursorPosition(7, Console.CursorTop);    // powrót kursora na początek linii
            Console.Write(line);
        }

        internal void PrintHeader()
        {
            Console.WriteLine(MenuHeader);
        }

        public string ShowInputDialog(string prompt)
        {
            Console.SetCursorPosition(7, Console.CursorTop);
            int pos = 1 + prompt.Length + 7 + 2;
            string line = prompt.Length > 56 ? prompt.Substring(0, 56) : prompt.PadRight(56);
            Console.Write(line);
            Console.SetCursorPosition(pos, Console.CursorTop);
            string value = Console.ReadLine();
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            return value;
        }

        protected void printBottomMenu()
        {
            Console.WriteLine(@"|---<>---------------------------------------------------------<>---|
    |                                                           |
    <>_________________________________________________________<>");
        }

        protected void sizeSwitch()
        {
            if (Console.WindowWidth == window_size_thin[1])
            {
                Console.WindowHeight = window_size_wide[0];
                Console.WindowWidth = window_size_wide[1];
                
            }
            else
            {
                Console.WindowHeight = window_size_thin[0];
                Console.WindowWidth = window_size_thin[1];
            }
        }

        internal void ErrorMessage(string v)
        {
            Console.SetCursorPosition(7, Console.CursorTop);    // powrót kursora na początek linii
            Console.WriteLine(v);
            Thread.Sleep(2000);
        }
    }
}
