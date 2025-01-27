using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal class MemberMenu : BaseMenu
    {

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    _presenter.UserTable();
                    Console.ReadLine();
                    break;
                case 2:
                    _presenter.CouncilTable();
                    break;
                case 3:
                    //new member
                    break;
                case 4:
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
    }
}
