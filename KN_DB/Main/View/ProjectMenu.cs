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
            throw new NotImplementedException();
            switch (choice)
            {
                case 8:
                    key = ConsoleKey.Escape;
                    return;
            }
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

        protected override string[] MenuParts => throw new NotImplementedException();
    }
}
