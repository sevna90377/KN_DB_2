using KN_DB.Attributes;
using KN_DB.Main.View;
using KN_DB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KN_DB.Main
{
    internal class Presenter
    {
        
        private BaseMenu _menu;

        public Presenter(BaseMenu menu)
        {
            _menu = menu;
        }

        public void SetCurrentMenu(BaseMenu menu)
        {
            _menu = menu;
        } 

        public void Show<T>(Func<PostgresContext, IQueryable<T>> query) where T : class
        {
            _menu.PrintHeader();
            using (var context = new PostgresContext())
            {
                var entities = query(context).ToList();

                foreach (var entity in entities)
                {
                    _menu.ShowEntity(entity.ToString());
                }
                _menu.RunTable();
            }
        }   // cała tabela

        public void Show<T>(Func<PostgresContext, IQueryable<T>> query, int i) where T : class
        {
            using (var context = new PostgresContext())
            {
                var entities = query(context).ToList();
                var entity = entities[i];
                _menu.ShowEntity(entity.ToString());
            }
        }   // i-ta encja

        public int IdfromIndex<T>(Func<PostgresContext, IQueryable<T>> query, int i)
        {
            /* aby uzyskać wartość pola ID dla odpowiedniej encji 
             * konieczne jest odtworzenie kolejności wypisywania
             * poprzez wykorzystanie tej samej kwerendy
             */

            using (var context = new PostgresContext())
            {
                var entities = query(context).ToList();
                if (i >= 0 && i < entities.Count)
                {
                    var entity = entities[i];
                    // wybór pola z Id enjci
                    var idProperty = entity.GetType()
                        .GetProperties()
                        .FirstOrDefault(prop => prop.Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase));
                    if (idProperty != null)
                    {
                        var idValue = idProperty.GetValue(entity);
                        if (idValue is int id)
                        {
                            return id;
                        }
                        else
                        {
                            Console.WriteLine($"Invalid ID value for entity: {idValue}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ID property found on the entity.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid index.");
                }

                return 0;
            }
        }

        public void Add<TEntity>(int? entityId = null) where TEntity : class, new()
        {
            using (var context = new PostgresContext())
            {
                TEntity entity;
                Type entityType = typeof(TEntity);

                if(entityId.HasValue)
                {
                    entity = context.Set<TEntity>().Find(entityId.Value);
                    if (entity == null)
                    {
                        _menu.ErrorMessage("Nie znaleziono encji.");
                        return;
                    }
                }
                else
                {
                    entity = new TEntity();
                }


                foreach (var property in entityType.GetProperties())
                {
                    // pole klas oznaczone atrybutem zostanie pominięte przy wprowadzaniu wartości przez użytkownika
                    if(Attribute.IsDefined(property, typeof(IgnoreOnCreation)))
                    {
                        continue;
                    }

                    string input = _menu.ShowInputDialog(property.Name);

                    // nie podano wartości, a pole może być null
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                            property.SetValue(entity, null);
                        else if (!entityId.HasValue)
                        {
                            _menu.ErrorMessage("Pole nie może być puste!");
                            return;
                        }
                    }
                    // zachowania dla różnych typów ustawianego pola encji
                    else if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, input);
                    }
                    else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                    {
                        if (int.TryParse(input, out int intValue) || string.IsNullOrEmpty(input))
                        {
                            property.SetValue(entity, string.IsNullOrEmpty(input) ? (int?)null : intValue);
                        }
                        else
                        {
                            _menu.ErrorMessage("Podano niepoprawną wartość dla - liczba całkowita -");
                            return;
                        }
                    }
                    else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                    {
                        if (bool.TryParse(input.ToLower(), out bool boolValue) || string.IsNullOrEmpty(input))
                        {
                            property.SetValue(entity, string.IsNullOrEmpty(input) ? (bool?)null : boolValue);
                        }
                        else
                        {
                            _menu.ErrorMessage("Podano niepoprawną wartość dla - true/false -");
                            return;
                        }
                    }
                    else if (property.PropertyType == typeof(DateOnly) || property.PropertyType == typeof(DateOnly?))
                    {
                        if (!string.IsNullOrWhiteSpace(input) && DateOnly.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly parsedDate))
                        {
                            property.SetValue(entity, parsedDate);
                        }
                        else if (!string.IsNullOrWhiteSpace(input))
                        {
                            _menu.ErrorMessage("Podano niepoprawną wartość dla - data d.mm.rrrr -");
                            return;
                        }
                    }
                }

                if (!entityId.HasValue)
                {
                    context.Set<TEntity>().Add(entity);
                }
                else
                {
                    context.Set<TEntity>().Update(entity);
                }
                context.SaveChanges();
            }
        }

        public void Delete<TEntity>(int id) where TEntity : class
        {
            using (var context = new PostgresContext())
            {
                var entity = context.Set<TEntity>().Find(id);
                if (entity == null)
                {
                    Console.WriteLine("Nie znaleziono encji.");
                    return;
                }

                if (typeof(TEntity) == typeof(Member))
                {
                    if (context.Sections.Where(s => s.LeadId == id).ToList().Count > 0)
                    {
                        _menu.ErrorMessage("Nie można usunąć członka, który prowadzi sekcje.");
                        return;
                    }
                    else if(context.Courses.Where(c => c.LecturerId == id).ToList().Count > 0)
                    {
                        _menu.ErrorMessage("Nie można usunąć członka, który prowadzi kursy.");
                        return;
                    }
                    else if (context.ProjectMembers.Where(p => p.MemberId == id).ToList().Count > 0)
                    {
                        _menu.ErrorMessage("Nie można usunąć członka, który jest przypisany do projektu.");
                        return;
                    }
                }

                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                _menu.ErrorMessage("Usunięto.");
            }
        }

        private void DeleteEntity<TEntity>(int id) where TEntity : class
        {
            using (var context = new PostgresContext())
            {
                // Find the ID property
                var idProperty = typeof(TEntity).GetProperties()
                    .FirstOrDefault(prop => prop.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase));

                if (idProperty == null)
                {
                    Console.WriteLine("No ID property found for the specified entity type.");
                    return;
                }

                // Retrieve all entities and find the one to delete
                var entity = context.Set<TEntity>().ToList()
                    .FirstOrDefault(e => idProperty.GetValue(e) != null && (int)idProperty.GetValue(e) == id);

                if (entity == null)
                {
                    Console.WriteLine("Entity not found.");
                    return;
                }

                // Remove the entity
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
                Console.WriteLine("Entity deleted successfully.");
            }
        }

        private void EditEntity<TEntity>(int id) where TEntity : class, new()
        {
            using (var context = new PostgresContext())
            {
                var entity = context.Set<TEntity>().Find(id);

                if (entity == null)
                {
                    Console.WriteLine("Entity not found.");
                    return;
                }

                Type entityType = typeof(TEntity);

                foreach (var property in entityType.GetProperties())
                {
                    string input = _menu.ShowInputDialog(property.Name);

                    if (string.IsNullOrWhiteSpace(input) && Nullable.GetUnderlyingType(property.PropertyType) != null)
                    {
                        property.SetValue(entity, null);
                    }
                    else if (property.PropertyType == typeof(string))
                    {
                        property.SetValue(entity, input);
                    }
                    else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                    {
                        if (int.TryParse(input, out int intValue) || string.IsNullOrEmpty(input))
                        {
                            property.SetValue(entity, string.IsNullOrEmpty(input) ? (int?)null : intValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for an integer. Please try again.");
                            return;
                        }
                    }
                    else if (property.PropertyType == typeof(bool) || property.PropertyType == typeof(bool?))
                    {
                        if (bool.TryParse(input, out bool boolValue) || string.IsNullOrEmpty(input))
                        {
                            property.SetValue(entity, string.IsNullOrEmpty(input) ? (bool?)null : boolValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for a boolean. Please try again.");
                            return;
                        }
                    }
                    else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                    {
                        if (DateTime.TryParse(input, out DateTime dateTimeValue) || string.IsNullOrEmpty(input))
                        {
                            property.SetValue(entity, string.IsNullOrEmpty(input) ? (DateTime?)null : dateTimeValue);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for a DateTime. Please try again.");
                            return;
                        }
                    }
                    // Add more cases for other data types (e.g., DateTime, etc.)
                }

                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }
    }
}
