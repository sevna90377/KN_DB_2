using KN_DB.Models;
using System;
using System.Threading;
 
/*
 * Klasa odpowiedzialna za komunikację z użytkownikiem (View)
 * 
 * 
 */

namespace KN_DB.Main.View
{
    internal class Menu : BaseMenu
    {

        public Menu() : base(null)
        {
            _presenter = new Presenter(this);
        }

        public void Startup()
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 69;

            Console.Write(welcome_panel);
            Thread.Sleep(1000);
            while (Console.KeyAvailable) Console.ReadKey(true);
        }

        internal void showEntity(string? v)
        {
            if (string.IsNullOrEmpty(v)) return;
            Console.WriteLine(v);
        }

        internal void showEntities(string[] v)
        {
            if (v == null) return;
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }

        internal void printHeader()
        {
            Console.WriteLine(MenuParts[0]);
        }

        internal void printBottomMenu()
        {
            Console.WriteLine(MenuParts[MenuParts.Length-1]);
        }

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    MemberMenu mMenu = new(_presenter);
                    mMenu.Run();
                    choice = 0;
                    break;
                case 2:
                    CourseMenu cMenu = new(_presenter);
                    cMenu.Run();
                    choice = 0;
                    break;
                case 3:
                    SectionMenu sMenu = new(_presenter);
                    sMenu.Run();
                    choice = 0;
                    break;
                case 4:
                    ProjectMenu pMenu = new(_presenter);
                    pMenu.Run();
                    choice = 0;
                    break;
                case 5:
                    Environment.Exit(0);
                    return;
            }
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
            }
        }

        protected override string[] MenuParts
        {
            get
            {
                return new string[] {
@"   <>-----------------------------------------------------------<>
  |                        CZŁONKOWIE                           |
|--<>-----------------------------------------------------------<>--|
| Imię                   | Nazwa na discord      | Data dołączenia  |
|                        |                       |                  |",

@"",

@"|---<>_________________________________________________________<>---|
    |                                                           |
    <>_________________________________________________________<>"
            };
            }
        }
    }
}
