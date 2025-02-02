using KN_DB.Attributes;
using KN_DB.Main.View;
using KN_DB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// klasa przygotowuje ekrany z kolumnami danych dla Menu

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
        }

        public void Show<T>(Func<PostgresContext, IQueryable<T>> query, int i) where T : class
        {
            using (var context = new PostgresContext())
            {
                var entities = query(context).ToList();
                var entity = entities[i];
                _menu.ShowEntity(entity.ToString());
            }
        }

        public void Add<TEntity>() where TEntity : class, new()
        {
            var entity = new TEntity();     

            using (var context = new PostgresContext())
            {
                Type entityType = typeof(TEntity);

                foreach (var property in entityType.GetProperties())
                {
                    // pole jest oznaczone atrybutem, aby zostało zignorowane przy wprowadzaniu wartości przez użytkownika
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
                        else
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
                        if (DateOnly.TryParseExact(input, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly parsedDate))
                        {
                            Console.WriteLine(parsedDate);
                            property.SetValue(entity, parsedDate);
                        }
                        else
                        {
                            _menu.ErrorMessage("Podano niepoprawną wartość dla - data d.mm.rrrr -");
                            return;
                        }
                    }
                }

                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        internal void Edit<T>(Func<PostgresContext, IQueryable<T>> query, int i) where T : class, new()
        {
            using (var context = new PostgresContext())
            {
                var entities = query(context).ToList();

                var entity = entities[i];

                // Find the property that ends with "ID" (case-insensitive)
                var idProperty = entity.GetType()
                    .GetProperties()
                    .FirstOrDefault(prop => prop.Name.EndsWith("ID", StringComparison.OrdinalIgnoreCase));

                if (idProperty != null)
                {
                    // Get the value of the ID property
                    var idValue = idProperty.GetValue(entity);

                    // Ensure the ID value is valid and call EditEntity
                    if (idValue is int id)
                    {
                        EditEntity<T>(id);
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
