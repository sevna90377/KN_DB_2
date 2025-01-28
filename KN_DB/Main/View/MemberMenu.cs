﻿using System;
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
                    Console.Clear();
                    _presenter.UserTable();
                    Console.ReadLine();
                    break;
                case 2:
                    _presenter.CouncilTable();
                    Console.ReadLine();
                    break;
                case 3:
                    //new member
                    break;
                case 4:
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

        protected override string[] MenuParts => throw new NotImplementedException();
    }
}
