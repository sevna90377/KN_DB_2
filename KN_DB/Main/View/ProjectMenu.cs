using KN_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal class ProjectMenu : BaseMenu
    {
        public ProjectMenu(Presenter presenter) : base(presenter)
        {
        }

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    Console.Clear();
                    _presenter.Show(table => table.Projects);
                    Console.ReadLine();
                    break;
                case 2:
                    _presenter.Add<Member>();
                    break;
                case 3:
                    key = ConsoleKey.Escape;
                    return;
            }
        }

        protected override void HandleBottomChoice(int choice, int bottom_choice)
        {
            switch (bottom_choice)
            {
                case 0:

                    bottom_choice = 0;
                    break;
                case 1:

                    bottom_choice = 0;
                    break;
                case 2:
                    _presenter.Add<Project>();
                    bottom_choice = 0;
                    break;
                case 3:
                    key = ConsoleKey.Escape;
                    break;
            };
        }

        protected override string[] MenuItems
        {
            get
            {
                return new string[] {
        @"
           <>-----------------------------------------------------------<>
           |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
           <>-----------------------------------------------------------<>
            |                                                           |
            |                                                           |
            |     WYSWIETL PROJEKTY                                     |
            |                                                           |
            |      DODAJ NOWY PROJEKT                                   |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                            WSTECZ esc     |
            <>_________________________________________________________<>
            |                                                           |
            <>_________________________________________________________<>",

        @"
           <>-----------------------------------------------------------<>
           |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
           <>-----------------------------------------------------------<>
            |                                                           |
            |                                                           |
            | >>  WYSWIETL PROJEKTY                                     |
            |                                                           |
            |      DODAJ NOWY PROJEKT                                   |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                            WSTECZ esc     |
            <>_________________________________________________________<>
            |                                                           |
            <>_________________________________________________________<>",

        @"
           <>-----------------------------------------------------------<>
           |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
           <>-----------------------------------------------------------<>
            |                                                           |
            |                                                           |
            |     WYSWIETL PROJEKTY                                     |
            |                                                           |
            |   >> DODAJ NOWY PROJEKT                                   |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                            WSTECZ esc     |
            <>_________________________________________________________<>
            |                                                           |
            <>_________________________________________________________<>",

        @"
           <>-----------------------------------------------------------<>
           |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
           <>-----------------------------------------------------------<>
            |                                                           |
            |                                                           |
            |     WYSWIETL PROJEKTY                                     |
            |                                                           |
            |      DODAJ NOWY PROJEKT                                   |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                                           |
            |                                            WSTECZ  <<     |
            <>_________________________________________________________<>
            |                                                           |
            <>_________________________________________________________<>"

                };
            }
        }

        protected override string[] MenuParts
        {
            get
            {
                return new string[] {

                    "EDYTUJ",
                    "USUN",
                    "DODAJ",
                    "WSTECZ"
                };
            }
        }


        protected override string MenuHeader
        {
            get
            {
                return

@"   <>-----------------------------------------------------------<>
   |                          PROJEKTY                           |
|--<>-----------------------------------------------------------<>--|
| Imię                   | Nazwa na discord      | Data dołączenia  |
|                        |                       |                  |";

            }
        }
    }
}
