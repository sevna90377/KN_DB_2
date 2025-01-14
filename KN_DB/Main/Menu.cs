using System;
using System.Threading;

/*
 * 1 naprawić esc 
 * (2) dodać menu poziome
 * (3) dodać metodę przyjmującą input
 * 
 */

namespace KN_DB.Main
{
    internal class Menu
    {

        bool running;
        int choice = 0;

        private void Startup()
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 69;
            
            
            Console.Write(welcome_panel);
            Thread.Sleep(1000);
            while (Console.KeyAvailable) Console.ReadKey(true);
        }
        public void Run()
        {
            Startup();
            ConsoleKey key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(main_menu[choice]);

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, main_menu.Length))
                {
                    switch (choice)
                    {
                        case 0:
                            break;
                        case 1:
                            MemberMenu();
                            choice = 0;
                            break;
                        case 2:
                            CoursesMenu();
                            choice = 0;
                            break;
                        case 3:
                            SectionsMenu();
                            choice = 0;
                            break;
                        case 4:
                            ProjectsMenu();
                            choice = 0;
                            break;
                        case 5:
                            return;
                    }
                }
            } while (key != ConsoleKey.Escape);

            Console.Clear();
            //komunikat na wyjście
        }


        private bool ChoiceHandle(ConsoleKey key, int length)
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

        private void MemberMenu()
        {
            ConsoleKey key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(member_menu[choice]);

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, member_menu.Length))
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
                            return;
                    }
                }
            } while (key != ConsoleKey.Escape);
        }
        private void CoursesMenu()
        {
            ConsoleKey key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(courses_menu[choice]);

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, courses_menu.Length))
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
                            return;
                    }
                }
            } while (key != ConsoleKey.Escape);
        }
        private void SectionsMenu()
        {
            ConsoleKey key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(sections_menu[choice]);

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, sections_menu.Length))
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
                            return;
                    }
                }
            } while (key != ConsoleKey.Escape);
        }
        private void ProjectsMenu()
        {
            ConsoleKey key = ConsoleKey.S;
            choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine(projects_menu[choice]);

                key = Console.ReadKey().Key;
                if (ChoiceHandle(key, projects_menu.Length))
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
                            return;
                    }
                }
            } while (key != ConsoleKey.Escape);
        }


        readonly string welcome_panel =
@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>
";
        readonly string[] main_menu = {
@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     CZŁONKOWIE                                            |
    |                                                           |
    |      KURSY                                                |
    |                                                           |
    |       SEKCJE                                              |
    |                                                           |
    |        PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE esc     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>",

@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |  >> CZŁONKOWIE                                            |
    |                                                           |
    |      KURSY                                                |
    |                                                           |
    |       SEKCJE                                              |
    |                                                           |
    |        PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE esc     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>",

@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     CZŁONKOWIE                                            |
    |                                                           |
    |   >> KURSY                                                |
    |                                                           |
    |       SEKCJE                                              |
    |                                                           |
    |        PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE esc     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>",

@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     CZŁONKOWIE                                            |
    |                                                           |
    |      KURSY                                                |
    |                                                           |
    |    >> SEKCJE                                              |
    |                                                           |
    |        PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE esc     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>",

@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     CZŁONKOWIE                                            |
    |                                                           |
    |      KURSY                                                |
    |                                                           |
    |       SEKCJE                                              |
    |                                                           |
    |     >> PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE esc     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>",

@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     CZŁONKOWIE                                            |
    |                                                           |
    |      KURSY                                                |
    |                                                           |
    |       SEKCJE                                              |
    |                                                           |
    |        PROJEKTY                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                           WYJSCIE  <<     |
    <>_________________________________________________________<>
    |                                                           |
    <>_________________________________________________________<>"
        };
        readonly string[] member_menu = {
@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     WYSWIETL CZLONKOW                                     |
    |                                                           |
    |      DODAJ NOWEGO CZLONKA                                 |
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
    | >>  WYSWIETL CZLONKOW                                     |
    |                                                           |
    |      DODAJ NOWEGO CZLONKA                                 |
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
    |     WYSWIETL CZLONKOW                                     |
    |                                                           |
    |   >> DODAJ NOWEGO CZLONKA                                 |
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
    |     WYSWIETL CZLONKOW                                     |
    |                                                           |
    |      DODAJ NOWEGO CZLONKA                                 |
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
        readonly string[] courses_menu = {
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
        readonly string[] sections_menu = {
@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |                                                           |
    |     WYSWIETL SEKCJE                                       |
    |                                                           |
    |      DODAJ NOWĄ SEKCJĘ                                    |
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
    | >>  WYSWIETL SEKCJE                                       |
    |                                                           |
    |      DODAJ NOWĄ SEKCJĘ                                    |
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
    |     WYSWIETL SEKCJE                                       |
    |                                                           |
    |   >> DODAJ NOWĄ SEKCJĘ                                    |
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
    |     WYSWIETL SEKCJE                                       |
    |                                                           |
    |      DODAJ NOWĄ SEKCJĘ                                    |
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
        readonly string[] projects_menu = {
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
