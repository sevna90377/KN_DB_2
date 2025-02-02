using KN_DB.Models;
using Microsoft.EntityFrameworkCore;
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
                    Console.Clear();
                    _presenter.Show<Course>(context => context.Courses
    .Include(c => c.Lecturer)
    .Include(c => c.CourseMembers)
    .OrderBy(c => c.CourseId));
                    HandleBottomChoice(choice, bottom_choice);
                    break;
                case 2:
                    _presenter.Add<Member>();
                    break;
                case 3:
                    key = ConsoleKey.Escape;
                    return;
            }
            key = ConsoleKey.S;
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
                    _presenter.Add<Course>();
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
   |                           KURSY                             |
|--<>-----------------------------------------------------------<>--|
| Nazwa kursu                        | Imię prowadzącego     | l.czł|
|                                    |                       |      |";

            }
        }
    }
}
