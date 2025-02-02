using KN_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal class MemberMenu : BaseMenu
    {
        public MemberMenu(Presenter presenter) : base(presenter)
        {
        }

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    sizeSwitch();
                    Console.Clear();
                    _presenter.Show(table => table.Members.OrderBy(m => m.MemberId));
                    sizeSwitch();
                    choice = 0;
                    break;
                case 2:
                    Console.Clear();
                    sizeSwitch();
                    Func<PostgresContext, IQueryable<Member>> query = context => context.Members
        .Where(m => m.IsCouncilMember);
                    _presenter.Show(query);
                    sizeSwitch();
                    break;
                case 3:
                    _presenter.Add<Member>();
                    break;
                case 4:
                    key = ConsoleKey.Escape;
                    choice = 0;
                    return;
            }
            key = ConsoleKey.S;
        }

        protected override void HandleBottomChoice(int choice, int bottom_choice)
        {
            switch (bottom_choice)
            {
                case 0:
                    _presenter.Show(table => table.Members.OrderBy(m => m.MemberId), y-5);
                    bottom_choice = 0;
                    break;
                case 1: //
                    break;
                case 2:
                    bottom_choice = 0;
                    break;
                case 3:
                    _presenter.Add<Member>();
                    Console.Clear();
                    _presenter.Show(table => table.Members.OrderBy(m => m.MemberId));
                    bottom_choice = 0;
                    break;
                case 4:
                    key = ConsoleKey.Escape;
                    break;
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
     |     WYSWIETL CZLONKOW                                     |
     |                                                           |
     |      WYSWIETL CZLONKOW ZARZADU                            |
     |                                                           |
     |       DODAJ NOWEGO CZLONKA                                |
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
     |  >> WYSWIETL CZLONKOW                                     |
     |                                                           |
     |      WYSWIETL CZLONKOW ZARZADU                            |
     |                                                           |
     |       DODAJ NOWEGO CZLONKA                                |
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
     |     WYSWIETL CZLONKOW                                     |
     |                                                           |
     |   >> WYSWIETL CZLONKOW ZARZADU                            |
     |                                                           |
     |       DODAJ NOWEGO CZLONKA                                |
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
     |     WYSWIETL CZLONKOW                                     |
     |                                                           |
     |      WYSWIETL CZLONKOW ZARZADU                            |
     |                                                           |
     |    >> DODAJ NOWEGO CZLONKA                                |
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
     |     WYSWIETL CZLONKOW                                     |
     |                                                           |
     |      WYSWIETL CZLONKOW ZARZADU                            |
     |                                                           |
     |       DODAJ NOWEGO CZLONKA                                |
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

                    "INFORMACJE",
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
   |                        CZŁONKOWIE                           |
|--<>-----------------------------------------------------------<>--|
| Imię                   | Nazwa na discord      | Data dołączenia  |
|                        |                       |                  |";

            }
        }
    }
}
