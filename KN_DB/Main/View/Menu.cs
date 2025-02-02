using KN_DB.Models;
using System;
using System.Security;
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
        BaseMenu currentContext;

        public Menu() : base(null)
        {
            _presenter = new Presenter(this);
        }

        public void Startup()
        {
            Console.WindowHeight = window_size_thin[0];
            Console.WindowWidth = window_size_thin[1];

            Console.Write(welcome_panel);
            Console.ReadKey();
            while (Console.KeyAvailable) Console.ReadKey(true);
        }

        protected override void HandleChoice(int choice)
        {
            switch (choice)
            {
                case 0:
                    break;
                case 1:
                    currentContext = new MemberMenu(_presenter);
                    _presenter.SetCurrentMenu(currentContext);
                    currentContext.Run();
                    choice = 0;
                    break;
                case 2:
                    currentContext = new CourseMenu(_presenter);
                    _presenter.SetCurrentMenu(currentContext);
                    currentContext.Run();
                    choice = 0;
                    break;
                case 3:
                    currentContext = new SectionMenu(_presenter);
                    _presenter.SetCurrentMenu(currentContext);
                    currentContext.Run();
                    choice = 0;
                    break;
                case 4:
                    currentContext = new ProjectMenu(_presenter);
                    currentContext.Run();
                    choice = 0;
                    break;
                case 5:
                    Environment.Exit(0);
                    return;
            }
        }

        protected override void HandleBottomChoice(int choice, int bottom_choice)
        {
            throw new NotImplementedException();
        }

        readonly string welcome_panel =
@"
   <>-----------------------------------------------------------<>
   |                SYSTEM OBSŁUGI KÓŁ NAUKOWYCH                 |
   <>-----------------------------------------------------------<>
    |                                                           |
    |  witaj w bazie!                                           |
    |                                                           |
    |  znajdziesz tu informacje o wszystkich członkach, ich     |
    |  projektach, sekcjach i kursach, do których należą;       |
    |                                                           |
    |     UŻYJ MYSZY, aby wybrać rząd do edycji/usunięcia!      |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    |                                                           |
    <>_________________________________________________________<>
    |        wcisnij dowolny przycisk aby kontynuowac :)        |
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

        protected override string[] MenuParts => new string[0];

        protected override string MenuHeader => "";
    }
}
