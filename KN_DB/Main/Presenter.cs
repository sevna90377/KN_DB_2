using KN_DB.Main.View;
using KN_DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// klasa przygotowuje ekrany z kolumnami danych dla Menu

namespace KN_DB.Main
{
    internal class Presenter
    {
        
        private readonly Menu _menu;

        public Presenter(Menu menu)
        {
            _menu = menu;
        }

        public void UserTable()
        {
            _menu.printHeader();
            using (var context = new PostgresContext())
            {
                var entities = context.Members.ToList();
                foreach (var entity in entities)
                {
                    _menu.showEntity(entity.ToString());
                }
                _menu.printBottomMenu();
            }
        }

        internal void CouncilTable()
        {
            throw new NotImplementedException();
        }

        private void addSampleMember()
        {
            using var context = new PostgresContext();
            var newMember = new Models.Member { Name = "Monika" };
            context.Members.Add(newMember);
            context.SaveChanges();
        }

        string Choice()
        {
            return "";
        }

        string Line()
        {
            return "";
        }
    }
}
