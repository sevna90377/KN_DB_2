using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main.View
{
    internal class CourseMenu : BaseMenu
    {
        public CourseMenu(Presenter presenter) : base(presenter)
        {
        }

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    key = ConsoleKey.Escape;
                    return;
            }
        }


        protected override string[] MenuItems
        {
            get
            {
                return new string[]
                     {
@"
    <>-----------------------------------------------------------<>
    |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
    <>-----------------------------------------------------------<>
     |                                                           |
     |                                                           |
     |     WYSWIETL KURSY                                        |
     |                                                           |
     |      DODAJ NOWY KURS                                      |
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
     | >>  WYSWIETL KURSY                                        |
     |                                                           |
     |      DODAJ NOWY KURS                                      |
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
     |     WYSWIETL KURSY                                        |
     |                                                           |
     |   >> DODAJ NOWY KURS                                      |
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
     |     WYSWIETL KURSY                                        |
     |                                                           |
     |      DODAJ NOWY KURS                                      |
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
